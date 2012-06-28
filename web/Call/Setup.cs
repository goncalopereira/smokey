using System.Collections.Generic;

namespace web.Call
{
    public class Setup : ISetup
    {
        private readonly IList<ICall> _calls;

        public Setup(IList<ICall> calls)
        {
            _calls = calls;
        }

        public IList<CallResponse> Execute()
        {
            bool stillRunning = true;
            List<CallResponse> results = new List<CallResponse>();

            foreach (var myCall in _calls)
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
                    results.Add(new CallResponse(myCall.Url,myCall.Name) {Status = CallResponse.CallStatus.NotExecuted});
                }               
            }

            return results;
        }
    }
}