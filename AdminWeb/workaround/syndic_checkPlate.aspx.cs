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

public partial class workaround_syndic_checkPlate : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(10))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndic, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7715))
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
        DataSet ds = Common.Pager("assessPlate", "*", "ModifiTime", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);

        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " InsertFlag=1 ";
        return rtn;
    }

    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(11))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndic, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7716))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string strID = e.CommandArgument.ToString();
        assessPlateDAL obj=new assessPlateDAL();
        string UserName = AdminUser.Username;
        if (e.CommandName == "pass")
        {
            if (obj.UpdateState(strID,UserName)>0)
            {
                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        else if (e.CommandName == "unpass")
        {
            if (obj.StopState(strID,UserName)>0)
            {
                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
    }

    protected void LinkCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认激活吗？')";
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认停用吗？')";
    }
    protected  string getPState(string state)
    {
        string rtn = "";
        switch(state)
        {
            case"0":
                rtn = "编辑";
                break;
            case "1":
                rtn = "激活";
                break;
            case "2":
                rtn = "作废";
                break;
            default:
                break;
               
        }
        return rtn;
    }
    
    
}
