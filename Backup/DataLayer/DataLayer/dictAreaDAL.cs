using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class dictAreaDAL:DataBaseClass
    {
        public DataSet Select()
        {
            DataSet ds;



            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_Area_SelectAll");

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
