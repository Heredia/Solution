using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApis.WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class AuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //if (actionContext.Request.Method == new HttpMethod("OPTIONS")) return;

            //IEnumerable<string> values;
            //if (!actionContext.Request.Headers.TryGetValues("Token", out values))
            //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized.");
        }
    }
}