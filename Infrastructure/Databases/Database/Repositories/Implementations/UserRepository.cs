using Helper.Collections;
using Infrastructure.Databases.Database.Context;
using Infrastructure.Databases.Database.Entities;
using Infrastructure.Databases.Database.Repositories.Interfaces;
using Infrastructure.Databases.EntityFramework;
using Model.Enums;
using FastMapper;
using Helper.Mapping;
using Model.Models;
using System.Linq;

namespace Infrastructure.Databases.Database.Repositories.Implementations
{
    public class UserRepository : EntityFrameworkRepositoryBase, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public long CountUsers()
        {
            return Count<User>();
        }

        public AuthenticationModel Login(LoginModel login)
        {
            return Queryable<User>(x =>
                x.Login.Equals(login.LoginHash) &&
                x.Password.Equals(login.PasswordHash) &&
                x.Status == Status.Active
            ).Select(x => new AuthenticationModel
            {
                UserId = x.UserId,
                Name = x.Name,
                Roles = x.UsersRoles.Select(y => y.Role)
            }).SingleOrDefault();
        }

        public PagedList<UserModel> PagedListUsers(PagedListParameters parameters)
        {
            return PagedList<User, UserModel>(parameters);
        }

        public void SaveUserLog(UserLogModel userLog)
        {
            var _userLog = MappingHelper.Map<UserLog>(userLog);
            InsertOrUpdate(_userLog);
            SaveChanges();
        }

        public UserModel SelectUserById(long userId)
        {
            return Queryable<User>(u => u.UserId == userId)
                .Project().To<UserModel>().SingleOrDefault();
        }
    }
}