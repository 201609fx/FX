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
using System.Security.Principal;

public partial class YLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dologin();
    }

    //域用户登陆处理
    private void dologin()
    {
        WindowsIdentity MyIdentity = WindowsIdentity.GetCurrent();
        string[] str;
       // Response.Write(MyIdentity.Name);
        if (MyIdentity.Name.IndexOf("SZAIC") >= 0)
        {
           // Response.Write("ccc");
            CSrvUserValid.CSrvUserValid objSrv = new CSrvUserValid.CSrvUserValid();
            CSrvUserValid.CUPGroup UserGroup = new CSrvUserValid.CUPGroup();
            string UserID = System.Environment.UserName.ToUpper();
            UserGroup = objSrv.GetNewUPGroup(UserID);
            string UserName = UserGroup.User.Name;
            CSrvUserValid.CUserPrivilage[] UserPrivilages = UserGroup.UserPrivilages;
            string rights = "";
            for (int i = 0; i < UserPrivilages.Length; i++)
            {
                rights += "," + UserPrivilages[i].PrivilageID;
            }
            if (rights != "")
            {
                rights += ",";
            }
            Session.Add("UserName", UserName);
            Session.Add("Rights", rights);
            //HttpCookie cookie;
            //ticket = new System.Web.Security.FormsAuthenticationTicket(1,
            //          UserID,
            //          DateTime.Now,
            //          DateTime.Now.AddMinutes(180),
            //          false,
            //          string.Format("{0}|{1}", UserName, rights));
            ////原来用Session记录权限进行判断
            ////Session["UserPrivilage"] = UserPrivilages;
            //cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName);
            //cookie.Value = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            //cookie.Expires = DateTime.Now.AddHours(1);
            //Response.Cookies.Add(cookie);

            Response.Redirect("Default.aspx");          

        }
        else
        {
            //用户不在域中
            this.Response.Redirect("NoRight.aspx");
            return;
        }
    }
}
