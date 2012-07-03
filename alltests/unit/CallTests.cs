using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using Rhino.Mocks;
using web.Call;

namespace alltests.unit
{
    [TestFixture]
    public class CallTests
    {
        [Test]
        public void When_Executing_if_there_is_an_exception_then_return_failed()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Throw(new Exception());
            Call call = new Call(client) { Url = "http://google.com" };

            var response = call.Execute();

            Assert.That(response.Status, Is.EqualTo(CallResponse.CallStatus.Failed));
            client.AssertWasCalled(x => x.Execute(Arg<IRestRequest>.Is.Anything));
        }

        [Test]
        public void When_Executing_if_there_is_no_exception_but_not_OK_then_fail()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse());
            Call call = new Call(client){Url = "http://google.com"};

            var response = call.Execute();

            Assert.That(response.Status, Is.EqualTo(CallResponse.CallStatus.Failed));
            client.AssertWasCalled(x => x.Execute(Arg<IRestRequest>.Is.Anything));
        }

        [Test]
        public void When_Executing_if_its_response_OK_then_return_OK()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse() { StatusCode = HttpStatusCode.OK} );
            Call call = new Call(client){Url = "http://google.com"};

            var response = call.Execute();

            Assert.That(response.Status, Is.EqualTo(CallResponse.CallStatus.OK));
            client.AssertWasCalled(x => x.Execute(Arg<IRestRequest>.Is.Anything));
        }


        [Test]
        public void When_executing_if_its_not_OK_there_is_error()
        {
            const string errormessage = "HTTP Status Code Not OK";

            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse());
            Call call = new Call(client) { Url = "http://google.com" };

            var response = call.Execute();

            Assert.That(response.Message, Is.EqualTo(errormessage));
        }

        [Test]
        public void When_executing_if_its_OK_there_is_no_error()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse() { StatusCode = HttpStatusCode.OK });
            Call call = new Call(client) { Url = "http://google.com" };

           var response = call.Execute();

            Assert.That(response.Message, Is.Null);
        }

        [Test]
        public void When_Executing_if_there_is_an_exception_then_return_exception_message()
        {
            const string errorMessage = "error message";

            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Throw(new Exception(errorMessage));
            Call call = new Call(client) { Url = "http://google.com" };

            var response = call.Execute();

            Assert.That(response.Message,Is.EqualTo(errorMessage));
        }
    }
   }

