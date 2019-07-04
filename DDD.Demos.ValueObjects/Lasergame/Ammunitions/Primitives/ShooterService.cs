using System;

namespace DDD.Demos.ValueObjects.Lasergame.Ammunitions.Primitives
{
    public sealed class ShooterService
    {
        private const int MaxLoadout = 10;
        private readonly IShooterRepository _shooterRepository;

        public ShooterService(IShooterRepository shooterRepository)
        {
            _shooterRepository = shooterRepository;
        }

        public void Reload(int shooterId)
        {
            Shooter shooterToUpdate = _shooterRepository.GetById(shooterId);

            if (shooterToUpdate.Ammunitions > MaxLoadout)
            {
                throw new ArgumentException($"Maximum loadout is {MaxLoadout}.");
            }

            if (shooterToUpdate.Ammunitions >= MaxLoadout)
            {
                return;
            }

            shooterToUpdate.Ammunitions += 1;

            _shooterRepository.Save(shooterToUpdate);
        }

        public void Decrease(int shooterId)
        {
            Shooter shooterToUpdate = _shooterRepository.GetById(shooterId);

            if (shooterToUpdate.Ammunitions > MaxLoadout)
            {
                throw new ArgumentException($"Maximum loadout is {MaxLoadout}.");
            }

            if (shooterToUpdate.Ammunitions == 0)
            {
                return;
            }

            shooterToUpdate.Ammunitions -= 1;

            _shooterRepository.Save(shooterToUpdate);
        }
    }
}
