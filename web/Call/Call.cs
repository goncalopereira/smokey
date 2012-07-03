using System;
using System.Net;
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
                var client = _client ?? new RestClient(string.Format("http://{0}", uri.Host));
                var request = new RestRequest(uri.PathAndQuery, Method);

                var response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new CallResponse(Url, Name) { Status = CallResponse.CallStatus.Failed }; 
                }
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