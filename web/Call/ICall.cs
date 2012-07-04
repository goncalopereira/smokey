using API.Response;
using RestSharp;

namespace API.Call
{
    public interface ICall
    {
        CallResponse Execute();
        string Url { get; }
        string Name { get; }
        Method Method { get; }
    }
}



