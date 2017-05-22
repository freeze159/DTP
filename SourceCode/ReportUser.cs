using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProJect
{
    public partial class ReportUser : Form
    {
        public ReportUser()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            UserReport rpt = new UserReport();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
