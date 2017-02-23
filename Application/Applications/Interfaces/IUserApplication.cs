using Helper.Collections;
using Model.Models;

namespace Application.Applications.Interfaces
{
    public interface IUserApplication : IBaseApplication
    {
        long CountUsers();

        AuthenticationModel Login(LoginModel login);

        void Logout(LogoutModel logout);

        PagedList<UserModel> PagedListUsers(PagedListParameters parameters);

        UserModel SelectUserById(long userId);
    }
}