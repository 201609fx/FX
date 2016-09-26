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

public partial class Notes_Default : SZMA.Core.Admin.PageBase
{
    int obj_id;
    protected void Page_Load(object sender, EventArgs e)
    {
            show();
            Data_Init();
    }

    private void Data_Init()
    {
        if (null != Request.QueryString["PID"])
        {
            switch (Request.QueryString["PID"])
            {
                case "1":
                    lblSortName.Text = "机构介绍";

                    if (!CheckRight(SZMA.BLL.Rights.szma_Int, Common.opt_see))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }

                    break;
                case "2":
                    lblSortName.Text = "政策法规";
                    if (!CheckRight(SZMA.BLL.Rights.szma_law, Common.opt_see))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    break;
                case "3":
                    if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_see))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    lblSortName.Text = "公告";
                    break;
                default:
                    break;
            }
        }
    }

    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;

        int recc;
        DataSet ds = Common.Pager("News", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
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
        if (null != Request.QueryString["PID"])
        {
            rtn = " SortID='" + Request.QueryString["PID"].Trim() + "'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_ma))
        {
            this.Response.Redirect("../NoRight.aspx");
        }
        string strID = e.CommandArgument.ToString();
        if (e.CommandName == "edit1")
        {
            this.Response.Redirect("NewsEdit.aspx?id=" + strID);
        }
        else if (e.CommandName == "del1")
        {
            int recc = 0;
            DataSet ds = Common.Pager("News", "*", "ID", 12, 1, true, "ID='" + strID + "'", out recc);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["IsSys"]=="1")
            {
                this.Response.Write("<script language='javascript'> alert('无法删除系统保留公告!')</script>");
                return;
            }
            if (Common.Delete("News", "ID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除成功!')</script>");
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
        }
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
}
