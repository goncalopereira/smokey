using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using web.Call;
using web.Resource;

namespace alltests.unit
{
    [TestFixture]
    public class ResourceTests
    {
        [Test]
        public void When_executing_run()
        {
            List<ICall> calls = new List<ICall>();
            var call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Execute()).Return(new CallResponse(string.Empty, string.Empty)
                                                    {Status = CallResponse.CallStatus.OK});
            var call2 = MockRepository.GenerateMock<ICall>();
            call2.Stub(x => x.Execute()).Return(new CallResponse(string.Empty, string.Empty)
                                                    {Status = CallResponse.CallStatus.OK});
            calls.Add(call1);
            calls.Add(call2);

            Resource resource = new Resource(calls, string.Empty);
            resource.Execute();

            foreach (var call in calls)
            {
                call.AssertWasCalled(x=>x.Execute());
            }
        }
  
    }
}
