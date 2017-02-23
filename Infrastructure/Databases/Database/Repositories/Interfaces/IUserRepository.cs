using Helper.Collections;
using Model.Models;

namespace Infrastructure.Databases.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        long CountUsers();

        AuthenticationModel Login(LoginModel login);

        PagedList<UserModel> PagedListUsers(PagedListParameters parameters);

        void SaveUserLog(UserLogModel userLog);

        UserModel SelectUserById(long userId);
    }
}