namespace DDD.Demos.ValueObjects.Lasergame.Ammunitions.ValueTypes
{
    public sealed class ShooterValueTypedService
    {
        private IShooterValueTypedRepository _shooterRepository;

        public ShooterValueTypedService(IShooterValueTypedRepository shooterRepository)
        {
            _shooterRepository = shooterRepository;
        }

        public void UpdateAmmunition(int shooterId)
        {
            ShooterValueTyped shooterToUpdate = _shooterRepository.GetById(shooterId);

            shooterToUpdate.Ammunitions.Reload();

            _shooterRepository.Save(shooterToUpdate);
        }
    }
}
