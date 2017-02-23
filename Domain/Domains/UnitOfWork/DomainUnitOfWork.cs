using Domain.Domains.Interfaces;

namespace Domain.Domains.UnitOfWork
{
    public class DomainUnitOfWork : IDomainUnitOfWork
    {
        public DomainUnitOfWork(IUserDomain userDomain)
        {
            UserDomain = userDomain;
        }

        public IUserDomain UserDomain { get; set; }
    }
}