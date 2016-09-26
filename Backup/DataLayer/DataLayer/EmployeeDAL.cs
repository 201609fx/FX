using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class EmployeeDAL:DataBaseClass
    {
        public DataSet SelectByCertNO(string CertType, string CertName, string certNO, string Name)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@CertType", CertType),
                                         dbHelper.GetParameter("@CertName", CertName),
                                         dbHelper.GetParameter("@Name", Name),
                                         dbHelper.GetParameter("@certNO", certNO)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "employee_SelectByCertNO", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet SelectByMainSCID(string MainSCID,int Type)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@MainSCID", MainSCID),
                                         dbHelper.GetParameter("@Type", Type)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "employee_SelectByMainSCID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        } 
        public int Update(string Name, string educational, string Eposition, string certNO, string CertType,string certName, string remark, string ID)
        {
	                IDataParameter[] paras = {
	                dbHelper.GetParameter("@Name", Name),
	                dbHelper.GetParameter("@educational", educational),
	                dbHelper.GetParameter("@Eposition", Eposition),
	            dbHelper.GetParameter("@certName", certName),
	                dbHelper.GetParameter("@CertType", CertType),
	                dbHelper.GetParameter("@certNO", certNO),
	                dbHelper.GetParameter("@remark", remark),
	                dbHelper.GetParameter("@ID", ID)
                };

        	
	        return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "employee_Update", paras);
        }
        public int Insert(string Name, string educational, string Eposition, string certNO, string certName, string CertType, string remark, string Type, string MainSCID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Name", Name),
	            dbHelper.GetParameter("@educational", educational),
	            dbHelper.GetParameter("@Eposition", Eposition),
	                dbHelper.GetParameter("@CertType", CertType),
	            dbHelper.GetParameter("@certName", certName),
	            dbHelper.GetParameter("@certNO", certNO),
	            dbHelper.GetParameter("@remark", remark),
	            dbHelper.GetParameter("@Type", Type),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "employee_Insert", paras);
        }
        public int Delete(string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };

            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "employee_Delete", paras);
        }

    }
}
