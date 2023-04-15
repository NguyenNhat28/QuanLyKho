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
using QLBH.GUI;

namespace QLBH
{

    public partial class VatLieu : Form
    {
        public VatLieu()
        {
            InitializeComponent();
        }
        VatTu vt;
        bool SaveFlag = true;
        private void LoadDataVatTu()
        {
            DataTable tblVT;
            vt = new VatTu();
            if (vt.Connect())
            {
                tblVT = vt.GetDataVl();
                grview.DataSource = tblVT;
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
            grview.Columns["MaVT"].HeaderText = "Mã vật tư";

            grview.Columns["TenVT"].HeaderText = "Tên vật tư";
 
            grview.Columns["DvTinh"].HeaderText = "Đơn vị tính";

            grview.Columns["SoLuong"].HeaderText = "Số lượng";

            BindingDataVatTu();
        }
        private void BindingDataVatTu()
        {
          
            txtmavt.DataBindings.Clear();
            txttenvt.DataBindings.Clear();
            txtdvt.DataBindings.Clear();
            txtsl.DataBindings.Clear();

            txtmavt.DataBindings.Add("Text",grview.DataSource, "MaVT");
            txttenvt.DataBindings.Add("Text",grview.DataSource, "TenVT");
            txtdvt.DataBindings.Add("Text",grview.DataSource, "DvTinh");
            txtsl.DataBindings.Add("Text", grview.DataSource, "SoLuong");
        }
        private void ResetAll()
        {
            txtmavt.ReadOnly = false;
            txtmavt.Text = "";
            txttenvt.ResetText();
            txtdvt.Clear();
            txtsl.Clear();
        }
        private void VatLieu_Load(object sender, EventArgs e)
        {
            LoadDataVatTu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtmavt.ReadOnly = false;
            ResetAll();
        }
        private int DeleteVatTu(VatTu vl)
        {
            string sqlDelete = "DELETE FROM VatTu WHERE MaVT = @mavt";
            string[] parameters = { "@mavt" };
            object[] values = { txtmavt.Text };
            return vl.VLExecuteNonQuery(sqlDelete,parameters, values, false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            vt = new VatTu();
            if (vt.Connect())
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa dòng này không ?","Thông báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                int rec = DeleteVatTu(vt);
                if ((dialogResult == DialogResult.Yes) && (rec > 0))
                {
                    MessageBox.Show("Đã xóa 1 dòng thành công", "Thông báo!");
                    LoadDataVatTu();
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
            txtmavt.ReadOnly = true;
            SaveFlag = false;
        }
        private int UpdateVatTu(VatTu vt)
        {
            string sqlUpdate = "UPDATE VatTu SET TenVT=@tenvt,DvTinh = @dvtinh,SoLuong=@soluong WHERE MaVT = @mavt";
            string[] parameters = { "@mavt", "@tenvt", "@dvtinh", "@soluong" };
            object[] values = { txtmavt.Text, txttenvt.Text,txtdvt.Text ,byte.Parse(txtsl.Text) };
            return vt.VLExecuteNonQuery(sqlUpdate, parameters, values,false);
        }
        private int InsertVatTu(VatTu vt)
        {
            string sqlInsert = "INSERT INTO VatTu(MaVT, TenVT,DvTinh,SoLuong)VALUES(@mavt, @tenvt, @dvtinh,@soluong)";
            string[] parameters = { "@mavt", "@tenvt", "@dvtinh", "@soluong" };
            object[] values = { txtmavt.Text, txttenvt.Text, txtdvt.Text,byte.Parse(txtsl.Text) };
            return vt.VLExecuteNonQuery(sqlInsert, parameters, values,false);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            vt = new VatTu();
            if (vt.Connect())
            {
                if (SaveFlag)
                {
                    int rec = InsertVatTu(vt);

                    if (rec > 0)
                    {
                        MessageBox.Show("Đã thêm thành công","Thông báo!");
                        LoadDataVatTu();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm dữ liệu", "Thông báo!");
                    }
                }
                else
                {
                    int rec = UpdateVatTu(vt);
                    if (rec > 0)
                    {
                        MessageBox.Show("Đã cập nhật dữ liệu thành công", "Thông báo!");
                        LoadDataVatTu();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật dữ liệu", "Thông báo!");
                    }
                    txtmavt.ReadOnly = false;
                }
            }
            else
            {
                MessageBox.Show("Kết nối với cơ sở dữ liệu thất bại!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                this.Hide();
                MenuKho dn = new MenuKho();
                dn.Show();
                
            }
        }

        private void txtmavt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttenvt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdvt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
