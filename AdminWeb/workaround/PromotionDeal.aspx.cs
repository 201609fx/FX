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

public partial class workaround_PromotionDeal : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(14))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Deal, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7719))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
            show();
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "MainSCTemp.*,(select PromotionDeal.ID from  PromotionDeal where PromotionDeal.MainSCID=MainSCTemp.ID) as PromotionDealID", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);

        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSCTemp.state =4 and MainSCTemp.InsertFlag not in(0)  ";
        if (txtKey.Text != "")
        {
            rtn += " and MainSCTemp.Company like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(15))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Deal, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7720))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string strID = e.CommandArgument.ToString();
        string UserName = this.AdminUser.Username;
        if (e.CommandName == "pass")
        {
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state", "UserName" }, new string[] { "7", UserName }))
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
            PromotionDealDAL obj = new PromotionDealDAL();
            if (obj.Select(strID).Tables[0].Rows.Count>0)
            {
                show();
                return;
            }
            if (obj.InsertNull(strID,UserName) > 0)
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
            examineResultDAL obj = new examineResultDAL();
            if (Common.Delete("PromotionDeal","ID",strID))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认完成提交下一步吗？')";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }

}
