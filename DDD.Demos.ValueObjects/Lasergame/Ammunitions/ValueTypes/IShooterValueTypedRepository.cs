namespace DDD.Demos.ValueObjects.Lasergame.Ammunitions.ValueTypes
{
    public interface IShooterValueTypedRepository
    {
        ShooterValueTyped GetById(int v);

        void Save(ShooterValueTyped shooterToUpdate);
    }
}