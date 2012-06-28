using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using web.Call;

namespace alltests.unit
{
    [TestFixture]
    public class SetupTests
    {
        [Test]
        public void When_setup_is_executed_all_calls_get_executed()
        {
            ICall call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Execute()).Return(new CallResponse(string.Empty,string.Empty) { Status = CallResponse.CallStatus.OK });
            ICall call2 = MockRepository.GenerateMock<ICall>();
            call2.Stub(x => x.Execute()).Return(new CallResponse(string.Empty,string.Empty) { Status = CallResponse.CallStatus.OK });
            var calls = new List<ICall> {call1, call2};

            ISetup setup = new Setup(calls);

            setup.Execute();

            call1.AssertWasCalled(x=>x.Execute());
            call2.AssertWasCalled(x=>x.Execute());
        }

        [Test]
        public void When_one_call_fails_remaning_are_not_run()
        {
            ICall call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Execute()).Return(new CallResponse(string.Empty,string.Empty) {Status = CallResponse.CallStatus.Failed});
            ICall call2 = MockRepository.GenerateMock<ICall>();
            var calls = new List<ICall> { call1, call2 };

            ISetup setup = new Setup(calls);

            setup.Execute();

            call1.AssertWasCalled(x => x.Execute());          
            call2.AssertWasNotCalled(x => x.Execute());
        }

        [Test]
        public void When_one_call_fails_number_of_response_is_still_the_same_as_total()
        {
            ICall call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Execute()).Return(new CallResponse(string.Empty,string.Empty) { Status = CallResponse.CallStatus.Failed });
            ICall call2 = new Call("url2","call2");
            var calls = new List<ICall> { call1, call2 };

            ISetup setup = new Setup(calls);

            IList<CallResponse> results = setup.Execute();
            Assert.That(results[0].Status,Is.EqualTo(CallResponse.CallStatus.Failed));
            Assert.That(results[1].Status, Is.EqualTo(CallResponse.CallStatus.NotExecuted));
        }

        [Test]
        public void All_responses_have_same_url_and_name_as_call()
        {
            ICall call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Name).Return("name");
            call1.Stub(x => x.Url).Return("url");
            call1.Stub(x => x.Execute()).Return(new CallResponse(call1.Url,call1.Name) { Status = CallResponse.CallStatus.Failed });
            ICall call2 = new Call("url2", "call2");
            var calls = new List<ICall> { call1, call2 };

            ISetup setup = new Setup(calls);

            IList<CallResponse> results = setup.Execute();
            Assert.That(results[0].Url, Is.EqualTo(call1.Url));
            Assert.That(results[1].Url, Is.EqualTo(call2.Url));

            Assert.That(results[0].Name, Is.EqualTo(call1.Name));
            Assert.That(results[1].Name, Is.EqualTo(call2.Name));
        }



    }
}
