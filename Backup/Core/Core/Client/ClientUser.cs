using System;
using System.Collections.Generic;
using System.Text;

namespace SZMA.Core.Client
{
    /// <summary>
    /// 管理用户信息类
    /// </summary>
    public class ClientUser
    {
        string username, realName, lastLogin, firmName, tel, fax, email, userID, sid;

        /// <summary>
        /// 当前管理用户
        /// </summary>
        public ClientUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        public string FirmName
        {
            set { firmName = value; }
            get { return firmName; }
        }

        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string Tel
        {
            set { tel = value; }
            get { return tel; }
        }

        /// <summary>
        /// 用户的SessionID
        /// </summary>
        public string SID
        {
            get { return sid; }
            set { sid = value; }
        }


        public string Fax
        {
            set { fax = value; }
            get { return fax; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }


        /// <summary>
        /// 用户登陆名
        /// </summary>
        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        /// <summary>
        /// 真名
        /// </summary>
        public string RealName
        {
            set { realName = value; }
            get { return realName; }
        }

        public string UserID
        {
            set { userID = value; }
            get { return userID; }
        }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public string LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }        

    }
}
