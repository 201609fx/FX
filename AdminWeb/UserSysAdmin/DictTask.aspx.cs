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

public partial class UserSysAdmin_DictTask : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(28))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_see))
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
            show();
        }
    }

    public void show(int pageindex)
    {
        int recc;
        DataSet ds = Common.Pager("dict_task],[UserRights", "dict_task.*,UserRights.Description", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);


        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }

    private object getTastName(string s, DataSet task)
    {
        string[] strs = s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        DataRow[] drs;
        string rtn = "";
        for (int i = 0; i < strs.Length; i++)
        {
            drs = task.Tables[0].Select("id=" + strs[i]);
            if (drs.Length > 0)
            {
                rtn += " [" + drs[0][2].ToString() + "]";//dict_task.des
            }
        }
        return rtn;
    }

    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        show(pageindex);
    }
    public string Buildcondition()
    {
        string rtn = " dict_task.rightID=UserRights.RightID ";
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;
        if (!CheckAdminRight(29))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7730))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
}
