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
    public partial class FrmDangNhap : Form
    {
        string strConn;
        SqlConnection conn;
        SqlDataReader reader = null;
        DataTable taiKhoan;
        SqlCommand command;
        public static string tenND;
        public static string money;
        public FrmDangNhap()
        {
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            conn = new SqlConnection(strConn);
            //conn.Open();
            InitializeComponent();
        }
        private string GetName()
        {
            //conn.Open();
            string name = string.Empty;
            SqlCommand cmd = new SqlCommand("Select * from taikhoan where Tentaikhoan = @Name", conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = txtTenDangNhap.Text;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name = reader["TenTaiKhoan"].ToString();
            }
            reader.Close();
            //conn.Close();
            return name;
            
        }
        private string GetMoney()
        {
            //conn.Open();
            string money = string.Empty;
            SqlCommand cmd = new SqlCommand("Select * from taikhoan where Tentaikhoan = @Name", conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = txtTenDangNhap.Text;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                money = reader["SoTien"].ToString();
            }
            reader.Close();
            //conn.Close();
            return money;
            
        }
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }
        public string MaHoaMatKhau(TextBox MatKhau)
        {
            return MatKhau.Text = MaHoaMD5.Md5(txtMatKhau.Text);

        }
        private void butDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                ////
                string sql = "Select Count(*) From TaiKhoan where TENTAIKHOAN=@acc And MATKHAU=@pass ";
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@acc", txtTenDangNhap.Text));
                command.Parameters.Add(new SqlParameter("@pass",MaHoaMatKhau(txtMatKhau)));
                int x = (int)command.ExecuteScalar();
                if (x == 1)
                {
                    tenND = GetName();
                    money = GetMoney();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng nhập lại");
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
           // if (conn.State == ConnectionState.Open)
            //    conn.Close();
        }

        

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void butThoat_Click(object sender, EventArgs e)
        {
            tenND = null;
            money = null;
            this.Close();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
