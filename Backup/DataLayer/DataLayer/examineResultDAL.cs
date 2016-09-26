using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class examineResultDAL:DataBaseClass
    {
        public int Insert(string MainSCID, string usernames, string UserName)
         {
             IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@usernames", usernames),
            dbHelper.GetParameter("@UserName", UserName)
            };


             return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "examineResult_InsertNull", paras);
         }

        public int Update(string Suggest, string result, string usernames, string member, string leader, string CompanyConfirm, string MainSCID, string UserName)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Suggest", Suggest),
	            dbHelper.GetParameter("@result", result),
	            dbHelper.GetParameter("@usernames", usernames),
	            dbHelper.GetParameter("@member", member),
	            dbHelper.GetParameter("@leader", leader),
                dbHelper.GetParameter("@CompanyConfirm", CompanyConfirm),
	            dbHelper.GetParameter("@MainSCID", MainSCID),
            dbHelper.GetParameter("@UserName", UserName)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "examineResult_Update", paras);
        }
        public DataSet SelectByMID(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };



            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "examineResult_SelectByMID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        
    }
}
