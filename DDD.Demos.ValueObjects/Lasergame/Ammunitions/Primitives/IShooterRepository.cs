namespace DDD.Demos.ValueObjects.Lasergame.Ammunitions.Primitives
{
    public interface IShooterRepository
    {
        Shooter GetById(int v);
        void Save(Shooter shooterToUpdate);
    }
}