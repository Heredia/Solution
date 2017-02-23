using Helper.Dependency;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace Wcfs.Wcf.Factories
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container = DependencyHelper.ConfigureContainer(container);
        }
    }
}