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
using SZMA.BLL;

public partial class workaround_syndic_checkPlateAddSort : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            string userName =AdminUser.Username;
            if (null == Request.QueryString["tid"])
            {
                pnlAll.Visible = false;
                btnOK.Visible = false;
                return;
            }
            if (Request.QueryString["tid"] == "1")
            {
                ProblemSortDAL obj = new ProblemSortDAL();
                lblSortName.Text = "添加题目类型";
                lblID.Text = obj.InsertNull(Request.QueryString["pid"], Request.QueryString["aid"], userName);
            }
            else
            {
                lblID.Text = Request.QueryString["id"];
                lblSortName.Text = "编辑题目类型";
                data_init();
            }
        }
    }

    private void data_init()
    {
        int recc;
      DataSet ds=  Common.Pager("ProblemSort", "*", "ID", 10, 1, true, "ID=" + Request.QueryString["id"],out recc);
        if(recc<1)
        {
            pnlAll.Visible = false;
            btnOK.Visible = false;
            return;
        }
        txtTotle.Text = ds.Tables[0].Rows[0]["totle"].ToString();
        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
        rbnlIsATotle.SelectedValue = ds.Tables[0].Rows[0]["IsAtotle"].ToString();
    }

    protected void btnAddT_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "" && txtTotle.Text != "")
        {
            string UserName = AdminUser.Username;
            ProblemSortDAL obj = new ProblemSortDAL();
            obj.UpdateByID(lblID.Text.Trim(), "0", txtName.Text,Utility.getVal( txtTotle.Text), txtRemark.Text, UserName, rbnlIsATotle.SelectedValue);
            this.Response.Write("<script language='javascript'>opener.window.location.href=opener.window.location.href;window.close();</script>");
        }
    }
}
