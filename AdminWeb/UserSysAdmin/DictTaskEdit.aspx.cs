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

public partial class UserSysAdmin_DictTaskEdit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!CheckAdminRight(29))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7730))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            if(null!=Request.QueryString["id"]&&Request.QueryString["id"]!="")
            show();
        }
    }

    public void show()
    {
        int recc;
        DataSet ds = Common.Pager("dict_task],[UserRights", "dict_task.*,UserRights.Description", "dict_task.ID", 100, 1, true, " dict_task.rightID=UserRights.RightID and  dict_task.ID='" + Request.QueryString["id"] + "'", out recc);
        if(recc>0)
        {
            lblDes.Text = ds.Tables[0].Rows[0]["des"].ToString();
            lblDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            txtDateNum.Text = ds.Tables[0].Rows[0]["DateNum"].ToString();
        }
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(29))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        int DateNum = 1;
        string UserName = AdminUser.Username;
        try
        {
            DateNum = int.Parse(txtDateNum.Text);
        }
        catch
        {
            this.Response.Write("<script language='javascript'>alert('请输入一个数字!')</script>");
            return;
        }
        DictTaskDAL obj=new DictTaskDAL();
        if(obj.Update(DateNum, DateTime.Now, UserName, Request.QueryString["id"])<1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("DictTask.aspx");
    }
}
