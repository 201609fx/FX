using System;
using System.Collections.Generic;
using System.Text;

namespace SZMA.Core.Admin
{
    /// <summary>
    /// �����û���Ϣ��
    /// </summary>
    public class AdminUser
    {
        string username, realname, rights, groupID, groupName, gh, encr;
        CSrvUserValid.CUserPrivilage[] userPrivilages;
        /// <summary>
        /// ��ǰ�����û�
        /// </summary>
        public AdminUser()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }


        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        /// <summary>
        /// �ܳ�
        /// </summary>
        public string ENCR
        {
            set { encr = value; }
            get { return encr; }
        }
        /// <summary>
        /// ����
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
        /// Ȩ��
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


        //���¼ӣ�
        public CSrvUserValid.CUserPrivilage[] UserPrivilages
        {
            set { userPrivilages = value; }
            get { return userPrivilages; }
        }
    }
}
