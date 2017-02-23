using Helper.Collections;
using Model.Models;

namespace Domain.Domains.Interfaces
{
    public interface IUserDomain : IBaseDomain
    {
        long CountUsers();

        AuthenticationModel Login(LoginModel login);

        void Logout(LogoutModel logout);

        PagedList<UserModel> PagedListUsers(PagedListParameters parameters);

        UserModel SelectUserById(long userId);
    }
}