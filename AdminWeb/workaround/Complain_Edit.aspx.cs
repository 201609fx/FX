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
public partial class workaround_Complain_Edit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(27))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
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
        btnSubmit.OnClientClick = "return confirm('您确定要保存操作吗?')";
        if (!IsPostBack)
        {
            data_init();
        }

    }

    private void data_init()
    {
        ComplainerDAL obj = new ComplainerDAL();
        DataSet ds = obj.SelectByID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblcontent.Text = ds.Tables[0].Rows[0]["content"].ToString();
            lblComplainer.Text = ds.Tables[0].Rows[0]["Complainer"].ToString();
            lblTel.Text = ds.Tables[0].Rows[0]["Ctel"].ToString();
            lblCaddresstou.Text = ds.Tables[0].Rows[0]["Caddresstou"].ToString();
            lblBCTel.Text = ds.Tables[0].Rows[0]["BCTel"].ToString();
            lblBContact.Text = ds.Tables[0].Rows[0]["BContact"].ToString();
            lblBComplainer.Text = ds.Tables[0].Rows[0]["BComplainer"].ToString();
            lblBAddress.Text = ds.Tables[0].Rows[0]["BAddress"].ToString();
            lblCTime.Text = getTime(ds.Tables[0].Rows[0]["CTime"].ToString());
            lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblType.Text = getType(ds.Tables[0].Rows[0]["Type"].ToString());
            txtLeader.Text = ds.Tables[0].Rows[0]["Leader"].ToString();
            txtsuggest.Text = ds.Tables[0].Rows[0]["suggest"].ToString().Replace("<br>","\t\n");
            txtResult.Text = ds.Tables[0].Rows[0]["suggest"].ToString().Replace("<br>", "\t\n");
            txtsuggester.Text = ds.Tables[0].Rows[0]["suggester"].ToString();
            txtLSuggest.Text = ds.Tables[0].Rows[0]["LSuggest"].ToString().Replace("<br>", "\t\n");
            txtLSuggest1.Text = ds.Tables[0].Rows[0]["LSuggest1"].ToString().Replace("<br>", "\t\n");
            txtLeader1.Text = ds.Tables[0].Rows[0]["Leader1"].ToString();
            dpLTime.Date = getTime(ds.Tables[0].Rows[0]["LSTime"].ToString());
            dpLTime1.Date = getTime(ds.Tables[0].Rows[0]["LSTime1"].ToString());
        }
    }


    public string getType(string state)
    {
        string rtn = "";
        switch (state)
        {
            case "0":
                rtn = "未确定";
                break;
            case "1":
                rtn = "电话";
                break;
            case "2":
                rtn = "网上";
                break;
            case "3":
                rtn = "现场";
                break;
            default:
                break;
        }
        return rtn;
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
    protected void btnPass_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(28))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        string UserName = AdminUser.Username;
        ComplainerDAL obj = new ComplainerDAL();
        if (!Common.Update("complain", "ID", Request.QueryString["id"], new string[] { "InsertFlag", "UserName" }, new string[] { "2", UserName }))
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("Complain.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(27))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        string UserName = AdminUser.Username;
        ComplainerDAL obj = new ComplainerDAL();
        if (obj.UpdateSecond(txtsuggest.Text.Replace("\r\n","<br>"),txtsuggester.Text,getDate(dpSTime.Date),txtResult.Text.Replace("\r\n","<br>"),
                             txtLeader.Text,txtLSuggest.Text.Replace("\r\n","<br>"),getDate(dpLTime.Date),txtLeader1.Text,
                             txtLSuggest1.Text.Replace("\r\n","<br>"),getDate(dpLTime1.Date),3,Request.QueryString["id"],UserName)< 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("approve.aspx");
    }
}
