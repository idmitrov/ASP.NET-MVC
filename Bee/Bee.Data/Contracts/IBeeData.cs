namespace Bee.Data.Contracts
{
    using Models;

    public interface IBeeData
    {
        IRepository<Buzz> Buzzes { get; }
        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
