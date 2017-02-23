using Helper.Dependency;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Webs.Web
{
    public class Global : HttpApplication
    {
        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new JsonResultAttribute());
            filters.Add(new ErrorAttribute());
            filters.Add(new ExecutingAttribute());
            filters.Add(new AuthorizationAttribute());
        }

        private static void RegisterMvcBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/Styles").IncludeDirectory("~/Styles", "*.css", true));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts").IncludeDirectory("~/Scripts", "*.js", true));
        }

        private static void RegisterMvcRoutes(RouteCollection routes)
        {
            routes.MapRoute("Angular", "$/{*.}", new { controller = "Route", action = "MasterPage" });
            routes.MapRoute("Views", "Views/{folder}/{file}", new { controller = "Route", action = "Views" });
            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Route", action = "MasterPage" });
        }

        private static void RegisterWebApiRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "Services/{controller}/{action}");
        }

        protected static void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var headers = new[] { "X-Powered-By", "X-AspNet-Version", "X-AspNetMvc-Version", "Server" };
            foreach (var header in headers) { HttpContext.Current.Response.Headers.Remove(header); }
        }

        private void Application_Start(object sender, EventArgs e)
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(DependencyHelper.ConfigureContainer()));

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            ControllerBuilder.Current.DefaultNamespaces.Add("Webs.Web.Controllers");

            RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(RegisterWebApiRoutes);

            RegisterMvcRoutes(RouteTable.Routes);

            RegisterMvcBundles(BundleTable.Bundles);

            AntiForgeryConfig.CookieName = Guid.NewGuid().ToString();

            //ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().FirstOrDefault());
            //ValueProviderFactories.Factories.Add(new JsonNetValueProviderFactory());
        }
    }
}