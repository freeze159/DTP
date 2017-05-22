using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace WinFormProJect
{

    public partial class FrmMain : Form
    {

        string strConn;
        DataBase objCSDL;
        DataTable taiKhoan,MenuDichVu;
        SqlConnection conn;
        FrmDoiMay FrmDM = new FrmDoiMay();
        FrmDangNhap FrmDN = new FrmDangNhap();
        FrmDangKy FrmDK = new FrmDangKy();
        FrmNapTien FrmNT = new FrmNapTien();
        Time pc1;
        Time pc2;
        Time pc3;
        int sec1 = 0;
        int sec2 = 0;
        int sec3 = 0;
        int getMoney;
        public FrmMain()
        {

            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            conn = new SqlConnection(strConn);
            //conn.Open();
            objCSDL = new DataBase(strConn);
            InitializeComponent();
        }
        public bool CheckDN(string checkDN)
        {
            if (checkDN == FrmDangNhap.tenND)
                return true;
            return false;
        }
        public bool LoginSuccess(Button btn)
        {
            if (btn.Enabled == false)
                return true;
            return false;
        }
        public void Update(int tien, TextBox taikhoan)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update TaiKhoan set Sotien = @sotien where tentaikhoan=@taikhoan", conn);
            cmd.Parameters.AddWithValue("@sotien", tien);
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void UpdateNapTien(int tienNap, string taiKhoan)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update taikhoan set Sotien = Sotien + @sotien, TongTien = tongtien + @sotien where tentaikhoan = @taikhoan",conn);
            cmd.Parameters.AddWithValue("@sotien", tienNap);
            cmd.Parameters.AddWithValue("@taikhoan", taiKhoan);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Time GetInformation(TextBox TThai, TextBox NDung, TextBox Tien, TextBox BDau, int getMoney, Button btnDXuat, Button btnPC)
        {
            Time pc = new Time();
            DateTime dt = new DateTime();
            TThai.Text = "ONLINE";
            TThai.BackColor = System.Drawing.Color.Aquamarine;
            NDung.Text = FrmDangNhap.tenND;
            getMoney = int.Parse(FrmDangNhap.money);
            Tien.Text = getMoney.ToString();
            pc = new Time(getMoney, 5000);          
            BDau.Text = dt.AddSeconds(pc.SumSecond).ToString("HH:mm:ss");
            btnDXuat.Enabled = true;
            btnPC.Enabled = false;
            return pc;
        }
        public Time GetInformationForChangePC(TextBox TThai, TextBox NDung, TextBox Tien, TextBox BDau, int getMoney, Button btnDXuat, Button btnPC, TextBox NDHT, TextBox TienHT)
        {
            Time pc = new Time();
            DateTime dt = new DateTime();
            TThai.Text = "ONLINE";
            TThai.BackColor = System.Drawing.Color.Aquamarine;
            NDung.Text = NDHT.Text;
            getMoney = int.Parse(TienHT.Text);
            Tien.Text = getMoney.ToString();
            pc = new Time(getMoney, 5000);
            BDau.Text = dt.AddSeconds(pc.SumSecond).ToString("HH:mm:ss");
            btnDXuat.Enabled = true;
            btnPC.Enabled = false;
            return pc;
        }
        public bool NewMoneyForActivatingAccount(Time pc,TextBox txtND,TextBox txtTien)
        {
            int SoTienNap;
            if (FrmNapTien.soTienNap != null)
            {
                if (FrmDangNhap.tenND != null)
                {
                    if (FrmNapTien.tenTKNap == txtND.Text)
                    {
                        SoTienNap = int.Parse(FrmNapTien.soTienNap);
                        pc.GetMoney += SoTienNap;
                        Update(pc.GetMoney, txtND);
                        txtTien.Text = pc.GetMoney.ToString();
                        return true;
                    }
                }
            }
            return false;
            
        }
        public int DemThoiGian(TextBox TThai, TextBox NDung, TextBox DDung, TextBox BDau, TextBox CLai, TextBox Tien, Timer t, Button btnDXuat, Button btnPC, Time pc, int sec)
        {
            DateTime dt = new DateTime();
            if (pc.GetMoney != 0)
            {
               
                sec++;           
                if (pc.SumSecond >= 0)
                {
                    CLai.Text = dt.AddSeconds(pc.SumSecond--).ToString("HH:mm:ss");
                    DDung.Text = dt.AddSeconds(sec).ToString("HH:mm:ss");
                }
                
                
                if ((sec % 36 == 0) && (sec != 0))
                {
                    if (pc.GetMoney > 0)
                        pc.GetMoney -= 50;
                    else
                        pc.GetMoney = 0;
                }
               
                Tien.Text = pc.GetMoney.ToString();
               
                if ((pc.SumSecond == 0))
                {
                    DialogResult res = MessageBox.Show("Hết thời gian sử dụng.","Over",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    if (res == DialogResult.OK)
                    {                      
                        Update(pc.GetMoney, NDung);                    
                        DangXuat(TThai, NDung, DDung, BDau, CLai, Tien, t, btnDXuat, btnPC);
                        sec = 0;
                    }
                }
            }
            
            else
            {
                Update(pc.GetMoney, NDung);
                DangXuat(TThai, NDung, DDung, BDau, CLai, Tien, t, btnDXuat, btnPC);
                sec = 0;
            }
            
            return sec;
        }
        
        public void DangXuat(TextBox TThai, TextBox NDung, TextBox DDung, TextBox BDau, TextBox CLai, TextBox Tien, Timer t, Button btnDXuat, Button btnPC)
        {
            TThai.Text = "OFFLINE";
            TThai.BackColor = System.Drawing.Color.Gray;
            NDung.Clear();
            DDung.Clear();
            BDau.Clear();
            CLai.Clear();
            Tien.Clear();
            t.Stop();
            btnDXuat.Enabled = false;
            btnPC.Enabled = true;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtTT1.Text = "OFFLINE";
            txtTT1.BackColor = System.Drawing.Color.Gray;
            txtTT2.Text = "OFFLINE";
            txtTT2.BackColor = System.Drawing.Color.Gray;
            txtTT3.Text = "OFFLINE";
            txtTT3.BackColor = System.Drawing.Color.Gray;
            btnDangXuat1.Enabled = false;
            btnDangXuat2.Enabled = false;
            btnDangXuat3.Enabled = false;
        }
        private void butDangKy_Click(object sender, EventArgs e)
        {
            FrmDK.ShowDialog();
        }



        private void butPC1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDN.ShowDialog();
                if (FrmDangNhap.tenND != null)
                {
                    if (CheckDN(txtND2.Text) || CheckDN(txtND3.Text))
                    {
                        MessageBox.Show("Tài khoản đang được sử dụng!");
                    }
                    else
                    {                                            
                        pc1 = GetInformation(txtTT1, txtND1, txtTien1, txtBD1, getMoney, btnDangXuat1, butPC1);
                        NewMoneyForActivatingAccount(pc1, txtND1, txtTien1);          
                        timer1 = new System.Windows.Forms.Timer();
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 1000;
                        timer1.Start();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


}
        private void butPC2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDN.ShowDialog();
                if (FrmDangNhap.tenND != null)
                {
                    if (CheckDN(txtND1.Text) || CheckDN(txtND3.Text))
                    {
                        MessageBox.Show("Tài khoản đang được sử dụng!");
                    }
                    else
                    {                       
                        pc2 = GetInformation(txtTT2, txtND2, txtTien2, txtBD2, getMoney, btnDangXuat2, butPC2);
                        timer2 = new System.Windows.Forms.Timer();
                        timer2.Tick += new EventHandler(timer2_Tick);
                        timer2.Interval = 1000;
                        timer2.Start();
                    }
                }
                else
                {
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void butPC3_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDN.ShowDialog();
                if (FrmDangNhap.tenND != null)
                {
                    if (CheckDN(txtND1.Text) || CheckDN(txtND2.Text))
                    {
                        MessageBox.Show("Tài khoản đang được sử dụng!");
                    }
                    else
                    {
                        pc3 = GetInformation(txtTT3, txtND3, txtTien3, txtBD3, getMoney, btnDangXuat3, butPC3);
                        timer3 = new System.Windows.Forms.Timer();
                        timer3.Tick += new EventHandler(timer3_Tick);
                        timer3.Interval = 1000;
                        timer3.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void timer_Tick(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                timer_Tick(sender, e);
                sec1 = DemThoiGian(txtTT1, txtND1, txtDaDung1, txtBD1, txtCL1, txtTien1, timer1, btnDangXuat1, butPC1, pc1, sec1);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
           
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                timer_Tick(sender, e);
                sec2 = DemThoiGian(txtTT2, txtND2, txtDaDung2, txtBD2, txtCL2, txtTien2, timer2, btnDangXuat2, butPC2, pc2, sec2);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                timer_Tick(sender, e);
                sec3 = DemThoiGian(txtTT3, txtND3, txtDaDung3, txtBD3, txtCL3, txtTien3, timer3, btnDangXuat3, butPC3, pc3, sec3);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            
        }
        
        private void btnDangXuat1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Update(pc1.GetMoney, txtND1);
                DangXuat(txtTT1, txtND1, txtDaDung1, txtBD1, txtCL1, txtTien1, timer1, btnDangXuat1, butPC1);
                sec1 = 0;                                          
            }
        }

        private void btnDangXuat2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Update(pc2.GetMoney, txtND2);
                DangXuat(txtTT2, txtND2, txtDaDung2, txtBD2, txtCL2, txtTien2, timer2, btnDangXuat2, butPC2);
                sec2 = 0;
            }
        }
        private void btnDangXuat3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Update(pc3.GetMoney, txtND3);
                DangXuat(txtTT3, txtND3, txtDaDung3, txtBD3, txtCL3, txtTien3, timer3, btnDangXuat3, butPC3);
                sec3 = 0;
            }
        }
        
        private void butDoiMay_Click(object sender, EventArgs e)
        {
            try {
                FrmDM.ShowDialog();
                if (FrmDoiMay.doiMay[0])
                {
                    pc1 = GetInformation(txtTT1, txtND1, txtTien1, txtBD1, getMoney, btnDangXuat1, butPC1);
                    pc2 = GetInformationForChangePC(txtTT2, txtND2, txtTien2, txtBD2, getMoney, btnDangXuat2, butPC2, txtND1, txtTien1);
                    sec2 = sec1;
                    timer2 = new Timer();
                    timer2.Tick += new EventHandler(timer2_Tick);
                    timer2.Interval = 1000;
                    timer2.Start();
                    DangXuat(txtTT1, txtND1, txtDaDung1, txtBD1, txtCL1, txtTien1, timer1, btnDangXuat1, butPC1);

                }
                else if (FrmDoiMay.doiMay[2])
                {
                    pc2 = GetInformation(txtTT2, txtND2, txtTien2, txtBD2, getMoney, btnDangXuat2, butPC2);
                    pc1 = GetInformationForChangePC(txtTT1, txtND1, txtTien1, txtBD1, getMoney, btnDangXuat1, butPC1, txtND2, txtTien2);
                    sec1 = sec2;
                    timer1 = new Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000;
                    timer1.Start();
                    DangXuat(txtTT2, txtND2, txtDaDung2, txtBD2, txtCL2, txtTien2, timer2, btnDangXuat2, butPC2);
                }
                else if (FrmDoiMay.doiMay[1])
                {
                    pc1 = GetInformation(txtTT1, txtND1, txtTien1, txtBD1, getMoney, btnDangXuat1, butPC1);
                    pc3 = GetInformationForChangePC(txtTT3, txtND3, txtTien3, txtBD3, getMoney, btnDangXuat3, butPC3, txtND1, txtTien1);
                    sec3 = sec1;
                    timer3 = new Timer();
                    timer3.Tick += new EventHandler(timer3_Tick);
                    timer3.Interval = 1000;
                    timer3.Start();
                    DangXuat(txtTT1, txtND1, txtDaDung1, txtBD1, txtCL1, txtTien1, timer1, btnDangXuat1, butPC1);
             
                }
                else if (FrmDoiMay.doiMay[4])
                {
                    pc3 = GetInformation(txtTT3, txtND3, txtTien3, txtBD3, getMoney, btnDangXuat3, butPC3);
                    pc1 = GetInformationForChangePC(txtTT1, txtND1, txtTien1, txtBD1, getMoney, btnDangXuat1, butPC1, txtND3, txtTien3);
                    sec3 = sec1;
                    timer1 = new Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000;
                    timer1.Start();
                    DangXuat(txtTT3, txtND3, txtDaDung3, txtBD3, txtCL3, txtTien3, timer3, btnDangXuat3, butPC3);
            
                }
                else if (FrmDoiMay.doiMay[3])
                {

                    pc2 = GetInformation(txtTT2, txtND2, txtTien2, txtBD2, getMoney, btnDangXuat2, butPC2);
                    pc3 = GetInformationForChangePC(txtTT3, txtND3, txtTien3, txtBD3, getMoney, btnDangXuat3, butPC3, txtND2, txtTien2);
                    sec3 = sec2;
                    timer3 = new Timer();
                    timer3.Tick += new EventHandler(timer3_Tick);
                    timer3.Interval = 1000;
                    timer3.Start();
                    DangXuat(txtTT2, txtND2, txtDaDung2, txtBD2, txtCL2, txtTien2, timer2, btnDangXuat2, butPC2);
                   
                }
                else if(FrmDoiMay.doiMay[5])
                {
                    pc3 = GetInformation(txtTT3, txtND3, txtTien3, txtBD3, getMoney, btnDangXuat3, butPC3);
                    pc2 = GetInformationForChangePC(txtTT2, txtND2, txtTien2, txtBD2, getMoney, btnDangXuat2, butPC2, txtND3, txtTien3);
                    sec2 = sec3;
                    timer2 = new Timer();
                    timer2.Tick += new EventHandler(timer2_Tick);
                    timer2.Interval = 1000;
                    timer2.Start();
                    DangXuat(txtTT3, txtND3, txtDaDung3, txtBD3, txtCL3, txtTien3, timer3, btnDangXuat3, butPC3);
                 
                }
            }
            catch
            {
                MessageBox.Show("Không có máy được đổi!");
            }
            
        }

        private void ToolStripMenuKhachHang_Click(object sender, EventArgs e)
        {
            ReportUser userRP = new ReportUser();
            userRP.ShowDialog();
        }

        private void ToolStripMenuDichVu_Click(object sender, EventArgs e)
        {
            ReportMenu MenuRP = new ReportMenu();
            MenuRP.ShowDialog();
        }

        private void btnNapTien_Click(object sender, EventArgs e)
        {
            try
            {               
                FrmNT.ShowDialog();                                  
                if (FrmNapTien.tenTKNap != null)
                {
                    int SoTienNap = int.Parse(FrmNapTien.soTienNap);
                    UpdateNapTien(SoTienNap, FrmNapTien.tenTKNap);
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void DangNhapTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập để sử dụng dịch vụ","Tip",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void DangXuatTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất dừng dịch vụ", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DangKyTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng ký là thành viên mới", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DichVuTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bao gồm những dịch vụ ăn uống", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoiMayTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đổi từ máy này sang máy khác", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NguyenHoangTuanTSMI_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("browser.exe", "https://www.facebook.com/ledly.nguyen");
        }

        private void TieuKhanhDuyTSMI_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("browser.exe", "https://www.facebook.com/Freeze.TheShy");
        }

        private void StackOverFlowTSMI_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("browser.exe", "https://stackoverflow.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát không?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                Close();
        }
        public void taoSTTtuDong()
        {
            for (int i = 0; i < dgvHoiVien.Rows.Count; i++)
            {
                dgvHoiVien.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void dgvHoiVien_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            taoSTTtuDong();
        }

        private void tabHoiVien_Click(object sender, EventArgs e)
        {
            taiKhoan = objCSDL.ReadData("SELECT stt[STT], tentaikhoan[Tên tài khoản], matkhau[Mật khẩu], ngaydangky[Ngày đăng ký], ngaysinh[Ngày sinh], sotien[Số tiền], sodienthoai[Số điện thoại] FROM TaiKhoan");
            dgvHoiVien.DataSource = taiKhoan;
            MenuDichVu = objCSDL.ReadData("SELECT loai[Loại],masp[Mã sản phẩm],ten[Tên],dongia[Đơn giá] from menudichvu");
            dgvDichVu.DataSource = MenuDichVu;
        }

       
    }
}
