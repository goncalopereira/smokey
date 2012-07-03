using RestSharp;

namespace web.CallResponse
{
    public interface ICallResponseValidation
    {
        bool Execute(IRestResponse response);
        string Message { get; set; }
    }
}