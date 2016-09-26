using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class dictbrandDAL:DataBaseClass
    {
        public int Update(string Name, string EName, string UserName, DateTime ModiTime, string InsertFlag, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Name", Name),
	            dbHelper.GetParameter("@EName", EName),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ModiTime", ModiTime),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "dict_brand_Update", paras);
        }
        public DataSet Select(string ID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_brand_Select", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public DataSet SelectAll()
        {
            DataSet ds;

            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_brand_SelectAll");

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
