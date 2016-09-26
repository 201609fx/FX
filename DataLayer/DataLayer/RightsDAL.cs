using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SZMA.DataLayer
{
    public class RightsDAL:DataBaseClass
    {
        public DataSet Select()
        {
            DataSet ds;
            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "UserRights_Select");
            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
