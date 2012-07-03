using RestSharp;

namespace web.Validation
{
    public interface ICallResponseValidation
    {
        bool Execute(IRestResponse response);
        string Message { get; set; }
    }
}