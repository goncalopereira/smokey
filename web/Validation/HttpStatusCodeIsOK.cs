using System.Net;
using RestSharp;

namespace web.Validation
{
    public class HttpStatusCodeIsOK : ICallResponseValidation
    {
        public string Message { get; set; }
        public bool Execute(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Message = response.ErrorMessage;
                return false;
            }
            return true;
        }
    }
}