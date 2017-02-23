using Infrastructure.Databases.Database.Context;
using Infrastructure.Databases.Database.Repositories.Interfaces;

namespace Infrastructure.Databases.Database.UnitOfWork
{
    public class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        private DatabaseContext DatabaseContext { get; set; }

        public IUserRepository UserRepository { get; set; }

        public DatabaseUnitOfWork(DatabaseContext databaseContext,
            IUserRepository userRepository)
        {
            DatabaseContext = databaseContext;
            UserRepository = userRepository;
        }

        public void SaveChanges()
        {
            DatabaseContext.SaveChanges();
        }
    }
}