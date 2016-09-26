using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer.User
{
   public class SSO_USERINFODAL:DataBase
  {
       public DataSet selectUser(string gh, string ENCRO)
       {
           string sql = "select * from SSO_USERINFO where gh=@gh and ENCRO=@ENCRO and DQYX='Y'";
           IDataParameter[] paras = {
	            dbHelper.GetParameter("@gh", gh),
	            dbHelper.GetParameter("@ENCRO", ENCRO)
            };
           DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

           if (0 == ds.Tables.Count)
               ds.Tables.Add(new DataTable());
           return ds;
       }

       public DataSet selectByGH(string GH)
       {
           string sql = "select * from SSO_UserINFO where GH=@GH and DQYX='Y' ";
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
