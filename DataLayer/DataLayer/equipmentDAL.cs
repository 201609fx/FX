using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
     public class equipmentDAL:DataBaseClass
    {
         public int Insert(string des, string Num,string Model, string Type, string MainSCID)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@des", des),
	            dbHelper.GetParameter("@Model", Model),
	            dbHelper.GetParameter("@Num", Num),
	            dbHelper.GetParameter("@Type", Type),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "equipment_Insert", paras);
         }
         public int Update(string des, string Num, string Model, string ID)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@des", des),
	            dbHelper.GetParameter("@Model", Model),
	            dbHelper.GetParameter("@Num", Num),
	            dbHelper.GetParameter("@ID", ID)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "equipment_Update", paras);
         }
         public int Delete(string ID)
         {
             IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };

             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "equipment_Delete", paras);
         }

         public int Delete(string ID,string toolType,string toolName,string toolNumber)
         {

             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, "delete from [equipment] where MainSCID='"+ID+"' and des='"+toolName+"' and Model='"+toolNumber+"' ");
         }

    }
}
