using Nancy;

namespace web
{
    public class Smoke : NancyModule
    {
        public Smoke()
            : base("/smoke")
        {
            Get["/"] = parameters => "Hello World";
            Get["/"] = status => HttpStatusCode.OK;
        }
    }

}
