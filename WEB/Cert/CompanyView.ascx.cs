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

public partial class Cert_CompanyView : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
            {
                string MID = Request.QueryString["id"];
                int recc;
                DataSet ds =
                   Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'",
                                out recc);
                if (recc < 1)
                    return;
                lblShow.Text = getNoteNum(ds.Tables[0].Rows[0]["ID"].ToString());
                lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            }
        }
    }
}
