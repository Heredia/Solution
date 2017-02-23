using Application.Applications.UnitOfWork;
using Model.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApis.WebApi.Controllers
{
    public class UserApiController : BaseApiController
    {
        public UserApiController(IApplicationUnitOfWork applicationUnitOfWork) : base(applicationUnitOfWork) { }

        [HttpDelete]
        public HttpResponseMessage Delete(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage Get(UserModel user)
        {
            user = ApplicationUnitOfWork.UserApplication.SelectUserById(user.UserId);
            if (user == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        public HttpResponseMessage Post(UserModel user)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}