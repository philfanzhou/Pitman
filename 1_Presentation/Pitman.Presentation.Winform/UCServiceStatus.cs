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
        public UCServiceStatus()
        {
            InitializeComponent();
        }

        public void StartService()
        {
            ServiceManager manager = ServiceManager.Instance;

            
        }

        private void AddServiceStatusItem(int index)
        {
            this.grpBoxServices.SuspendLayout();
            this.SuspendLayout();

            UCServiceStatusItem statusItem = new UCServiceStatusItem();
            this.grpBoxServices.Controls.Add(statusItem);

            statusItem.Dock = DockStyle.Top;
            //this.ucServiceStatusItem1.Location = new Point(3, 16);
            statusItem.Name = "ucServiceStatusItem" + index;
            statusItem.Size = new Size(667, 66);
            statusItem.TabIndex = index;

            this.grpBoxServices.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
