using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class NewsDAL:DataBaseClass
    {
        public DataSet SelectBySortID(int SortID, int InsertFlag)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@SortID", SortID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "News_SelectBySortID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public int UpdateByID(string Title,  string Abstract, string Keyword, string Author, string Refer, string Content, int InsertFlag, string UserName,  DateTime ModifiTime, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Title", Title),
	            dbHelper.GetParameter("@Abstract", Abstract),
	            dbHelper.GetParameter("@Keyword", Keyword),
	            dbHelper.GetParameter("@Author", Author),
	            dbHelper.GetParameter("@Refer", Refer),
	            dbHelper.GetParameter("@Content", Content),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ModifiTime", ModifiTime),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "News_UpdateByID", paras);
        }

        public bool AddClickTime(string StrID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", StrID)
            };
            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "News_UpdateClickTimes", paras)>0;

        }
    }
}
