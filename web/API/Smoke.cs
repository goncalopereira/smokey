using System.Collections.Generic;
using API.Resource;
using API.Response;
using Nancy;
using Nancy.Responses;

namespace API.API
{
    public class Smoke : NancyModule
    {
        public Smoke(IResourceRepository repository)
            : base("/smoke")
        {
            Get["/{id}/execute"] = parameters => Execute(repository, parameters["id"]);
            Get["/{id}"] = parameters => Show(repository, parameters["id"]);
            Get["/"] = parameters => Show(repository);
        }

        private JsonResponse<IResource> Show(IResourceRepository repository, string id)
        {
            IResource resource = repository.Get(id);
            return new JsonResponse<IResource>(resource,new DefaultJsonSerializer());
        }

        private JsonResponse<IList<IResource>> Show(IResourceRepository repository)
        {
            IList<IResource> resources = repository.GetAll();
            return new JsonResponse<IList<IResource>>(resources, new DefaultJsonSerializer());
        }

        private static JsonResponse<IList<CallResponse>> Execute(IResourceRepository repository, string id)
        {
            IResource resource = repository.Get(id);
            IList<CallResponse> callResponses = resource.Execute();
            return new JsonResponse<IList<CallResponse>>(callResponses, new DefaultJsonSerializer());
        }
    }
}
