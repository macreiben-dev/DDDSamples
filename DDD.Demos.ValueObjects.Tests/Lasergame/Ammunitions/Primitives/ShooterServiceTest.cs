using DDD.Demos.ValueObjects.Lasergame;
using DDD.Demos.ValueObjects.Lasergame.Ammunitions.Primitives;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DDD.Demos.ValueObjects.Tests.Lasergame.Ammunitions.Primitives
{
    [Category("Primitive type based")]
    public sealed class ShooterServiceTest
    {
        private IShooterRepository _shooterRepo;
        private Shooter _originalShooter;
        private const int ShooterIdentifier = 555;

        [SetUp]
        public void SetUp()
        {
            _shooterRepo = Substitute.For<IShooterRepository>();

            _originalShooter = new Shooter()
            {
                Id = ShooterIdentifier
            };

            _shooterRepo.GetById(ShooterIdentifier).Returns(_originalShooter);
        }

        private ShooterService GetTarget()
        {
            return new ShooterService(_shooterRepo);
        }

        [Test]
        public void Should_decrease_ammunition_when_shooting()
        {
            // ARRANGE
            _originalShooter.Ammunitions = 10;

            // ACT
            GetTarget().Decrease(ShooterIdentifier);

            // ASSERT
            Check.That(_originalShooter.Ammunitions).IsEqualTo(9);
        }

        [Test]
        public void Should_be_at_max_charge_when_reloaded_ten_times()
        {
            // ARRANGE
            int maxCharge = 10;

            _originalShooter.Ammunitions = 0;

            // ACT

            for (int i = 0; i < 10; i++)
            {
                GetTarget().Reload(ShooterIdentifier);
            }

            // ASSERT
            Check.That(_originalShooter.Ammunitions).IsEqualTo(maxCharge);
        }

        #region Reloading/Decreasing ammutions

        [TestCase(11)]
        [TestCase(40)]
        [TestCase(50)]
        public void Should_not_exceed_maximum_loadout_WHEN_reload(int reloadTimes)
        {
            // ARRANGE
            _originalShooter.Ammunitions = 0;

            // ACT 
            ShooterService target = GetTarget();

            for (int i = 0; i < reloadTimes; i++)
            {
                target.Reload(ShooterIdentifier);
            }

            // ASSERT
            Check.That(_originalShooter.Ammunitions).IsEqualTo(10);
        }


        [TestCase(11)]
        [TestCase(40)]
        [TestCase(50)]
        public void Should_not_exceed_minimum_loadout_WHEN_decrease(int decraseTimes)
        {
            // ARRANGE
            _originalShooter.Ammunitions = 0;

            // ACT 
            ShooterService target = GetTarget();

            for (int i = 0; i < decraseTimes; i++)
            {
                target.Decrease(ShooterIdentifier);
            }

            // ASSERT
            Check.That(_originalShooter.Ammunitions).IsEqualTo(0);
        }

        [Test]
        public void Should_fail_when_one_shooter_has_more_thanMaxLoadout_WHEN_RELOAD()
        {
            // ARRANGE
            _originalShooter.Ammunitions = 100;

            // ACT 
            ShooterService target = GetTarget();

            Check.ThatCode(() => target.Reload(ShooterIdentifier))
                .Throws<Exception>()
                .WithMessage("Maximum loadout is 10.");
        }

        [Test]
        public void Should_fail_when_one_shooter_has_more_than_minLoadout_WHEN_DECREASE()
        {
            // ARRANGE
            _originalShooter.Ammunitions = 100;

            // ACT 
            ShooterService target = GetTarget();

            Check.ThatCode(() => target.Decrease(ShooterIdentifier))
                .Throws<Exception>()
                .WithMessage("Maximum loadout is 10.");
        }

        #endregion Reloading/Decreasing ammutions

        [Test]
        public void Should_not_decrase_lower_than_minimumLoadout()
        {
            // ARRANGE
            _originalShooter.Ammunitions = 0;

            // ACT
            GetTarget().Decrease(ShooterIdentifier);

            // ASSERT
            Check.That(_originalShooter.Ammunitions).IsEqualTo(0);
        }

        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================
        // =====================================================


        [Category("Primtive type based")]
        [Test]
        [Ignore("")]
        public void Explore()
        {
            // ARRANGE
            int shooterId = 10;

            Shooter original = new Shooter()
            {
                Id = shooterId,
                Ammunitions = int.MaxValue
            };

            _shooterRepo.GetById(10).Returns(original);

            // ACT
            GetTarget().Reload(shooterId);

            Check.That(original.Ammunitions).IsEqualTo(int.MinValue);
        }
    }
}
