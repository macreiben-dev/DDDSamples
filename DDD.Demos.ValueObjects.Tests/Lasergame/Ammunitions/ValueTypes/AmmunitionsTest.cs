using DDD.Demos.ValueObjects.Lasergame;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Demos.ValueObjects.Tests.Lasergame.Ammunitions.ValueTypes
{
    public sealed class AmmunitionsTest
    {
        [Test]
        public void Should_be_empty_by_default()
        {
            Check.That(new Ammunition().IsEmpty()).IsTrue();
        }
        
    }
}
