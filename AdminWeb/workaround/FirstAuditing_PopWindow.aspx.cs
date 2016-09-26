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

public partial class workaround_FirstAuditing_PopWindow : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(5))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_First, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7711))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        btnOK.OnClientClick = "return confirm('确定退回吗?')";
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(5))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_First, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7712))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if(null!=Request.QueryString["mid"])
        {
            string UserName = "";
            bool rtn=Common.Update("MainSCTemp", "ID", Request.QueryString["mid"], new string[] { "suggest", "InsertFlag", "checkUser", "checkTime"},
                          new string[] { txtSummary.Text.Trim().Replace("\r\n", "<br\\>"), "2", UserName, DateTime.Now.ToString("g") });
            if(rtn)
            {

                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
                this.Response.Write("<script language='javascript'> window.opener.location.href='FirstAuditing.aspx?tid=" + Request.QueryString["tid"] + "';window.close();</script>");
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
            
        }
    }
}
