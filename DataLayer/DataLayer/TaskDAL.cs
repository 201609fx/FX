using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class TaskDAL:DataBaseClass
    {
        public DataSet Select(string InsertFlag, string state)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@InsertFlag", InsertFlag),
                                         dbHelper.GetParameter("@state", state)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Task_Select", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet SelectByUser(string userName)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@UserName", userName)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_task_SelectByUser", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        
        public DataSet SelectAll()
        {
            DataSet ds;

            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.dict_task_SelectAll");

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
