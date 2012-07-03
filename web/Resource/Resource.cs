using System.Collections.Generic;
using Nancy.Helpers;
using web.Call;

namespace web.Resource
{
    public class Resource : IResource
    {
       
        public List<ICall> Calls { get; private set; }
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

        public IList<CallResponse.CallResponse> Execute()
        {
            bool stillRunning = true;
            var results = new List<CallResponse.CallResponse>();

            foreach (var myCall in Calls)
            {
                if (stillRunning)
                {
                    var result = myCall.Execute();
                    results.Add(result);

                    if (result.Status == CallResponse.CallResponse.CallStatus.Failed)
                    {
                        stillRunning = false;
                    }
                }
                else
                {
                    results.Add(new CallResponse.CallResponse(myCall.Url, myCall.Name) { Status = CallResponse.CallResponse.CallStatus.NotExecuted });
                }
            }

            return results;
        }
    }
}