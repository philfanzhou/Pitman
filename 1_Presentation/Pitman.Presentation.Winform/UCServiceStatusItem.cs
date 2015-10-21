using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pitman.Presentation.Winform
{
    public partial class UCServiceStatusItem : UserControl
    {
        public UCServiceStatusItem()
        {
            InitializeComponent();
        }

        public string ServiceType
        {
            get { return this.lblServiceType.Text; }
            set { this.lblServiceType.Text = value; }
        }

        public string ServiceStatus
        {
            get { return this.lblServiceStatus.Text; }
            set { this.lblServiceStatus.Text = value; }
        }
    }
}
