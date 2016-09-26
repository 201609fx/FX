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
    public class MasterPageBase : System.Web.UI.MasterPage
    {
        AdminUser adminUser;
        /// <summary>
        /// Constructor
        /// </summary>
        public MasterPageBase()
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

        private void PageBase_Init(object sender, EventArgs e)
        {
            adminUser = new AdminUser();
            FormsAuthenticationTicket ticket;
            string[] str;
            if (Request.IsAuthenticated)
            {
                ticket = ((FormsIdentity)Context.User.Identity).Ticket;
                str = ticket.UserData.Split('|');
                if (str[3].Trim() == "admin")
                {
                    adminUser.Realname = str[1];
                    adminUser.Username = str[0];
                    adminUser.Rights = str[2];
                }
                else
                {
                    adminUser.Realname = "遊客";
                    adminUser.Username = "Guest";
                    adminUser.Rights = "0";
                }

            }
            else
            {
                adminUser.Realname = "遊客";
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
