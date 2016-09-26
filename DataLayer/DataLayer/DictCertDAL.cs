using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
     public class DictCertDAL:DataBaseClass
    {
         public DataSet Select()
         {
             DataSet ds;



             ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Dict_Cert_Select");

             if (0 == ds.Tables.Count)
                 ds.Tables.Add(new DataTable());
             return ds;
         }
    }
}
