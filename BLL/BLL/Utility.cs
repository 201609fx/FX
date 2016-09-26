using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SZMA.BLL
{
    /// <summary>
    /// Utility ��ժҪ˵����
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
                        return "<font color=\"#ff0033\"  style=\"font-size:12px ; \" >�ѹ���</font>";
                    }
                    else
                    {
                        return "<font color=\"#009900\" style=\"font-size:12px ;\">��Ч</font>"; 
                    }
                    break;
                case"2":
                    return "<font color=\"#ff0033\" style=\"font-size:12px ; \">�ѳ���</font>";
                    break;
                default:
                    if (dt.AddDays(1) < DateTime.Now)
                    {
                        return "<font color=\"#ff0033\"  style=\"font-size:12px ; \" >�ѹ���</font>";
                    }
                    else
                    {
                        return "<font color=\"#009900\" style=\"font-size:12px ;\">��Ч</font>";
                    }
                    break;
            }
      
        }
        /// <summary>
        /// ת��HTML���룬��������ת��Ϊ&lt;��ʽ
        /// </summary>
        /// <param name="exp1">Ҫת�����ַ���</param>
        /// <returns>���ع��˺���ַ���</returns>
        public static String Deal(string exp1)
        {
            String exp2;
            exp2 = exp1.Replace("<", "&lt;");
            exp2 = exp2.Replace(">", "&gt;");
            exp2 = exp2.Replace("'", "''");
            exp2 = exp2.Replace("\"", "\\\"");
            exp2 = exp2.Replace("  ", "��");
            exp2 = exp2.Replace("\n", "<br>");
            exp2 = exp2.Replace("\r", "");
            return exp2;
        }

        /// <summary>
        /// ���˽ű��ַ�
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
        /// ת��HTML���룬��������ת��Ϊ&lt;��ʽ������ת�����з�
        /// </summary>
        /// <param name="exp1">Ҫת�����ַ���</param>
        /// <returns></returns>
        public static string DealNoReturn(string exp1)
        {
            string exp2;
            exp2 = exp1.Replace("<", "&lt;");
            exp2 = exp2.Replace(">", "&gt;");
            exp2 = exp2.Replace("'", "''");
            exp2 = exp2.Replace("  ", "��");
            return exp2;
        }

        /// <summary>
        /// ����SQL����
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string SqlStr(string sql)
        {
            string trimStr = String.Concat(@"\<|\>|&|\r|\n|\'|\x5c|~|\$|\@|`|!|\*|%|;|\x5f");
            return Regex.Replace(sql, trimStr, "");
        }

        /// <summary>
        /// �ж��Ƿ�ΪEmail
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// ת��Ϊint���粻��ת������0
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
        /// ת��Ϊdecimal���粻��ת������0
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
        /// ת��Ϊ������λС���Ļ���
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
        /// ת��Ϊ����
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
        /// ȡ�ַ���ǰlengthλ�ַ������Ƿ���ĩβ��ʡ�Ժ�
        /// </summary>
        /// <param name="src"></param>
        /// <param name="length"></param>
        /// <param name="addDots">�Ƿ��ʡ�Ժ�</param>
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
        /// ת��ΪDateTime
        /// </summary>
        /// <param name="src"></param>
        /// <returns>ת�����DateTime���粻��ת������DateTime.MinValue</returns>
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
        /// ��ip���һ��ת��Ϊ*
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
        /// �������˴���
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
        /// ֻ����'
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
