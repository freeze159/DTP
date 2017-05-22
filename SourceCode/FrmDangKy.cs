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
    public partial class FrmDangKy : Form
    {
        string strConn;
        int dongdangxet;
        DataBase objCSDL;
        DataTable taiKhoan;
        SqlConnection conn;


        public FrmDangKy()
        {
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            conn = new SqlConnection(strConn);
            objCSDL = new DataBase(strConn);
            InitializeComponent();
            
        }
        public string MaHoaMatKhau(TextBox MatKhau)
        {
            return MatKhau.Text = MaHoaMD5.Md5(txtMatKhau.Text);
           
        }
        public void HienThi()
        {

        }
        public void taoSTTtuDong()
        {
                for (int i = 0; i < dgvHoiVien.Rows.Count; i++)
                {
                    dgvHoiVien.Rows[i].Cells[0].Value = i + 1;
                }
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            conn.Open();           
            taiKhoan = objCSDL.ReadData("SELECT stt[STT],  tentaikhoan[Tên tài khoản], matkhau[Mật khẩu], ngaydangky[Ngày đăng ký],ngaysinh[Ngày sinh],sotien[Số tiền],sodienthoai[Số điện thoại] FROM TaiKhoan");
            dgvHoiVien.DataSource = taiKhoan;
            conn.Close();
        }
        public void DuaThongTinVaoDataRow()
        {
            DataRow dataRow = taiKhoan.NewRow();
            dataRow[1] = txtTenDN.Text;
            dataRow[2] = txtMatKhau.Text;
            dataRow[3] = dateTimePicker1.Text;
            dataRow[4] = dateTimePicker2.Text;
            dataRow[5] = txtSoTien.Text;
            dataRow[6] = txtSDT.Text;
            MaHoaMatKhau(txtMatKhau);
            taiKhoan.Rows.Add(dataRow);
        }
        public void DuaThongTinRaControl()
        {
            DataRow dataRow = taiKhoan.Rows[dongdangxet];
            txtTenDN.Text = dataRow[1].ToString();
            txtMatKhau.Text = dataRow[2].ToString();
            dateTimePicker1.Text = dataRow[3].ToString();
            dateTimePicker2.Text = dataRow[4].ToString();
            txtSoTien.Text = dataRow[5].ToString();
            txtSDT.Text = dataRow[6].ToString();
            MaHoaMatKhau(txtMatKhau);
        }
        public void DuaThongTinDaCapNhatVaoDataRow()
        {
            DataRow dataRow = taiKhoan.Rows[dongdangxet];
            dataRow[1] = txtTenDN.Text;
            dataRow[2] = MaHoaMatKhau(txtMatKhau);
            dataRow[3] = dateTimePicker1.Text;
            dataRow[4] = dateTimePicker2.Text;
            dataRow[5] = txtSoTien.Text;
            dataRow[6] = txtSDT.Text;           
        }
        public void ClearData(TextBox tendangnhap, TextBox matKhau, TextBox SoTien, TextBox SDT)
        {
            SDT.Clear();
            matKhau.Clear();
            SoTien.Clear();
            tendangnhap.Clear();
        }
        public void TaoMaTuDong(DataGridView dgv, TextBox stt)
        {
            int count = 0;
            count = dgv.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgv.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0,0)));
            stt.Text = (chuoi2 + 2).ToString();
        }
        private void butThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                
                string sql = ("insert into taikhoan(tentaikhoan,matkhau,ngaydangky,ngaysinh,sotien,sodienthoai,tongtien) values ( @tentaikhoan , @matkhau, @ngaydangky, @ngaysinh, @sotien, @sodienthoai,@tongtien) ");
                SqlCommand cmd = new SqlCommand(sql, conn);              
                cmd.Parameters.AddWithValue("@tentaikhoan", txtTenDN.Text);
                cmd.Parameters.AddWithValue("@matkhau", MaHoaMatKhau(txtMatKhau) );
                cmd.Parameters.AddWithValue("@ngaydangky", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text);
                cmd.Parameters.AddWithValue("@sodienthoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@tongtien", txtSoTien.Text);
                cmd.ExecuteNonQuery();
                DuaThongTinVaoDataRow();   
                ClearData(txtTenDN, txtMatKhau, txtSoTien, txtSDT);
            }
            catch
            {       
                MessageBox.Show("Tài khoản đã tồn tại hoặc thông tin đã để trống. Vui lòng nhập lại");
                ClearData(txtTenDN, txtMatKhau, txtSoTien, txtSDT);
            }
            conn.Close();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Bạn có muốn xóa tài khoản này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    conn.Open();
                    string sqlDelete = "Delete from taikhoan where tentaikhoan = @taikhoan";
                    SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                    cmd.Parameters.AddWithValue("@taikhoan", txtTenDN.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    taiKhoan = objCSDL.ReadData("SELECT stt[STT], tentaikhoan[Tên tài khoản], matkhau[Mật khẩu], ngaydangky[Ngày đăng ký],ngaysinh[Ngày sinh],sotien[Số tiền],sodienthoai[Số điện thoại] FROM TaiKhoan ORDER BY STT ASC");
                    dgvHoiVien.DataSource = taiKhoan;
                }
            }
            catch 
            {
                MessageBox.Show("Không có tài khoản để xóa");
            }
           

        }
        private void butSua_Click(object sender, EventArgs e)
        {
            try
            {
                DuaThongTinDaCapNhatVaoDataRow();
                dgvHoiVien.DataSource = taiKhoan;
                objCSDL.UpdateData(taiKhoan, "SELECT tentaikhoan[Tên tài khoản], matkhau[Mật khẩu], ngaydangky[Ngày đăng ký],ngaysinh[Ngày sinh],sotien[Số tiền],sodienthoai[Số điện thoại] FROM TaiKhoan");
            }
            catch
            {
                MessageBox.Show("Không có tài khoản để sửa.");
            }
        }
        private void dgvHoiVien_Click(object sender, EventArgs e)
        {
            try
            {
                dongdangxet = dgvHoiVien.CurrentRow.Index;
                DuaThongTinRaControl();
            }              
            catch
            {
                
                MessageBox.Show("Không có dòng được chọn.");
            }
        }
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter ("SELECT * FROM TAIKHOAN Where TENTAIKHOAN like '%" + txtTimKiem.Text + "%'",conn);  
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHoiVien.DataSource = dt;
            conn.Close();
        }

        private void butThoat_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        private void txtMatKhau_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void txtMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode.Equals(Keys.A))
                    txtMatKhau.SelectAll();
        }

        private void txtSoTien_KeyUp(object sender, KeyEventArgs e)
        {
            int so;
            if ((txtSoTien.Text != "") && (int.TryParse(txtSoTien.Text,out so) == false))
                MessageBox.Show("Phải nhập số!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoiVien_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            taoSTTtuDong();
        }
    }
}
