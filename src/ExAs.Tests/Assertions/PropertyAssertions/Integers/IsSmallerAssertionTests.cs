﻿using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.Integers
{
    [TestFixture]
    public class IsSmallerAssertionTests
    {
        [Test]
        public void On15_With14_ShouldSucceed()
        {
            ValueAssertionResult result = IsSmallerThan(15).AssertValue(14);
            result.ExAssert(r => r.p(x => x.succeeded)        .IsTrue()
                                  .p(x => x.actualValueString).IsEqualTo("14")
                                  .p(x => x.expectationString).IsEqualTo(ComposeLog.Expected("15")));
        }

        [Test]
        public void On7_With6_ShouldSucceed()
        {
            ValueAssertionResult result = IsSmallerThan(7).AssertValue(6);
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.actualValueString).IsEqualTo("6")
                                  .p(x => x.expectationString).IsEqualTo(ComposeLog.Expected("7")));
        }

        private static IsSmallerAssertion IsSmallerThan(int expected)
        {
            return new IsSmallerAssertion(expected);
        }
    }
}