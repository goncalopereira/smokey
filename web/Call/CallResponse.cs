namespace web.Call
{
    public class CallResponse
    {
        public enum CallStatus
        {
            OK,
            Failed,
            NotExecuted
        };

        public CallStatus Status { get; set; }
    }
}