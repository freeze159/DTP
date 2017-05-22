namespace WinFormProJect
{
    partial class FrmDoiMay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoiMay));
            this.label1 = new System.Windows.Forms.Label();
            this.gbMayDuocDoi = new System.Windows.Forms.GroupBox();
            this.rBtnMDD03 = new System.Windows.Forms.RadioButton();
            this.rBtnMDD02 = new System.Windows.Forms.RadioButton();
            this.rBtnMDD01 = new System.Windows.Forms.RadioButton();
            this.gbMayDoi = new System.Windows.Forms.GroupBox();
            this.rBtnMD03 = new System.Windows.Forms.RadioButton();
            this.rBtnMD02 = new System.Windows.Forms.RadioButton();
            this.rBtnMD01 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbMayDuocDoi.SuspendLayout();
            this.gbMayDoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Name = "label1";
            // 
            // gbMayDuocDoi
            // 
            this.gbMayDuocDoi.Controls.Add(this.rBtnMDD03);
            this.gbMayDuocDoi.Controls.Add(this.rBtnMDD02);
            this.gbMayDuocDoi.Controls.Add(this.rBtnMDD01);
            this.gbMayDuocDoi.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.gbMayDuocDoi, "gbMayDuocDoi");
            this.gbMayDuocDoi.Name = "gbMayDuocDoi";
            this.gbMayDuocDoi.TabStop = false;
            // 
            // rBtnMDD03
            // 
            resources.ApplyResources(this.rBtnMDD03, "rBtnMDD03");
            this.rBtnMDD03.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rBtnMDD03.Name = "rBtnMDD03";
            this.rBtnMDD03.TabStop = true;
            this.rBtnMDD03.UseVisualStyleBackColor = true;
            
            // 
            // rBtnMDD02
            // 
            resources.ApplyResources(this.rBtnMDD02, "rBtnMDD02");
            this.rBtnMDD02.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rBtnMDD02.Name = "rBtnMDD02";
            this.rBtnMDD02.TabStop = true;
            this.rBtnMDD02.UseVisualStyleBackColor = true;
           
            // 
            // rBtnMDD01
            // 
            resources.ApplyResources(this.rBtnMDD01, "rBtnMDD01");
            this.rBtnMDD01.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rBtnMDD01.Name = "rBtnMDD01";
            this.rBtnMDD01.TabStop = true;
            this.rBtnMDD01.UseVisualStyleBackColor = true;
          
            // 
            // gbMayDoi
            // 
            this.gbMayDoi.Controls.Add(this.rBtnMD03);
            this.gbMayDoi.Controls.Add(this.rBtnMD02);
            this.gbMayDoi.Controls.Add(this.rBtnMD01);
            this.gbMayDoi.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.gbMayDoi, "gbMayDoi");
            this.gbMayDoi.Name = "gbMayDoi";
            this.gbMayDoi.TabStop = false;
            // 
            // rBtnMD03
            // 
            resources.ApplyResources(this.rBtnMD03, "rBtnMD03");
            this.rBtnMD03.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rBtnMD03.Name = "rBtnMD03";
            this.rBtnMD03.TabStop = true;
            this.rBtnMD03.UseVisualStyleBackColor = true;
            // 
            // rBtnMD02
            // 
            resources.ApplyResources(this.rBtnMD02, "rBtnMD02");
            this.rBtnMD02.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rBtnMD02.Name = "rBtnMD02";
            this.rBtnMD02.TabStop = true;
            this.rBtnMD02.UseVisualStyleBackColor = true;
            // 
            // rBtnMD01
            // 
            resources.ApplyResources(this.rBtnMD01, "rBtnMD01");
            this.rBtnMD01.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rBtnMD01.Name = "rBtnMD01";
            this.rBtnMD01.TabStop = true;
            this.rBtnMD01.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::WinFormProJect.Properties.Resources.Symbol_Check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnThoat, "btnThoat");
            this.btnThoat.Image = global::WinFormProJect.Properties.Resources.Symbol_Delete;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmDoiMay
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbMayDoi);
            this.Controls.Add(this.gbMayDuocDoi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDoiMay";
            this.gbMayDuocDoi.ResumeLayout(false);
            this.gbMayDuocDoi.PerformLayout();
            this.gbMayDoi.ResumeLayout(false);
            this.gbMayDoi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMayDuocDoi;
        private System.Windows.Forms.RadioButton rBtnMDD03;
        private System.Windows.Forms.RadioButton rBtnMDD02;
        private System.Windows.Forms.RadioButton rBtnMDD01;
        private System.Windows.Forms.GroupBox gbMayDoi;
        private System.Windows.Forms.RadioButton rBtnMD03;
        private System.Windows.Forms.RadioButton rBtnMD02;
        private System.Windows.Forms.RadioButton rBtnMD01;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnThoat;
    }
}