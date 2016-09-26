using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public class ApproveDAL : DataBaseClass
    {
       public int InsertNull(string MainSCID, string UserName)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "approve_Insert", paras);
       }
       public int Update(string superintendent, string suggest, DateTime stime, string remark,string UserName, string MainSCID)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@superintendent", superintendent),
	            dbHelper.GetParameter("@suggest", suggest),
	            dbHelper.GetParameter("@stime",  DTCheck(stime)),
	            dbHelper.GetParameter("@remark", remark),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "approve_Update", paras);
       }


       public int UpdateAll(string superintendent, string suggest, DateTime stime,
           string promoter, string Psuggest, DateTime Ptime,
           string leader, string Lsuggest, DateTime Ltime, 
           string remark, string UserName, string MainSCID)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@superintendent", superintendent),
	            dbHelper.GetParameter("@suggest", suggest),
	            dbHelper.GetParameter("@stime",  DTCheck(stime)),
	            dbHelper.GetParameter("@promoter", promoter),
	            dbHelper.GetParameter("@Psuggest", Psuggest),
	            dbHelper.GetParameter("@Ptime",  DTCheck(Ptime)),
	            dbHelper.GetParameter("@leader", leader),
	            dbHelper.GetParameter("@Lsuggest", Lsuggest),
	            dbHelper.GetParameter("@Ltime",  DTCheck(Ltime)),
	            dbHelper.GetParameter("@remark", remark),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "approve_UpdateAll", paras);
       }

       public DataSet SelectByMID(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "approve_Select", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
         public DataSet SelectAllByMID(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "approve_SelectAll", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       
    }
}
