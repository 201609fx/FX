using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using GotDotNet.ApplicationBlocks.Data;
using System.Text.RegularExpressions;

namespace SZMA.DataLayer.User
{
   public class DataBase
    {
        /// <summary>
        /// get the SqlHelper object
        /// </summary>
        public static AdoHelper dbHelper
        {
            get { return new Oracle(); }
        }

       public static string SqlStr2(string sql)
       {
           string trimStr = String.Concat(@"\'|`");
           return Regex.Replace(sql, trimStr, "");
       }
        /// <summary>
        /// 过滤SQL代码
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string SqlStr(string sql)
        {
            string trimStr = String.Concat(@"\<|\>|&|\r|\n|\'|\x5c|~|\$|\@|`|!|\*|%|;|\x5f");
            return Regex.Replace(sql, trimStr, "");
        }

        public object DTCheck(DateTime DT)
        {
            if (DT.Ticks == 0)
                return DBNull.Value;
            else
                return DT;
        }
        public string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["OracleConnectionString"];
    }
}
