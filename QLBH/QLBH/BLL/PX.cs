using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.DAL;
using System.Data;
using System.Data.SqlClient;

namespace QLBH.BLL
{
    internal class PX
    {
        Providers providers = new Providers();
        public SqlConnection Connection()
        {
            return providers.connection;
        }
      
        public Boolean Connect()
        {
            return providers.Connect();
        }


        public void DisConnect()
        {
            providers.DisConnect();
        }
        public DataTable GetDataPhieuXuat()
        {
            string[] parameters = { };
            string[] values = { };
            return providers.GetData("Select * From PhieuXuat",parameters, values, false);
        }
        public int PhieuXuatExecuteNonQuery(string queryOrSpName,string[] Parameters, object[] Values, bool isStored)
        {
            return providers.ExecuteNonQuery(queryOrSpName, Parameters, Values, isStored);
        }

        }
}
