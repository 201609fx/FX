using System;
using System.Collections.Generic;
using System.Text;

namespace SZMA.Core.Client
{
    /// <summary>
    /// �����û���Ϣ��
    /// </summary>
    public class ClientUser
    {
        string username, realName, lastLogin, firmName, tel, fax, email, userID, sid;

        /// <summary>
        /// ��ǰ�����û�
        /// </summary>
        public ClientUser()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }


        public string FirmName
        {
            set { firmName = value; }
            get { return firmName; }
        }

        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string Tel
        {
            set { tel = value; }
            get { return tel; }
        }

        /// <summary>
        /// �û���SessionID
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
        /// �û���½��
        /// </summary>
        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        /// <summary>
        /// ����
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
        /// ����½ʱ��
        /// </summary>
        public string LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }        

    }
}
