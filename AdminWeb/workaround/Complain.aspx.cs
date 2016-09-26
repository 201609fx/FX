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

public partial class workaround_Complain : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(26))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7727))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
            show();
    }
    
      public string  getCState(string state)
      {
          string rtn = "";
          switch(state)
          {
              case"0":
                  rtn = "临时";
                  break;
              case"1":
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
        if (ddlState.SelectedIndex>0)
        {
            rtn += " and InsertFlag ='"+ddlState.SelectedValue.Trim()+"'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        
        //if (!CheckRight(SZMA.BLL.Rights.szma_work, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7728))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;
        if (e.CommandName == "unpass")
        {
            if (!CheckAdminRight(28))
            {
                this.Response.Redirect("../NoRight.aspx");
                return;
            }
            if (Common.Update("complain", "ID", strID, new string[] { "InsertFlag", "UserName" }, new string[] { "1",UserName }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        if (e.CommandName == "passF")
        {
            if (!CheckAdminRight(28))
            {
                this.Response.Redirect("../NoRight.aspx");
                return;
            }
            if (Common.Update("complain", "ID", strID, new string[] { "InsertFlag", "UserName" }, new string[] { "2", UserName }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        if (e.CommandName == "passS")
        {
            if (!CheckAdminRight(29))
            {
                this.Response.Redirect("../NoRight.aspx");
                return;
            }
            if (Common.Update("complain", "ID", strID, new string[] { "InsertFlag", "UserName" }, new string[] { "3", UserName }))
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
            if (!CheckAdminRight(27))
            {
                this.Response.Redirect("../NoRight.aspx");
                return;
            }
            if (!Common.Delete("complain", "ID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
            else
                show();
        }
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认立案吗？')";
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected void LinkCategory_Load3(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认结案吗？')";
    }
    protected void LinkCategory_Load4(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认退回再立案吗？')";
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
