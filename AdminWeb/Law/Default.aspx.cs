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

public partial class Law_Default : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {

        
        
        if(!IsPostBack)
        {
            show();
            Data_Init();
        }
    }
    private void Data_Init()
    {
        if (null != Request.QueryString["PID"])
        {
            switch (Request.QueryString["PID"])
            {
                case "1":
                    lblSortName.Text = "机构介绍";
                    if (!CheckAdminRight(1))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_Int, Common.opt_see))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7701))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}

                    break;
                case "2":
                    lblSortName.Text = "政策法规";
                    if (!CheckAdminRight(2))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_law, Common.opt_see))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7707))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                case "3":
                    if (!CheckAdminRight(2))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_see))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7709))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    lblSortName.Text = "公告";
                    break;
                case "4":
                    if (!CheckAdminRight(1))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_see))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7703))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    lblSortName.Text = "办证指南";
                    break;
                default:
                    break;
            }
        }
    }

    public  void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
     
        int recc;
        DataSet ds = Common.Pager("News", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(),out recc);
        int pagecount = recc % AspNetPager1.PageSize>0
                            ? ((int) (recc/AspNetPager1.PageSize)) + 1
                            : (int) (recc/AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " insertFlag='1' ";
        if(null!=Request.QueryString["PID"])
        {
            rtn += "  and SortID='" + Request.QueryString["PID"].Trim() + "'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (null != Request.QueryString["PID"])
        {
            switch (Request.QueryString["PID"])
            {
                case "1":
                    if (!CheckAdminRight(1))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_Int, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7702))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}

                    break;
                case "2":
                    if (!CheckAdminRight(3))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_law, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7708))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                case "3":
                    if (!CheckAdminRight(3))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7710))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                case "4":
                    if (!CheckAdminRight(1))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7704))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                default:
                    break;
            }
        }
        string strID = e.CommandArgument.ToString();
        if(e.CommandName=="edit1")
        {
            this.Response.Redirect("NewsEdit.aspx?id=" + strID);
        }
        else if(e.CommandName=="del1")
        {
           if( Common.Delete("News", "ID", strID))
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

    protected void LinkCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }

    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
}
