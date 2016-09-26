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

public partial class UserSysAdmin_UserGroup_edit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(31))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        if (!IsPostBack)
        {
            if (null == Request.QueryString["id"] || Request.QueryString["id"] == "")
            {
                lblID.Text = Common.Insert("UserGroup", "InsertFlag", "CreateTime");
            }
            else
            {
                lblID.Text = Request.QueryString["id"];
            }
            Data_bind();
            Data_init();
        }
    }

    private void Data_init()
    {
        UserGroupDAL obj = new UserGroupDAL();
        DataSet ds = obj.SelectByID(lblID.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtRights.Text = ds.Tables[0].Rows[0]["Rights"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        }
    }

    private void Data_bind()
    {
        RightsDAL Robj = new RightsDAL();
        DataSet Rds = Robj.Select();
        DLRights.DataSource = Rds;
        DLRights.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName = AdminUser.Username;
        UserGroupDAL obj = new UserGroupDAL();
        if (txtName.Text == "")
        {
            this.Response.Write("<script language='javascript'> alert('请输入用户名!')</script>");
            return;
        }

        if (obj.Update(txtName.Text, txtRights.Text, UserName, DateTime.Now, lblID.Text) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("UserGroupList.aspx");
    }
   
}
