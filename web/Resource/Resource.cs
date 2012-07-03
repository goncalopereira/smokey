using System.Collections.Generic;
using Nancy.Helpers;
using web.Call;

namespace web.Resource
{
    public class Resource : IResource
    {
       
        public List<ICall> Calls { get; private set; }
        public string Url { 
            get { return HttpUtility.UrlPathEncode(string.Format(@"http://smokey/smoke/{0}", Name)); }
        }
        public string ExecuteUrl
        {
            get { return Url + "/Execute"; }
        }

        public string Name { get; private set; }
        public Resource(List<ICall> calls, string name)
        {
            Calls = calls;
            Name = name;
        }

        public IList<CallResponse> Execute()
        {
            bool stillRunning = true;
            List<CallResponse> results = new List<CallResponse>();

            foreach (var myCall in Calls)
            {
                if (stillRunning)
                {
                    var result = myCall.Execute();
                    results.Add(result);

                    if (result.Status == CallResponse.CallStatus.Failed)
                    {
                        stillRunning = false;
                    }
                }
                else
                {
                    results.Add(new CallResponse(myCall.Url, myCall.Name) { Status = CallResponse.CallStatus.NotExecuted });
                }
            }

            return results;
        }
    }
}