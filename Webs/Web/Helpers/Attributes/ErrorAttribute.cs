using Model.Constants;
using Model.Exceptions;
using Helper.Logging;
using System.Net;

namespace System.Web.Mvc
{
    public sealed class ErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.TrySkipIisCustomErrors = true;
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new JsonResult();

            if (HttpContext.Current.IsDebuggingEnabled || context.Exception is DomainException)
            {
                result.Data = context.Exception.Message;
            }
            else
            {
                result.Data = TEXTS.Error;
                LogHelper.Error(context.Exception);
            }

            context.Result = result;
        }
    }
}