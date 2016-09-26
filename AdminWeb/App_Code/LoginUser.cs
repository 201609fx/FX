using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// LoginUser 的摘要说明
/// </summary>
public class LoginUser
{
    public string user;
    public LoginUser(string str)
    {
        user = str;
    }
    public string getGh()
    {
        return user;
    }
}
