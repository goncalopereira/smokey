using System.Collections.Generic;
using API.Call;
using API.Response;
using Nancy.Helpers;

namespace API.Resource
{
    public class Resource : IResource
    {
        private List<ICall> Calls { get; set; }
        public string Name { get; private set; }

        public string Url { 
            get { return HttpUtility.UrlPathEncode(string.Format("/smoke/{0}", Name)); }
        }
        public string ExecuteUrl
        {
            get { return string.Format("{0}/execute", Url); }
        }

        public Resource(List<ICall> calls, string name)
        {
            Calls = calls;
            Name = name;
        }

        public IList<CallResponse> Execute()
        {
            bool stillRunning = true;
            var results = new List<CallResponse>();

            foreach (var myCall in Calls)
            {
                if (stillRunning)
                {
                    var result = myCall.Execute();
                    results.Add(result);

                    if (result.Status == CallStatus.Failed)
                    {
                        stillRunning = false;
                    }
                }
                else
                {
                    results.Add(new CallResponse(myCall.Url, myCall.Name) { Status = CallStatus.NotExecuted });
                }
            }

            return results;
        }
    }
}