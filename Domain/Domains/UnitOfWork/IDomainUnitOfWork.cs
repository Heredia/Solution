using Domain.Domains.Interfaces;

namespace Domain.Domains.UnitOfWork
{
    public interface IDomainUnitOfWork
    {
        IUserDomain UserDomain { get; set; }
    }
}