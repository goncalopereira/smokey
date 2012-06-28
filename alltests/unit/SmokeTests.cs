using NUnit.Framework;
using Rhino.Mocks;
using web.Resource;
using web.Web;

namespace alltests.unit
{
    [TestFixture]
    public class SmokeTests
    {
        [Test]
        public void When_running_a_smoke_execute_it()
        {
            IResourceRepository resourceRepository = MockRepository.GenerateMock<IResourceRepository>();
            var resource = MockRepository.GenerateMock<IResource>();
            resourceRepository.Stub(x => x.Get(Arg<string>.Is.Anything)).Return(resource);

            var smoke = new Smoke(resourceRepository);

            resourceRepository.AssertWasCalled(x => x.Get(Arg<string>.Is.Anything));
            resource.AssertWasCalled(x=>x.Execute());
        }
    }
}
