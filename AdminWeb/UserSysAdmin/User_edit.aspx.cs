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

public partial class UserSysAdmin_User_edit :SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(33))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        if (!IsPostBack)
        {
            if (null == Request.QueryString["id"] || Request.QueryString["id"] == "")
            {
                lblID.Text = Common.Insert("UserInfo", "IsAvailible", "ModifiTime");
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
        UserInfoDAL obj=new UserInfoDAL();
        DataSet ds = obj.SelectByID(lblID.Text);
        if(ds.Tables[0].Rows.Count>0)
        {
            txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            txtRealName.Text = ds.Tables[0].Rows[0]["RealName"].ToString();
            ddlIsAvailible.SelectedValue = ds.Tables[0].Rows[0]["IsAvailible"].ToString();
            ddlUserGroup.SelectedValue = ds.Tables[0].Rows[0]["UserGroupID"].ToString();
        }
    }

    private void Data_bind()
    {
        UserGroupDAL obj=new UserGroupDAL();
        DataSet ds = obj.SelectAll();
        ddlUserGroup.DataSource = ds;
        ddlUserGroup.DataBind();
        ListItem lt=new ListItem("请选择用户组","0");
        ddlUserGroup.Items.Insert(0,lt);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string CheckUser =AdminUser.Username;
        UserInfoDAL obj = new UserInfoDAL();
        if (txtUserName.Text=="")
        {
            this.Response.Write("<script language='javascript'> alert('请输入用户名!')</script>");
            return;
        }
        
          DataSet dsuser=  obj.SelectByUserName(txtUserName.Text);
          if (dsuser.Tables[0].Rows.Count>1)
          {
              this.Response.Write("<script language='javascript'> alert('用户名已被占用!')</script>");
              return;
          }
          if (dsuser.Tables[0].Rows.Count > 0)
          {
              if (dsuser.Tables[0].Rows[0]["ID"].ToString() != lblID.Text)
              {
                  this.Response.Write("<script language='javascript'> alert('用户名已被占用!')</script>");
                  return;
              }
          }
        if (ddlUserGroup.SelectedValue == "0")
        {
            this.Response.Write("<script language='javascript'> alert('请选择用户组!')</script>");
            return;
        }
        if (ddlUserGroup.SelectedValue == "")
        {
            this.Response.Write("<script language='javascript'> alert('请选择用户状态!')</script>");
            return;
        }
        if (obj.Update(txtUserName.Text,txtRealName.Text,ddlUserGroup.SelectedValue,ddlIsAvailible.SelectedValue,CheckUser,lblID.Text)< 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        if (txtPassword.Text == "")
        {
            this.Response.Redirect("UserList.aspx");
            return;
        }
        string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "md5");
        if (Common.Update("UserInfo", "ID", lblID.Text, new string[] { "PassWord", "CheckUser" }, new string[] { pass, AdminUser.Username }))
        {
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('修改密码失败!')</script>");
            return;
        }
        this.Response.Redirect("UserList.aspx");
    }
    protected void btnUpdatePass_Click(object sender, EventArgs e)
    {
        if(txtPassword.Text=="")
        {
            this.Response.Write("<script language='javascript'> alert('密码不能为空!')</script>");
            return;
        }
       string pass= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "md5");
       if (Common.Update("UserInfo", "ID", lblID.Text, new string[] { "PassWord","CheckUser" }, new string[] { pass,AdminUser.Username }))
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
