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

public partial class workaround_FirstCheck : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(6))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Check, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7713))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            tbxDataStart.Text = string.Format("{0:d}", DateTime.Now.AddMonths(-2));
            tbxDataEnd.Text = string.Format("{0:d}", DateTime.Now);
            show();
        }
    }
    public void show()
    {
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "*", "ID", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, true, Buildcondition(), out recc);

        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " state in(1,11,12) and InsertFlag not in(0)";
        if (null != Request.QueryString["TID"])
        {
            rtn += " and type=" + Request.QueryString["TID"];
        }
        if (txtKey.Text != "")
        {
            rtn += " and MainSCTemp.Company like '%" + txtKey.Text + "%'";
        }

        string ds = "";
        string de = "";
        try
        {
            ds = string.Format("{0:d}", Convert.ToDateTime(tbxDataStart.Text).AddDays(-1));
            de = string.Format("{0:d}", Convert.ToDateTime(tbxDataEnd.Text).AddDays(1));
        }
        catch (Exception)
        {
            tbxDataStart.Text = string.Format("{0:d}", DateTime.Now.AddMonths(-2).AddDays(-1));
            tbxDataEnd.Text = string.Format("{0:d}", DateTime.Now.AddDays(1));
            ds = tbxDataStart.Text.Trim();
            de = tbxDataEnd.Text.Trim();
        }
        rtn += " and  ModifiTime between  '" + ds + "' and '" + de + "' ";

        return rtn;
    }
    
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;
        if (!CheckAdminRight(7))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Check, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7714))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (e.CommandName == "pass")
        {
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state", "UserName" }, new string[] { "12", UserName }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        if (e.CommandName == "set")
        {
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state", "UserName" }, new string[] { "2", UserName }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        else if (e.CommandName == "unpass")
        {
            if (Common.Update("MainSCTemp", "ID", strID, new string[] { "state","UserName"}, new string[] { "11",UserName}))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
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
        AssessDAL aobj=new AssessDAL();
       int rtn= aobj.Insert(MID, ds.Tables[0].Rows[0]["ID"].ToString(),AdminUser.Username);
       if(rtn<1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!')</script>");
            return false;
        }
        return true;
    }
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认合格吗？')";
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认不合格吗？')";
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认完成吗？')";
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
