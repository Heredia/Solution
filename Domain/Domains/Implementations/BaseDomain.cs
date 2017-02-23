using Infrastructure.Databases.Database.UnitOfWork;
using Domain.Domains.Interfaces;

namespace Domain.Domains.Implementations
{
    public abstract class BaseDomain : IBaseDomain
    {
        protected BaseDomain(IDatabaseUnitOfWork database)
        {
            Database = database;
        }

        public IDatabaseUnitOfWork Database { get; set; }
    }
}