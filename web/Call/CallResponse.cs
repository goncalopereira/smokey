using Nancy.Json;

namespace web.Call
{
    public class CallResponse
    {
        public CallResponse(string url, string name)
        {
            Name = name;
            Url = url;
     
        }

        public enum CallStatus
        {
            OK,
            Failed,
            NotExecuted
        };

        [ScriptIgnore]
        public CallStatus Status { get; set; }
        
        public string Url { get; private set; }
        public string Name { get; private set; }
        public string State
        {
            get { return Status.ToString(); }
          
        }

        public string Message { get; set; }
    }
}