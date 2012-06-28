﻿using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using web;

namespace alltests.unit
{
    [TestFixture]
    public class SetupTests
    {
        [Test]
        public void When_setup_is_executed_all_calls_get_executed()
        {
            ICall call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Execute()).Return(new CallResponse() { Status = CallResponse.CallStatus.OK });
            ICall call2 = MockRepository.GenerateMock<ICall>();
            call2.Stub(x => x.Execute()).Return(new CallResponse() { Status = CallResponse.CallStatus.OK });
            var calls = new List<ICall> {call1, call2};

            ISetup setup = new Setup(calls);

            setup.Execute();

            call1.AssertWasCalled(x=>x.Execute());
            call2.AssertWasCalled(x=>x.Execute());
        }

        [Test]
        public void When_one_call_fails_remaning_are_not_run()
        {
            ICall call1 = MockRepository.GenerateMock<ICall>();
            call1.Stub(x => x.Execute()).Return(new CallResponse() {Status = CallResponse.CallStatus.Failed});
            ICall call2 = MockRepository.GenerateMock<ICall>();
            var calls = new List<ICall> { call1, call2 };

            ISetup setup = new Setup(calls);

            setup.Execute();

            call1.AssertWasCalled(x => x.Execute());
            call2.AssertWasNotCalled(x => x.Execute());
        }
    }
}