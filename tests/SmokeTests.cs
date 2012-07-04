using System.Collections.Generic;
using NUnit.Framework;
using Nancy.Testing;
using Rhino.Mocks;
using API.Resource;
using API.Response;

namespace tests
{
    [TestFixture]
    public class SmokeTests
    {
        [Test]
        public void When_running_a_smoke_execute_it()
        {
            const string id = "id";

            IResourceRepository resourceRepository = MockRepository.GenerateMock<IResourceRepository>();
            var resource = MockRepository.GenerateMock<IResource>();
            IList<CallResponse> results = new List<CallResponse>();
            resource.Stub(x => x.Execute()).Return(results);
            resourceRepository.Stub(x => x.Get(id)).Return(resource);

            Nancy.Bootstrapper.INancyBootstrapper bootstrapper = new ConfigurableBootstrapper(with => with.Dependency(resourceRepository));
            var browser = new Browser(bootstrapper);

            browser.Get(string.Format("/smoke/{0}/execute", id), with => with.HttpRequest());

            resourceRepository.AssertWasCalled(x => x.Get(id));
            resourceRepository.AssertWasNotCalled(x => x.GetAll());
            resource.AssertWasCalled(x => x.Execute());
        }

        [Test]
        public void When_showing_a_smoke_dont_execute_it()
        {
            const string id = "id";

            IResourceRepository resourceRepository = MockRepository.GenerateMock<IResourceRepository>();
            var resource = MockRepository.GenerateMock<IResource>();
            IList<CallResponse> results = new List<CallResponse>();
            resource.Stub(x => x.Execute()).Return(results);
            resourceRepository.Stub(x => x.Get(id)).Return(resource);

            Nancy.Bootstrapper.INancyBootstrapper bootstrapper = new ConfigurableBootstrapper(with => with.Dependency(resourceRepository));
            var browser = new Browser(bootstrapper);

            browser.Get(string.Format("/smoke/{0}", id), with => with.HttpRequest());

            resourceRepository.AssertWasCalled(x => x.Get(id));
            resourceRepository.AssertWasNotCalled(x => x.GetAll());
            resource.AssertWasNotCalled(x => x.Execute());
        }

        [Test]
        public void When_running_smoke_root_get_all()
        {

            IResourceRepository resourceRepository = MockRepository.GenerateMock<IResourceRepository>();
            var resource = MockRepository.GenerateMock<IResource>();
            IList<CallResponse> results = new List<CallResponse>();
            resource.Stub(x => x.Execute()).Return(results);
            resourceRepository.Stub(x => x.GetAll()).Return(new List<IResource>() {resource, resource});

            Nancy.Bootstrapper.INancyBootstrapper bootstrapper = new ConfigurableBootstrapper(with => with.Dependency(resourceRepository));
            var browser = new Browser(bootstrapper);

            browser.Get(string.Format("/smoke/"), with => with.HttpRequest());

            resourceRepository.AssertWasCalled(x => x.GetAll());
            resourceRepository.AssertWasNotCalled(x => x.Get(Arg<string>.Is.Anything));
            resource.AssertWasNotCalled(x => x.Execute());
        }

        [Test]
        public void When_I_know_the_resource_I_can_show_it()
        {
            const string id = "id";

            IResourceRepository resourceRepository = MockRepository.GenerateMock<IResourceRepository>();
            var resource = MockRepository.GenerateMock<IResource>();
            IList<CallResponse> results = new List<CallResponse>();
            resource.Stub(x => x.Execute()).Return(results);
            resource.Stub(x => x.Name).Return(id);
            resource.Stub(x => x.Url).Return("/smoke/id");
            resource.Stub(x => x.ExecuteUrl).Return("/smoke/id/execute");
            resourceRepository.Stub(x => x.Get(id)).Return(resource);

            Nancy.Bootstrapper.INancyBootstrapper bootstrapper = new ConfigurableBootstrapper(with => with.Dependency(resourceRepository));
            var browser = new Browser(bootstrapper);

            browser.Get(resource.Url, with => with.HttpRequest());

            resourceRepository.AssertWasCalled(x => x.Get(id));
            resourceRepository.AssertWasNotCalled(x => x.GetAll());
            resource.AssertWasNotCalled(x => x.Execute());
        }

        [Test]
        public void When_I_know_the_resource_I_can_execute_it()
        {
            const string id = "id";

            IResourceRepository resourceRepository = MockRepository.GenerateMock<IResourceRepository>();
            var resource = MockRepository.GenerateMock<IResource>();
            IList<CallResponse> results = new List<CallResponse>();
            resource.Stub(x => x.Execute()).Return(results);
            resource.Stub(x => x.Name).Return(id);
            resource.Stub(x => x.Url).Return("/smoke/id");
            resource.Stub(x => x.ExecuteUrl).Return("/smoke/id/execute");
            resourceRepository.Stub(x => x.Get(id)).Return(resource);

            Nancy.Bootstrapper.INancyBootstrapper bootstrapper = new ConfigurableBootstrapper(with => with.Dependency(resourceRepository));
            var browser = new Browser(bootstrapper);

            browser.Get(resource.ExecuteUrl, with => with.HttpRequest());

            resourceRepository.AssertWasCalled(x => x.Get(id));
            resourceRepository.AssertWasNotCalled(x => x.GetAll());
            resource.AssertWasCalled(x => x.Execute());
        }
    }
}
