using Application.Applications.UnitOfWork;
using Wcfs.Wcf.Interfaces;

namespace Wcfs.Wcf.Implementations
{
    public class ServiceUser : IServiceUser
    {
        private readonly IApplicationUnitOfWork ApplicationUnitOfWork;

        public ServiceUser(IApplicationUnitOfWork applicationUnitOfWork)
        {
            ApplicationUnitOfWork = applicationUnitOfWork;
        }

        public long CountUsers()
        {
            return ApplicationUnitOfWork.UserApplication.CountUsers();
        }
    }
}