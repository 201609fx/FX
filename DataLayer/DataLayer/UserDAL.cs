using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class UserDAL:DataBaseClass
    {
        public DataSet CheckLogin(string UserName, string UsPassWord)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@UsPassWord", UsPassWord)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "UserInfo_Select", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
