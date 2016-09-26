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

public partial class workaround_approve : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(16))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_approve, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}       
        //if (!checkYUright(7721))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
            show();
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "MainSCTemp.*,(select Approve.ID from Approve where MainSCTemp.ID=Approve.MainSCID) as ApproveID", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);


        AspNetPager1.RecordCount = recc;

        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSCTemp.state =5 and MainSCTemp.InsertFlag not in(0)  ";
        if (null != Request.QueryString["TID"])
        {
            rtn += " and MainSCTemp.type=" + Request.QueryString["TID"];
        }
        if(txtKey.Text!="")
        {
            rtn += " and MainSCTemp.Company like '%" + txtKey.Text +"%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        string UserName = this.AdminUser.Username;

        if (!CheckAdminRight(17))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_approve, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7722))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (e.CommandName == "pass")
        {
            ApproveDAL obj = new ApproveDAL();
            DataSet ds = obj.SelectByMID(strID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string CertNO =
                    getCertNO(ds.Tables[0].Rows[0]["CertNO"].ToString(), ds.Tables[0].Rows[0]["Type"].ToString(),
                              ds.Tables[0].Rows[0]["oldCertNO"].ToString(), strID);
            }
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state", "UserName" }, new string[] { "6", UserName }))
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
            ApproveDAL obj = new ApproveDAL();
            if (obj.SelectByMID(strID).Tables[0].Rows.Count > 0)
            {
                show();
                return;
            }
            if (obj.InsertNull(strID,UserName) < 1)
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");

            }
            else
                show();
        }
        else if (e.CommandName == "del")
        {
            if (!Common.Delete("approve", "MainSCID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
            else
            {
                if(!Common.Update("MainSCTemp", "ID", strID, new string[] {"CertNO"}, new string[] {""}))
                {
                    this.Response.Write("<script language='javascript'> alert('重置证书失败!')</script>");
                }
                show();
            }
        }
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
