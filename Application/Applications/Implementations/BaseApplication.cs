using Application.Applications.Interfaces;
using Domain.Domains.UnitOfWork;

namespace Application.Applications.Implementations
{
    public abstract class BaseApplication : IBaseApplication
    {
        protected BaseApplication(IDomainUnitOfWork domain)
        {
            Domain = domain;
        }

        public IDomainUnitOfWork Domain { get; set; }
    }
}