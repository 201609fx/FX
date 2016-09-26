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

public partial class UserSysAdmin_TaskNateEdit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(29))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Task, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7729))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            if(null!=Request.QueryString["id"]&&Request.QueryString["id"]!="")
            Data_bind();
            Data_init();
        }
    }

    private void Data_init()
    {
        UserInfoDAL obj = new UserInfoDAL();
        DataSet ds = obj.SelectByID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
        }
    }

    private void Data_bind()
    {
        DictTaskDAL obj = new DictTaskDAL();
        DataSet ds = obj.SelectByUserID(Request.QueryString["id"]);
        dlList.DataSource = ds;
        dlList.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(29))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Task, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7729))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string CheckUser = AdminUser.Username;
        UserInfoDAL obj = new UserInfoDAL();
        if (txtUserName.Text == "")
        {
            this.Response.Write("<script language='javascript'> alert('请输入用户名!')</script>");
            return;
        }
        string taskID = "";
        for(int i=0;i<dlList.Items.Count;i++)
        {
            if(dlList.Items[i].ItemType==ListItemType.Item||dlList.Items[i].ItemType==ListItemType.AlternatingItem)
            {
                string s = "";
                CheckBox cb = dlList.Items[i].FindControl("chk") as CheckBox;
                if(cb.Checked)
                {
                    s = cb.Text;
                    s = s.Substring(s.IndexOf("[") + 1, s.IndexOf("]")-s.IndexOf("[")-1);
                    taskID += s+",";
                }
                
            }
        }
        if (obj.Update(DateTime.Now, CheckUser, taskID, Request.QueryString["id"]) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("TaskNote.aspx");
    }
}
