using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class CertDictDAL:DataBaseClass
    {

        public int Add( string ID)
        {
            IDataParameter[] paras = {
	        dbHelper.GetParameter("@ID", ID)
        };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "certDict_AddC_Value", paras);
        }

        public DataSet SelectByID(string ID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "certDict_Select", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
