using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class dictresuleDAL:DataBaseClass
    {
        public DataSet Select()
        {
            DataSet ds;



            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_PromotionDeal_Select");

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


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dict_PromotionDeal_SelectByID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
