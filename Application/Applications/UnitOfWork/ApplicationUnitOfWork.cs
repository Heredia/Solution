using Application.Applications.Interfaces;

namespace Application.Applications.UnitOfWork
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        public IUserApplication UserApplication { get; set; }
    }
}