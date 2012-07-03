using System.Collections.Generic;
using RestSharp;
using web.Call;
using web.Resource;
using web.Validation;

namespace web.Configuration
{
    internal class DemoResourceConfig : IResourceConfig
    {
        public IDictionary<string, IResource> Get()
        {
            var tryToPingGoogle = new Resource.Resource(new List<ICall>()
                                                   {
                                                       new Call.Call()
                                                           {
                                                               Method = Method.GET,
                                                               Name = "Ping Google",
                                                               Url = "http://google.com",
                                                               Validation = new HttpStatusCodeIsOK()
                                                           },
                                                       new Call.Call()
                                                           {
                                                               Method = Method.GET,
                                                               Name = "Failed Ping Google",
                                                               Url = "http://google.coxm",
                                                               Validation = new HttpStatusCodeIsOK()
                                                           },
                                                       new Call.Call()
                                                           {
                                                               Method = Method.GET,
                                                               Name = "Valid but never called Ping Google",
                                                               Url = "http://google.com",
                                                               Validation = new HttpStatusCodeIsOK()
                                                           }
                                                   }, "Chained up GETs for Ping Google");

            var tryToPing7D = new Resource.Resource(new List<ICall>()
                                               {
                                                   new Call.Call()
                                                       {
                                                           Method = Method.GET,
                                                           Name = "Call status...",
                                                           Url =
                                                               "http://api.7digital.com/1.2/status?oauth_consumer_key=YOUR_KEY_HERE",
                                                               Validation = new HttpStatusCodeIsOK()
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