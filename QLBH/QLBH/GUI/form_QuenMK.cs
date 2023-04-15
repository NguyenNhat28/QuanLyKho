using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            lblkq.Text = "";
        }
        Modify modify = new Modify();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gmail = txtLayLaiMatKhau.Text;
            if (gmail.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập gmail đã đăng ký!");
            }
            string query = "Select * from TaiKhoan where Gmail = '" + gmail + "'";
            if(modify.taiKhoans(query).Count!=0)
            {
                lblkq.ForeColor = Color.Blue;
                lblkq.Text = "Mật khẩu: " + modify.taiKhoans(query)[0].MatKhau;
            }
            else
            {
                lblkq.ForeColor = Color.Red;
                lblkq.Text = "Gmail này chưa được đăng ký!";
            }
        }
    }
}
