using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace WebApis.WebApi.Helpers
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer Container;

        public UnityResolver(IUnityContainer container)
        {
            Container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Container.Dispose();
            Container = null;
        }

        public object GetService(Type serviceType)
        {
            try { return Container.Resolve(serviceType); }
            catch { return null; }
        }

        public T GetService<T>()
        {
            try { return (T)Container.Resolve(typeof(T)); }
            catch { return default(T); }
        }

        public T GetService<T>(string name)
        {
            try { return (T)Container.Resolve(typeof(T), name); }
            catch { return default(T); }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try { return Container.ResolveAll(serviceType); }
            catch { return new List<object>(); }
        }
    }
}