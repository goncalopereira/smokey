namespace web.Call
{
    public class Call : ICall
    {
        public Call(string url, string name)
        {
            Name = name;
            Url = url;
        }

        public CallResponse Execute()
        {
            return new CallResponse(Url, Name);
        }

        public string Url { get; private set; }
        public string Name { get; private set; }
    }
}