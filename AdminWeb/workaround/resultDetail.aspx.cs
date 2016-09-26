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

public partial class workaround_resultDetail : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!CheckAdminRight(19))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Result, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7717))
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
        examineResultDAL obj = new examineResultDAL();
        DataSet ds = obj.SelectByMID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblNO.Text = getMainNO(ds.Tables[0].Rows[0]["MainSCID"].ToString(), ds.Tables[0].Rows[0]["Type"].ToString());
            lblPSTime.Text = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
            OperationMainDAL objopMain = new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainID1(Request.QueryString["id"]);
            for (int i = 0; i < dsOperationMain.Tables[0].Rows.Count; i++)
            {
                if (dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim() != "")
                    lblOperation.Text += "、" + dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim();
            }
            lblOperation.Text = lblOperation.Text.Trim().TrimStart("、".ToCharArray());
            //lblOperation.Text = ds.Tables[0].Rows[0]["Operation"].ToString();
            txtSuggest.Text = ds.Tables[0].Rows[0]["Suggest"].ToString();
            txtResult.Text = ds.Tables[0].Rows[0]["result"].ToString();
            txtLeader.Text = ds.Tables[0].Rows[0]["Leader"].ToString();
            txtCompanyConfirm.Text = ds.Tables[0].Rows[0]["CompanyConfirm"].ToString();
        }
    }

}
