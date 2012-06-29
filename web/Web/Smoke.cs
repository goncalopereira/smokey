using System.Collections.Generic;
using Nancy;
using Nancy.Responses;
using web.Call;
using web.Resource;

namespace web.Web
{
    public class Smoke : NancyModule
    {
        public Smoke(IResourceRepository repository)
            : base("/smoke")
        {
            Get["/{id}"] = parameters => ReturnById(repository, parameters["id"]); ;
            Get["/"] = parameters => Return(repository);
        }

        private JsonResponse<IList<IResource>> Return(IResourceRepository repository)
        {
            IList<IResource> resources = repository.GetAll();
            return new JsonResponse<IList<IResource>>(resources, new DefaultJsonSerializer());
        }

        private static JsonResponse<IList<CallResponse>> ReturnById(IResourceRepository repository, string id)
        {
            IResource resource = repository.Get(id);
            IList<CallResponse> callResponses = resource.Execute();
            return new JsonResponse<IList<CallResponse>>(callResponses,new DefaultJsonSerializer());
        }
    }
}
