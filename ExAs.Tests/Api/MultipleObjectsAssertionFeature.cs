﻿using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class MultipleObjectsAssertionFeature
    {
        private readonly Dojo narutosDojo = new Dojo(new Ninja(), new DateTime(1515, 11, 1));

        [Test]
        public void WithNarutosDojo_AndValidAssertions_ShouldPass()
        {
            AssertionResult result = narutosDojo.Evaluate(
                d => d.Property(x => x.Master).Fulfills(n => n.Property(x => x.Name).EqualTo("Naruto")
                                                                 .Property(x => x.Age) .EqualTo(12))
                      .Property(x => x.Founded).EqualTo(new DateTime(1515, 11, 1)));

            Assert.IsTrue(result.succeeded);
            Console.Out.WriteLine(result.log);
            Assert.AreEqual("Dojo: Master  = Ninja: Name = 'Naruto' (expected: 'Naruto')".NewLine()
                       .Add("                       Age  = 12       (expected: 12)").NewLine()
                       .Add("      Founded = 01.11.1515 00:00:00    (expected: 01.11.1515 00:00:00)"),
                       result.log);
        }

        [Test]
        public void WithNullsDojo_AndValidAssertions_ShouldPass()
        {
            var nullDojo = new Dojo(null, new DateTime(1515, 11, 1));
            AssertionResult result = nullDojo.Evaluate(
                d => d.Property(x => x.Master) .Fulfills(n => n.IsNull())
                      .Property(x => x.Founded).EqualTo(new DateTime(1515, 11, 1)));
            Assert.IsTrue(result.succeeded);
            Console.Out.WriteLine(result.log);
            Assert.AreEqual("Dojo: Master  = null                (expected: null)".NewLine()
                       .Add("      Founded = 01.11.1515 00:00:00 (expected: 01.11.1515 00:00:00)"),
           result.log);
        }
    }
}