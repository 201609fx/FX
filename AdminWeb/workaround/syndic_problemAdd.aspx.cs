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
using SZMA.BLL;

public partial class workaround_syndic_problemAdd : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = AdminUser.Username;
        ProblemDAL obj = new ProblemDAL();
        if (!IsPostBack)
        {
            if (null == Request.QueryString["sid"])
            {
                Response.Write("<script>");
                Response.Write("alert('请指定一个父类型!');");
                Response.Write("</script>");
                return;
            }
            if (null != Request.QueryString["ID"])
            {
                lblProblemID.Text = Request.QueryString["ID"];
                Data_init();
                plQuestion.Visible = true;
            }
            else
            {
                plQuestion.Visible = true;
               
                lblProblemID.Text = obj.InsertNull(Request.QueryString["sid"], UserName);
             
            }
        }  
        if(lblProblemID.Text=="")
        {
            lblProblemID.Text = obj.InsertNull(Request.QueryString["sid"], UserName);
        }
    }

    protected  void Data_init()
    {
        int recc;
        DataSet ds = Common.Pager("Problem", "*", "ID", 10, 1, true, "ID=" + lblProblemID.Text, out recc);
        if(ds.Tables[0].Rows.Count>0)
        {
            txtProblemContent.Text = ds.Tables[0].Rows[0]["ProblemContent"].ToString();
            txtTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            rdoltProblemType.SelectedValue = ds.Tables[0].Rows[0]["ProblemTypeID"].ToString();
        }
    }
    
    

    #region //问题update
    protected void btnUpdateProblem_Click(object sender, EventArgs e)
    {
        string id = lblProblemID.Text;
        lblProblemID.Text = "";
        string UserName = AdminUser.Username;
        if (id == string.Empty)
        {
            Response.Write("<script>");
            Response.Write("alert('请选择要更新的记录!');");
            Response.Write("</script>");
            return;
        }
        ProblemDAL obj=new ProblemDAL();
        int count =
            obj.Update( rdoltProblemType.SelectedValue, txtProblemContent.Text,Utility.getVal( txtTotle.Text),
                       txtRemark.Text, UserName, id);
        if (count > 0)
        {
            Response.Write("<script>");
            Response.Write("alert('操作成功!');");
            Response.Write(" parent.window.document.getElementById('FrameProblem').style.display='none';parent.location.href=parent.location.href;");
            Response.Write("</script>");
            
        }
    }
    #endregion

    #region //问题delete
    protected void btnDeleteProblem_Click(object sender, EventArgs e)
    {
        string id = lblProblemID.Text;

        //if (id == string.Empty)
        //{
        //    Response.Write("<script>");
        //    Response.Write("alert('请选择要删除的记录!');");
        //    Response.Write("</script>");
        //    return;
        //}

        //if (Common.Delete("Problem", "ID", id))
        //{
        //    Response.Write("<script>");
        //    Response.Write("alert('删除成功!');");
        //    Response.Write("</script>");
        //    lblProblemID.Text = string.Empty;
        //    txtProblemContent.Text = string.Empty;
        //    getData();
        //}
        this.Response.Write("<script language=javascript>parent.location.href=parent.location.href;</script>");
    }
    #endregion

}
