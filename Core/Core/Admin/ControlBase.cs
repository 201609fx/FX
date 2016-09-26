using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace SZMA.Core.Admin
{
    public class ControlBase : UserControl
    {
        AdminUser adminUser;
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlBase()
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
            //try
            //{
            //    string strID_dm = string.Concat(",", Model_DM.ToString(), ";") + opt_dm.ToUpper() + ",";

            //    int s = AdminUser.Rights.IndexOf(strID_dm);
            //    if (s > -1)
            //    {
                    return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch
            //{ }
            //return false;
        }
        private void PageBase_Init(object sender, EventArgs e)
        {
            adminUser = new AdminUser();
            FormsAuthenticationTicket ticket;
            string[] str;
            if (Request.IsAuthenticated)
            {
                ticket = ((FormsIdentity)Context.User.Identity).Ticket;
                str = ticket.UserData.Split('|');
                adminUser.Realname = str[2];
                adminUser.Username = str[1];
                adminUser.GroupName = str[4];
                adminUser.Rights = str[5];

            }
            else
            {
                adminUser.Realname = "遊客";
                adminUser.GroupName = "";
                adminUser.Username = "Guest";
                adminUser.Rights = "0";
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
    }
}
