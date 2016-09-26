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

public partial class Complain_default : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSubmit.OnClientClick = "return confirm('您确定要保存操作吗?')";
        if (!IsPostBack)
        {
            if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
            {
                lblID.Text = Request.QueryString["id"];
                data_init();
            }
            else
            {
                string strID = Common.Insert("complain", "InsertFlag", "CreateTime");
                if (strID != "")
                    lblID.Text = strID;
            }
        }

    }

    private void data_init()
    {
        ComplainerDAL obj = new ComplainerDAL();
        DataSet ds = obj.SelectByID(lblID.Text);
        ddlCType.SelectedValue = "0";
        ddlCType.Enabled = false;
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtContent.Text = ds.Tables[0].Rows[0]["content"].ToString().Replace("<br>", "\r\n");
            txtComplainer.Text = ds.Tables[0].Rows[0]["Complainer"].ToString();
            txtCtel.Text = ds.Tables[0].Rows[0]["Ctel"].ToString();
            txtCaddresstou.Text = ds.Tables[0].Rows[0]["Caddresstou"].ToString();
            txtBCTel.Text = ds.Tables[0].Rows[0]["BCTel"].ToString();
            txtBContact.Text = ds.Tables[0].Rows[0]["BContact"].ToString();
            txtBComplainer.Text = ds.Tables[0].Rows[0]["BComplainer"].ToString();
            txtBAddress.Text = ds.Tables[0].Rows[0]["BAddress"].ToString();
            ddlCType.SelectedValue = ds.Tables[0].Rows[0]["InsertFlag"].ToString();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName = "Guest";
        ComplainerDAL obj = new ComplainerDAL();
        if (obj.UpdateFirst(DateTime.Now, txtComplainer.Text, txtCaddresstou.Text, txtCtel.Text,
                            txtBComplainer.Text, txtBCTel.Text, txtBContact.Text, txtBAddress.Text,
                            txtName.Text, txtContent.Text.Replace("\r\n", "<br>"),
        ddlCType.SelectedValue, 1, lblID.Text, UserName) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
    }
}
