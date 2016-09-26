using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer.User
{
    public class TXW_CYDADAL:DataBase
    {
        public DataSet selectAll( string subsystem)
        {
            string sql = "select txw_cyda.* from txw_cyda, secu_groupping where secu_groupping.GROUP_ID" +
                    " in (select distinct SECU_INFO.SECU_GROUP_ID from secu_info where subsys=@subsystem) and txw_cyda.GH=secu_groupping.GH ";
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@subsystem", subsystem)
            };
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public DataSet selectByGH(string GH)
        {
            string sql = "select * from TXW_CYDA where GH=@GH  ";
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@GH", GH)
            };
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
