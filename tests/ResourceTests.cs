using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using API.Call;
using API.Resource;
using API.Response;

namespace tests
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
                                                    {Status = CallStatus.OK});
            var call2 = MockRepository.GenerateMock<ICall>();
            call2.Stub(x => x.Execute()).Return(new CallResponse(string.Empty, string.Empty)
                                                    {Status = CallStatus.OK});
            calls.Add(call1);
            calls.Add(call2);

            Resource resource = new Resource(calls, string.Empty);
            resource.Execute();

            foreach (var call in calls)
            {
                call.AssertWasCalled(x=>x.Execute());
            }
        }

        [Test]
        public void When_getting_url_show_path()
        {
            const string name = "name";
            Resource resource = new Resource(new List<ICall>(), name);
            Assert.That(resource.Url, Is.EqualTo(string.Format("/smoke/{0}",name)));
        }

        [Test]
        public void When_getting_execute_url_show_path()
        {
            const string name = "name";
            Resource resource = new Resource(new List<ICall>(), name);
            Assert.That(resource.ExecuteUrl, Is.EqualTo(string.Format("/smoke/{0}/execute",name)));
        }
  
    }
}
