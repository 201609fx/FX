using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class UserGroupDAL:DataBaseClass
    {
        public DataSet SelectAll()
        {
            DataSet ds;
            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "UserGroup_Select");

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


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "UserGroup_SelectByID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public int Update(string Name, string Rights, string UserName,  DateTime ModifiTime, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Name", Name),
	            dbHelper.GetParameter("@Rights", Rights),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ModifiTime", ModifiTime),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UserGroup_Update", paras);
        }

    }
}
