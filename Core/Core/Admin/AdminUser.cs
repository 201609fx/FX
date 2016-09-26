using System;
using System.Collections.Generic;
using System.Text;

namespace SZMA.Core.Admin
{
    /// <summary>
    /// 管理用户信息类
    /// </summary>
    public class AdminUser
    {
        string username, realname, rights, groupID, groupName, gh, encr;
        CSrvUserValid.CUserPrivilage[] userPrivilages;
        /// <summary>
        /// 当前管理用户
        /// </summary>
        public AdminUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        /// <summary>
        /// 密匙
        /// </summary>
        public string ENCR
        {
            set { encr = value; }
            get { return encr; }
        }
        /// <summary>
        /// 工号
        /// </summary>
        public string GH
        {
            set { gh = value; }
            get { return gh; }
        }
        public string Realname
        {
            set { realname = value; }
            get { return realname; }
        }

        public string GroupName
        {
            set { groupName = value; }
            get { return groupName; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        /// <returns></returns>
        public string Rights
        {
            set { rights = value; }
            get { return rights; }
        }


        public string GroupID
        {
            set { groupID = value; }
            get { return groupID; }
        }


        //域新加：
        public CSrvUserValid.CUserPrivilage[] UserPrivilages
        {
            set { userPrivilages = value; }
            get { return userPrivilages; }
        }
    }
}
