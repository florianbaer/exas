﻿using System;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.Generic
{
    [TestFixture]
    public class GenericAdapterTests
    {
        [Test]
        public void Assert_OnStringAdapter_WithAnyString_ShouldReturnUnderlyingResult()
        {
            bool succeeded = CreateRandom.Bool();
            string log = CreateRandom.String();
            var genericAdapter = CreateGenericAdapter<string>(s => new AssertionResult(succeeded, log));

            AssertionResult result = genericAdapter.Assert("anyString");
            Assert.AreEqual(succeeded, result.succeeded);
            Assert.AreEqual(log, result.log);
        }

        [Test]
        public void Assert_OnStringAdapter_WithInt_ShouldFail()
        {
            GenericAdapter<string> genericAdapter = CreateGenericAdapter<string>(s => new AssertionResult(true, "Whatever"));
            AssertionResult result = genericAdapter.Assert(12);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("not of expected type System.String", result.log);
        }

        private static GenericAdapter<T> CreateGenericAdapter<T>(Func<T, AssertionResult> behavior)
        {
            var assertionStub = new AssertionStub<T> { assertBehavior = behavior };
            return new GenericAdapter<T>(assertionStub);
        } 
    }
}