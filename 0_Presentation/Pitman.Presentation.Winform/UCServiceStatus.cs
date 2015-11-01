using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pitman.Application.Management;

namespace Pitman.Presentation.Winform
{
    public partial class UCServiceStatus : UserControl
    {
        private ServiceManager manager;

        public UCServiceStatus()
        {
            InitializeComponent();
        }

        public void StartService()
        {
            manager = ServiceManager.Instance;
            this.ucRealTimeService.ServiceType = "实时数据";
            this.timerServiceStatus.Enabled = true;
        }

        private void timerServiceStatus_Tick(object sender, EventArgs e)
        {
            string status = manager.Services.FirstOrDefault().Status.ToString();

            this.ucRealTimeService.ServiceStatus = status;
        }
    }
}
