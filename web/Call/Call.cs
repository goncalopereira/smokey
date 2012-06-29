using System;
using Nancy.Json;
using RestSharp;

namespace web.Call
{
    public class Call : ICall
    {
        public CallResponse Execute()
        {
            try
            {
                var uri = new Uri(Url);
                var client = new RestClient(uri.Host);
                IRestResponse response = client.Execute(new RestRequest(uri, Method));
            }
            catch (Exception e)
            {
                return new CallResponse(Url, Name) {Status = CallResponse.CallStatus.Failed};
            }

            return new CallResponse(Url, Name);
        }

        public string Url { get; set; }
        public string Name { get; set; }

        [ScriptIgnore]
        public Method Method { get; set; }

        public string HTTPMethod
        {
            get { return Method.ToString(); }
        }
    }
}