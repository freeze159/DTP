using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WinFormProJect
{
    public partial class FrmNapTien : Form
    {
        string strConn;
        SqlConnection conn;
        SqlDataReader reader;
        public static string tenTKNap;
        public static string soTienNap;
        public FrmNapTien()
        {
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            conn = new SqlConnection(strConn);
            //conn.Open();
            InitializeComponent();
        }
        private string GetName()
        {
            string name = string.Empty;
            SqlCommand cmd = new SqlCommand("Select * from taikhoan where Tentaikhoan = @Name", conn);
            cmd.Parameters.AddWithValue("@Name",txtTaiKhoan.Text);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name = reader["TenTaiKhoan"].ToString();
            }
            reader.Close();
            return name;
        }
        private string GetAddedMoney()
        {
            if (txtSoTienNap.Text == "")
                txtSoTienNap.Text= 0.ToString();
            return txtSoTienNap.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                
                string sql = "Select Count(*) From TaiKhoan where TENTAIKHOAN=@acc ";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@acc", txtTaiKhoan.Text));               
                int x = (int)command.ExecuteScalar();
                if (x == 1)
                {
                    tenTKNap = GetName();
                    soTienNap = GetAddedMoney();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản không đúng. Vui lòng nhập lại");
                    txtTaiKhoan.Text = "";
                    txtSoTienNap.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            conn.Close();
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            tenTKNap = null;
            soTienNap = null;
            this.Close();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void FrmNapTien_Load(object sender, EventArgs e)
        {
            txtSoTienNap.Clear();
            txtTaiKhoan.Clear();
        }

        private void txtSoTienNap_TextChanged(object sender, EventArgs e)
        {
            int sumSecond;
            DateTime dt = new DateTime();
            if (txtSoTienNap.Text == "")
            {
                sumSecond = 0;              
            }              
            else
                sumSecond = (int.Parse(txtSoTienNap.Text)) * 3600 / 5000;
            txtThoiGianNapTien.Text = dt.AddSeconds(sumSecond).ToString("HH:mm:ss");
        }

        private void txtSoTienNap_KeyUp(object sender, KeyEventArgs e)
        {
            int so;
            if ((txtSoTienNap.Text != "") && (int.TryParse(txtSoTienNap.Text, out so) == false))
                MessageBox.Show("Phải nhập số!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
