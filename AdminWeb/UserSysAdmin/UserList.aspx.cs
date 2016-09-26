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

public partial class UserSysAdmin_UserList : SZMA.Core.Admin.PageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!CheckAdminRight(32))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        if (!IsPostBack)
        {
            Data_bind();
            show();
        }
    }

    private void Data_bind()
    {
        UserGroupDAL obj = new UserGroupDAL();
        DataSet ds = obj.SelectAll();
        ddlUserGroup.DataSource = ds;
        ddlUserGroup.DataBind();
        ListItem lt = new ListItem("请选择用户组", "0");
        ddlUserGroup.Items.Insert(0, lt);
    }
    public void show(int pageindex)
    {
        int recc;
        DataSet ds = Common.Pager("UserInfo],[UserGroup", "UserInfo.*,UserGroup.Name as GroupName", "UserInfo.ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        AspNetPager1.CurrentPageIndex = pageindex;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("UserInfo],[UserGroup", "UserInfo.*,UserGroup.Name as GroupName", "RegistTime", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " UserGroup.ID=UserInfo.UserGroupID ";
        if(ddlUserGroup.SelectedValue!="0")
        {
            rtn += " and UserInfo.UserGroupID='" + ddlUserGroup.SelectedValue + "'";
        }
        if(txtKey.Text!="")
        {
            rtn += " and UserInfo.UserName like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(33))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        string strID = e.CommandArgument.ToString();
        string UserName = "double";
        if (e.CommandName == "pass")
        {
            if (Common.Update("UserInfo", "ID", strID, new string[] { "IsAvailible" }, new string[] { "1" }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        if (e.CommandName == "unpass")
        {
            if (Common.Update("UserInfo", "ID", strID, new string[] { "IsAvailible" }, new string[] { "2" }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        else if (e.CommandName == "del")
        {
            if (!Common.Delete("UserInfo", "ID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
            else
                show();
        }
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认激活吗？')";
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected void LinkCategory_Load3(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认废止吗？')";
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("User_edit.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        show(1);
    }
}
