using System.ComponentModel;
using System.Configuration.Install;

namespace WindowsServices.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}