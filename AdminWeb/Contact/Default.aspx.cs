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

public partial class Contact_Default : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(6))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_concact, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7705))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}

            if (!IsPostBack)
            {
                Data_Init();
            }
     
    }
    protected void Data_Init()
    {
        int recc;
        DataSet ds =
            Common.Pager("News", "*", "ID", 1, 1, true,
                         " ID='1'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ftbContent.Text = ds.Tables[0].Rows[0]["Content"].ToString();
            ftbContent1.Text = ds.Tables[0].Rows[0]["Abstract"].ToString();
            ftbContent2.Text = ds.Tables[0].Rows[0]["Refer"].ToString();
            lblID.Text = ds.Tables[0].Rows[0]["ID"].ToString();
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('数据库文件丢失!')</script>");
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(6))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_concact, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7706))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        NewsDAL obj = new NewsDAL();
        int rtn = obj.UpdateByID("联系我们", ftbContent1.Text, "", "", ftbContent2.Text,
                        ftbContent.Text, 1, AdminUser.Username, DateTime.Now, lblID.Text);
        if (rtn < 1)
        {
            this.Response.Write("<script language='javascript'> alert('更新失败!')</script>");
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ftbContent.Text = "";
        ftbContent1.Text = "";
        ftbContent2.Text = "";
    }
}
