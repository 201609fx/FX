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

public partial class UserSysAdmin_BrandEdit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(39))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!checkYUright(7730))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            if (null == Request.QueryString["id"] || Request.QueryString["id"] == "")
            {
                lblID.Text = Common.Insert("dict_brand", "InsertFlag", "ModiTime");
            }
            else
            {
                lblID.Text = Request.QueryString["id"];
            }
            Data_init();
        }
    }

    private void Data_init()
    {
        dictbrandDAL obj = new dictbrandDAL();
        DataSet ds = obj.Select(lblID.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtBrand.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtEBrand.Text = ds.Tables[0].Rows[0]["EName"].ToString();
        }
    }

    public bool save()
    {
        dictbrandDAL obj = new dictbrandDAL();
        if (txtBrand.Text == "")
        {
            this.Response.Write("<script language='javascript'> alert('请输入名称!')</script>");
            return false;
        }
        int recc;
        DataSet dsbrand = Common.Pager("dict_brand", "*", "ID", 100, 1, true, "Name='" + txtBrand.Text + "'", out recc);

        if (dsbrand.Tables[0].Rows.Count > 1)
        {
            this.Response.Write("<script language='javascript'> alert('名称已被占用!')</script>");
            return false;
        }
        if (dsbrand.Tables[0].Rows.Count > 0)
        {
            if (dsbrand.Tables[0].Rows[0]["ID"].ToString() != lblID.Text)
            {
                this.Response.Write("<script language='javascript'> alert('名称已被占用!')</script>");
                return false;
            }
        }
        if (obj.Update(txtBrand.Text,txtEBrand.Text, AdminUser.Username, DateTime.Now, "1", lblID.Text) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return false;
        }
        return true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string CheckUser = AdminUser.Username;
        if (!save())
            return;

        this.Response.Redirect("Brand.aspx");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        string CheckUser = AdminUser.Username;
        if (!save())
            return;

        lblID.Text = Common.Insert("dict_brand", "InsertFlag", "ModiTime");
        txtBrand.Text = "";
    }
}
