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
    public partial class FrmDoiMay : Form
    {
        public static bool[] doiMay = new bool[6];
     
        public FrmDoiMay()
        {
            InitializeComponent();
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rBtnMDD01.Checked && rBtnMD02.Checked)
                doiMay[0] = true;
            if (rBtnMDD01.Checked && rBtnMD03.Checked)
                doiMay[1] = true;
            if (rBtnMDD02.Checked && rBtnMD01.Checked)
                doiMay[2] = true;
            if (rBtnMDD02.Checked && rBtnMD03.Checked)
                doiMay[3] = true;
            if (rBtnMDD03.Checked && rBtnMD01.Checked)
                doiMay[4] = true;
            if (rBtnMDD03.Checked && rBtnMD02.Checked)
                doiMay[5] = true;


            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDoiMay_Load(object sender, EventArgs e)
        {
           
        }
    }
}
