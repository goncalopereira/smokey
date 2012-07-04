using System;
using System.Collections.Generic;
using API.Response;
using Nancy;
using Newtonsoft.Json;
using RestSharp;

namespace API.Web
{
    public class Status : NancyModule
    {
        private const string Host = "http://smokey";
        private const string PathToListOfTests = "/smoke";

        public Status()
            : base("/status")
        {

            Get["/"] = parameters => GetStatus();
        }

        private Nancy.Response GetStatus()
        {
        
            RestClient client = new RestClient(Host);
            RestRequest request = new RestRequest(PathToListOfTests);

            IRestResponse response = client.Execute(request);

            var statusModel = JsonConvert.DeserializeObject<List<Resource.Resource>>(response.Content);

   
            return View["status.sshtml",statusModel];
        }
    }
}

