using Model.Enums;
using System.Linq;
using System.Net;
using Webs.Web.Helpers;

namespace System.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class AuthorizationAttribute : AuthorizeAttribute
    {
        private readonly Role[] _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public override void OnAuthorization(AuthorizationContext context)
        {
            if (context.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                context.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)) return;

            if (Tokens.Authentication != null && (!_roles.Any() || Tokens.Authentication.Roles.Intersect(_roles).Any())) return;

            context.HttpContext.Response.TrySkipIisCustomErrors = true;
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            base.OnAuthorization(context);
        }
    }
}