namespace web.Call
{
    public class Call : ICall
    {
        public Call(string url)
        {
            Url = url;
        }

        public CallResponse Execute()
        {
           return new CallResponse(Url);
        }

        public string Url { get; private set; }
      
    }
}