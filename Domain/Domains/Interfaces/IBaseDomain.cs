using Infrastructure.Databases.Database.UnitOfWork;

namespace Domain.Domains.Interfaces
{
    public interface IBaseDomain
    {
        IDatabaseUnitOfWork Database { get; set; }
    }
}