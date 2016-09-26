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
using System.Security.Principal;

public partial class UserSysAdmin_TaskNote :SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(28))
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
            show();
        }
    }

    public void show(int pageindex)
    {
        /**************************************************************************************************************************/
        //找出所有该局使用系统的用户插入本地系统数据库中
        //原来是局用户--现改为域用户


        //SZMA.DataLayer.User.TXW_CYDADAL objUser = new SZMA.DataLayer.User.TXW_CYDADAL();
        //UserInfoDAL objUserInfo = new UserInfoDAL();
        //DataSet dsUser = objUser.selectAll(Common.rjsystem);
        //string condition = " and UserName in(";
        //for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
        //{
        //    condition += "'" + dsUser.Tables[0].Rows[i]["GH"].ToString() + "',";

        //}
        //condition = condition.TrimEnd(",".ToCharArray());
        //condition += ")";
        //CSrvUserValid.CSrvUserValid objSrv = new CSrvUserValid.CSrvUserValid();
        //CSrvUserValid.CUser[] Users = objSrv.GetUsers("7700", "0");//7700为系统首页权限号

        //int recUser;
        //DataSet dsSql = Common.Pager("UserInfo", "*", "ID", 1000, 1, true, " IsAvailible not in(0)", out recUser);
        //for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
        //{
        //    if (dsSql.Tables[0].Select("UserName='" + dsUser.Tables[0].Rows[i]["GH"].ToString() + "'").Length == 0)
        //    {
        //        objUserInfo.Insert(dsUser.Tables[0].Rows[i]["GH"].ToString(), dsUser.Tables[0].Rows[i]["XM"].ToString(), AdminUser.Username);
        //    }
        //}
        //int recUser;
        //DataSet dsSql = Common.Pager("UserInfo", "*", "ID", 1000, 1, true, " IsAvailible not in(0)", out recUser);
        //for (int i = 0; i < Users.Length; i++)
        //{
        //    if (dsSql.Tables[0].Select("UserName='" + Users[i].UserID + "'").Length == 0)
        //    {
        //        objUserInfo.Insert(Users[i].UserID, Users[i].Name, System.Environment.UserName);
        //    }
        //}
        /*************************************************************************************************************************/


        int recc,recc1;
        //DataSet ds = Common.Pager("UserInfo", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition() + condition, out recc);
        DataSet ds = Common.Pager("UserInfo", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        DataSet dsTask = Common.Pager("dict_task", "*", "ID", 100, 1, true, "", out recc1);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        DataTable dtList = new DataTable();
        dtList.Columns.Add("ID");
        dtList.Columns.Add("Username");
        dtList.Columns.Add("RealName");
        dtList.Columns.Add("TaskName");
        for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
        {
            dtList.Rows.Add(
                new object[] { ds.Tables[0].Rows[i]["ID"], ds.Tables[0].Rows[i]["UserName"], ds.Tables[0].Rows[i]["RealName"], getTastName(ds.Tables[0].Rows[i]["TaskID"].ToString(), dsTask) });
        }

        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        AspNetPager1.CurrentPageIndex = pageindex;
        gvList.DataSource = dtList;
        gvList.DataBind();
    }

    private object getTastName(string s, DataSet task)
    {
       string[] strs=  s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
       DataRow[] drs;
       string rtn = "";
        for(int i=0;i<strs.Length;i++)
        {
            drs = task.Tables[0].Select("id=" + strs[i]);
            if(drs.Length>0)
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
        string rtn = " IsAvailible not in(0)";
        if (txtKey.Text != "")
        {
            rtn += " and UserName like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;
        if (e.CommandName == "pass")
        {
            if (Common.Update("UserInfo", "ID", strID, new string[] { "IsAvailible" }, new string[] { "1" }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        if (e.CommandName == "unpass")
        {
            if (Common.Update("UserInfo", "ID", strID, new string[] { "IsAvailible" }, new string[] { "2" }))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        else if (e.CommandName == "del")
        {
            if (!Common.Delete("UserInfo", "ID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
            else
                show();
        }
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        show(1);
    }
}
