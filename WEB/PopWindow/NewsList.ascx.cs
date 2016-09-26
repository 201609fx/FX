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

public partial class PopWindow_NewsList : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (null != Request.QueryString["PID"] && Request.QueryString["PID"] != "")
            {
                if (null == Request.QueryString["search"] || Request.QueryString["PID"] != "true")
                {
                    Data_init();
                    show();
                }
                else if (null != Request.QueryString["search"] && Request.QueryString["PID"] == "true")
                {
                    Data_init();
                    show(1);
                }
            }
            else
            {
                lblSortName.Text = "参数错误";
            }
                
          
        }
    }
    protected void Data_init()
    {
        switch (Request.QueryString["PID"])
        {
            case "1":
                lblSortName.Text = "机构介绍";
                break;
            case "2":
                lblSortName.Text = "政策法规";
                break;
            case "3":
                lblSortName.Text = "公告栏";
                break;
            default:
                return;
                break;
        }
        show();
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("News", "*", "ID", AspNetPager1.PageSize, pageindex, true,
                         Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        rptList.DataSource = ds;
        rptList.DataBind();
    }

    public string Buildcondition()
    {
        string rtn = " InsertFlag=1 and IsSys not in(1) ";
        if (null != Request.QueryString["PID"])
        {
            rtn += " and SortID='" + Request.QueryString["PID"] + "'";
        }
        if (null != Request.QueryString["key"])
        {
            rtn += " and Title like '%" + Request.QueryString["key"] + "%' ";
        }
        //if (txtKey.Text.Trim() != "")
        //{
        //    rtn += " and Title like '%" + txtKey.Text.Trim() + "%' ";
        //}
        return rtn;
    }
    public void show(int pageindex)
    {
        int recc;
        DataSet ds = Common.Pager("News", "*", "ID", AspNetPager1.PageSize, pageindex, true,
                         Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        rptList.DataSource = ds;
        rptList.DataBind();
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    show(1);
    //}
}
