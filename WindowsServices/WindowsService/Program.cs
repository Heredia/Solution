using System.ServiceProcess;

namespace WindowsServices.WindowsService
{
    internal static class Program
    {
        private static void Main()
        {
            ServiceBase.Run(new ServiceBase[] { new Service() });
        }
    }
}