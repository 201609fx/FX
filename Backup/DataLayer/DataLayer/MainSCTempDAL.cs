using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace SZMA.DataLayer
{
    public class MainSCTempDAL : DataBaseClass
    {
        public DataSet  Insert()
        {
            return dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "MainSCTemp_InsertNull");
        }
        public int Update(string AreaID, string Company, string address, string code, string contact, string phone, string mobile, string fax, string frdb, string ftel, string area, string Anum, string Mnum, string Bnum,  int Type, string summary, DateTime CreateTime, int InsertFlag, string state, string oldCertNO, string newCertNO, string ID)
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
	            dbHelper.GetParameter("@CreateTime", CreateTime),
	            dbHelper.GetParameter("@InsertFlag", InsertFlag),
	            dbHelper.GetParameter("@state", state),
	            dbHelper.GetParameter("@oldCertNO", oldCertNO),
	            dbHelper.GetParameter("@newCertNO", newCertNO),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "MainSCTemp_Update", paras);
        }

    }
    
    
}
