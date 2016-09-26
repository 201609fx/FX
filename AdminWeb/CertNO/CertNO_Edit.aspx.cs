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
using SZMA.Core;

public partial class CertNO_CertNO_Edit : SZMA.Core.Admin.PageBase
{
      protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(20))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma_FF, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7726))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        btnSubmit.OnClientClick = "return confirm('您确定要保存操作吗?')";
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
            dpStartTime.Date = getTime(ds.Tables[0].Rows[0]["StartTime"].ToString());
            dpEndTime.Date = getTime(ds.Tables[0].Rows[0]["EndTime"].ToString());
        }
    }

   
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName = AdminUser.Username;
        if (!CheckAdminRight(20))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma_FF, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7726))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        CertNODAL obj = new CertNODAL();
        if (obj.Update(UserName,getDate(dpStartTime.Date),getDate(dpEndTime.Date),Request.QueryString["id"]) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        MainSCDAL Mobj = new MainSCDAL();
        if (Mobj.Update(txtLZR.Text, Request.QueryString["id"]) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("Default.aspx");
    }
}
