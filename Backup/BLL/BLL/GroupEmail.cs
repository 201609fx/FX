using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web.Mail;

namespace SZMA.BLL
{
    public class GroupEmail
    {
        /// <summary>
        /// �����ʼ�,�ɹ��򷵻�����1,ʧ���򷵻�����0
        /// </summary>
        /// <param name="subject">����</param>
        /// <param name="htmlBody">Html����</param>
        /// <param name="receiverlist">�÷ֺŸ������ռ��˵�ַ�б�</param>
        public int SendEmail(string fromAddress, string smtpServer, string smtpUsername, string smtpPassword, string fromName, string subject, string htmlBody, string receiverlist, string[] attachmentlist)
        {
            string[] EmailList = receiverlist.Split(';');
            //ʵ����һ��Message����
            MailMessage Msg = new MailMessage();

            Msg.BodyEncoding = Encoding.GetEncoding("gb2312");
            Msg.Priority = MailPriority.Normal; //���ȼ�
            Msg.Subject = subject; //�ʼ�����
            Msg.Body = htmlBody; //�ʼ�����
            Msg.BodyFormat = MailFormat.Html;
            if (attachmentlist.Length > 1)
            {
                for (int i = 1; i < attachmentlist.Length; i++)
                    Msg.Attachments.Add(new MailAttachment(attachmentlist[i].ToString()));
            }

            #region smtpserver�û���,����
            if (smtpUsername.Length > 0 && smtpPassword.Length > 0)
            {
                Msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //basic authentication
                Msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpUsername); //set your username here
                Msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword); //set your password here
            }
            else
            {
            }

            SmtpMail.SmtpServer = smtpServer;
            Msg.From = string.Format("{0}<{1}>", fromName, fromAddress); //�����˵�ַ

            #endregion

            #region ���������

            string ToList = "";
            for (int i = 0; i < EmailList.Length; i++)
            {
                ToList += EmailList[i].Trim() + ";";
            }

            Msg.To = ToList;

            #endregion

            int success = 0;
            try
            {
                SmtpMail.Send(Msg);
                success = 1;
            }
            catch
            {
                //				throw new Exception(ex.Message);
            }
            return success;
        }
    }
}
