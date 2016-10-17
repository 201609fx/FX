using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class OperateSADAL : DataBaseClass
    {

        public DataSet SelectMainSCID(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };
            string sql = "select * from OperateSA where MainSCID=@MainSCID ";
            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql,paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public int Update( string Brand, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Brand", Brand),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OperateSA_Update", paras);
        }
        public int Insert(string MainSCID, string Brand)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@Brand", Brand)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OperateSA_Insert", paras);
        }

        public int Delete(string ID)
        {
            IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };

            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OperateSA_Delete", paras);
        }

        public int Delete(string ID,string busName)
        {
            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, "  Delete From [OperateSA] Where MainSCID='" + ID + "'  and brand ='" + busName + "'");
        }

    }
}
