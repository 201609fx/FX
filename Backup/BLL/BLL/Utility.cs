using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SZMA.BLL
{
    /// <summary>
    /// Utility 的摘要说明。
    /// </summary>
    public class Utility
    {

        public static string getState(DateTime dt, string CertState)
        {
            switch (CertState)
            {
                case"1":
                    if (dt.AddDays(1) < DateTime.Now)
                    {
                        return "<font color=\"#ff0033\"  style=\"font-size:12px ; \" >已过期</font>";
                    }
                    else
                    {
                        return "<font color=\"#009900\" style=\"font-size:12px ;\">有效</font>"; 
                    }
                    break;
                case"2":
                    return "<font color=\"#ff0033\" style=\"font-size:12px ; \">已撤消</font>";
                    break;
                default:
                    if (dt.AddDays(1) < DateTime.Now)
                    {
                        return "<font color=\"#ff0033\"  style=\"font-size:12px ; \" >已过期</font>";
                    }
                    else
                    {
                        return "<font color=\"#009900\" style=\"font-size:12px ;\">有效</font>";
                    }
                    break;
            }
      
        }
        /// <summary>
        /// 转换HTML代码，将尖括号转换为&lt;形式
        /// </summary>
        /// <param name="exp1">要转换的字符串</param>
        /// <returns>返回过滤后的字符串</returns>
        public static String Deal(string exp1)
        {
            String exp2;
            exp2 = exp1.Replace("<", "&lt;");
            exp2 = exp2.Replace(">", "&gt;");
            exp2 = exp2.Replace("'", "''");
            exp2 = exp2.Replace("\"", "\\\"");
            exp2 = exp2.Replace("  ", "　");
            exp2 = exp2.Replace("\n", "<br>");
            exp2 = exp2.Replace("\r", "");
            return exp2;
        }

        /// <summary>
        /// 过滤脚本字符
        /// </summary>
        /// <param name="exp1"></param>
        /// <returns></returns>
        public static String ScriptStr(string exp1)
        {
            String exp2;
            exp2 = exp1.Replace("'", "''");
            exp2 = exp2.Replace("\"", "\\\"");
            exp2 = exp2.Replace("\\", "\\\\");
            exp2 = exp2.Replace("<br>", "\\n");
            return exp2;
        }

        /// <summary>
        /// 转换HTML代码，将尖括号转换为&lt;形式，但不转换换行符
        /// </summary>
        /// <param name="exp1">要转换的字符串</param>
        /// <returns></returns>
        public static string DealNoReturn(string exp1)
        {
            string exp2;
            exp2 = exp1.Replace("<", "&lt;");
            exp2 = exp2.Replace(">", "&gt;");
            exp2 = exp2.Replace("'", "''");
            exp2 = exp2.Replace("  ", "　");
            return exp2;
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

        /// <summary>
        /// 判断是否为Email
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 转换为int，如不能转换返回0
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int getVal(object src)
        {
            try
            {
                return int.Parse(src.ToString());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为decimal，如不能转换返回0
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static decimal getDecimal(object src)
        {
            try
            {
                return decimal.Parse(src.ToString());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为保留两位小数的货币
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string getMoney(object src)
        {
            string str = "";
            try
            {
                str = decimal.Parse(src.ToString()).ToString("0.00");
            }
            catch
            {
            }

            return str == "0.00" ? "" : str;
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string getDate(object src)
        {
            try
            {
                return DateTime.Parse(src.ToString()).ToShortDateString() == "1900-1-1" ? "" : DateTime.Parse(src.ToString()).ToShortDateString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 取字符串前length位字符，并是否在末尾加省略号
        /// </summary>
        /// <param name="src"></param>
        /// <param name="length"></param>
        /// <param name="addDots">是否加省略号</param>
        /// <returns></returns>
        public static string getLeft(string src, int length, bool addDots)
        {
            if (src.Length > length)
            {
                src = string.Concat(src.Substring(0, length - 1), addDots ? "..." : string.Empty);
            }
            return src;
        }

        /// <summary>
        /// 转换为DateTime
        /// </summary>
        /// <param name="src"></param>
        /// <returns>转换后的DateTime，如不能转换返回DateTime.MinValue</returns>
        public static DateTime getDateTime(string src)
        {
            DateTime d;
            try
            {
                d = DateTime.Parse(src);
            }
            catch
            {
                d = DateTime.MinValue;
            }
            return d;
        }

        /// <summary>
        /// 将ip最后一段转换为*
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string IPStr(string ip)
        {
            return string.Concat(ip.Substring(0, ip.LastIndexOf('.') + 1), "*");
        }

        /// <summary>
        /// delete html tag
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string ClearHtml(string inString)
        {
            return Regex.Replace(inString, @"\<[^\>]*?\>", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 批量过滤代码
        /// </summary>
        /// <param name="MyValues"></param>
        /// <returns></returns>
        public static string[] EncodeAll(string[] MyValues)
        {
            for (int i = 0; i < MyValues.Length; i++)
            {
                MyValues[i] = SqlStr(MyValues[i]);
            }
            return MyValues;
        }

        /// <summary>
        /// 只过滤'
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string SqlStr2(string sql)
        {
            string trimStr = String.Concat(@"\'|`");
            return Regex.Replace(sql, trimStr, "");
        }
    }
}
