using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class MainSCDAL:DataBaseClass
    {
        public int Insert(string MainSCID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "MainSC_Insert", paras);
        }
        public DataSet Select(string MainSCID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "MainSC_Select1", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public DataSet SelectAll(string strWhere)
        {
            string sql = "SELECT a.*,(SELECT ID FROM MainSCTemp WHERE (ID = a.MainSCID)) AS MainSCTempID FROM  MainSC AS a INNER JOIN cert AS b ON a.MainSCID = b.MainSCID WHERE " + strWhere + "";
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql);
            return ds;
        }

        public DataSet SelectBYCertNO(string CertNO)
        {
            DataSet ds;
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@CertNO", CertNO)
                                     };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "MainSC_SelectByCertNO", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        
        public int Update(string LZR, string MainSCID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@LZR", LZR),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "MainSC_Update", paras);
        }

        public int Update(string AreaID, string Company, string address, string code, string contact, string phone, string mobile, string fax, string frdb, string ftel, string area, string Anum, string Mnum, string Bnum, int Type, string summary, int InsertFlag, string state, string oldCertNO, string newCertNO, string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@AreaID", AreaID),
	            dbHelper.GetParameter("@Company", Company),
	            dbHelper.GetParameter("@address", address),
	            dbHelper.GetParameter("@code", code),
	            dbHelper.GetParameter("@contact", contact),
	            dbHelper.GetParameter("@phone", phone),
	            dbHelper.GetParameter("@mobile", mobile),
	            dbHelper.GetParameter("@fax", fax),
	            dbHelper.GetParameter("@frdb", frdb),
	            dbHelper.GetParameter("@ftel", ftel),
	            dbHelper.GetParameter("@area", area),
	            dbHelper.GetParameter("@Anum", Anum),
	            dbHelper.GetParameter("@Mnum", Mnum),
	            dbHelper.GetParameter("@Bnum", Bnum),
	            dbHelper.GetParameter("@Type", Type),
	            dbHelper.GetParameter("@summary", summary),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            dbHelper.GetParameter("@state", state),
	            dbHelper.GetParameter("@oldCertNO", oldCertNO),
	            dbHelper.GetParameter("@newCertNO", newCertNO),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "MainSC_UpdateAll", paras);
        }


    }
}
