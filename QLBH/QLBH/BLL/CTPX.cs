using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBH.DAL;
using System.Windows.Forms;

namespace QLBH.BLL
{
    internal class CTPX
    {
        Providers provider = new Providers();
        public SqlConnection connection()
        {
            return provider.connection;
        }
        public bool Connect()
        {
            return provider.Connect();
        }
        public void DisConnec()
        {
            provider.DisConnect();
        }
        public DataTable GetDataCTXuat()
        {

            DataTable tbl = new DataTable();

            SqlCommand cmdSelect = new SqlCommand("Select MaVT From VatTu", connection());
       
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
      
            da.Fill(tbl);
       
            return tbl;
        }
        public DataTable GetDataCTPXuat()
        {

            DataTable tb = new DataTable();

            SqlCommand cmdSelect = new SqlCommand("Select SoPX From PhieuXuat", connection());

            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);

            da.Fill(tb);

            return tb;
        }
        public DataTable GetDataChiTietPhieuXuat()
        {
            string[] parameters = { };
            string[] values = { };
            return provider.GetData("Select * From CTPhieuXuat", parameters, values, false);
        }
        public int CTPhieuXuatExecuteNonQuery(string queryOrSpName, string[] Parameters, object[] Values, bool isStored)
        {
            return provider.ExecuteNonQuery(queryOrSpName, Parameters, Values, isStored);
        }


    }
}
