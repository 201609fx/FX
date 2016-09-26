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

public partial class Introduction_Default :SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
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
        //if (!checkYUright(7701))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if(!IsPostBack)
        {
            Data_Init();
        }
    }
    protected void Data_Init()
    {
        SortDAL obj=new SortDAL();
        DataSet ds=obj.Select("机构简介");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ftbContent.Text = ds.Tables[0].Rows[0]["des"].ToString();
            ftbContent1.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
            lblID.Text = ds.Tables[0].Rows[0]["ID"].ToString();
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('数据库文件丢失!')</script>");
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
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
        SortDAL obj = new SortDAL();
        int rtn = obj.Update(ftbContent.Text, lblID.Text.Trim(), ftbContent1.Text);
        if(rtn<1)
        {
            this.Response.Write("<script language='javascript'> alert('更新失败!')</script>");
        }
       
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ftbContent.Text = "";
        ftbContent1.Text = "";
    }
}
