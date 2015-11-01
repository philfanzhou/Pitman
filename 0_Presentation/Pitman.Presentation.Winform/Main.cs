using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pitman.Presentation.Winform
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            this.ucServiceStatus.StartService();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }
    }
}
