using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using RestSharp;
using web.Call;

namespace alltests.smoke
{ 
    [TestFixture]
    public class SmokeTests
    {
        private const string Hostname = "http://smokey";

        [Test]
        public void tests_root_returns_two_calls()
        {           
            var client = new RestClient(Hostname);
            var request = new RestRequest("/smoke/id", Method.GET);
            IRestResponse response = client.Execute(request);


            var model = new List<CallResponse>()
                            {
                                new CallResponse("url1", "call1"), new CallResponse("url2", "call2")
                            };

            Assert.That(response.Content, Is.EqualTo(JsonConvert.SerializeObject(model)));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

    }
}
