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
using SZMA.Core;
using SZMA.DataLayer;

public partial class workaround_syndic : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(8))
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
        if(!IsPostBack)
        show();
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "MainSCTemp.*,(select assess.assessPlateID from assess where MainSCTemp.ID=assess.MainSCID) as assessPlateID,(select assess.ID from assess where MainSCTemp.ID=assess.MainSCID) as assessID", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);

        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSCTemp.state =2 and MainSCTemp.InsertFlag not in(0)  ";
        if (null != Request.QueryString["TID"])
        {
            rtn += " and MainSCTemp.type=" + Request.QueryString["TID"];
        }
        if (txtKey.Text != "")
        {
            rtn += " and MainSCTemp.Company like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(9))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndic, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7715))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string UserName = AdminUser.Username;
        string strID = e.CommandArgument.ToString();
        if (e.CommandName == "pass")
        {
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state", "UserName" }, new string[] { "3", UserName }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        else if (e.CommandName == "set")
        {
            if (setAsscee(strID))
            {
                show();
            }
        }
        else if (e.CommandName == "del")
        {
            AssessDAL obj=new AssessDAL();
            if (obj.delete(strID)>0)
            {
                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
                show();
            }
        }
    }
    protected bool setAsscee(string MID)
    {
        assessPlateDAL obj = new assessPlateDAL();
        DataSet ds = obj.SelectActive();
        if (ds.Tables[0].Rows.Count < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!没有一个激活的模版!')</script>");
            return false;
        }
        AssessDAL aobj = new AssessDAL();
        int rtn = 0;
        try
        {
            rtn = aobj.Insert(MID, ds.Tables[0].Rows[0]["ID"].ToString(),AdminUser.Username);
        }
        catch
        {
        }
        if (rtn < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!')</script>");
            return false;
        }
        return true;
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认完成吗？')";
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
      protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }
}
