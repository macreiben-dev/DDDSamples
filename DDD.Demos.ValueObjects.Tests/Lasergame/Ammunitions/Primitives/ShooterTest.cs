using DDD.Demos.ValueObjects.Lasergame;
using NFluent;
using NUnit.Framework;

namespace DDD.Demos.ValueObjects.Tests.Lasergame.Ammunitions.Primitives
{
    [Category("Primitive type based")]
    public class ShooterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static Shooter GetTarget()
        {
            return new Shooter();
        }

        [Test]
        public void Should_start_with_empty_magazine()
        {
            int empty = 0;

            Check.That(GetTarget().Ammunitions).IsEqualTo(empty);
        }

        // Let's update the ammunition, 
    }
}