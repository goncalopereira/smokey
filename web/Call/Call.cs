using System;
using Nancy.Json;
using RestSharp;

namespace web.Call
{
    public class Call : ICall
    {
        private readonly IRestClient _client;

        public Call(IRestClient client)
        {
            _client = client;
        }

        public Call()
        {
            _client = new RestClient();
        }

        public CallResponse Execute()
        {
            Uri uri;
            try
            {
                uri = new Uri(Url);
            }
            catch(Exception e)
            {
                return new CallResponse(Url, Name) { Status = CallResponse.CallStatus.Failed };
            }

            try
            {
                IRestResponse response = _client.Execute(new RestRequest(uri, Method));
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