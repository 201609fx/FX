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

public partial class workaround_PromotionDeal_edit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(15))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Deal, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7720))
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
        PromotionDealDAL obj = new PromotionDealDAL();
        DataSet ds = obj.Select(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lblTel.Text = ds.Tables[0].Rows[0]["phone"].ToString();
            lblcontact.Text = ds.Tables[0].Rows[0]["contact"].ToString();
            lblOldCertNO.Text = ds.Tables[0].Rows[0]["oldCertNO"].ToString();
            lblLevel.Text = getLevel(ds.Tables[0].Rows[0]["oldCertNO"].ToString());
            txtLeader.Text = ds.Tables[0].Rows[0]["leader"].ToString();
            dpLTime.Date = getTime(ds.Tables[0].Rows[0]["lTime"].ToString());
            lblPSTime.Text = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
            LblPS.Text = ds.Tables[0].Rows[0]["PSUserName"].ToString();
       
            txtLevel.Text=ds.Tables[0].Rows[0]["Level"].ToString();
            
            dictresuleDAL objPro=new dictresuleDAL();
           DataSet dsDdl= objPro.Select();
           ddlResult.DataSource = dsDdl;
            ddlResult.DataBind();
            ddlResult.Items.Insert(0,new ListItem("请选择一个处理结果","0"));
            
            ddlResult.SelectedValue = ds.Tables[0].Rows[0]["Result"].ToString();
            if(ddlResult.SelectedValue=="3")
                txtLevel.Attributes.Add("style","display:inline");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName = AdminUser.Username;
        PromotionDealDAL obj = new PromotionDealDAL();
        if(ddlResult.SelectedIndex<1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        if (ddlResult.SelectedValue.Trim() != "3")
            txtLevel.Text = "";
        if (obj.Update(ddlResult.SelectedValue,txtLevel.Text,
                       txtLeader.Text, getDate(dpLTime.Date), Request.QueryString["id"],UserName)<1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("PromotionDeal.aspx");
    }
}
