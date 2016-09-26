using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class DictTaskDAL:DataBaseClass
    {
        public DataSet Select(string UserID)
        {
            DataSet ds;
            IDataParameter[] paras = {
                dbHelper.GetParameter("@UserID", UserID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_task_SelectByUserID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

  
        
         public DataSet SelectByUserID(string UserID)
        {
            DataSet ds;
            IDataParameter[] paras = {
                dbHelper.GetParameter("@UserID", UserID)
            };
            string sql =
                @"     
        Select  dict_task.* ,1 as HasTask  From [dict_task] ,UserInfo
	Where UserInfo.ID='"+UserID+@"'  
  and UserInfo.taskID like '%'+Ltrim(str([dict_task].ID))+',%'
	union
Select  a.* ,0 as HasTask  From [dict_task] a ,UserInfo c
	Where c.ID='"+UserID+@"' 
  and a.ID not in( select b.ID from dict_task b where c.taskID like '%'+Rtrim(Ltrim(str(b.ID)))+',%')";

            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text,sql);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public int Update(int DateNum, DateTime CreateTime, string UserName, string ID)
        {
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@DateNum", DateNum),
                                         dbHelper.GetParameter("@CreateTime", CreateTime),
                                         dbHelper.GetParameter("@UserName", UserName),
                                         dbHelper.GetParameter("@ID", ID)
                                     };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "dict_task_Update", paras);
        }

    }
}
