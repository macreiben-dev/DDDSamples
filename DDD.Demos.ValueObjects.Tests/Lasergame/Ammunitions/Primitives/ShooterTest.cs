using DDD.Demos.ValueObjects.Lasergame;
using DDD.Demos.ValueObjects.Lasergame.Ammunitions.Primitives;
using NFluent;
using NUnit.Framework;

namespace Tests
{
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

        [Category("Primtive type based")]
        [Test]
        public void Should_start_with_empty_magazine()
        {
            int empty = 0;

            Check.That(GetTarget().Ammunitions).IsEqualTo(empty);
        }

        // Let's update the ammunition, 
    }
}