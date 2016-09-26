using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer.User
{
    public class SECU_OBJDAL:DataBase
    {
        public DataSet selectUserObj(string gh)
        {
            string sql = @"select secu_OBJ.ID as OBJ_ID,User_AUTHORITY.MODEL_ID,User_AUTHORITY.OPT_ID ,secu_operation.OPT_DM,secu_Model.url,secu_Model.DM as ModelDM
from User_AUTHORITY,secu_Model ,secu_OBJ,secu_operation
where User_AUTHORITY.gh=@gh and User_AUTHORITY.MODEL_ID=secu_Model.ID  and secu_OBJ.ID=secu_Model.SECUID and User_AUTHORITY.OPT_ID=secu_operation.ID and User_AUTHORITY.SUBSYS='" + Common.rjsystem + @"'
union 
select secu_OBJ.ID as OBJ_ID,SECU_INFO.MODEL_ID,SECU_INFO.OPT_ID ,secu_operation.OPT_DM,secu_Model.url,secu_Model.DM as ModelDM
from SECU_INFO,secu_OBJ,SECU_GROUPPING,secu_Model,secu_operation
where SECU_GROUPPING.gh=@gh and SECU_INFO.SECU_GROUP_ID=SECU_GROUPPING.GROUP_ID and SECU_INFO.MODEL_ID=secu_Model.ID and  secu_OBJ.ID=secu_Model.SECUID and SECU_INFO.OPT_ID=secu_operation.ID and SECU_INFO.SUBSYS='" + Common.rjsystem + "'";

            
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@gh", SqlStr(gh))
            };
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }


        public string selectObjIDbyUrl(string Url)
        {
            string sql = @"select secu_Model.SECUID as OBJ_ID
from secu_Model
where URL like '%'||@Url||'%'";

            IDataParameter[] paras = {
	            dbHelper.GetParameter("@Url", Url)
            };
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

            if (0 == ds.Tables.Count)
                return "";
            return ds.Tables[0].Rows[0][0].ToString();
        }

//        public DataSet selectFObjBySubAndGh(string gh,string subsystem)
//        {
//            string sql = @"select * from (select secu_OBJ.*
//from User_AUTHORITY,secu_Model ,secu_OBJ,secu_operation
//where User_AUTHORITY.gh=@gh and User_AUTHORITY.MODEL_ID=secu_Model.ID  and secu_OBJ.ID=secu_Model.SECUID and secu_OBJ.SUBSYS=@subsystem and secu_OBJ.PARENT_ID is null
//union 
//select secu_OBJ.*
//from SECU_INFO,secu_OBJ,SECU_GROUPPING,secu_Model,secu_operation
//where SECU_GROUPPING.gh=@gh and SECU_INFO.SECU_GROUP_ID=SECU_GROUPPING.GROUP_ID and SECU_INFO.MODEL_ID=secu_Model.ID and  secu_OBJ.ID=secu_Model.SECUID and secu_OBJ.SUBSYS=@subsystem and secu_OBJ.PARENT_ID is null) order by ORDER_ID";
            
//            IDataParameter[] paras = {
//                dbHelper.GetParameter("@gh", gh),
//                dbHelper.GetParameter("@subsystem", subsystem)
//            };
//            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

//            if (0 == ds.Tables.Count)
//                ds.Tables.Add(new DataTable());
//            return ds;
//        }

        #region
        public DataSet selectFObjBySubAndGh(string gh, string subsystem)
        {
            string sql = @"select * from (select secu_OBJ.*
from User_AUTHORITY,secu_Model ,secu_OBJ,secu_operation
where User_AUTHORITY.gh=@gh and User_AUTHORITY.MODEL_ID=secu_Model.ID  and secu_OBJ.ID=secu_Model.SECUID and secu_OBJ.SUBSYS=@subsystem and secu_OBJ.PARENT_ID ='" + Common.rjBase + @"'
union 
select secu_OBJ.*
from SECU_INFO,secu_OBJ,SECU_GROUPPING,secu_Model,secu_operation
where SECU_GROUPPING.gh=@gh and SECU_INFO.SECU_GROUP_ID=SECU_GROUPPING.GROUP_ID and SECU_INFO.MODEL_ID=secu_Model.ID and  secu_OBJ.ID=secu_Model.SECUID and secu_OBJ.SUBSYS=@subsystem and secu_OBJ.PARENT_ID ='" + Common.rjBase + "') order by ORDER_ID";

            IDataParameter[] paras = {
                dbHelper.GetParameter("@gh", gh),
                dbHelper.GetParameter("@subsystem", subsystem)
            };
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
#endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gh"></param>
        /// <param name="subsystem"></param>
        /// <param name="PARENT_ID"></param>
        /// <returns></returns>

        public DataSet selectSObjByPIDSubAndGh(string gh, string subsystem, string PARENT_ID)
        {

            string sql = @"select * from (select secu_OBJ.*
from User_AUTHORITY,secu_Model ,secu_OBJ,secu_operation
where User_AUTHORITY.gh=@gh and User_AUTHORITY.MODEL_ID=secu_Model.ID  and secu_OBJ.ID=secu_Model.SECUID and secu_OBJ.SUBSYS=@subsystem and PARENT_ID=@PARENT_ID
union 
select secu_OBJ.*
from SECU_INFO,secu_OBJ,SECU_GROUPPING,secu_Model,secu_operation
where SECU_GROUPPING.gh=@gh and SECU_INFO.SECU_GROUP_ID=SECU_GROUPPING.GROUP_ID and SECU_INFO.MODEL_ID=secu_Model.ID and  secu_OBJ.ID=secu_Model.SECUID and secu_OBJ.SUBSYS=@subsystem and PARENT_ID=@PARENT_ID) order by ORDER_ID";
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@gh", gh),
	            dbHelper.GetParameter("@subsystem", subsystem),
	            dbHelper.GetParameter("@PARENT_ID", PARENT_ID)
            };
            DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
       
    }
}
