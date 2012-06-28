using Nancy;
using web.Resource;

namespace web.Web
{
    public class Smoke : NancyModule
    {
        public Smoke(IResourceRepository repository)
            : base("/smoke")
        {
            Get["/"] = parameters => "Hello World";
            Get["/"] = status => HttpStatusCode.OK;

            IResource resource = repository.Get("id");
            resource.Execute();
        }
    }
}
