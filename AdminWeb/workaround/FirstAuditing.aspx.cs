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

public partial class workaround_Default : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(4))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_First, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7711))
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
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
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
        string rtn = "";
        if (null != Request.QueryString["TID"])
        {
            rtn += " state=0 and type=" + Request.QueryString["TID"] + " and InsertFlag not in(0,4)";
        }
        else
        {
            rtn += " state=0 and type=1 and InsertFlag not in(0)";
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
        rtn += " and  ModifiTime between  '" + ds + "' and '"+de+"' ";



        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(5))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_First, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7712))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;
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
    protected void LinkCategorydel_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认通过吗？')";
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
            default:
                break;
        }
        return rtn;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }

}
