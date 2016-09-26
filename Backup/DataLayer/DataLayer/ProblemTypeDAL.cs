using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public class ProblemTypeDAL:DataBaseClass
    {

       public string SelectNameByID(string ID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	dbHelper.GetParameter("@ID", ID)
};


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProblemType_SelectByID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds.Tables[0].Rows[0]["TypeName"].ToString();
       }
    }
}
