
namespace QLBH
{
    partial class DangNhap
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
            this.txtDangNhapTK = new System.Windows.Forms.TextBox();
            this.txtDangNhapMK = new System.Windows.Forms.TextBox();
            this.linkLabel_QuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.linkLabel_DangKy = new System.Windows.Forms.LinkLabel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDangNhapTK
            // 
            this.txtDangNhapTK.Location = new System.Drawing.Point(196, 208);
            this.txtDangNhapTK.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.txtDangNhapTK.Name = "txtDangNhapTK";
            this.txtDangNhapTK.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDangNhapTK.Size = new System.Drawing.Size(250, 23);
            this.txtDangNhapTK.TabIndex = 4;
            this.txtDangNhapTK.TextChanged += new System.EventHandler(this.txtDangNhapTK_TextChanged);
            this.txtDangNhapTK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDangNhapTK_KeyDown);
            // 
            // txtDangNhapMK
            // 
            this.txtDangNhapMK.Location = new System.Drawing.Point(196, 285);
            this.txtDangNhapMK.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.txtDangNhapMK.Name = "txtDangNhapMK";
            this.txtDangNhapMK.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDangNhapMK.Size = new System.Drawing.Size(250, 23);
            this.txtDangNhapMK.TabIndex = 5;
            this.txtDangNhapMK.UseSystemPasswordChar = true;
            this.txtDangNhapMK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDangNhapMK_KeyDown);
            // 
            // linkLabel_QuenMatKhau
            // 
            this.linkLabel_QuenMatKhau.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_QuenMatKhau.AutoSize = true;
            this.linkLabel_QuenMatKhau.BackColor = System.Drawing.Color.White;
            this.linkLabel_QuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_QuenMatKhau.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_QuenMatKhau.LinkColor = System.Drawing.Color.Black;
            this.linkLabel_QuenMatKhau.Location = new System.Drawing.Point(34, 358);
            this.linkLabel_QuenMatKhau.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.linkLabel_QuenMatKhau.Name = "linkLabel_QuenMatKhau";
            this.linkLabel_QuenMatKhau.Size = new System.Drawing.Size(162, 25);
            this.linkLabel_QuenMatKhau.TabIndex = 6;
            this.linkLabel_QuenMatKhau.TabStop = true;
            this.linkLabel_QuenMatKhau.Text = "Quên Mật Khẩu?";
            this.linkLabel_QuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuenMatKhau_LinkClicked);
            // 
            // linkLabel_DangKy
            // 
            this.linkLabel_DangKy.AutoSize = true;
            this.linkLabel_DangKy.BackColor = System.Drawing.Color.White;
            this.linkLabel_DangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_DangKy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkLabel_DangKy.LinkColor = System.Drawing.Color.Black;
            this.linkLabel_DangKy.Location = new System.Drawing.Point(449, 359);
            this.linkLabel_DangKy.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.linkLabel_DangKy.Name = "linkLabel_DangKy";
            this.linkLabel_DangKy.Size = new System.Drawing.Size(184, 25);
            this.linkLabel_DangKy.TabIndex = 7;
            this.linkLabel_DangKy.TabStop = true;
            this.linkLabel_DangKy.Text = "Đăng Ký Tài Khoản";
            this.linkLabel_DangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_DangKy_LinkClicked);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.White;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(229, 420);
            this.btnDangNhap.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(208, 46);
            this.btnDangNhap.TabIndex = 8;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtDangNhapTK);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtDangNhapMK);
            this.panel1.Controls.Add(this.linkLabel_QuenMatKhau);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 492);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::QLBH.Properties.Resources.conku;
            this.pictureBox1.Location = new System.Drawing.Point(207, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QLBH.Properties.Resources.ezgif_com_resize__7_;
            this.pictureBox2.Location = new System.Drawing.Point(135, 192);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::QLBH.Properties.Resources.ezgif_com_resize__8_;
            this.pictureBox3.Location = new System.Drawing.Point(135, 269);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(55, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 489);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.linkLabel_DangKy);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DangNhap";
            this.ShowIcon = false;
            this.Text = "Đăng Nhập";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtDangNhapTK;
        private System.Windows.Forms.TextBox txtDangNhapMK;
        private System.Windows.Forms.LinkLabel linkLabel_QuenMatKhau;
        private System.Windows.Forms.LinkLabel linkLabel_DangKy;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Panel panel1;
    }
}

