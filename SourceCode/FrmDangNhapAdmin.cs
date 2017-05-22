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
    public partial class FrmDangNhapAdmin : Form
    {
        private int count;
        private string user = "admin";
        private string pass = "admin";
        private int secondtime = 30;
      
        public FrmDangNhapAdmin()
        {
            InitializeComponent();
        }

        private void FrmDangNhapAdmin_Load(object sender, EventArgs e)
        {

        }
        private void DemThoiGianKhiDangNhapSai()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }
        private void AnNoiDung()
        {
            txtMatKhau.Enabled = false;
            txtTenDangNhap.Enabled = false;
            butDangNhap.Enabled = false;
            butThoat.Enabled = false;
            cBHienMK.Enabled = false;
        }
        private void HienNoiDung()
        {
            txtMatKhau.Enabled = true;
            txtTenDangNhap.Enabled = true;
            butDangNhap.Enabled = true;
            butThoat.Enabled = true;
            cBHienMK.Enabled = true;
        }
        private void butDangNhap_Click(object sender, EventArgs e)
        {     
            if (user.Equals(txtTenDangNhap.Text.ToLower()) && pass.Equals(txtMatKhau.Text))
            {
                this.Hide();
                MessageBox.Show("WELCOME TO DTUFFALO GAMING.", "Welcome", MessageBoxButtons.OK);
                FrmMain main = new FrmMain();
                main.ShowDialog();             
                this.Close();
            }
            else
            {
                count++;
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu! ");
                if (count == 2)
                {
                    MessageBox.Show("Chờ 30s để nhập lại.");
                    DemThoiGianKhiDangNhapSai();
                }
                if (count == 4)
                {
                    MessageBox.Show("Bạn đã nhập sai nhiều lần. Chương trình sẽ đóng! ");                                     
                    this.Close();
                }
            }
            
        }

        private void butThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
                Close();
        }

        private void cBHienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !cBHienMK.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = secondtime--.ToString();
            AnNoiDung();
            if (secondtime == -2)
            {
                timer1.Stop();
                lbTime.Hide();
                HienNoiDung();
            }
        }
    }
}

