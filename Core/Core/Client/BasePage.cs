using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using SZMA.DataLayer;

namespace SZMA.Core.Client
{
    /// <summary>
    /// Summary description for BasePage.
    /// </summary>
    public class BasePage : UserControl
    {
        ClientUser clientuser;
        /// <summary>
        /// Constructor
        /// </summary>
        public BasePage()
        {
            this.Init += new EventHandler(PageBase_Init);
        } 

        /// <summary>
        /// 当前登陆的用户
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
                    clientuser.RealName = "遊客";
                    clientuser.Username = "Guest";
                    clientuser.SID = Session.SessionID;
                }
            }
            else
            {
                clientuser.RealName = "遊客";
                clientuser.Username = "Guest";
                clientuser.SID = Session.SessionID;
            }
            HttpContext.Current.Items["UserID"] = clientuser.UserID;
            HttpContext.Current.Items["LoginName"] = clientuser.Username;
            HttpContext.Current.Items["UserName"] = clientuser.RealName;
            HttpContext.Current.Items["UserID"] = clientuser.UserID;
        }


        /// <summary>
        /// 更新在线用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="act"></param>
        public void UpdateOnline(string username, string act)
        {
            Online online = new Online();
            online.UpdateOnlineUser(Session.SessionID, username, Request.UserHostAddress, act, Request.RawUrl);
        }
       
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncryptMD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            return str;
        }


        #region 数据类型转换

        /// <summary>
        /// 返回空的时候自动填写表格空格符号
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
        /// 改变浏览器标题
        /// </summary>
        /// <param name="Title"></param>

        public void SetTitle(string Title)
        {
            Response.Write("<title>" + Title + "</title>");
        }


        /// <summary>
        /// //将1换成"是",0换成"否"
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
                    str = "是";
                }
                if (o.ToString() == "0")
                {
                    str = "否";
                }
            }
            catch
            {
            }
            return str;
        }



        /// <summary>
        /// //将1换成"是",0换成"否"
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
        /// //将1换成"是",0换成"否"
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
                    str = "合格";
                }
                if (o.ToString() == "0")
                {
                    str = "不合格";
                }
            }
            catch
            {
            }
            return str;
        }




        /// <summary>
        /// 将长度大于25的标题截断并添加省略号
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
                    str = o.ToString().Substring(0, length) + "……";
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
        /// 转换为DateTime
        /// </summary>
        /// <param name="src"></param>
        /// <returns>转换后的DateTime，如不能转换返回DateTime.MinValue</returns>
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

        #region 日期和时间的格式化显示

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
        /// 时间格式化
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

        #region 字符类型转换

        /// <summary>
        ///   字符转换为数字
        /// </summary>
        /// <param name="str">要转换的字符</param>
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
        /// 字符转换为浮点数
        /// </summary>
        /// <param name="str">要转换的字符</param>
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
        ///   数字转换为字符
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
        ///   True、False转换位1，0
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

        #region 弹出对话框

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
        /// 脚本填写
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
        /// 格式化提示信息
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
        /// 格式化提示信息
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
        /// 格式化提示信息
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
        /// 显示消息
        /// </summary>
        /// <param name="name">消息名称，如果为empty则使用Guid生成</param>
        /// <param name="message">消息内容</param>
        public void ShowAlert(string name, string message)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), name == string.Empty ? Guid.NewGuid().ToString() : name, string.Format("<script language=javascript>alert(\"{0}\")</script>", message));
        } 
        #endregion


        public string getMainNO(string mid, string tid)
        {
            return "(" + (tid == "2" ? "晋" : "申") + ")" + mid.PadLeft(5, '0');
        }
        public string getNoteNum(string MID)
        {
            int recc;

            DataSet dsNote = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'", out recc);
            if (recc > 0 &&null!=dsNote.Tables[0].Rows[0]["NoteNum"]&& dsNote.Tables[0].Rows[0]["NoteNum"].ToString()!="")
            {
                return dsNote.Tables[0].Rows[0]["NoteNum"].ToString();
            }
            DataSet ds = Common.Pager("certDict", "C_Value", "ID", 100, 1, true, "ID=2", out recc);
            string rtn = "记录" + DateTime.Now.ToString("yyMM") + "-" + ds.Tables[0].Rows[0][0].ToString().PadLeft(5, '0');
            ///保存生成的记录号到数据库
            Common.Update("MainSCTemp", "ID", MID, new string[] { "NoteNum" }, new string[] { rtn });
            CertDictDAL obj = new CertDictDAL();
            ///把记录流水号计数加一
            obj.Add("2");
            return rtn;
        }
        public string GetInsertFlag(string InsertFlag)
        {
            string rtn = "";
            //update: status display 11.7
            switch (InsertFlag)
            {
                case "0":
                    rtn = "临时";
                    break;
                case "1":
                    rtn = "网上申请初审";
                    break;
                case "2":
                    rtn = "网上申请初审未通过";
                    break;
                case "3":
                    rtn = "网上申请初审通过";
                    break;
                default:
                    break;
            }
            //switch (InsertFlag)
            //{
            //    case "0":
            //        rtn = "网上申请";
            //        break;
            //    case "1":
            //        rtn = "书面资料审核";
            //        break;
            //    case "11":
            //        rtn = "书面资料审核未通过";
            //        break;
            //    case "12":
            //        rtn = "书面资料审核通过";
            //        break;
            //    case "2":
            //        rtn = "现场评审";
            //        break;
            //    case "3":
            //        rtn = "评审结论";
            //        break;
            //    case "4":
            //        rtn = "处理通知";
            //        break;
            //    case "5":
            //        rtn = "待审批";
            //        break;
            //    case "6":
            //        rtn = "待领证";
            //        break;
            //    case "7":
            //        rtn = "申请未通过";
            //        break;
            //    default:
            //        break;
            //}
            return rtn;
        }
        public string  getIstate(string state,string InsertFlag)
        {
            string rtn = getState(state);
            if (rtn == "" || state=="0")
            {
                rtn = GetInsertFlag(InsertFlag);
            }
            return rtn;
        }
        public string getState(string state)
        {//0为申请；1为初审；2为评审；3为结论；4为通知；5为待领证
            string rtn = "";
            //switch (state)
            //{
            //    case "0":
            //        rtn = "申请";
            //        break;
            //    case "1":
            //        rtn = "初审";
            //        break;
            //    case "11":
            //        rtn = "初审未通过";
            //        break;
            //    case "12":
            //        rtn = "初审通过";
            //        break;
            //    case "2":
            //        rtn = "评审";
            //        break;
            //    case "3":
            //        rtn = "结论";
            //        break;
            //    case "4":
            //        rtn = "通知";
            //        break;
            //    case "5":
            //        rtn = "待审批";
            //        break;
            //    case "6":
            //        rtn = "待领证";
            //        break;
            //    case "7":
            //        rtn = "申请未通过";
            //        break;
            //    default:
            //        break;
            //}
            switch (state)
            {
                case "0":
                    rtn = "网上申请";
                    break;
                case "1":
                    rtn = "书面资料审核";
                    break;
                case "11":
                    rtn = "书面资料审核未通过";
                    break;
                case "12":
                    rtn = "书面资料审核通过";
                    break;
                case "2":
                    rtn = "现场评审";
                    break;
                case "3":
                    rtn = "评审结论";
                    break;
                case "4":
                    rtn = "处理通知";
                    break;
                case "5":
                    rtn = "待审批";
                    break;
                case "6":
                    rtn = "待领证";
                    break;
                case "7":
                    rtn = "申请未通过";
                    break;
                default:
                    break;
            }
            return rtn;
        }
        protected string getno(string text)
        {
            string rtn = "";
            text = text.Replace("记", "").Replace("录", "").Replace("(", "").Replace(")", "");

            text = text.Replace("_", "-").Replace("-", "-").Replace("－", "-");
            if(text.IndexOf("-")<0)
            {
                text = text.Substring(0, 4) + "-" + text.Substring(4);
            }
            text = "记录" + text;
            return text;
        }
          protected string getMainno(string text)
        {
            string rtn = "";
            text = text.Replace("(", "").Replace(")", "").Replace("申", "").Replace("晋", "").TrimStart(
                    "0".ToCharArray());
            text = "记录" + text;
            return text;
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
            string str = CertNO.TrimEnd().Substring(CertNO.Length - 1, 1);
            string rtn = "";
            switch (str.ToLower())
            {
                case "a":
                    rtn = "一级";
                    break;
                case "b":
                    rtn = "二级";
                    break;
                case "c":
                    rtn = "三级";
                    break;
                default:
                    rtn = "未知等级";
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
        
        #region //弹出对话框
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
