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
using SZMA.DataLayer.User;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.AddHeader("P3P", "CP='CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR'");
       
        string gh = Request.Form["gh"];
        string ENCRO = Request.Form["ENCR"];
        dologin(gh, ENCRO);
    }
    protected void dologin(string gh, string ENCRO)
    {
        if (gh=="" || ENCRO=="" )
        {
            ShowAlert("登陆错误!", "工号与密匙不能为空！");
            return;
        }

        SSO_USERINFODAL obj = new SSO_USERINFODAL();
        DataSet ds = obj.selectUser(gh, ENCRO);
        if (ds.Tables[0].Rows.Count == 1)
        {
            //登陆成功！
            SECU_OBJDAL seobj = new SECU_OBJDAL();
            DataSet dsUser = seobj.selectUserObj(gh);
            string Rights = "";
            for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
            {
                Rights += "," + dsUser.Tables[0].Rows[i]["ModelDM"].ToString() + ";" + dsUser.Tables[0].Rows[i]["OPT_DM"].ToString().ToUpper() + ",";
            }
            DataRow dr = ds.Tables[0].Rows[0];
            HttpCookie cookie;
            FormsAuthenticationTicket ticket;
            ticket = new FormsAuthenticationTicket(1,
                dr["gh"].ToString(),
                DateTime.Now,
                DateTime.Now.AddDays(1),
                false,
                string.Format("{0}|{1}|{2}",
                              dr["gh"].ToString() == "" ? "无" : dr["gh"].ToString().Trim(),
                              dr["ENCRO"].ToString() == "" ? "无" : dr["ENCRO"].ToString().Trim(),
                              "0",
                              "SZMA_Admin"));

            //this.Response.Write("<script langauge='javascript'>" + ticket.UserData + "<script>");
            cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            //cookie.Path = System.Web.Security.FormsAuthentication.FormsCookiePath;
            //cookie.Expires = System.DateTime.Now.AddYears(100);
            cookie.Value = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            //cookie["Userdata"] = Rights;
            //this.Response.Write("<script langauge='javascript'>" + System.Web.Security.FormsAuthentication.Encrypt(ticket) + "<script>");
            Response.Cookies.Add(cookie);

            if (null == this.Session["rjwxuserdata"])
            {
                this.Session.Add("rjwxuserdata", "");
            }
            this.Session["rjwxuserdata"] = Rights;
           
         


            this.Response.Write("<script language=javascript>alert(\"登陆成功\")</script>");
            ShowAlert("登陆信息", "登陆成功！");
            //this.Response.Write(Rights + ",,,,,,,,,,,,,,,,<br/>" + dr["gh"].ToString().Trim() + "<br/> " + dr["ENCRO"].ToString().Trim());
            Response.Redirect("Default2.aspx");
          //  this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "goBack", @"<script>history.back();</script>");

        }
        else
        {
            //登陆失败！
            Response.Write(gh + ",,," + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(ENCRO, "md5"));
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
