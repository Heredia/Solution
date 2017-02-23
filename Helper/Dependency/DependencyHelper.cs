using Microsoft.Practices.Unity;

namespace Helper.Dependency
{
    public static class DependencyHelper
    {
        public static IUnityContainer ConfigureContainer(IUnityContainer container = null)
        {
            if (container == null) container = new UnityContainer();

            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);

            return container;
        }
    }
}