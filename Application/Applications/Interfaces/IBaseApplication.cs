using Domain.Domains.UnitOfWork;

namespace Application.Applications.Interfaces
{
    public interface IBaseApplication
    {
        IDomainUnitOfWork Domain { get; set; }
    }
}