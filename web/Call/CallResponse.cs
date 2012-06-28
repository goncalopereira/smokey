namespace web.Call
{
    public class CallResponse
    {
        public CallResponse(string url)
        {
            Url = url;
        }
   
        public enum CallStatus
        {
            OK,
            Failed,
            NotExecuted
        };

        public CallStatus Status { get; set; }

        public string Url { get; private set; }
    }
}