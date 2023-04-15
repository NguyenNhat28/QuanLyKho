using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.BLL;

namespace QLBH.GUI
{
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
        {
            InitializeComponent();
        }
        PX phieuxuat;
        bool SaveFlag = true;

        private void LoadDataPX()
        {
            DataTable dt;
            phieuxuat = new PX();
            if (phieuxuat.Connect())
            {
                dt = phieuxuat.GetDataPhieuXuat();
                dtgv.DataSource = dt;
                phieuxuat.DisConnect();
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
            dtgv.Columns["SoPX"].HeaderText = "Số phiếu xuất";
            dtgv.Columns["NgayXuat"].HeaderText = "Ngày xuất";
            dtgv.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dtgv.Columns["sdt"].HeaderText = "Số điện thoại";
            BindingDataPhieuXuat();
        }
        private void BindingDataPhieuXuat()
        {
            txtkh.DataBindings.Clear();
            txtsdt.DataBindings.Clear();
            txtpx.DataBindings.Clear();

            txtpx.DataBindings.Add("Text", dtgv.DataSource, "SoPX");
            txtkh.DataBindings.Add("Text", dtgv.DataSource, "TenKH");
            txtsdt.DataBindings.Add("Text", dtgv.DataSource, "sdt");
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            LoadDataPX();   
        }
        private int UpdatePhieuXuat(PX phieuxuat)
        {
            string sqlUpdate = "UPDATE PhieuXuat SET SoPX=@sopx,TenKH = @tenkh WHERE SoPX = @sopx";
            string[] parameters = { "@sopx","@tenkh", "@sdt" };
            object[] values = { txtpx.Text, txtkh.Text,txtsdt.Text};
            return phieuxuat.PhieuXuatExecuteNonQuery(sqlUpdate, parameters, values, false);
        }
        private int InsertPhieuXuat(PX phieuxuat)
        {
            //string ngay = dtp.Value.ToString("dd-MM-yyyy");

            string sqlInsert = "INSERT INTO PhieuXuat(SoPX,NgayXuat,TenKH,sdt) VALUES (@sopx,@ngayxuat,@tenkh,@sdt)";
            string[] parameters = { "@sopx","@ngayxuat","@tenkh", "@sdt" };
            object[] values = { txtpx.Text, DateTime.Parse(dtp.Text) ,txtkh.Text, txtsdt.Text};
            return phieuxuat.PhieuXuatExecuteNonQuery(sqlInsert, parameters, values, false);
          
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            phieuxuat = new PX();
            if (phieuxuat.Connect())
            {
                if (SaveFlag)
                {
                    if (txtpx.Text.Length > 4)
                    {
                        MessageBox.Show("Bạn nhập ô phiếu xuất quá 4 ký tự", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int rec = InsertPhieuXuat(phieuxuat);

                        if (rec > 0)
                        {
                            MessageBox.Show("Đã thêm thành công", "Thông báo!");

                            LoadDataPX();
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm dữ liệu", "Thông báo!");
                        }

                    }
                }
                else
                {
                    int rec = UpdatePhieuXuat(phieuxuat);
                    if (rec > 0)
                    {
                        MessageBox.Show("Đã cập nhật dữ liệu thành công", "Thông báo!");

                        LoadDataPX();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật dữ liệu", "Thông báo!");
                    }
                    txtpx.ReadOnly = false;
                }
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
        }
        private void ResetAll()
        {
            txtpx.ReadOnly = false;
            txtkh.Text = "";
            txtsdt.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtpx.ReadOnly = false;
            ResetAll();
        }
        private int DeletePhieuXuat(PX phieuxuat)
        {
            string sql_CT_PX = "select SoPX from CTPhieuXuat";
            string DelCTpx = "DELETE FROM CTPhieuXuat WHERE SoPX = @sopx";
            string sqlDelete = "DELETE FROM PhieuXuat WHERE SoPX = @sopx";
            string[] parameters = { "@sopx" };
            object[] values = { txtpx.Text };
            if(sql_CT_PX.Equals(parameters))
            {
                phieuxuat.PhieuXuatExecuteNonQuery(DelCTpx, parameters, values, false);
            }
            else
            {
                phieuxuat.PhieuXuatExecuteNonQuery(sqlDelete, parameters, values, false);
            }
            return DeletePhieuXuat(phieuxuat);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            phieuxuat = new PX();
            if (phieuxuat.Connect())
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa dòng này không ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int rec = DeletePhieuXuat(phieuxuat);
                if ((dialogResult == DialogResult.Yes) && (rec > 0))
                {
                    MessageBox.Show("Đã xóa 1 dòng thành công", "Thông báo!");
                    LoadDataPX();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa dòng dữ liệu", "Thông báo!");
                }
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa dòng dữ liệu", "Thông báo!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtpx.ReadOnly = true;
            SaveFlag = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Hide();
                MenuKho dn = new MenuKho();
                dn.Show();
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtpx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
    }
   

}
