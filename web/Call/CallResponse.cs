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

        public CallStatus Status { get; set; }

        public string Url { get; private set; }
        public string Name { get; private set; }
    }
}