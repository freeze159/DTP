namespace WinFormProJect
{
    partial class FrmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.butThoat = new System.Windows.Forms.Button();
            this.butDangNhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Gradoo", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(95, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Facebook", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Đăng Nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Facebook", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật Khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(161, 149);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(171, 20);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(161, 103);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(171, 20);
            this.txtTenDangNhap.TabIndex = 0;
            // 
            // butThoat
            // 
            this.butThoat.BackColor = System.Drawing.Color.White;
            this.butThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThoat.Image = global::WinFormProJect.Properties.Resources.Symbol_Delete;
            this.butThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThoat.Location = new System.Drawing.Point(233, 213);
            this.butThoat.Name = "butThoat";
            this.butThoat.Size = new System.Drawing.Size(99, 44);
            this.butThoat.TabIndex = 6;
            this.butThoat.Text = "Thoát";
            this.butThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThoat.UseVisualStyleBackColor = false;
            this.butThoat.Click += new System.EventHandler(this.butThoat_Click);
            // 
            // butDangNhap
            // 
            this.butDangNhap.BackColor = System.Drawing.Color.White;
            this.butDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDangNhap.Image = global::WinFormProJect.Properties.Resources.Symbol_Check1;
            this.butDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDangNhap.Location = new System.Drawing.Point(66, 213);
            this.butDangNhap.Name = "butDangNhap";
            this.butDangNhap.Size = new System.Drawing.Size(117, 44);
            this.butDangNhap.TabIndex = 2;
            this.butDangNhap.Text = "Đăng Nhập";
            this.butDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDangNhap.UseVisualStyleBackColor = false;
            this.butDangNhap.Click += new System.EventHandler(this.butDangNhap_Click);
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(398, 282);
            this.Controls.Add(this.butThoat);
            this.Controls.Add(this.butDangNhap);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Button butDangNhap;
        private System.Windows.Forms.Button butThoat;
    }
}