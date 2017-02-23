using Infrastructure.Databases.Database.Repositories.Interfaces;

namespace Infrastructure.Databases.Database.UnitOfWork
{
    public interface IDatabaseUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        void SaveChanges();
    }
}