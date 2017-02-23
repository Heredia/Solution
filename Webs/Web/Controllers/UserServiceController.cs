using Application.Applications.UnitOfWork;
using Helper.Collections;
using Model.Models;
using System.Web.Mvc;
using Webs.Web.Helpers;

namespace Webs.Web.Controllers
{
    public class UserServiceController : BaseController
    {
        public UserServiceController(IApplicationUnitOfWork application) : base(application) { }

        [AllowAnonymous]
        [HttpPost]
        public void Login(LoginModel login)
        {
            Tokens.Authentication = Application.UserApplication.Login(login);
        }

        [AllowAnonymous]
        [HttpPost]
        public void Logout()
        {
            if (Tokens.Authentication == null) return;
            var logout = new LogoutModel { UserId = Tokens.Authentication.UserId };
            Application.UserApplication.Logout(logout);
        }

        [HttpPost]
        public ActionResult PagedListUsers(PagedListParameters parameters)
        {
            var pagedList = Application.UserApplication.PagedListUsers(parameters);
            return Json(pagedList);
        }

        [HttpPost]
        public ActionResult SelectUserById(long userId)
        {
            var user = Application.UserApplication.SelectUserById(userId);
            return Json(user);
        }
    }
}