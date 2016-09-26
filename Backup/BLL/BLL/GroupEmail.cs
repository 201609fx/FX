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
        /// 发送邮件,成功则返回数字1,失败则返回数字0
        /// </summary>
        /// <param name="subject">主题</param>
        /// <param name="htmlBody">Html内容</param>
        /// <param name="receiverlist">用分号隔开的收件人地址列表</param>
        public int SendEmail(string fromAddress, string smtpServer, string smtpUsername, string smtpPassword, string fromName, string subject, string htmlBody, string receiverlist, string[] attachmentlist)
        {
            string[] EmailList = receiverlist.Split(';');
            //实例化一个Message对象
            MailMessage Msg = new MailMessage();

            Msg.BodyEncoding = Encoding.GetEncoding("gb2312");
            Msg.Priority = MailPriority.Normal; //优先级
            Msg.Subject = subject; //邮件主题
            Msg.Body = htmlBody; //邮件内容
            Msg.BodyFormat = MailFormat.Html;
            if (attachmentlist.Length > 1)
            {
                for (int i = 1; i < attachmentlist.Length; i++)
                    Msg.Attachments.Add(new MailAttachment(attachmentlist[i].ToString()));
            }

            #region smtpserver用户名,密码
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
            Msg.From = string.Format("{0}<{1}>", fromName, fromAddress); //发信人地址

            #endregion

            #region 添加收信人

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
