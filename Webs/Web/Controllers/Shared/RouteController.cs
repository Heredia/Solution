using Application.Applications.UnitOfWork;
using System.Web.Mvc;

namespace Webs.Web.Controllers
{
    public class RouteController : BaseController
    {
        public RouteController(IApplicationUnitOfWork application) : base(application) { }

        [AllowAnonymous]
        public ActionResult Error() => View();

        [AllowAnonymous]
        public ActionResult MasterPage() => View();

        [AllowAnonymous]
        public ActionResult Views(string folder, string file) => PartialView($"~/Views/{folder}/{file}.cshtml");
    }
}