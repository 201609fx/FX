using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public  class ProblemDAL : DataBaseClass
    {
       public int Update( string ProblemTypeID, string ProblemContent, float totle, string Remark,  string UserName, string ID)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@ProblemTypeID", ProblemTypeID),
	            dbHelper.GetParameter("@ProblemContent", ProblemContent),
	            dbHelper.GetParameter("@totle", totle),
	            dbHelper.GetParameter("@Remark", Remark),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ID", ID)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Problem_UpdateByID", paras);
       }

       public int Up(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Problem_Up", paras);
       }

       public int Down(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Problem_down", paras);
       }

       public int Top(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Problem_Top", paras);
       }

       public string InsertNull(string ProblemSortID,  string UserName)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ProblemSortID", ProblemSortID),
	        dbHelper.GetParameter("@UserName", UserName)
        };

           DataSet ds =
               dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Problem_InsertNull", paras);
           return ds.Tables[0].Rows[0][0].ToString();
       }

       public int Delete(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Problem_delete", paras);
       }

       public DataSet SelectByID(string ID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Problem_SelectByID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       
       public DataSet SelectByPID(string PID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@PID", PID)
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Problem_SelectByPID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }

       public DataSet SelectByPIDandMID(string PID, string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@PID", PID),
             dbHelper.GetParameter("@MainSCID", PID)
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Problem_SelectByPIDAndMainSCID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
    }
}
