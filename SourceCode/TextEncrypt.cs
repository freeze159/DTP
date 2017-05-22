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
    public partial class TextEncrypt : Form
    {
        public TextEncrypt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strPassEncoded = MaHoaMD5.Md5(txtText.Text);
            txtEncryptedText.Text = strPassEncoded;
        }

        private void btnEncrypt2_Click(object sender, EventArgs e)
        {
            string strPassEncoded = MaHoaMD5.Md5(txtEncryptedText.Text);
           txt2.Text = strPassEncoded;
        }
    }
}
