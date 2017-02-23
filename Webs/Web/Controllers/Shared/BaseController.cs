using Application.Applications.UnitOfWork;
using System.Web.Mvc;

namespace Webs.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IApplicationUnitOfWork application)
        {
            Application = application;
        }

        protected IApplicationUnitOfWork Application { get; set; }
    }
}