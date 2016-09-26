using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class SortDAL: DataBaseClass
    {

        public DataSet Select(string SortName)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@SortName", SortName)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Sort_SelectBySortName", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public int Update(string Des, string ID, string Summary)
        {
            IDataParameter[] paras = {
	        dbHelper.GetParameter("@Summary", Summary),
	        dbHelper.GetParameter("@Des", Des),
	        dbHelper.GetParameter("@ID", ID)
        };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Sort_UpdateByID", paras);
        }

    }
}
