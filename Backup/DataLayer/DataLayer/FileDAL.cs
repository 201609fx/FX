using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SZMA.DataLayer
{
    public class FIleDAL : DataBaseClass
    {

        /// <summary>
        /// 添加附件（插入关系表）
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="FileFormat"></param>
        /// <param name="FileUrl"></param>
        /// <param name="Username"></param>
        /// <param name="FileSortID"></param>
        /// <param name="MainID"></param>
        /// <returns></returns>
        public int File_Insert(string Name, string FileFormat, string FileUrl, string Username, int FileSortID, int MainID)
        {
            IDataParameter[] paras = {
										 dbHelper.GetParameter("@Name", Name),
										 dbHelper.GetParameter("@FileFormat", FileFormat),
										 dbHelper.GetParameter("@FileUrl", FileUrl),
										 dbHelper.GetParameter("@Username", Username),
										 dbHelper.GetParameter("@FileSortID", FileSortID),
										 dbHelper.GetParameter("@MainID", MainID)
									 };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "File_Insert", paras);
        }




        /// <summary>
        /// 更新文件信息（小图片）
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="FileFormat"></param>
        /// <param name="FileUrl"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int File_Update(string Name, string FileFormat, string FileUrl, Int64 ID)
        {
            IDataParameter[] paras = {
										 dbHelper.GetParameter("@Name", Name),
										 dbHelper.GetParameter("@FileFormat", FileFormat),
										 dbHelper.GetParameter("@FileUrl", FileUrl),
										 dbHelper.GetParameter("@ID", ID)
									 };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "File_Update", paras);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int File_Delete(Int64 ID)
        {
            IDataParameter[] paras = {
										 dbHelper.GetParameter("@ID", ID)
									 };

            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "File_Delete", paras);
        }
    }
}
