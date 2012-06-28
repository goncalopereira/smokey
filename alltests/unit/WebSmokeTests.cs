using NUnit.Framework;
using Rhino.Mocks;
using web;

namespace alltests.unit
{
    [TestFixture]
    public class SmokeTests
    {
        [Test]
        public void When_executing_run()
        {
            ISetup setup = MockRepository.GenerateMock<ISetup>();

            Smoke smoke = new Smoke(setup);
            smoke.Execute();

            setup.AssertWasCalled(x=>x.Execute());
        }
    }
}
