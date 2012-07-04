using RestSharp;

namespace API.Validation
{
    public interface ICallResponseValidation
    {
        bool Execute(IRestResponse response);
        string Message { get; set; }
    }
}