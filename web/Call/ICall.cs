using RestSharp;

namespace web.Call
{
    public interface ICall
    {
        CallResponse.CallResponse Execute();
        string Url { get; }
        string Name { get; }
        Method Method { get; }
    }
}



