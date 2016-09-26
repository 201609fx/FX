using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public class assessPlateDAL:DataBaseClass
    {

       public int UpdateState(string ID, string UserName)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID),
	            dbHelper.GetParameter("@UserName", UserName)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assessPlate_UpdateStateByID", paras);
        }

       public int StopState(string ID, string UserName)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID),
	            dbHelper.GetParameter("@UserName", UserName)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assessPlate_StopStateByID", paras);
       }

       public DataSet SelectActive()
       {
           DataSet ds;

           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "assessPlate_SelectActive");

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }
       public DataSet SelectByID(string ID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "assessPlate_SelectByID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }

       public int Update(string des, string UserName, string state, int InsertFlag, DateTime ModifiTime, string ID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@des", des),
	        dbHelper.GetParameter("@UserName", UserName),
	        dbHelper.GetParameter("@state", state),
           dbHelper.GetParameter("@InsertFlag", InsertFlag),
	        dbHelper.GetParameter("@ModifiTime", ModifiTime),
	        dbHelper.GetParameter("@ID", ID)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assessPlate_Update", paras);
       }

    }
}
