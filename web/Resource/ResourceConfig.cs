using System.Collections.Generic;
using RestSharp;
using web.Call;

namespace web.Resource
{
    internal static class ResourceConfig
    {
        public static IDictionary<string, IResource> Get()
        {
            var resources = new Dictionary<string, IResource>
                                {
                                    {
                                        "Ping Google",
                                        new Resource(new List<ICall>()
                                                         {
                                                             new Call.Call()
                                                                 {
                                                                     Method = Method.GET,
                                                                     Name = "Ping Google",
                                                                     Url = "http://google.com"
                                                                 },
                                                                  new Call.Call()
                                                                 {
                                                                     Method = Method.GET,
                                                                     Name = "Failed Ping Google",
                                                                     Url = "http://google.coxm"
                                                                 }
                                                         },"Ping Google")
                                        }
                                };

            return resources;
        }
    }
}