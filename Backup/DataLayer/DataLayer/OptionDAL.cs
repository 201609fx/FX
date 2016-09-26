using System;
using System.Collections.Generic;
using System.Text;
using SZMA.DataLayer;
using System.Data;

namespace SZMA.DataLayer
{
    public class OptionDAL : DataBaseClass
    {
       public DataSet Select(string  ProblemID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@ProblemID", ProblemID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Option_SelectByProblemID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }

       public int Up(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Option_Up", paras);
       }

       public int Down(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Option_down", paras);
       }

       public int Top(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Option_Top", paras);
       }

       public DataSet SelectByID(string ID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Option_SelectByID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public int Insert(string ProblemID, string OptionContent, string ISWrite, string UserName)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ProblemID", ProblemID),
	            dbHelper.GetParameter("@OptionContent", OptionContent),
	            dbHelper.GetParameter("@ISWrite", ISWrite),
	            dbHelper.GetParameter("@UserName", UserName)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Option_Insert", paras);
  }

       public int Delete(string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };



           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Option_delete", paras);
       }

        public int Update( string OptionContent, string ISWrite,  string UserName, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@OptionContent", OptionContent),
	            dbHelper.GetParameter("@ISWrite", ISWrite),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Option_UpdateByID", paras);
        }

    }
    
}
