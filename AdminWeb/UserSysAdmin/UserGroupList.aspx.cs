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

public partial class UserSysAdmin_UserGroupList : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!CheckAdminRight(30))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        if (!IsPostBack)
            show();
    }


    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("UserGroup", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
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
        string rtn = " InsertFlag=1";
        if (txtKey.Text != "")
        {
            rtn += " and Name like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string[] strNum =
        e.CommandArgument.ToString().Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
        string UserName = AdminUser.Username;
        if (e.CommandName == "del")
        {
            if (strNum[1] == "0")
            {
                if (!Common.Delete("UserGroup", "ID", strNum[0]))
                {
                    this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
                }
                else
                    show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('系统保留用户组无法删除!')</script>");
            }
        }
    }

    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("UserGroup_edit.aspx");
    }


    public void show(int pageindex)
    {
        int recc;
        DataSet ds = Common.Pager("UserGroup", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        AspNetPager1.CurrentPageIndex = pageindex;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        show(1);
    }
}
