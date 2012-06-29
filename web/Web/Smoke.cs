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
            IResource resource = repository.Get("id");

            IList<CallResponse> callResponses = resource.Execute();
            Get["/{id}"] = x => new JsonResponse<IList<CallResponse>>(callResponses,new DefaultJsonSerializer()); ;
        }

    }
}
