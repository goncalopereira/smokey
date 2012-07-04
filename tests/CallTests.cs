using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using Rhino.Mocks;
using web.Call;
using web.Response;
using web.Validation;

namespace tests
{
    [TestFixture]
    public class CallTests
    {
        [Test]
        public void When_Executing_if_there_is_an_exception_then_return_failed()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Throw(new Exception());
            Call call = new Call(client) { Url = "http://google.com"};

            var response = call.Execute();

            Assert.That(response.Status, Is.EqualTo(CallStatus.Failed));
            client.AssertWasCalled(x => x.Execute(Arg<IRestRequest>.Is.Anything));
        }

        [Test]
        public void When_Executing_if_there_is_no_exception_but_not_OK_then_fail()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse());
            ICallResponseValidation validation = MockRepository.GenerateMock<ICallResponseValidation>();
            validation.Stub(x => x.Execute(Arg<IRestResponse>.Is.Anything)).Return(false);
            Call call = new Call(client) { Url = "http://google.com", Validation = validation};

            var response = call.Execute();

            Assert.That(response.Status, Is.EqualTo(CallStatus.Failed));
            client.AssertWasCalled(x => x.Execute(Arg<IRestRequest>.Is.Anything));
        }

        [Test]
        public void When_Executing_if_its_response_OK_then_return_OK()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse() { StatusCode = HttpStatusCode.OK} );
            ICallResponseValidation validation = MockRepository.GenerateMock<ICallResponseValidation>();
            validation.Stub(x => x.Execute(Arg<IRestResponse>.Is.Anything)).Return(true);
            Call call = new Call(client) { Url = "http://google.com", Validation = validation };

            var response = call.Execute();

            Assert.That(response.Status, Is.EqualTo(CallStatus.OK));
            client.AssertWasCalled(x => x.Execute(Arg<IRestRequest>.Is.Anything));
        }


        [Test]
        public void When_executing_if_its_not_OK_there_is_error()
        {
            const string errormessage = "errorMessage";

            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse());
            ICallResponseValidation validation = MockRepository.GenerateMock<ICallResponseValidation>();
            validation.Stub(x => x.Execute(Arg<IRestResponse>.Is.Anything)).Return(false);
            validation.Stub(x => x.Message).Return(errormessage);
            Call call = new Call(client) {Url = "http://google.com", Validation = validation};

            var response = call.Execute();

            Assert.That(response.Message, Is.EqualTo(errormessage));
        }

        [Test]
        public void When_executing_if_its_OK_there_is_no_error()
        {
            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Return(new RestResponse() { StatusCode = HttpStatusCode.OK });
            ICallResponseValidation validation = MockRepository.GenerateMock<ICallResponseValidation>();
            validation.Stub(x => x.Execute(Arg<IRestResponse>.Is.Anything)).Return(false);
            Call call = new Call(client) { Url = "http://google.com", Validation = validation};
           var response = call.Execute();

            Assert.That(response.Message, Is.Null);
        }

        [Test]
        public void When_Executing_if_there_is_an_exception_then_return_exception_message()
        {
            const string errorMessage = "error message";

            IRestClient client = MockRepository.GenerateMock<IRestClient>();
            client.Stub(x => x.Execute(Arg<IRestRequest>.Is.Anything)).Throw(new Exception(errorMessage));
            Call call = new Call(client) { Url = "http://google.com", Validation = new HttpStatusCodeIsOK() };

            var response = call.Execute();

            Assert.That(response.Message,Is.EqualTo(errorMessage));
        }
    }
   }

