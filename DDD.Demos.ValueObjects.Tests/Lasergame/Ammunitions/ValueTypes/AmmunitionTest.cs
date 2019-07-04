using DDD.Demos.ValueObjects.Lasergame;
using NFluent;
using NUnit.Framework;
using System;

namespace DDD.Demos.ValueObjects.Tests.Lasergame.Ammunitions.ValueTypes
{
    [Category("Value typed based")]
    public class AmmunitionTest
    {
        private const int Zero = 0;

        private Ammunition GetTarget()
        {
            return new Ammunition();
        }

        [Test]
        public void Should_decrease_ammunition_when_shooting()
        {
            // ARRANGE & ACT
            Ammunition actual = new Ammunition(10).Decrease();

            // ASSERT
            Check.That(actual.Loadout).IsEqualTo(9);
        }

        [Test]
        public void Should_be_at_max_charge_when_reloaded_ten_times()
        {
            Ammunition target = GetTarget();

            Ammunition current = target;

            for (int i = 0; i < 10; i++)
            {
                current = current.Reload();
            }

            Check.That(current.Loadout).IsEqualTo(10);
        }

        [TestCase(11)]
        [TestCase(40)]
        [TestCase(50)]
        public void Should_not_exceed_maximum_loadout(int reloadTimes)
        {
            Ammunition target = GetTarget();

            Ammunition current = target;

            for (int i = 0; i < reloadTimes; i++)
            {
                current = current.Reload();
            }

            Check.That(current.Loadout).IsEqualTo(10);
        }

        [Test]
        public void Should_not_decrease_lower_than_minimum_loadout()
        {
            // ACT
            Ammunition target = new Ammunition(); // Default is 0 which is our minimum

            Ammunition actual = target.Decrease();

            // ASSERT
            Check.That(actual.Loadout).IsEqualTo(0);
        }

        [TestCase(11)]
        [TestCase(40)]
        [TestCase(50)]
        public void Should_not_have_more_than_max_loadout(int loadout)
        {
            Check.ThatCode(() => new Ammunition(loadout))
                .Throws<Exception>()
                .WithMessage("Maximum loadout is 10.");
        }

        [Test]
        public void Should_start_with_empty_magazine()
        {
            Check.That(new Ammunition().IsEmpty()).IsTrue();
        }

        [Test]
        public void Should_be_empty_when_initialLoadout_is_zero() // Value object specific
        {
            // ARRANGE
            Ammunition target = new Ammunition(Zero);

            Check.That(target.IsEmpty()).IsTrue();
        }
    }
}
