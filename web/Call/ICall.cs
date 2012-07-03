using RestSharp;
using web.Response;

namespace web.Call
{
    public interface ICall
    {
        CallResponse Execute();
        string Url { get; }
        string Name { get; }
        Method Method { get; }
    }
}



