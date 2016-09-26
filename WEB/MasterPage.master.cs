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

public partial class MasterPage : SZMA.Core.Client.BaseClientPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        lblWeek.Text = "星期" + DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("zh-cn"));  
    }
}
