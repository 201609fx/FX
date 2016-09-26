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

public partial class FLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("P3P", "CP='CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR'");
        string gh = Request.Form["gh"];
        string Pwd = Request.Form["ENCR"];

//        this.RegisterStartupScript("as", @"<script langauge='javascript'>
// document.forms['theform'].action='Login.aspx';
//                document.forms['theform'].ENCR.value='123456';
//document.forms['theform'].gh.value='double';
//document.forms['theform'].submit();</script>");
        dologin(gh, Pwd);
    }
    protected void dologin(string gh, string Pwd)
    {

        if (gh == "" || Pwd == "")
        {
            ShowAlert("登陆错误!", "工号与密码不能为空！");
            return;
        }

        TXW_CYDADAL objCY = new TXW_CYDADAL();

        DataSet dsUser = objCY.selectByGH(gh);

        //SSO_USERINFODAL obj = new SSO_USERINFODAL();
        //DataSet ds = obj.selectUser(gh, ENCRO);
        //this.Response.Write("<script langauge='javascript'>alert('" + ds.Tables[0].Rows.Count.ToString() + "')</script>");
        //if (ds.Tables[0].Rows.Count == 1)
        if (dsUser.Tables[0].Rows.Count == 1)
        {
            SSO_USERINFODAL obj = new SSO_USERINFODAL();
            DataSet ds = obj.selectByGH(gh);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string ENCRO = ds.Tables[0].Rows[0]["ENCRO"].ToString();

                this.RegisterStartupScript("as", @"<script langauge='javascript'>
 document.forms['theform'].action='Login.aspx';
                document.forms['theform'].ENCR.value='" + ENCRO + @"';
document.forms['theform'].gh.value='" + gh + @"';
document.forms['theform'].submit();</script>");
            }
            ////登陆成功！
            //SECU_OBJDAL seobj = new SECU_OBJDAL();
            //DataSet dsUser = seobj.selectUserObj(gh);
            //string Rights = "";
            //for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
            //{
            //    Rights += "," + dsUser.Tables[0].Rows[i]["ModelDM"].ToString() + ";" + dsUser.Tables[0].Rows[i]["OPT_DM"].ToString().ToUpper() + ",";
            //    //Rights += "," + dsUser.Tables[0].Rows[i]["OBJ_ID"].ToString() + ";" + dsUser.Tables[0].Rows[i]["OPT_DM"].ToString().ToUpper() + ";" + dsUser.Tables[0].Rows[i]["url"].ToString().ToUpper() + ",";
            //}
            //DataRow dr = ds.Tables[0].Rows[0];
            //HttpCookie cookie;
            //FormsAuthenticationTicket ticket;
            //ticket = new FormsAuthenticationTicket(1,
            //    dr["gh"].ToString(),
            //    DateTime.Now,
            //    DateTime.Now.AddDays(1),
            //    false,
            //    string.Format("{0}|{1}|{2}",
            //                  dr["gh"].ToString() == "" ? "无" : dr["gh"].ToString().Trim(),
            //                  dr["ENCRO"].ToString() == "" ? "无" : dr["ENCRO"].ToString().Trim(),
            //                  "0",
            //                  "SZRZ_Admin"));

            ////this.Response.Write("<script langauge='javascript'>" + ticket.UserData + "<script>");
            //cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            ////cookie.Path = System.Web.Security.FormsAuthentication.FormsCookiePath;
            ////cookie.Expires = System.DateTime.Now.AddYears(100);
            //cookie.Value = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            ////cookie["Userdata"] = Rights;
            ////this.Response.Write("<script langauge='javascript'>" + System.Web.Security.FormsAuthentication.Encrypt(ticket) + "<script>");
            //Response.Cookies.Add(cookie);

            //if (null == this.Session["szrzuserdata"])
            //{
            //    this.Session.Add("szrzuserdata", "");
            //}
            //this.Session["szrzuserdata"] = Rights;

            //if (Request.IsAuthenticated)
            //{
            //    this.Response.Write("<script langauge='javascript'>" + Response.Cookies[FormsAuthentication.FormsCookieName].Value + "<script>");


            //}
            //else
            //{
            //    this.Response.Write("<script langauge='javascript'>sadasdsa" + Response.Cookies[FormsAuthentication.FormsCookieName].Value + "<script>");

            //}



            //ShowAlert("登陆信息", "登陆成功！");
            //Response.Redirect("Default.aspx");
            //  this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "goBack", @"<script>history.back();</script>");

        }
        else
        {
            //登陆失败！
            ShowAlert("登陆信息", "登陆失败！");
            Response.Write(gh + ",,," + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd, "md5"));
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
