using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public class CSFileDAL:DataBaseClass
    {
       public DataSet SelectByMainSCID1(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "CSFile_SelectByMainSCID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       public DataSet SelectByMainSCID2(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "CSFile_SelectByMainSCID2", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       public int InsertGongZhang(string MainSCID,  string ISCheck, string Remark, string CheckUser, DateTime CheckTime, string UserName)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@MainSCID", MainSCID),
	        dbHelper.GetParameter("@ISCheck", ISCheck),
	        dbHelper.GetParameter("@Remark", Remark),
	        dbHelper.GetParameter("@CheckUser", CheckUser),
	        dbHelper.GetParameter("@CheckTime", CheckTime),
	        dbHelper.GetParameter("@UserName", UserName)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "CSlist_InsertGongZhang", paras);
       }

       public int Insert(string MainSCID, string CSFileID, string ISCheck, string Remark, string CheckUser, DateTime CheckTime, string UserName)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@MainSCID", MainSCID),
	        dbHelper.GetParameter("@CSFileID", CSFileID),
	        dbHelper.GetParameter("@ISCheck", ISCheck),
	        dbHelper.GetParameter("@Remark", Remark),
	        dbHelper.GetParameter("@CheckUser", CheckUser),
	        dbHelper.GetParameter("@CheckTime", CheckTime),
	        dbHelper.GetParameter("@UserName", UserName)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "CSlist_Insert", paras);
       }
       public int Update(string Num, string ID)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@Num", Num),
	            dbHelper.GetParameter("@ID", ID)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "CSlist_Update", paras);
       }
       public int Delete(string ID)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };

           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "CSlist_Delete", paras);
       }

    }
}
