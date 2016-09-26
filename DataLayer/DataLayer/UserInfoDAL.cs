using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SZMA.DataLayer
{
    public class UserInfoDAL:DataBaseClass
    {
        public DataSet SelectByID(string ID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ID", ID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "UserInfo_SelectByID", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public DataSet SelectByUserName(string UserName)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@UserName", UserName)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "UserInfo_SelectByUserName", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }

        public int Update(string UserName,  string RealName, string UserGroupID, string IsAvailible,string CheckUser,string ID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@RealName", RealName),
	            dbHelper.GetParameter("@UserGroupID", UserGroupID),
	            dbHelper.GetParameter("@IsAvailible", IsAvailible),
	            dbHelper.GetParameter("@CheckUser", CheckUser),
	            dbHelper.GetParameter("@ID", ID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UserInfo_UpdatebyID", paras);
        }

        public int Update(string RealName, DateTime ModifiTime, string CheckUser, string UserName)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@RealName", RealName),
	            dbHelper.GetParameter("@ModifiTime", ModifiTime),
	            dbHelper.GetParameter("@CheckUser", CheckUser),
	            dbHelper.GetParameter("@UserName", UserName)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UserInfo_Update", paras);
        }
        public int Update(DateTime ModifiTime, string CheckUser,  string taskID, string ID)
        {
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@ModifiTime", ModifiTime),
                                         dbHelper.GetParameter("@CheckUser", CheckUser),
                                         dbHelper.GetParameter("@taskID", taskID),
                                         dbHelper.GetParameter("@ID", ID)
                                     };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UserInfo_UpdateTaskID", paras);
        }


        public int Insert(string UserName,string RealName, string CheckUser)
        {
            string sql = @"insert into UserInfo(UserName,UserGroupID,RealName,CheckUser,IsAvailible,ActiveID,Status,RegistTime,ModifiTime) 
            values(@UserName,2,@RealName,@CheckUser,1,1,1,getdate(),getdate())";
            IDataParameter[] paras = {
                                         dbHelper.GetParameter("@UserName", UserName),
                                         dbHelper.GetParameter("@RealName", RealName),
                                         dbHelper.GetParameter("@CheckUser", CheckUser)
                                     };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, paras);
        }
    }
}
