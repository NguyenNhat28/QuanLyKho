using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QLBH
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        public bool checkAccount(string ac)//dung check mat khau va tai khoan
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        public bool checkGmail(string em)//dung check gmail
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9.]{3,20}@gmail.com$");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        Modify modify = new Modify();
        private void btnDKy_Click(object sender, EventArgs e)
        {
            string tentk = txtDKyTK.Text;
            string matkhau = txtDKyMK.Text;
            string xnmatkhau = txtXacNhanLaiMK.Text;
            string gmail = txtDKyGmail.Text;
            if(!checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }
            if(!checkAccount(matkhau))
            {
                MessageBox.Show("Vui lòng nhập tên mật khẩu dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }
            if(xnmatkhau!=matkhau)
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu chính xác!");
                return;
            }
            if(!checkGmail(gmail))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng và đầy đủ các phần tử của gmail!");
                return;
            }
            if(modify.taiKhoans("Select * from TaiKhoan where Gmail = '"+gmail+"'").Count!=0)
            {
                MessageBox.Show("Vui lòng đăng ký gmail khác!");
                return;
            }
            try
            {
                string query = "Insert into TaiKhoan values ('"+ tentk +"','"+ matkhau +"','" + gmail + "')";
                modify.Conmand(query);
                if(MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập luôn không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng ký lại tài khoản khác!");
            }
            
               
            
        }
    }
}
