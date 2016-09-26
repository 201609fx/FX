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

public partial class workaround_Complain_History : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            show();
    }

    public string getCState(string state)
    {
        string rtn = "";
        switch (state)
        {
            case "0":
                rtn = "临时";
                break;
            case "1":
                rtn = "待确定";
                break;
            case "2":
                rtn = "立案";
                break;
            case "3":
                rtn = "结案";
                break;
            default:
                break;
        }
        return rtn;
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("complain", "*", "CreateTime", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public void show(int pageindex)
    {
        int recc;
        DataSet ds = Common.Pager("complain", "*", "CreateTime", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        AspNetPager1.CurrentPageIndex = pageindex;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " InsertFlag not in(0)  ";
        if (txtKey.Text != "")
        {
            rtn += " and (Complainer like '%" + txtKey.Text + "%'" + " or Name like '%" + txtKey.Text + "%'" + " or BComplainer like '%" + txtKey.Text + "%'" + " or CTel like '%" + txtKey.Text + "%'" + " or BCTel like '%" + txtKey.Text + "%')";
        }
        if(null!=Request.QueryString["id"]&&Request.QueryString["id"]!="")
        {
            rtn += " and BComplainer = '" + Request.QueryString["id"] + "'" ;
      
        }
        if (ddlState.SelectedIndex > 0)
        {
            rtn += " and InsertFlag ='" + ddlState.SelectedValue.Trim() + "'";
        }
        return rtn;
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("Complain_EditFirst.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        show(1);
    }
}
