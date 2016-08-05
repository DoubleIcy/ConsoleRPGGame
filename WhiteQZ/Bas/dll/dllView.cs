using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe; 

namespace Bas.dll
{
    public class dllView
    {
        public string sdfFile = @"Y:\github\2016-6-14\ConsoleRPGGame\WhiteQZ\Bas\DB\Db_sdf.sdf", connection = @"Data Source=Y:\github\2016-6-14\ConsoleRPGGame\WhiteQZ\Bas\DB\Db_sdf.sdf";
        
        SqlCeConnection sqlceCon;
        public DataSet GetData(string tableName,string filter)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from {0}" + (string.IsNullOrEmpty(filter) ? "" : " where {1}"), tableName, filter);

            try
            {
                sqlceCon = new SqlCeConnection(connection);
                sqlceCon.Open();
                SqlCeDataAdapter adptrOdbc = new SqlCeDataAdapter(str, sqlceCon);
                adptrOdbc.Fill(ds);
            }
            catch
            {

            }
            finally
            {
                sqlceCon.Close();
            }

            return ds;
        }

        public object com_Get1()
        {
            Bas.dll.common.DbHelper.DbConnectionString = connection;
            Bas.dll.common.DbHelper.DbProviderName = "System.Data.SqlServerCe.3.5";
            Bas.dll.common.DbHelper db = new Bas.dll.common.DbHelper();
            DataSet ds=db.ExecuteDataSet("select a.*,'☑' as mark from bas_user a");
            return ds;
        }
        public object com_Get2()
        {
            Bas.dll.common.DbHelper db = new Bas.dll.common.DbHelper(connection, "System.Data.SqlServerCe.3.5");
            DataTable dt= db.ExecuteDataTable("select * from bas_user");
            return dt;
        }
    }
}
