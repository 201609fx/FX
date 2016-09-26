using System;
using System.Collections.Generic;
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
public partial class workaround_result_Edit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(13))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Result, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7718))
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
            txtMember.Text = ds.Tables[0].Rows[0]["member"].ToString();
            txtLeader.Text = ds.Tables[0].Rows[0]["Leader"].ToString();
            txtCompConfirm.Text = ds.Tables[0].Rows[0]["CompanyConfirm"].ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName=AdminUser.Username;
        examineResultDAL obj=new examineResultDAL();
        obj.Update(txtSuggest.Text.Replace("/r/n", "<br>"), txtResult.Text.Replace("/r/n", "<br>"), UserName,
                   txtMember.Text,txtLeader.Text, txtCompConfirm.Text, Request.QueryString["id"], UserName);
        this.Response.Redirect("Result.aspx");
    }
    
}
