using System.ServiceProcess;
using System.Threading;

namespace WindowsServices.WindowsService
{
    public partial class Service : ServiceBase
    {
        private readonly Thread _threadServiceProcess;

        public Service()
        {
            InitializeComponent();
            _threadServiceProcess = new Thread(ServiceProcess);
        }

        protected override void OnStart(string[] args)
        {
            _threadServiceProcess.Start();
        }

        protected override void OnStop()
        {
            _threadServiceProcess.Abort();
        }

        protected void ServiceProcess()
        {
        }
    }
}