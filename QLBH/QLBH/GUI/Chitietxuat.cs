using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.BLL;

namespace QLBH.GUI
{
    public partial class Chitietxuat : Form
    {
        public Chitietxuat()
        {
            InitializeComponent();
        }
        CTPX chitiet;
        bool SaveFlag = true;
        private void LoadDataCT()
        {
            DataTable tblc;
            chitiet = new CTPX();
            if (chitiet.Connect())
            {
                tblc = chitiet.GetDataChiTietPhieuXuat();
                datagrid.DataSource = tblc;
                chitiet.DisConnec();
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
            datagrid.Columns["SoPX"].HeaderText = "Số phiếu xuất";
            datagrid.Columns["MaVT"].HeaderText = "Mã vật tư";
            datagrid.Columns["SoLuongXuat"].HeaderText = "Số lượng xuất";
            datagrid.Columns["DonGiaXuat"].HeaderText = "Đơn giá xuất";
            BindingDataCTX();
        }
        private void BindingDataCTX()
        {
            txtslx.DataBindings.Clear();
            txtdgx.DataBindings.Clear();
            cbbpx.DataBindings.Clear();
            cbvt.DataBindings.Clear();

            txtslx.DataBindings.Add("Text",datagrid.DataSource, "SoLuongXuat");
            txtdgx.DataBindings.Add("Text", datagrid.DataSource, "DonGiaXuat");
            cbbpx.DataBindings.Add("Text", datagrid.DataSource, "SoPX");
            cbvt.DataBindings.Add("Text", datagrid.DataSource, "MaVT");
        }
        private void Chitietxuat_Load(object sender, EventArgs e)
        {
            CTPX ct = new CTPX();
            if (ct.Connect())
            {
                cbvt.DataSource = ct.GetDataCTXuat();
                cbvt.DisplayMember = "TenVT";
                cbvt.ValueMember = "MaVT";
            }
            else
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }

            if (ct.Connect())
            {
                cbbpx.DataSource = ct.GetDataCTPXuat();
                cbbpx.DisplayMember = "TenKH";
                cbbpx.ValueMember = "SoPX";
            }
            else
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
            LoadDataCT();
        }
        private int UpdateCT(CTPX chitiet)
        {
            string sqlUpdate = "UPDATE CTPhieuXuat SET SoPX=@sopx,MaVT = @mavt WHERE SoPX = @sopx";
            string[] parameters = { "@sopx", "@mavt" };
            object[] values = {byte.Parse(txtslx.Text), byte.Parse(txtdgx.Text) };
            return chitiet.CTPhieuXuatExecuteNonQuery(sqlUpdate, parameters, values,false);
        }
        private int InsertCT(CTPX chitiet)
        {
            string sqlInsert = "INSERT INTO CTPhieuXuat(SoPX,MaVT,SoLuongXuat,DonGiaXuat)VALUES(@sopx,@mavt,@soluongxuat,@dongiaxuat)";
            string[] parameters = {"@sopx", "@mavt","@soluongxuat","@dongiaxuat"};
            object[] values = {cbbpx.Text,cbvt.Text,txtslx.Text,txtdgx.Text};
            return chitiet.CTPhieuXuatExecuteNonQuery(sqlInsert, parameters, values, false);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            chitiet = new CTPX();
            if (chitiet.Connect())
            {
                if (SaveFlag)
                {
                    int rec = InsertCT(chitiet);

                    if (rec > 0)
                    {
                        MessageBox.Show("Đã thêm thành công","Thông báo!");
                        LoadDataCT();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm dữ liệu", "Thông báo!");
                    }
                }
                else
                {
                    int rec = UpdateCT(chitiet);
                    if (rec > 0)
                    {
                        MessageBox.Show("Đã cập nhật dữ liệu thành công", "Thông báo!");
                        LoadDataCT();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật dữ liệu", "Thông báo!");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
            datagrid.Enabled = true;


        }
        private void ResetAll()
        {
            txtslx.Text = "";
            cbbpx.Text = "";
            cbvt.Text = "";
            txtdgx.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            datagrid.Enabled = false;
            ResetAll();
           
        }
        private int DeleteCT(CTPX chitiet)
        {
            string sqlDelete = "DELETE FROM CTPhieuXuat WHERE SoLuongXuat = @soluongxuat";
            string[] parameters = { "@soluongxuat" };
            object[] values = { txtslx.Text };
            return chitiet.CTPhieuXuatExecuteNonQuery(sqlDelete,parameters, values, false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chitiet = new CTPX();
            if (chitiet.Connect())
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa dòng này không ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int rec = DeleteCT(chitiet);
                if ((dialogResult == DialogResult.Yes)  && (rec > 0))
                {
                    MessageBox.Show("Đã xóa 1 dòng thành công", "Thông báo!");
                    LoadDataCT();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa dòng dữ liệu", "Thông báo!");
                }
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                this.Hide();
                MenuKho dn = new MenuKho();
                dn.Show();
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtslx_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbbpx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbvt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtdgx_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
