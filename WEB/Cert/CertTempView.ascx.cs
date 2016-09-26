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

public partial class Cert_CertTempView :SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
        {
            Data_bind();
        }
    }
    protected void Data_bind()
    {
        int recc = 0;
        DataSet ds =
            Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, " ID='" + Request.QueryString["id"] + "'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lblState.Text = getState(ds.Tables[0].Rows[0]["state"].ToString());
            lblPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
        }
    }
}
