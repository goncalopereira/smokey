using Nancy.Json;

namespace API.Response
{
    public enum CallStatus
    {
        OK,
        Failed,
        NotExecuted
    };

    public class CallResponse
    {
        public CallResponse(string url, string name)
        {
            Name = name;
            Url = url;
     
        }

      
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