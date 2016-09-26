using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
     public class PromotionDealDAL:DataBaseClass
    {
         public int InsertNull(string MainSCID, string UserName)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@UserName", UserName)
            };
             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "PromotionDeal_InsertNull", paras);
         }
         public DataSet Select(string MainSCID)
         {
             DataSet ds;
             IDataParameter[] paras = {
	                dbHelper.GetParameter("@MainSCID", MainSCID)
                };


             ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PromotionDeal_Select", paras);

             if (0 == ds.Tables.Count)
                 ds.Tables.Add(new DataTable());
             return ds;
         }
         public int Update(string result, string Level, string leader, DateTime lTime, string MainSCID, string UserName)
         {
             object objlTime = lTime.Ticks == 0 ? DBNull.Value:(object)lTime;
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@result", result),
	            dbHelper.GetParameter("@Level", Level),
	            dbHelper.GetParameter("@leader", leader),
	            dbHelper.GetParameter("@lTime", objlTime),
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@UserName", UserName)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "PromotionDeal_Update", paras);
         }

    }
}
