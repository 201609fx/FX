using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SZMA.DataLayer
{
   public class OperationDAL:DataBaseClass
    {
       public DataSet Select(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
                                        dbHelper.GetParameter("@MainSCID", MainSCID)
                                    };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Operation_SelectByMainSCID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }

       public int Insert(string SortID, string Content, string brand, string MainSCID)
       {
           IDataParameter[] paras = {
                                        dbHelper.GetParameter("@SortID", SortID),
                                        dbHelper.GetParameter("@Content", Content),
                                        dbHelper.GetParameter("@brand", brand),
                                        dbHelper.GetParameter("@MainSCID", MainSCID)
                                    };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Operation_Insert", paras);
       }

       public int Update(string SortID, string Content, string brand, string ID)
       {
           IDataParameter[] paras = {
                                        dbHelper.GetParameter("@SortID", SortID),
                                        dbHelper.GetParameter("@Content", Content),
                                        dbHelper.GetParameter("@brand", brand),
                                        dbHelper.GetParameter("@ID", ID)
                                    };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Operation_Update", paras);
       }

       public int Delete(string ID)
       {
           IDataParameter[] paras = {
                                        dbHelper.GetParameter("@ID", ID)
                                    };

           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Operation_Delete", paras);
       }


    }
}
