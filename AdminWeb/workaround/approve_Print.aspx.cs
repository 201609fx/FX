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
public partial class workaround_approve_Print : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(17))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_approve, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7721))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        data_init();
    }

    private void data_init()
    {
        ApproveDAL obj = new ApproveDAL();
        DataSet ds = obj.SelectByMID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            string CertNO =
                getCertNO(ds.Tables[0].Rows[0]["CertNO"].ToString(), ds.Tables[0].Rows[0]["Type"].ToString(),
                          ds.Tables[0].Rows[0]["oldCertNO"].ToString(), Request.QueryString["id"]);
            lblCertNO.Text = (CertNO == "" ? "" : getLevel(CertNO));
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString() == ""
                                 ? "等级证书编号:" + CertNO
                                 : ds.Tables[0].Rows[0]["Remark"].ToString();
            txtSuggest.Text = ds.Tables[0].Rows[0]["suggest"].ToString();
        }
    }

}
