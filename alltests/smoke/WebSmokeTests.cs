using System.Net;
using NUnit.Framework;
using RestSharp;

namespace alltests.smoke
{ 
    [TestFixture]
    public class WebSmokeTests
    {
        private const string Hostname = "http://smokey";

        [Test]
        public void tests_root_returns_hello_world()
        {           
            var client = new RestClient(Hostname);
     
            var request = new RestRequest("/smoke", Method.GET);
            IRestResponse response = client.Execute(request);
            
            Assert.That(response.Content,Is.EqualTo("Hello World"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
