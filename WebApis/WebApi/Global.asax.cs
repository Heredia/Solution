using Helper.Dependency;
using System.Web;
using System.Web.Http;
using WebApis.WebApi.Helpers;

namespace WebApis.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        public static void HttpConfiguration(HttpConfiguration config)
        {
            config.EnableSystemDiagnosticsTracing();
            config.DependencyResolver = new UnityResolver(DependencyHelper.ConfigureContainer());
            config.EnableCors();
            config.Filters.Add(new AuthorizationAttribute());
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.Indent = true;
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Service", "Services/{controller}/{action}");
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(HttpConfiguration);
        }
    }
}