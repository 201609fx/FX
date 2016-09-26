using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace SZMA.Core.Client
{
    public class BaseClientPage : System.Web.UI.MasterPage
    {
         ClientUser clientuser;
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseClientPage()
        {
            this.Init += new EventHandler(PageBase_Init);
        } 

        /// <summary>
        /// ��ǰ��½���û�
        /// </summary>
        public ClientUser ClientUser
        {
            get { return clientuser; }
        }

        public void PageBase_Init(object sender, EventArgs e)
        {
            clientuser = new ClientUser();
            FormsAuthenticationTicket ticket;
            string[] str;
            if (Request.IsAuthenticated)
            {
                ticket = ((FormsIdentity)Context.User.Identity).Ticket;
                str = ticket.UserData.Split('|');
                if (str[3].Trim() == "client")
                {
                    clientuser.Username = ticket.Name;
                    clientuser.UserID = str[0];
                    clientuser.RealName = str[1];
                    clientuser.FirmName = str[2];
                    clientuser.SID = Session.SessionID;
                }
                else
                {
                    clientuser.RealName = "�[��";
                    clientuser.Username = "Guest";
                    clientuser.SID = Session.SessionID;
                }
            }
            else
            {
                clientuser.RealName = "�[��";
                clientuser.Username = "Guest";
                clientuser.SID = Session.SessionID;
            }
            HttpContext.Current.Items["UserID"] = clientuser.UserID;
            HttpContext.Current.Items["LoginName"] = clientuser.Username;
            HttpContext.Current.Items["UserName"] = clientuser.RealName;
            HttpContext.Current.Items["UserID"] = clientuser.UserID;
        }


        /// <summary>
        /// ���������û���Ϣ
        /// </summary>
        /// <param name="username"></param>
        /// <param name="act"></param>
        public void UpdateOnline(string username, string act)
        {
            Online online = new Online();
            online.UpdateOnlineUser(Session.SessionID, username, Request.UserHostAddress, act, Request.RawUrl);
        }
       
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncryptMD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            return str;
        }


        #region ��������ת��

        /// <summary>
        /// ���ؿյ�ʱ���Զ���д���ո����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string NullTonbsp(object o)
        {
            string str = o.ToString();
            if (o.ToString().Length < 1)
            {
                str = "&nbsp;";
            }
            else
            {
            }
            return str;
        }

        /// <summary>
        /// �ı����������
        /// </summary>
        /// <param name="Title"></param>

        public void SetTitle(string Title)
        {
            Response.Write("<title>" + Title + "</title>");
        }


        /// <summary>
        /// //��1����"��",0����"��"
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string ConvertBoolToString(object o)
        {
            string str = "";
            try
            {
                if (o.ToString() == "1")
                {
                    str = "��";
                }
                if (o.ToString() == "0")
                {
                    str = "��";
                }
            }
            catch
            {
            }
            return str;
        }



        /// <summary>
        /// //��1����"��",0����"��"
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string FormatEmpty(object o)
        {
            string str = "";
            try
            {
                if (o.ToString().Substring(0, 4) != "1900")
                {
                    str = o.ToString();
                }

            }
            catch
            {
            }
            return str;
        }



        /// <summary>
        /// //��1����"��",0����"��"
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string ConvertBoolToString1(object o)
        {
            string str = "";
            try
            {
                if (o.ToString() == "1")
                {
                    str = "�ϸ�";
                }
                if (o.ToString() == "0")
                {
                    str = "���ϸ�";
                }
            }
            catch
            {
            }
            return str;
        }




        /// <summary>
        /// �����ȴ���25�ı���ضϲ����ʡ�Ժ�
        /// </summary>
        /// <param name="o"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string CutTitle(object o, int length)
        {
            string str = "";
            try
            {
                if (o.ToString().Length > length)
                {
                    str = o.ToString().Substring(0, length) + "����";
                }
                else
                {
                    str = o.ToString();
                }
            }
            catch
            {
            }
            return str;
        }

        /// <summary>
        /// ת��ΪDateTime
        /// </summary>
        /// <param name="src"></param>
        /// <returns>ת�����DateTime���粻��ת������DateTime.MinValue</returns>
        public DateTime StrToDateTime(string src)
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

        #endregion

        #region ���ں�ʱ��ĸ�ʽ����ʾ

        /// <summary>
        /// Formats a datetime value into 07.03.2003 22:32:34
        /// </summary>
        /// <param name="o">The date to be formatted</param>
        /// <returns></returns>
        public string FormatDateTime(object o)
        {
            DateTime dt = (DateTime)o;
            return String.Format("{0:F}", dt);
        }

        /// <summary>
        /// ʱ���ʽ��
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string FormatDateTimeShort(object o)
        {
            DateTime dt = (DateTime)o;
            return String.Format("{0:f}", dt);
        }

        /// <summary>
        /// Formats a datetime value into 7. februar 2003
        /// </summary>
        /// <param name="dt">The date to be formatted</param>
        /// <returns></returns>
        public string FormatDateLong(DateTime dt)
        {
            return String.Format("{0:D}", dt);
        }
        /// <summary>
        ///  Formats a datetime value into 07.03.2003
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>

        public string FormatDateShort(object o)
        {
            if (o.ToString().Length == 0)
            {
                return "";
            }

            DateTime dt = (DateTime)o;
            return String.Format("{0:d}", dt);
        }

        /// <summary>
        /// Formats a datetime value into 22:32:34
        /// </summary>
        /// <param name="dt">The date to be formatted</param>
        /// <returns></returns>
        public string FormatTime(DateTime dt)
        {
            return String.Format("{0:T}", dt);
        }
        #endregion       

        #region �ַ�����ת��

        /// <summary>
        ///   �ַ�ת��Ϊ����
        /// </summary>
        /// <param name="str">Ҫת�����ַ�</param>
        /// <returns>int</returns>
        public int StrToInt(string str)
        {
            int lngResult = 0;
            try
            {
                lngResult = int.Parse(str);
            }
            catch
            {
                lngResult = 0;
            }
            return lngResult;
        }

        /// <summary>
        /// �ַ�ת��Ϊ������
        /// </summary>
        /// <param name="str">Ҫת�����ַ�</param>
        /// <returns>float</returns>
        public float StrToFloat(string str)
        {
            float fResult;
            try
            {
                fResult = float.Parse(str);
            }
            catch
            {
                fResult = 0;
            }
            return fResult;
        }

        /// <summary>
        ///   ����ת��Ϊ�ַ�
        /// </summary>
        /// <returns>string</returns>
        public string IntToStr()
        {
            string str = "";
            try
            {
            }
            catch
            {

            }
            return str;
        }

        /// <summary>
        ///   True��Falseת��λ1��0
        /// </summary>
        /// <returns>int</returns>
        public int BoolToInt(string str)
        {
            int lngResult = 0;
            try
            {
                if (str.Length > 0)
                {
                    if (str.ToLower() == "true")
                    {
                        lngResult = 1;
                    }
                    else if (str.ToLower() == "false")
                    {
                        lngResult = 0;
                    }
                }
            }
            catch
            {
                lngResult = 0;
            }
            return lngResult;
        }

        #endregion

        #region �����Ի���

        /// <summary>
        /// Adds a message that is displayed to the user when the page is loaded.
        /// </summary>
        /// <param name="msg">The message to display</param>
        public void AddLoadMessage(string msg)
        {
            Response.Write("<script language='javascript'>");
            Response.Write("alert('" + msg + "')");
            Response.Write("</script>");
        }
        /// <summary>
        /// �ű���д
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string WriteScript(string str)
        {
            string strScript = "<script language=\"javascript\">\r\n";
            strScript += str + "\r\n";
            strScript += "</script>";
            return strScript;
        }
        /// <summary>
        /// ��ʽ����ʾ��Ϣ
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public string WriteAlert(string Msg)
        {
            Msg = Msg.Replace("'", "\'");
            string strReturn = "<script language=\"javascript\">";
            strReturn += "alert('" + Msg + "')";
            strReturn += "</script>";
            return strReturn;
        }
        /// <summary>
        /// ��ʽ����ʾ��Ϣ
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string WriteAlert(string Msg, string Url)
        {
            Random rand = new Random();
            Msg = Msg.Replace("'", "\'");
            string strRand = rand.Next(100000, 999999).ToString();
            string strReturn = "<script language=\"javascript\">";
            strReturn += "alert('" + Msg + "');";
            if (Url != "")
            {
                if (Url.IndexOf("?") > 0)
                {
                    Url = Url + "&rand=" + strRand;
                }
                else
                {
                    Url = Url + "?rand=" + strRand;
                }
                strReturn += "window.open('" + Url + "','_parent')";
            }
            else
            {
                strReturn += "history.go(-1);";
            }
            strReturn += "</script>";
            return strReturn;
        }
        /// <summary>
        /// ��ʽ����ʾ��Ϣ
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Url"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public string WriteAlert(string Msg, string Url, string Target)
        {
            Random rand = new Random();
            Msg = Msg.Replace("'", "\'");
            string strRand = rand.Next(100000, 999999).ToString();

            string strReturn = "<script language=\"javascript\">";
            strReturn += "alert('" + Msg + "');";
            if (Url != "")
            {
                if (Url.IndexOf("?") > 0)
                {
                    Url = Url + "&rand=" + strRand;
                }
                else
                {
                    Url = Url + "?rand=" + strRand;
                }
                strReturn += "window.open('" + Url + "','" + Target + "')";
            }
            else
            {
                strReturn += "history.go(-1);";
            }
            strReturn += "</script>";
            return strReturn;
        }


        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        /// <param name="name">��Ϣ���ƣ����Ϊempty��ʹ��Guid����</param>
        /// <param name="message">��Ϣ����</param>
        public void ShowAlert(string name, string message)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), name == string.Empty ? Guid.NewGuid().ToString() : name, string.Format("<script language=javascript>alert(\"{0}\")</script>", message));
        } 
        #endregion
    }
}
