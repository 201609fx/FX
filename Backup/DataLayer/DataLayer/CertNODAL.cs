using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class CertNODAL : DataBaseClass
    {
        public int Insert(string MainSCID,  string UserName, DateTime StartTime, DateTime EndTime)
        {
            object objStartTime = StartTime.Ticks == 0 ? DBNull.Value :(object) StartTime;
            object objEndTime = EndTime.Ticks == 0 ? DBNull.Value : (object)EndTime;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@StartTime", objStartTime),
	            dbHelper.GetParameter("@EndTime", objEndTime)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "cert_Insert", paras);
        }

        public int Insert(string MainSCID, string UserName,int InsertFlag)
        {
            string sql = " Insert into cert(MainSCID,UserName,InsertFlag) values(@MainSCID,@UserName,@InsertFlag)";
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, paras);
        }
        public DataSet Select(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	                dbHelper.GetParameter("@MainSCID", MainSCID)
                };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "cert_Select", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet MainSC_SelectBYNEWCertNO(string MainSCID, string certNO)
        {
            DataSet ds;
            IDataParameter[] paras = {
	                dbHelper.GetParameter("@MainSCID", MainSCID),
	                dbHelper.GetParameter("@certNO", certNO)
                };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "MainSC_SelectBYNEWCertNO", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        
        public int Update(string UserName, DateTime StartTime, DateTime EndTime, string MainSCID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@StartTime", StartTime),
	            dbHelper.GetParameter("@EndTime", EndTime),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "cert_Update", paras);
        }

    }
}