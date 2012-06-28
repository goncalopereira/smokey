using NUnit.Framework;
using Rhino.Mocks;
using web;
using web.Call;
using web.Resource;

namespace alltests.unit
{
    [TestFixture]
    public class SmokeTests
    {
        [Test]
        public void When_executing_run()
        {
            ISetup setup = MockRepository.GenerateMock<ISetup>();

            Resource resource = new Resource(setup);
            resource.Execute();

            setup.AssertWasCalled(x=>x.Execute());
        }
    }
}
