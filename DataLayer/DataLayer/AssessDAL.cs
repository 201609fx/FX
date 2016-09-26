using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
   public  class AssessDAL:DataBaseClass
    {
        public DataSet Select(string MainSCID, string assessPlateID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@assessPlateID", assessPlateID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "assess_SelectByMIDandAPID", paras);

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


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "assess_SelectByID", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }

       public int Update(string PSUserName, DateTime PSTime, string ID)
       {
           object dt = PSTime.Ticks == 0 ? DBNull.Value : (object) PSTime;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@PSUserName", PSUserName),
	            dbHelper.GetParameter("@PSTime", dt),
	            dbHelper.GetParameter("@ID", ID)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assess_Update", paras);
       }

       public int Insert(string MainSCID, string assessPlateID, string UserName)
       {
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@assessPlateID", assessPlateID),
	            dbHelper.GetParameter("@UserName", UserName)
            };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assess_Insert", paras);
       }
       public int delete(string assessID)
       {
           IDataParameter[] paras = {
                                        dbHelper.GetParameter("@AssessID", assessID)
                                    };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assess_Delete", paras);
       }
       public int UpdateTotle(string MainSCID, string assessPlateID)
       {
           IDataParameter[] paras = {
	        dbHelper.GetParameter("@MainSCID", MainSCID),
	        dbHelper.GetParameter("@assessPlateID", assessPlateID)
        };


           return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "assess_UpdateTotle", paras);
       }
       public DataSet SelectCertNO(string MainSCID)
       {
           DataSet ds;
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


           ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "assess_SelectCertNO", paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }


    }
}
