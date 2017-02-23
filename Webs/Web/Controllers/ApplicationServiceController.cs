using Application.Applications.UnitOfWork;
using System.Web.Mvc;

namespace Webs.Web.Controllers
{
    public class ApplicationServiceController : BaseController
    {
        public ApplicationServiceController(IApplicationUnitOfWork application) : base(application) { }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoadApplication()
        {
            return Json(new Model.Constants.Application());
        }
    }
}