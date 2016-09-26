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

public partial class workaround_syndic_checkPlateEdit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(11))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndic, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7716))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            if (null == Request.QueryString["id"] || Request.QueryString["id"]=="")
            {
                string id = Common.Insert("assessPlate", "InsertFlag", "CreateTime");
                this.Response.Redirect("syndic_checkPlateEdit.aspx?id=" + id);
            }
            InvestigateDataBind();
            getData();
        }
    }

    #region //调查数据读取
    private void InvestigateDataBind()
    {
        assessPlateDAL obj=new assessPlateDAL();
        DataSet ds = obj.SelectByID(Request.QueryString["id"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtDes.Text = ds.Tables[0].Rows[0]["Des"].ToString();
            rblState.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();

        }
    }
    #endregion

    #region //调查项目保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        assessPlateDAL obj = new assessPlateDAL();
        string UserName = AdminUser.Username;
        int count = obj.Update(txtDes.Text, UserName, rblState.SelectedValue, 1,DateTime.Now, Request.QueryString["ID"]);
        if (count > 0)
        {
            Response.Write("<script>");
            Response.Write("alert('操作成功!');");
            Response.Write("</script>");
            getData();

        }
    }
    #endregion

    #region //列表数据绑定
    private void getData()
    {
        ProblemSortDAL obj = new ProblemSortDAL();
        DataSet ds = obj.SelectByAssessID(Request.QueryString["id"].ToString());
        rptProblemSort.DataSource = ds;
        rptProblemSort.DataBind();
    }
    #endregion


    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Write("<script language=javascript>window.location.href='workaround/syndic_checkPlate.aspx';</script>");
    }
    protected void rptProblemSort_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        bool rtn=true;
        ProblemSortDAL obj = new ProblemSortDAL();
       switch(e.CommandName)
       {
         case "del":
             rtn = obj.Delete( e.CommandArgument.ToString())>0;
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
        if(rtn)
        {
            getData();
        }
        else
        {
            this.Response.Write("<script language='javascript'>alert('操作失败')</script>");
        }
    }
    protected void rptProblemSort_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Repeater rptSProblemSort = e.Item.FindControl("rptSProblemSort") as Repeater;
            DataRowView drv = (DataRowView)e.Item.DataItem;
            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet ds = obj.SelectSecond(drv["ID"].ToString());
            rptSProblemSort.DataSource = ds.Tables[0].DefaultView;
            rptSProblemSort.DataBind();
        }
        catch(Exception e1)
        {
        }
   
    }
    protected void rptSProblemSort_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Repeater rptTProblemSort = e.Item.FindControl("rptTProblemSort") as Repeater;
            DataRowView drv = (DataRowView)e.Item.DataItem;
            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet ds = obj.SelectSecond(drv["ID"].ToString());
            rptTProblemSort.DataSource = ds.Tables[0].DefaultView;
            rptTProblemSort.DataBind();
        }
        catch (Exception e1)
        {
        }

    }
    protected void  LinkCategory_Load(object sender,EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
}
