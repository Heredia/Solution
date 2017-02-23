using Helper.Collections;
using Model.Constants;
using Infrastructure.Databases.Database.UnitOfWork;
using Domain.Domains.Interfaces;
using Model.Enums;
using Model.Exceptions;
using Model.Models;

namespace Domain.Domains.Implementations
{
    public class UserDomain : BaseDomain, IUserDomain
    {
        public UserDomain(IDatabaseUnitOfWork database) : base(database) { }

        public long CountUsers()
        {
            return Database.UserRepository.CountUsers();
        }

        public AuthenticationModel Login(LoginModel login)
        {
            if (string.IsNullOrEmpty(login?.Login) || string.IsNullOrEmpty(login.Password))
            {
                throw new DomainException(TEXTS.LoginOrPasswordInvalid);
            }

            var authentication = Database.UserRepository.Login(login);
            if (authentication == null)
            {
                throw new DomainException(TEXTS.LoginOrPasswordInvalid);
            }

            SaveUserLog(authentication.UserId, LogType.Login);

            return authentication;
        }

        public void Logout(LogoutModel logout)
        {
            SaveUserLog(logout.UserId, LogType.Logout);
        }

        public PagedList<UserModel> PagedListUsers(PagedListParameters parameters)
        {
            return Database.UserRepository.PagedListUsers(parameters);
        }

        public UserModel SelectUserById(long userId)
        {
            return Database.UserRepository.SelectUserById(userId);
        }

        private void SaveUserLog(long userId, LogType logType, string message = null)
        {
            var userLog = new UserLogModel(userId, logType, message);
            Database.UserRepository.SaveUserLog(userLog);
            Database.SaveChanges();
        }
    }
}