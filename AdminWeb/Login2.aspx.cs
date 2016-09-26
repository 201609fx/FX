using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SZMA.DataLayer;

public partial class Login2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim().Length < 1 || txtPwd.Text.Trim().Length < 1)
        {
            ShowAlert("登陆错误!", "用户名和密码不能为空！");
            return;
        }

        if (Session["ValidateCode"] == null || string.Compare(txtVailCode.Text, Session["ValidateCode"].ToString(), true) != 0)
        {
            ShowAlert("登陆错误!", "您输入的验证码不对！");
            return;
        }
        UserDAL obj = new UserDAL();
        DataSet ds = obj.CheckLogin(txtUserName.Text.Trim(), System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text.Trim(), "md5"));
        if (ds.Tables[0].Rows.Count == 1)
        {
            //登陆成功！
            DataRow dr = ds.Tables[0].Rows[0];
            HttpCookie cookie;
            FormsAuthenticationTicket ticket;

            if (dr["IsAvailible"].ToString() != "1")
            {
                ShowAlert("登陆失败!", "您的账户未激活！");
                return;
            }
            ticket = new FormsAuthenticationTicket(1,
                dr["UserName"].ToString(),
                DateTime.Now,
                DateTime.Now.AddDays(1),
                false,
                string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                              dr["UserName"].ToString() == "" ? "无" : dr["UserName"].ToString().Trim(),
                              dr["RealName"].ToString() == "" ? "无" : dr["RealName"].ToString().Trim(),
                              dr["UserGroupID"].ToString() == "" ? "无" : dr["UserGroupID"].ToString().Trim(),
                              dr["Rights"].ToString() == "" ? "无" : dr["Rights"].ToString().Trim(),
                              dr["Name"].ToString() == "" ? "无" : dr["Name"].ToString().Trim(),
                              "SZMA_Admin"));

            cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            cookie.Value = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(cookie);
            ShowAlert("登陆信息", "登陆成功！");
            Response.Redirect("Default.aspx");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "goBack", @"<script>history.back();</script>");

        }
        else
        {
            //登陆失败！
            ShowAlert("登陆信息", "登陆失败！");
        }
    }

    /// <summary>
    /// 显示消息
    /// </summary>
    /// <param name="name">消息名称，如果为empty则使用Guid生成</param>
    /// <param name="message">消息内容</param>
    public void ShowAlert(string name, string message)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), name == string.Empty ? Guid.NewGuid().ToString() : name, string.Format("<script language=javascript>alert(\"{0}\")</script>", message));
    }
}
