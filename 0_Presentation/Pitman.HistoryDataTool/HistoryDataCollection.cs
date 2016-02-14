using Pitman.Application.DataCollection.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pitman.HistoryDataTool
{
    public partial class HistoryDataCollection : Form
    {
        public HistoryDataCollection()
        {
            InitializeComponent();
        }

        private void btnGetKLine_Click(object sender, EventArgs e)
        {
            this.btnGetKLine.Enabled = false;

            new HistoryDataService().RefreshKLineData();

            this.btnGetKLine.Enabled = true;
        }
    }
}
