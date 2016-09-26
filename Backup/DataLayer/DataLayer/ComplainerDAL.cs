using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SZMA.DataLayer
{
     public class ComplainerDAL:DataBaseClass
    {
         public DataSet SelectByID(string ID)
         {
             DataSet ds;
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };

             ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "complain_SelectByID", paras);

             if (0 == ds.Tables.Count)
                 ds.Tables.Add(new DataTable());
             return ds;
         }
         public int UpdateFirst(DateTime CTime, string Complainer, string Caddresstou, string CTel, string BComplainer, string BCTel, string BContact, string BAddress, string Name, string content, string Type, int InsertFlag, string ID, string UserName)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@CTime",  DTCheck(CTime)),
	            dbHelper.GetParameter("@Complainer", Complainer),
	            dbHelper.GetParameter("@Caddresstou", Caddresstou),
	            dbHelper.GetParameter("@CTel", CTel),
	            dbHelper.GetParameter("@BComplainer", BComplainer),
	            dbHelper.GetParameter("@BCTel", BCTel),
	            dbHelper.GetParameter("@BContact", BContact),
	            dbHelper.GetParameter("@BAddress", BAddress),
	            dbHelper.GetParameter("@Name", Name),
	            dbHelper.GetParameter("@content", content),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            
              dbHelper.GetParameter("@Type", Type),
	            dbHelper.GetParameter("@ID", ID),
	            dbHelper.GetParameter("@UserName", UserName)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "complain_UpdateByFirst", paras);
         }
         public int UpdateSecond(string suggest, string suggester, DateTime STime, string result, string Leader, string LSuggest, DateTime LSTime, string Leader1, string LSuggest1, DateTime LSTime1, int InsertFlag, string ID,string UserName)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@suggest", suggest),
	            dbHelper.GetParameter("@suggester", suggester),
	            dbHelper.GetParameter("@STime", DTCheck(STime)),
	            dbHelper.GetParameter("@result", result),
	            dbHelper.GetParameter("@Leader", Leader),
	            dbHelper.GetParameter("@LSuggest", LSuggest),
	            dbHelper.GetParameter("@LSTime",  DTCheck(LSTime)),
                //dbHelper.GetParameter("@Leader1", Leader1),
                //dbHelper.GetParameter("@LSuggest1", LSuggest1),
                //dbHelper.GetParameter("@LSTime1",  DTCheck(LSTime1)),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            dbHelper.GetParameter("@ID", ID),
	            dbHelper.GetParameter("@UserName", UserName)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "complain_UpdateBySecond", paras);
         }

         public int UpdateInsertFlag(int InsertFlag, Int64 ID)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            dbHelper.GetParameter("@ID", ID)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "complain_UpdateInsertFlag", paras);
         }

    }
}
