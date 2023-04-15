using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.GUI;

namespace QLBH
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
        }

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
        }

        private void txtDangNhapTK_TextChanged(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tentk = txtDangNhapTK.Text;
            string matkhau = txtDangNhapMK.Text;
            if(tentk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập lại tên tài khoản!");
           
            }
            else
            if(matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                
            }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan = '" + tentk + "' and MatKhau = '" + matkhau + "'";
                if(modify.taiKhoans(query).Count!=0)
                {
                    MessageBox.Show("Đăng nhập thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    MenuKho menu = new MenuKho();
                    menu.ShowDialog();
                    this.Hide();
                }else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ!","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void txtDangNhapTK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtDangNhapMK.Focus();
            }
        }

        private void txtDangNhapMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}
