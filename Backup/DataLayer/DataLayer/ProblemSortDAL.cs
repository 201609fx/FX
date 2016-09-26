using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public class ProblemSortDAL : DataBaseClass
    {


       public DataSet SelectByMIDandPID(string PID, string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@PID", PID),
	         dbHelper.GetParameter("@MainSCID", MainSCID)
	        
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectByMIDandPID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
        /// <summary>
       /// 带统计总分
       /// </summary>
       /// <param name="AssessID"></param>
       /// <param name="MainSCID"></param>
       /// <returns></returns>
       public DataSet SelectByAssessIDandMainSCID(string AssessID, string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@AssessID", AssessID),
	         dbHelper.GetParameter("@MainSCID", MainSCID)
	        
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectByAssessIDandMainSCID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       
       /// <summary>
       /// 不带答案
       /// </summary>
       /// <param name="AssessID"></param>
       /// <returns></returns>
       public DataSet SelectByAssessID(string  AssessID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@AssessID", AssessID)
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectByAssessID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
         /// <summary>
       /// 选择所有基础记分的
       /// </summary>
       /// <param name="AssessID"></param>
       /// <returns></returns>
       public DataSet SelectAllByAssessID(string  AssessID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@AssessID", AssessID)
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectAllByAssessID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
               /// <summary>
       /// 选择所有基础记分的带记分
       /// </summary>
       /// <param name="AssessID"></param>
       /// <param name="MainSCID"></param>
       /// <returns></returns>
       public DataSet SelectTotleByAssessID(string AssessID, string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@AssessID", AssessID),
	         dbHelper.GetParameter("@MainSCID", MainSCID)
	        
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectTotleByAssessID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       
       public DataSet SelectSecond(string  ParentID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@ParentID", ParentID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectSecond", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       
        public DataSet SelectForPlate(string  ParentID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@ParentID", ParentID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_SelectSecondForPlate", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       
       public int UpdateByID(string ID, string ProblemID, string Name, float totle, string Remark, string UserName,string IsATotle)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID),
	        dbHelper.GetParameter("@ProblemID", ProblemID),
	        dbHelper.GetParameter("@Name", Name),
	        dbHelper.GetParameter("@totle", totle),
	        dbHelper.GetParameter("@Remark", Remark),
	        dbHelper.GetParameter("@UserName", UserName),
             dbHelper.GetParameter("@IsATotle", IsATotle)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ProblemSort_UpdateByID", paras);
       }


       public string InsertNull(string ParentID, string AssessID, string UserName)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ParentID", ParentID),
	        dbHelper.GetParameter("@AssessID", AssessID),
	        dbHelper.GetParameter("@UserName", UserName)
        };

           DataSet ds =
               dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemSort_InsertNull", paras);
           return ds.Tables[0].Rows[0][0].ToString();
       }

       public int Up(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ProblemSort_Up", paras);
       }
       public int Delete(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ProblemSort_delete", paras);
       }
       public int Down(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ProblemSort_down", paras);
       }

       public int Top(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ProblemSort_Top", paras);
       }
    }
}
