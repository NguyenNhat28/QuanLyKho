using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.GUI
{
    public partial class MenuKho : Form
    {
        public MenuKho()
        {
            InitializeComponent();
        }

        private void btn_logOut_mn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.OK)
            {
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
            }
        }

        private void btn_frm_vattu_Click(object sender, EventArgs e)
        {
            this.Hide();
            VatLieu vatLieu = new VatLieu();
            vatLieu.Show();
        }

        private void btn_frm_phieunhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void btn_frm_px_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuXuat phieuXuat = new PhieuXuat();
            phieuXuat.Show();
        }

        private void btn_frm_ctpx_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chitietxuat chitietxuat = new Chitietxuat();
            chitietxuat.Show();
        }

        private void MenuKho_Load(object sender, EventArgs e)
        {

        }
    }
}
