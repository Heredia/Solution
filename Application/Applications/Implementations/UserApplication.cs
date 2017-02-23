using Application.Applications.Interfaces;
using Helper.Collections;
using Domain.Domains.UnitOfWork;
using Model.Models;

namespace Application.Applications.Implementations
{
    public class UserApplication : BaseApplication, IUserApplication
    {
        public UserApplication(IDomainUnitOfWork domain) : base(domain) { }

        public long CountUsers()
        {
            return Domain.UserDomain.CountUsers();
        }

        public AuthenticationModel Login(LoginModel login)
        {
            return Domain.UserDomain.Login(login);
        }

        public void Logout(LogoutModel logout)
        {
            Domain.UserDomain.Logout(logout);
        }

        public PagedList<UserModel> PagedListUsers(PagedListParameters parameters)
        {
            return Domain.UserDomain.PagedListUsers(parameters);
        }

        public UserModel SelectUserById(long userId)
        {
            return Domain.UserDomain.SelectUserById(userId);
        }
    }
}