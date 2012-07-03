using System.Collections.Generic;
using Nancy;
using Nancy.Responses;
using web.Resource;

namespace web.Web
{
    public class Smoke : NancyModule
    {
        public Smoke(IResourceRepository repository)
            : base("/smoke")
        {
            Get["/{id}/execute"] = parameters => ExecuteById(repository, parameters["id"]); 
            Get["/{id}"] = parameters => ShowById(repository, parameters["id"]);
            Get["/"] = parameters => Show(repository);
        }

        private JsonResponse<IResource> ShowById(IResourceRepository repository, string id)
        {
            IResource resource = repository.Get(id);
            return new JsonResponse<IResource>(resource,new DefaultJsonSerializer());
        }

        private JsonResponse<IList<IResource>> Show(IResourceRepository repository)
        {
            IList<IResource> resources = repository.GetAll();
            return new JsonResponse<IList<IResource>>(resources, new DefaultJsonSerializer());
        }

        private static JsonResponse<IList<CallResponse.CallResponse>> ExecuteById(IResourceRepository repository, string id)
        {
            IResource resource = repository.Get(id);
            IList<CallResponse.CallResponse> callResponses = resource.Execute();
            return new JsonResponse<IList<CallResponse.CallResponse>>(callResponses, new DefaultJsonSerializer());
        }
    }
}
