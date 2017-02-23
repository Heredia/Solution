using Application.Applications.UnitOfWork;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApis.WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public IApplicationUnitOfWork ApplicationUnitOfWork { get; set; }

        public BaseApiController(IApplicationUnitOfWork applicationUnitOfWork)
        {
            ApplicationUnitOfWork = applicationUnitOfWork;
        }

        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}