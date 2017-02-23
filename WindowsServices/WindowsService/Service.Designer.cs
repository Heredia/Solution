using System.ComponentModel;

namespace WindowsServices.WindowsService
{
    partial class Service
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ServiceName = "Service";
        }
    }
}