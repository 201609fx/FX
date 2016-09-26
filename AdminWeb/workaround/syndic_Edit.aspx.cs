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
public partial class workaround_syndic_Edit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(9))
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
        btnSubmit.OnClientClick = "return confirm('您确定要保存操作吗?')";
        if(!IsPostBack)
        {
            data_init();
        }
        
    }

    private void data_init()
    {
        AssessDAL obj=new AssessDAL();
        DataSet ds=obj.SelectByID(Request.QueryString["id"]);
        if(ds.Tables[0].Rows.Count>0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblNO.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            lblTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            txtSyndic.Text = ds.Tables[0].Rows[0]["PSUserName"].ToString();
            dpPStime.Date = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        AssessDAL aobj=new AssessDAL();
        aobj.Update(txtSyndic.Text, getDate(dpPStime.Date), Request.QueryString["id"]);
        this.Response.Redirect("syndic.aspx");
    }
    
    
    protected DateTime getDate(string dt)
    {
        DateTime rtn=new DateTime(0);
        try
        {
            rtn = DateTime.Parse(dt);
        }
        catch
        {
        }
        return rtn;
    }
    
    protected string getTime(string DS)
    {
        string rtn = "";
        try
        {
            rtn=DateTime.Parse(DS).ToString("yyyy/MM/dd");
        }
        catch
        {
        }
        return rtn;
    }
}
