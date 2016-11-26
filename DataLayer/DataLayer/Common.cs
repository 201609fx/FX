using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;
using SZMA.BLL;

namespace SZMA.DataLayer
{
	/// <summary>
	/// Common 的摘要说明。
	/// </summary>
	public class Common : DataBaseClass
	{
		public Common()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


        public static string opt_see = "1";
        public static string opt_ma = "2";

        public static string rjBase = "m_rjwx";
        public static string rjsystem = "rjwx";
		///<summary>
		/// 说明：通用Select方法
		/// </summary>
		///@tblName varchar(255),-- 表名
		///@fldName varchar(255),-- 字段名
		///@PageSize int         -- 页尺寸
		///@PageIndex int        -- 页码
		///@OrderType bit        -- 设置排序类型, 非 0 值则降序
		///@strWhere     varchar(1000)
		/// <returns>
		///通用Select方法，返回类型为DataSet
		/// </returns>
		public static DataSet SelectByPager(string tblName, string fldName, int PageSize, int PageIndex, int OrderType, string strWhere)
		{
			DataSet ds;
            strWhere = System.Text.RegularExpressions.Regex.Replace(strWhere, "exec|declare", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			IDataParameter[] paras = {
										dbHelper.GetParameter("@tblName", tblName),
										dbHelper.GetParameter("@fldName", fldName),
										dbHelper.GetParameter("@PageSize", PageSize),
										dbHelper.GetParameter("@PageIndex", PageIndex),
										dbHelper.GetParameter("@OrderType", OrderType),
										dbHelper.GetParameter("@strWhere", strWhere)
									 };

		
			ds = dbHelper.ExecuteDataset(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Pager" , paras);

			if(0 == ds.Tables.Count)
				ds.Tables.Add(new DataTable());
			return ds;
		}

        /// <summary>
        /// 直接传入SQL返回ds
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static DataSet SelectByPager(string sqlStr)
        {
            DataSet ds;

            ds = dbHelper.ExecuteDataset(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, sqlStr, null);

            return ds;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="Fields"></param>
		/// <param name="keyField"></param>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="order"></param>
		/// <param name="condition"></param>
		/// <param name="recc"></param>
		/// <returns></returns>
		public static DataSet Pager(string tableName, string Fields, string keyField, int pageSize, int pageIndex, bool order, string condition, out int recc)
		{
			DataSet ds;
            condition = System.Text.RegularExpressions.Regex.Replace(condition, "exec|declare", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        
			IDataParameter[] paras = {
												 dbHelper.GetParameter("@tblName", tableName),
												 dbHelper.GetParameter("@strGetFields", Fields),
												 dbHelper.GetParameter("@fldName", keyField),
												 dbHelper.GetParameter("@PageSize", pageSize),
												 dbHelper.GetParameter("@PageIndex", pageIndex),
												 dbHelper.GetParameter("@OrderType", order),
												 dbHelper.GetParameter("@strWhere", condition)
											 };
            ds = dbHelper.ExecuteDataset(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Pager", paras);
			recc = int.Parse(ds.Tables[1].Rows[0][0].ToString());
			if(0 == ds.Tables.Count)
				ds.Tables.Add(new DataTable());
			return ds;
		}

		
		public static DataSet SelectByPager(string tableName, string Field,string keyField, string condition, bool order, int pageIndex, int pageSize, out int totalRecord)
		{
			DataSet ds;

            condition = System.Text.RegularExpressions.Regex.Replace(condition, "exec|declare", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			SqlParameter[] paras = {
									   new SqlParameter("@tblName", SqlDbType.VarChar, 255),
									   new SqlParameter("@fldName", SqlDbType.VarChar, 255),
									   new SqlParameter("@PageSize", SqlDbType.Int),
									   new SqlParameter("@PageIndex", SqlDbType.Int),
									   new SqlParameter("@OrderType", SqlDbType.Bit),
									   new SqlParameter("@strWhere", SqlDbType.NVarChar, 4000),
									   new SqlParameter("@strGetFields", SqlDbType.VarChar, 255)
								   };

			paras[0].Value = tableName;
			paras[1].Value = keyField;
			paras[2].Value = pageSize;
			paras[3].Value = pageIndex;
			paras[4].Value = order;
			paras[5].Value = condition;
			paras[6].Value = Field;

			ds = dbHelper.ExecuteDataset(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Pager" , paras);
			totalRecord = int.Parse(ds.Tables[1].Rows[0][0].ToString());
			if(0 == ds.Tables.Count)
				ds.Tables.Add(new DataTable());
			return ds;
		}
		
		public static DataSet SelectByPager(string tableName, string keyField, string condition, bool order, int pageIndex, int pageSize, out int totalRecord)
		{
			return SelectByPager( tableName, "*", keyField, condition, order, pageIndex, pageSize, out totalRecord);
		}

		/// <summary>
		/// 新增的公共方法--无排序行
		/// 1。表需要有InsertFlag字段，默认0为显示
		/// 2。表需要有CreateTime字段，默认为getdate()
		/// </summary>
		/// <param name="TableName">表名</param>
		/// <param name="InsertFlag">插入标志:0为有效1为无效</param>
		/// <param name="CreateTime">创建时间</param>
		/// <returns>插入行@@IDENTITY</returns>
		static public string Insert(string TableName,string InsertFlag,string CreateTime)
		{
			return Insert(TableName,InsertFlag,CreateTime,"","");
		}

		/// <summary>
		/// 新增的公共方法--有排序行
		/// 1。表需要有InsertFlag字段，默认0为显示
		/// 2。表需要有CreateTime字段，默认为getdate()
		/// </summary>
		/// <param name="TableName">表名</param>
		/// <param name="InsertFlag">插入标志</param>
		/// <param name="CreateTime">创建时间</param>
		/// <param name="RowRank">排序标志</param>
		/// <param name="ID">主键名称</param>
		/// <returns>插入行@@IDENTITY</returns>
		static public string Insert(string TableName,string InsertFlag,string CreateTime,string RowRank,string ID)
		{
			DataSet ds;

			SqlParameter[] paras = {
									   new SqlParameter("@TableName", SqlDbType.NVarChar, 50),
									   new SqlParameter("@InsertFlag", SqlDbType.NVarChar, 50),
									   new SqlParameter("@CreateTime", SqlDbType.NVarChar, 50),
									   new SqlParameter("@RowRank", SqlDbType.NVarChar, 50),
									   new SqlParameter("@ID", SqlDbType.NVarChar, 50),
			};

			paras[0].Value = TableName;
			paras[1].Value = InsertFlag;
			paras[2].Value = CreateTime;
			paras[3].Value = RowRank;
			paras[4].Value = ID;

			ds = dbHelper.ExecuteDataset(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Public_Insert" , paras);
			return ds.Tables[0].Rows[0][0].ToString();
		}

		/// <summary>
		/// 删除某行数据
		/// </summary>
		/// <param name="TableName">表名</param>
		/// <param name="IDName">主键名</param>
		/// <param name="ID">主键ID</param>
		/// <returns></returns>
		static public bool Delete(string TableName,string IDName,string ID) 
		{
			SqlParameter[] paras = {
									   new SqlParameter("@TableName", SqlDbType.NVarChar, 50),
									   new SqlParameter("@IDName", SqlDbType.NVarChar, 50),
									   new SqlParameter("@ID", SqlDbType.NVarChar, 50),
			};

			paras[0].Value = TableName;
			paras[1].Value = IDName;
			paras[2].Value = ID;

			return (int)dbHelper.ExecuteScalar(ConfigurationManager.AppSettings["ConnectionString"],"Public_Delete",paras)!=0;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="MyKey">表唯一键</param>
		/// <param name="MyKeyValue">表唯一键值</param>
		/// <param name="TableName">数据库表名</param>
		/// <param name="MyColumns">数据库列名</param>
		/// <param name="MyValues">TextBox.Text(Values)</param>
		/// <returns></returns>
		static public bool Update(string TableName, string MyKey, string MyKeyValue, string[] MyColumns, string[] MyValues)
		{
			bool bResult = false;
			//检查输入数组符合条件
			if (MyColumns.Length == MyValues.Length && MyColumns.Length != 0)
			{
				StringBuilder strSql = new StringBuilder(500);
				strSql.Append("Update ").Append(TableName).Append(" Set ");
				//对输入进行SQL检查
				MyValues = Utility.EncodeAll(MyValues);
				//声称SQL语句
				for (int i = 0; i < MyColumns.Length; i++)
				{
					strSql.Append(MyColumns[i]).Append("='").Append(MyValues[i]).Append("',");
				}
				strSql.Remove(strSql.Length-1,1);

				strSql.Append(" Where ").Append(MyKey).Append("='").Append(MyKeyValue).Append("'");

				try
				{
					dbHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, strSql.ToString());
					bResult = true;
				}
				catch (Exception e)
				{
					throw new Exception(e.Message);
				}
			}
			return bResult;
		}

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="MyKey">表唯一键</param>
        /// <param name="MyKeyValue">表唯一键值</param>
        /// <param name="TableName">数据库表名</param>
        /// <param name="MyColumns">数据库列名</param>
        /// <param name="MyValues">TextBox.Text(Values)</param>
        /// <returns></returns>
        static public int UpdateByInt(string TableName, string MyKey, string MyKeyValue, string[] MyColumns, string[] MyValues)
        {
            int bResult = 0;
            //检查输入数组符合条件
            if (MyColumns.Length == MyValues.Length && MyColumns.Length != 0)
            {
                StringBuilder strSql = new StringBuilder(500);
                strSql.Append("Update ").Append(TableName).Append(" Set ");
                //对输入进行SQL检查
                MyValues = Utility.EncodeAll(MyValues);
                //声称SQL语句
                for (int i = 0; i < MyColumns.Length; i++)
                {
                    strSql.Append(MyColumns[i]).Append("='").Append(MyValues[i]).Append("',");
                }
                strSql.Remove(strSql.Length - 1, 1);

                strSql.Append(" Where ").Append(MyKey).Append("='").Append(MyKeyValue).Append("'");

                try
                {
                    bResult = dbHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, strSql.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return bResult;
        }
	}
}