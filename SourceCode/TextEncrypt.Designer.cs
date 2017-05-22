namespace WinFormProJect
{
    partial class TextEncrypt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtEncryptedText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEncrypt2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Encrypted Text:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(110, 61);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(100, 20);
            this.txtText.TabIndex = 2;
            // 
            // txtEncryptedText
            // 
            this.txtEncryptedText.Location = new System.Drawing.Point(110, 164);
            this.txtEncryptedText.Name = "txtEncryptedText";
            this.txtEncryptedText.Size = new System.Drawing.Size(214, 20);
            this.txtEncryptedText.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(110, 217);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(214, 20);
            this.txt2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Encrypted Text:";
            // 
            // btnEncrypt2
            // 
            this.btnEncrypt2.Location = new System.Drawing.Point(375, 206);
            this.btnEncrypt2.Name = "btnEncrypt2";
            this.btnEncrypt2.Size = new System.Drawing.Size(82, 27);
            this.btnEncrypt2.TabIndex = 7;
            this.btnEncrypt2.Text = "Encrypt2";
            this.btnEncrypt2.UseVisualStyleBackColor = true;
            this.btnEncrypt2.Click += new System.EventHandler(this.btnEncrypt2_Click);
            // 
            // TextEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 261);
            this.Controls.Add(this.btnEncrypt2);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEncryptedText);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TextEncrypt";
            this.Text = "TextEncrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtEncryptedText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEncrypt2;
    }
}