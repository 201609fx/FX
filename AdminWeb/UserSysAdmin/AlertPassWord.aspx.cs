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

public partial class UserSysAdmin_AlertPassWord : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(13))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            Data_init();
        }
    }

    private void Data_init()
    {
        UserInfoDAL obj = new UserInfoDAL();
        DataSet ds = obj.SelectByID(lblID.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            txtRealName.Text = ds.Tables[0].Rows[0]["RealName"].ToString();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string CheckUser = AdminUser.Username;
        UserInfoDAL obj = new UserInfoDAL();
        if (obj.Update( txtRealName.Text,DateTime.Now, CheckUser, lblID.Text) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Write("<script language='javascript'> alert('保存成功!')</script>");
    }
    protected void btnUpdatePass_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text == "")
        {
            this.Response.Write("<script language='javascript'> alert('密码不能为空!')</script>");
            return;
        }
        string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "md5");
        if (Common.Update("UserInfo", "ID", lblID.Text, new string[] { "PassWord" }, new string[] { pass }))
        {
            this.Response.Write("<script language='javascript'> alert('修改成功!')</script>");
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('修改密码失败!')</script>");
            return;
        }

    }
}
