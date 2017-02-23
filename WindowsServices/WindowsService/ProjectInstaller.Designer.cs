using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WindowsServices.WindowsService
{
    partial class ProjectInstaller
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Password = null;
            serviceProcessInstaller.Username = null;

            serviceInstaller.Description = "WindowsServices.WindowsService";
            serviceInstaller.DisplayName = "WindowsServices.WindowsService";
            serviceInstaller.ServiceName = "WindowsServices.WindowsService";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.AddRange(new Installer[] { serviceProcessInstaller, serviceInstaller });
        }

        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;
    }
}