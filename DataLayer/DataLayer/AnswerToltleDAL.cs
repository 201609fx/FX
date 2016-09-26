using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public class AnswerToltleDAL:DataBaseClass
   {

       public DataSet SelectAllTotle(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "AnswerTotle_SelectAllTotleByMID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Totle"></param>
       /// <param name="MainSCID"></param>
       /// <param name="ProblemSOrtID"></param>
       /// <param name="UserName"></param>
       /// <returns></returns>
       public int Insert(string Totle, string MainSCID, string ProblemSOrtID, string UserName)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@Totle", Totle),
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@ProblemSOrtID", ProblemSOrtID),
	            dbHelper.GetParameter("@UserName", UserName)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "AnswerTotle_Insert", paras);
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Totle"></param>
       /// <param name="MidofiTIme"></param>
       /// <param name="UserName"></param>
       /// <param name="ProblemSortID"></param>
       /// <param name="MainSCID"></param>
       /// <returns></returns>
       public int Update(string Totle, DateTime MidofiTIme, string UserName, string ProblemSortID, string MainSCID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@Totle", Totle),
	        dbHelper.GetParameter("@MidofiTIme", MidofiTIme),
	        dbHelper.GetParameter("@UserName", UserName),
	        dbHelper.GetParameter("@ProblemSOrtID", ProblemSortID),
	        dbHelper.GetParameter("@MainSCID", MainSCID)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "AnswerTotle_Update", paras);
       }

       public int Delete(string ProblemSOrtID, string MainSCID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ProblemSOrtID", ProblemSOrtID),
	        dbHelper.GetParameter("@MainSCID", MainSCID)
        };

           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "AnswerTotle_Delete", paras);
       }

   }
}
