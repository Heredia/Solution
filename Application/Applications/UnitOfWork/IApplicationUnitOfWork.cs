using Application.Applications.Interfaces;

namespace Application.Applications.UnitOfWork
{
    public interface IApplicationUnitOfWork
    {
        IUserApplication UserApplication { get; set; }
    }
}