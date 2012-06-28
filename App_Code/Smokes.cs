

using Nancy;

public class Smokes : NancyModule
{
	public Smokes() : base("/smoke")
	{
	   Get["/"] = parameters => "Hello World";
	   Get["/"] = status => HttpStatusCode.OK;

	}
}