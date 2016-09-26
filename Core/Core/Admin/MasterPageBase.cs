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
        /// ��ǰ��½���û�
        /// </summary>
        public AdminUser AdminUser
        {
            get { return adminUser; }
        }

        /// <summary>
        /// ����û��Ƿ���ĳȨ��
        /// </summary>
        /// <param name="right">Ҫ����Ȩ�޺�</param>
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
                    adminUser.Realname = "�[��";
                    adminUser.Username = "Guest";
                    adminUser.Rights = "0";
                }

            }
            else
            {
                adminUser.Realname = "�[��";
                adminUser.Username = "Guest";
                adminUser.Rights = "0";
            }
            HttpContext.Current.Items["LoginName"] = adminUser.Username;
            HttpContext.Current.Items["UserName"] = adminUser.Realname;
        }
        //���û�Ȩ���¼ӣ�
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
                adminUser.Username = "�[��";
                adminUser.Rights = "";
            }
            HttpContext.Current.Items["LoginName"] = adminUser.Username;
        }
        ////��Ȩ�޺��ж�
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
