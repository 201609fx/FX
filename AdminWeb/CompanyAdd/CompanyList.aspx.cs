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

public partial class CompanyAdd_CompanyList : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!CheckAdminRight(22))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7731))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            show();
        }
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);

        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = "";
        if (null != Request.QueryString["TID"])
        {
            rtn += " state=0 and type=" + Request.QueryString["TID"] + " and MainSCTemp.Company is not null";
        }
        else
        {
            rtn += " MainSCTemp.Company is not null";
        }
        if (txtKey.Text != "")
        {
            rtn += " and MainSCTemp.Company like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;

        if (!CheckAdminRight(23))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7732))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (e.CommandName == "pass")
        {
           
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state", "checkUser", "InsertFlag" }, new string[] { "1", UserName, "3" }))
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
            if (!Common.Delete("MainSCTemp", "ID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
            else
            {
                show();
            }
        }
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认通过吗？')";
    }
    protected void LinkCategorydel_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected string getFlag(string Flag)
    {//0为申请；1为初审；2为评审；3为结论；4为通知；5为待领证
        string rtn = "";
        switch (Flag)
        {
            case "0":
                rtn = "临时";
                break;
            case "1":
                rtn = "待审核";
                break;
            case "2":
                rtn = "退回";
                break;
            case "3":
                rtn = "通过";
                break;
            case "4":
                rtn = "保存";
                break;
            default:
                break;
        }
        return rtn;
    }
    protected string getType(string Type)
    {
        switch (Type)
        {
            case"1":
                return "初次申请";
                break;
            case"2":
                return "晋级申请";
                break;
            default:
                return "";
                break;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }

}