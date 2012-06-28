namespace web
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