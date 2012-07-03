using System;
using Nancy.Json;
using RestSharp;
using web.CallResponse;

namespace web.Call
{
    public class Call : ICall
    {
        private readonly IRestClient _client;

        public Call(IRestClient client)
        {
            _client = client;
        }

        public Call() {}

        public CallResponse.CallResponse Execute()
        {
            Uri uri;
            try
            {
                uri = new Uri(Url);
            }
            catch(Exception e)
            {
                return new CallResponse.CallResponse(Url, Name) { Status = CallResponse.CallResponse.CallStatus.Failed };
            }

            try
            {
                var client = _client ?? new RestClient(string.Format("http://{0}", uri.Host));
                var request = new RestRequest(uri.PathAndQuery, Method);

                var response = client.Execute(request);

                bool validated = Validation.Execute(response);
                if (!validated)
                {
                    return new CallResponse.CallResponse(Url, Name) { Status = CallResponse.CallResponse.CallStatus.Failed, Message = Validation.Message}; 
                }
            }
            catch (Exception e)
            {
                return new CallResponse.CallResponse(Url, Name) {Status = CallResponse.CallResponse.CallStatus.Failed, Message = e.Message};
            }

            return new CallResponse.CallResponse(Url, Name);
        }

        public string Url { get; set; }
        public string Name { get; set; }
        public ICallResponseValidation Validation { get; set; }
        
        [ScriptIgnore]
        public Method Method { get; set; }

        public string HTTPMethod
        {
            get { return Method.ToString(); }
        }
    }
}