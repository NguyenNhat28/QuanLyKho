using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLBH.DAL;
using System.Runtime.Remoting.Contexts;

namespace QLBH.BLL
{
    class VatTu
    {
        Providers provider = new Providers();
        public SqlConnection connection()
        {
            return provider.connection;
        }
        public Boolean Connect()
        {
            return provider.Connect();
        }
        public void DisConnec()
        {
            provider.DisConnect();
        }
        public DataTable GetDataVl()
        {

            string[] parameters = { };
            string[] values = { };
            return provider.GetData("Select * From VatTu", parameters, values, false);

        }
        public int VLExecuteNonQuery(string queryOrSpName, string[] Parameters, object[] Values, bool isStored)
        {
            return provider.ExecuteNonQuery(queryOrSpName, Parameters, Values, isStored);
        }
    }
}
