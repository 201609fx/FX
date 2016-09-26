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

public partial class CertNO_CompanyShowDetail : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!CheckAdminRight(21))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7725))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            data_init();
        }

    }

    private void data_init()
    {
        int recc = 0;
        DataSet ds = Common.Pager("MainSC],[cert", "MainSC.*,cert.StartTime,cert.EndTime", "MainSC.ID", 10, 1, true, " cert.MainSCID=MainSC.MainSCID and  MainSC.MainSCID='" + Request.QueryString["ID"] + "'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            lblNO.Text = getMainNO(ds.Tables[0].Rows[0]["MainSCID"].ToString(), ds.Tables[0].Rows[0]["Type"].ToString());
            txtLZR.Text = ds.Tables[0].Rows[0]["LZR"].ToString();
            dpStartTime.Text = getTime(ds.Tables[0].Rows[0]["StartTime"].ToString());
            dpEndTime.Text = getTime(ds.Tables[0].Rows[0]["EndTime"].ToString());
        }
    }
}
