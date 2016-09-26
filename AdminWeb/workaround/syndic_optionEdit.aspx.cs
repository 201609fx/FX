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

public partial class workaround_syndic_optionEdit : SZMA.Core.Admin.PageBase
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
            ProblemInfoInit();
            getData();
        }
    }

    #region //处理问题信息
    private void ProblemInfoInit()
    {
        ProblemDAL obj=new ProblemDAL();
        DataSet ds = obj.SelectByID(Request.QueryString["id"].Trim());
        lblProblemInfo.Text = ds.Tables[0].Rows[0]["ProblemContent"].ToString();
        lblProblemInfo.Text += "（题目类型：" + ds.Tables[0].Rows[0]["TypeName"].ToString() + "）";
        if (ds.Tables[0].Rows[0]["ProblemTypeID"].ToString() != "5" && ds.Tables[0].Rows[0]["ProblemTypeID"].ToString() != "6" && ds.Tables[0].Rows[0]["ProblemTypeID"].ToString() != "3")
        {
            rdoltIsWrite.SelectedValue = "0";
            plIsCheck.Visible = false;
            lblTishi.Visible = false;
        }
        else
        {
            rdoltIsWrite.SelectedValue = "1";
            plIsCheck.Visible = true;
            lblTishi.Visible = true;
        }
    }
    #endregion

    #region //列表数据绑定
    private void getData()
    {
        OptionDAL obj=new OptionDAL();
        DataSet ds = obj.Select(Request.QueryString["id"].ToString());
        gdvOption.DataSource = ds;
        gdvOption.DataBind();
    }
    #endregion

    #region //列表删除事件
    protected void gdvOption_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        OptionDAL obj = new OptionDAL(); 
        string id = gdvOption.DataKeys[e.RowIndex].Value.ToString();
        if (obj.Delete(id) > 0)
        {
            Response.Write("<script>");
            Response.Write("alert('删除成功!');");
            Response.Write("</script>");
            getData();
        }
    }
    #endregion

    #region //删除确定
    protected void gdvOption_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Controls.Count > 0)
            {
                //删除确认        
                LinkButton delBttn = (LinkButton)e.Row.Cells[5].Controls[0];
                delBttn.Attributes.Add("onclick", "javascript:return confirm('确定删除[ " + e.Row.Cells[1].Text + " ]?');");
            }
        }
    }
    #endregion

    #region //列表选择事件
    protected void gdvOption_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        OptionDAL obj=new OptionDAL();
        gdvOption.Rows[e.NewSelectedIndex].BackColor = System.Drawing.Color.LightGray;
        lblOptionID.Text = gdvOption.DataKeys[e.NewSelectedIndex].Value.ToString();
        DataSet ds = obj.SelectByID(lblOptionID.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtOptionContent.Text = ds.Tables[0].Rows[0]["OptionContent"].ToString();
            rdoltIsWrite.SelectedValue = ds.Tables[0].Rows[0]["IsWrite"].ToString();
        }
    }
    #endregion

    #region //列表翻页事件
    protected void gdvOption_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvOption.PageIndex = e.NewPageIndex;
        getData();
    }
    #endregion

    #region //问题Add
    protected void btnAddOption_Click(object sender, EventArgs e)
    {
        string UserName = AdminUser.Username;
        OptionDAL obj = new OptionDAL();
        int count = obj.Insert(Request.QueryString["id"].ToString(), txtOptionContent.Text, rdoltIsWrite.SelectedValue, UserName);
        if (count > 0)
        {
            getData();
            txtOptionContent.Text = "";
        }
    }
    #endregion

    #region //问题update
    protected void btnUpdateOption_Click(object sender, EventArgs e)
    {
        string id = lblOptionID.Text;
        string UserName = AdminUser.Username;
        OptionDAL obj=new OptionDAL();

        if (id == string.Empty)
        {
            Response.Write("<script>");
            Response.Write("alert('请选择要更新的记录!');");
            Response.Write("</script>");
            return;
        }

        int count = obj.Update(txtOptionContent.Text, rdoltIsWrite.SelectedValue, UserName,  id);
        if (count > 0)
        {
            Response.Write("<script>");
            Response.Write("alert('更新成功!');");
            Response.Write("</script>");
            getData();
            txtOptionContent.Text = "";
        }
    }
    #endregion


    #region //上下移动
    protected void gdvOption_RowCommand(object source, GridViewCommandEventArgs e)
    {
        OptionDAL obj = new OptionDAL();
        switch (e.CommandName)
        {
            case "up":
                obj.Up(e.CommandArgument.ToString());
                break;
            case "down":
                obj.Down(e.CommandArgument.ToString());
                break;
            case "top":
                obj.Top(e.CommandArgument.ToString());
                break;
       
            default:
                break;
        }
        getData();
    }
    #endregion
}
