using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Security;
using SZMA.DataLayer;

namespace SZMA.Core.Client
{
    public class BasePageByPage : System.Web.UI.Page
    {

        ClientUser clientuser;
        /// <summary>
        /// Constructor
        /// </summary>
        public BasePageByPage()
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



        public string PageTitle
        {
            set { Context.Items["ClientPageTitle"] = ConfigurationManager.AppSettings["SiteName"] + "_" + value; }
        }
        
        private void PageBase_Init(object sender, EventArgs e)
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
        public string  getLeft(string str,int length,bool Flag)
        {
            string rtn = "";
            if (str.Length > length)
            {
                rtn = str.Substring(0, length);
                if (Flag)
                    rtn += "...";
            }
            else
            {
                rtn = str;
            }
            return rtn;
        }

        public string getMainNO(string mid, string tid)
        {
            return "(" + (tid == "2" ? "��" : "��") + ")" + mid.PadLeft(5, '0');
        }
        public string getNoteNum(string MID)
        {
            int recc;

            DataSet dsNote = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'", out recc);
            if (recc > 0 && null != dsNote.Tables[0].Rows[0]["NoteNum"] && dsNote.Tables[0].Rows[0]["NoteNum"].ToString() != "")
            {
                return dsNote.Tables[0].Rows[0]["NoteNum"].ToString();
            }
            DataSet ds = Common.Pager("certDict", "C_Value", "ID", 100, 1, true, "ID=2", out recc);
            string rtn = "��¼" + DateTime.Now.ToString("yyMM") + "-" + ds.Tables[0].Rows[0][0].ToString().PadLeft(5, '0');
            ///�������ɵļ�¼�ŵ����ݿ�
            Common.Update("MainSCTemp", "ID", MID, new string[] { "NoteNum" }, new string[] { rtn });
            CertDictDAL obj = new CertDictDAL();
            ///�Ѽ�¼��ˮ�ż�����һ
            obj.Add("2");
            return rtn;
        }
        public string getState(string state)
        {//0Ϊ���룻1Ϊ����2Ϊ����3Ϊ���ۣ�4Ϊ֪ͨ��5Ϊ����֤
            string rtn = "";
            switch (state)
            {
                case "0":
                    rtn = "����";
                    break;
                case "1":
                    rtn = "����";
                    break;
                case "11":
                    rtn = "����δͨ��";
                    break;
                case "12":
                    rtn = "����ͨ��";
                    break;
                case "2":
                    rtn = "����";
                    break;
                case "3":
                    rtn = "����";
                    break;
                case "4":
                    rtn = "֪ͨ";
                    break;
                case "5":
                    rtn = "������";
                    break;
                case "6":
                    rtn = "����֤";
                    break;
                case "7":
                    rtn = "����δͨ��";
                    break;
                default:
                    break;
            }
            return rtn;
        }
        protected DateTime getDate(string dt)
        {
            DateTime rtn = new DateTime(0);
            try
            {
                rtn = DateTime.Parse(dt);
            }
            catch
            {
            }
            return rtn;
        }

        protected string getTime(string DS)
        {
            string rtn = "";
            try
            {
                rtn = DateTime.Parse(DS).ToString("yyyy/MM/dd");
            }
            catch
            {
            }
            return rtn;
        }
        public string getLevel(string CertNO)
        {
            string str = CertNO.Substring(CertNO.Length - 1, 1);
            string rtn = "";
            switch (str.ToLower())
            {
                case "a":
                    rtn = "һ��";
                    break;
                case "b":
                    rtn = "����";
                    break;
                case "c":
                    rtn = "����";
                    break;
                default:
                    rtn = "δ֪�ȼ�";
                    break;
            }
            return rtn;
        }

        public string removeHtml(string str)
        {
            string rtn = str;
            while (rtn.IndexOf("<") > -1 && rtn.IndexOf(">") > rtn.IndexOf("<"))
            {
                rtn = rtn.Remove(rtn.IndexOf("<"), rtn.IndexOf(">") - rtn.IndexOf("<"));
            }
            return rtn;
        }

        #region //�����Ի���
        public bool OpenWindow(string Height, string Width, string Top, string Left, string WindowName, string Url)
        {
            try
            {
                string str = "<script language='javascript'>window.open( '" + Url + "', '" + WindowName + "', 'width=" + Width + @",height=" + Height + @",scrollbars=yes,left=" + Left + @",top=" + Top + ",resizable=yes');</script>";
                this.Response.Write(str);
                return true;
            }
            catch
            {
            }
            return false;
        }
        #endregion
    }
}
