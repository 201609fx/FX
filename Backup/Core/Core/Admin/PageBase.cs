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

namespace SZMA.Core.Admin
{
    public class PageBase : System.Web.UI.Page
    {
        AdminUser adminUser;
        /// <summary>
        /// Constructor
        /// </summary>
        public PageBase()
        {
            this.Init += new EventHandler(PageBase_Init);
        } 

        /// <summary>
        /// 当前登陆的用户
        /// </summary>
        public AdminUser AdminUser
        {
            get { return adminUser; }
        }

        /// <summary>
        /// 检测用户是否有某权限
        /// </summary>
        /// <param name="right">要检测的权限号</param>
        /// <returns></returns>
        public bool CheckAdminRight(int right)
        {
            return AdminUser.Rights.IndexOf(string.Concat(",", right, ",")) > -1;
        }


        /// <summary>
        /// 验证功能模块代码与，操作代码
        /// </summary>
        /// <param name="opt_dm"></param>
        /// <param name="Model_DM"></param>
        /// <returns></returns>
        public bool CheckRight(string Model_DM, string opt_dm)
        {
            try
            {
                string strID_dm = string.Concat(",", Model_DM.ToString(), ";") + opt_dm.ToUpper() + ",";

                int s = AdminUser.Rights.IndexOf(strID_dm);
                if (s > -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            { }
            return false;
        }
        #region///删除 
        ///// <summary>
        ///// 检测用户是否有某权限
        ///// </summary>
        ///// <param name="right">要检测的权限号</param>
        ///// <returns></returns>
        //public bool CheckAdminRight(int obj_id,string opt_dm,string url)
        //{
        //    try
        //    {
        //        string strID_dm = string.Concat(",", obj_id.ToString(), ";") + opt_dm.ToUpper() + ";";

        //        int s = AdminUser.Rights.IndexOf(strID_dm);
        //        if (s < 0)
        //        {
        //            return false;
        //        }
        //        string strurl = AdminUser.Rights;

        //        while (strurl.IndexOf(strID_dm) > -1)
        //        {
        //            strurl = strurl.Substring(strurl.IndexOf(strID_dm) + strID_dm.Length);
        //            if (url.ToLower().IndexOf(strurl.Substring(0, strurl.IndexOf(',')).ToLower()) > -1)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    catch
        //    { }
        //    return false;
        //}
        #endregion

        private void PageBase_Init(object sender, EventArgs e)
        {
            adminUser = new AdminUser();
            FormsAuthenticationTicket ticket;
            string[] str;
            if (Request.IsAuthenticated)
            {
                ticket = ((FormsIdentity)Context.User.Identity).Ticket;
                str=ticket.UserData.Split('|');                
                adminUser.Username = str[0];
                adminUser.Realname = str[0];
                if (null != Session["rjwxuserdata"] && Session["rjwxuserdata"].ToString() != "")
                {
                    adminUser.Rights = Session["rjwxuserdata"].ToString();
                }
                adminUser.GroupID = str[2];
                adminUser.Rights = str[3];
                //adminUser.GroupName = str[4];
                adminUser.GH = str[0];
                adminUser.ENCR = str[1];
            }
            else
            {
                adminUser.Realname = "遊客";
                adminUser.GroupName = "";
                adminUser.Username = "Guest";
                adminUser.Rights = "0";
                adminUser.GH = "test";
                adminUser.ENCR = "123456";
            }
            HttpContext.Current.Items["LoginName"] = adminUser.Username;
            HttpContext.Current.Items["UserName"] = adminUser.Realname;
        }


        //域用户权限新加：
        private void PageBase_Init1(object sender, EventArgs e)
        {
            adminUser = new AdminUser();
            if (Session["Rights"] != null && Session["UserName"] != null)
            {
                // ticket = ((FormsIdentity)Context.User.Identity).Ticket;
                // str = ticket.UserData.Split('|');
                string UserName = Session["UserName"].ToString();
                string Rights = Session["Rights"].ToString();
                adminUser.Username = UserName;
                adminUser.Rights = Rights;
                //if (null != Session["UserPrivilages"] && Session["UserPrivilages"].ToString() != "")
                //{
                //    adminUser.UserPrivilages = (CSrvUserValid.CUserPrivilage[])Session["UserPrivilages"];
                //}
            }
            else
            {
                adminUser.Username = "遊客";
                adminUser.Rights = "";
            }
            HttpContext.Current.Items["LoginName"] = adminUser.Username;
        }
        ////域权限号判断
        //private bool checkYUright(string strPG_ID)
        //{
        //    bool rtn = false;
        //    for(int i=0;i<adminUser.UserPrivilages.Length;i++)
        //    {
        //        if (adminUser.UserPrivilages[i].PrivilageID == strPG_ID)
        //        {
        //            rtn = true;
        //            return rtn;
        //        }
        //    }
        //    return rtn;
        //}
        public bool checkYUright(int right)
        {
            return adminUser.Rights.IndexOf(string.Concat(",", right, ",")) > -1;
        }





















        public string getMainNO(string mid, string tid)
        {
            return "(" + (tid == "2" ? "晋" : "申") + ")" + mid.PadLeft(5, '0');
        }
        public string getSimpleMainNO(string mid, string tid)
        {
            return  mid.PadLeft(5, '0');
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
            string rtn = "记录" + DateTime.Now.ToString("yyMM") + "-" + ds.Tables[0].Rows[0][0].ToString().PadLeft(5, '0');
            ///保存生成的记录号到数据库
            Common.Update("MainSCTemp", "ID", MID, new string[] { "NoteNum" }, new string[] { rtn });
            CertDictDAL obj = new CertDictDAL();
            ///把记录流水号计数加一
            obj.Add("2");
            return rtn;
        }

        public string getAPPNumNO(string MID)
        {
            int recc;

            DataSet dsNote = Common.Pager("approve", "*", "ID", 100, 1, true, "MainSCID='" + MID + "'", out recc);
            if (recc > 0 && null != dsNote.Tables[0].Rows[0]["AppNO"] && dsNote.Tables[0].Rows[0]["AppNO"].ToString() != "")
            {
                return dsNote.Tables[0].Rows[0]["AppNO"].ToString();
            }
            DataSet ds = Common.Pager("certDict", "C_Value", "ID", 100, 1, true, "ID=4", out recc);
            string rtn = "(审)" + DateTime.Now.ToString("yyMM") + "-" + ds.Tables[0].Rows[0][0].ToString().PadLeft(6, '0');
            ///保存生成的记录号到数据库
            Common.Update("approve", "MainSCID", MID, new string[] { "AppNO" }, new string[] { rtn });
            CertDictDAL obj = new CertDictDAL();
            ///把记录流水号计数加一
            obj.Add("4");
            return rtn;
        }

        public string getCertNO(string CertNO, string MyType, string oldCertNO, string Mid)
        {
            string rtn = "";
            try
            {
                if (CertNO == "")
                {
                    switch (MyType)
                    {
                        case "1":
                            rtn = getNewCertNO(Mid);
                            break;
                        case "2":
                            rtn = oldCertNO.Substring(0, oldCertNO.Length - 1);
                            break;
                        default:
                            break;
                    }
                    AssessDAL obj = new AssessDAL();
                    DataSet ds = obj.SelectCertNO(Mid);
                    float Totle;
                    string strTotle = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["totle"].ToString() != "")
                        {
                            strTotle = ds.Tables[0].Rows[0]["totle"].ToString();
                        }
                    }
                    Totle = strTotle == "" ? 0 : float.Parse(strTotle);
                    if (Totle >= 90)
                    {
                        rtn += "A";
                    }
                    else if (Totle >= 80)
                    {
                        rtn += "B";
                    }
                    else if (Totle >= 70)
                        rtn += "C";
                    else
                        return "";
                    ///保存证书号到数据库
                    Common.Update("MainSCTemp", "ID", Mid, new string[] { "CertNO" }, new string[] { rtn });
                }
                else
                {
                    rtn = CertNO;
                }
            }
            catch
            {
            }
            return rtn;
        }
        public string getNewCertNO(string MID)
        {
            int recc;
            DataSet ds = Common.Pager("certDict", "C_Value", "ID", 100, 1, true, "ID=1", out recc);
            string rtn = DateTime.Now.ToString("yy") + "-" + ds.Tables[0].Rows[0][0].ToString().PadLeft(4, '0');
            ///保存生成的记录号到数据库
            Common.Update("MainSCTemp", "ID", MID, new string[] { "NoteNum" }, new string[] { rtn });
            CertDictDAL obj = new CertDictDAL();
            ///把记录流水号计数加一
            obj.Add("1");
            return rtn;
        }
        public string getState(string state)
        {//0为申请；1为初审；2为评审；3为结论；4为通知；5为待领证
            string rtn = "";
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
            if(CertNO=="")
            {
                return "";
            }
           string str = CertNO.Substring(CertNO.Length - 1, 1);
           string rtn = "";
           switch(str.ToLower())
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
        protected string getno(string text)
        {
            string rtn = "";
            text = text.Replace("记", "").Replace("录", "").Replace("(", "").Replace(")", "");

            text = text.Replace("_", "-").Replace("-", "-").Replace("－", "-");
            if (text.IndexOf("-") < 0)
            {
                text = text.Substring(0, 4) + "-" + text.Substring(4);
            }
            text = "记录" + text;
            return text;
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
        public  bool OpenWindow(string Height,string Width,string Top,string Left,string WindowName,string Url)
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
    }
}
