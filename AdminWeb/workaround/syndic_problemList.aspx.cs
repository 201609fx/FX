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

public partial class workaround_syndic_problemList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(null!=Request.QueryString["ID"])
            show();
            else
            {
                this.Response.Write("<script language='javascript'> alert('请指定一个父类型!!!');window.close();</script>");
            }
        }
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("Problem", "*", "OrderNum", AspNetPager1.PageSize, pageindex, false, Buildcondition(), out recc);
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
        string rtn = " InsertFlag =1 ";
        if (null != Request.QueryString["ID"])
        {
            rtn += "  and ProblemSortID=" + Request.QueryString["ID"];
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        string UserName = "double";
        bool rtn = true;
        ProblemDAL obj=new ProblemDAL();
       switch(e.CommandName)
       {case "del":
           rtn = obj.Delete( strID)>0;
               break;
           case "top":
               rtn = obj.Top(e.CommandArgument.ToString()) > 0;
               break;
           case "down":
               rtn = obj.Down(e.CommandArgument.ToString()) > 0;
               break;
           case "up":
               rtn = obj.Up(e.CommandArgument.ToString()) > 0;
               break;
           default:
               break;
               
     }
     if (rtn)
     {
         show();
     }
     else
     {
         this.Response.Write("<script language='javascript'>alert('操作失败')</script>");
     }
 
    }

    protected void LinkCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected string gettype(string strID)
    {
        string rtn = "";
        ProblemTypeDAL obj = new ProblemTypeDAL();
        rtn = obj.SelectNameByID(strID);
        return rtn;
    }


}
