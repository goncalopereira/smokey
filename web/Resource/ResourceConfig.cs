using System.Collections.Generic;
using RestSharp;
using web.Call;

namespace web.Resource
{
    internal static class ResourceConfig
    {
        public static IDictionary<string, IResource> Get()
        {
            var tryToPingGoogle = new Resource(new List<ICall>()
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
                                                           },
                                                       new Call.Call()
                                                           {
                                                               Method = Method.GET,
                                                               Name = "Valid but never called Ping Google",
                                                               Url = "http://google.com"
                                                           }
                                                   }, "Chained up GETs for Ping Google");

            var tryToPing7D = new Resource(new List<ICall>()
                                               {
                                                   new Call.Call()
                                                       {
                                                           Method = Method.GET,
                                                           Name = "Call status...",
                                                           Url =
                                                               "http://api.7digital.com/1.2/status?oauth_consumer_key=YOUR_KEY_HERE"
                                                       }
                                               }, "Get 7d API current time");

            return new Dictionary<string, IResource>
                       {
                           {tryToPingGoogle.Name,tryToPingGoogle},
                           {tryToPing7D.Name, tryToPing7D}
                       };
        }
    }
}