using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class OperationMainDAL:DataBaseClass
    {
        public DataSet SelectAll()
        {
            DataSet ds;

            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "OperationMain_SelectAll");

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        
        public DataSet SelectOther(string MainSCID)
        {
            DataSet ds;
            string sql = "select * from OperationMain where MainSCID='" + MainSCID + "' and ProductID='0'";
            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
             public DataSet SelectPruductByMainID(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@MainSCID", MainSCID)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "pruduct_SelectByMainSCID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet SelectByMainID1(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@MainSCID", MainSCID)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "OperationMain_SelectByMainSCID1", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet SelectByMainID2(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@MainSCID", MainSCID)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "OperationMain_SelectByMainSCID2", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet SelectByMainIDMainSC(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@MainSCID", MainSCID)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "OperationMain_SelectByMainSCIDMainSC", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        
        public int Insert(string MainSCID, string ProductID, string UserName, DateTime ModiTime)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@ProductID", ProductID),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ModiTime", ModiTime)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OperationMain_Insert", paras);
        }
        public int Delete(string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };

            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OperationMain_Delete", paras);
        }
        public int Delete(string ID,string busTypeId)
        {
            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, "Delete From OperationMain Where MainSCID='"+ID+"'  and productId='" + busTypeId + "'");
        }

        public int Update(string ProductID, string UserName, DateTime ModiTime, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ProductID", ProductID),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@ModiTime", ModiTime),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OperationMain_Update", paras);
        }


    }
}
