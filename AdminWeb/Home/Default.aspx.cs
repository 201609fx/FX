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

public partial class Home_Default : SZMA.Core.Admin.PageBase
{
    int obj_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!checkYUright(7700))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        show();
    }

    public void show()
    {

        int recc;
        TaskDAL obj=new TaskDAL();
        DataSet ds = obj.Select("'1','2','3'","'0','1','2','3','4','5','6','11'");


        DataTable dt;
        dt=getDT(ds);
        AspNetPager1.RecordCount = dt.Rows.Count;
        lblNum.Text = "共" + dt.Rows.Count + "条，分" + ((int)(AspNetPager1.RecordCount / AspNetPager1.PageSize) + AspNetPager1.RecordCount%AspNetPager1.PageSize>0?1:0).ToString() + "页显示。";
        gvList.DataSource = dt;
        gvList.DataBind();
    }

    private DataTable getDT(DataSet ds)
    {
        TaskDAL obj = new TaskDAL();
        //string UserName = "double";此处需改为当前用户
        string UserName = AdminUser.Username;
        //string UserName = System.Environment.UserName;

        DataSet dsDictTask = obj.SelectByUser(UserName);
        DataTable dt = new DataTable();
        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            dt.Columns.Add(ds.Tables[0].Columns[i].ColumnName);
        
        DataRow[] drs;

        for (int i = 0; i < dsDictTask.Tables[0].Rows.Count; i++)
        {
            drs =
                ds.Tables[0].Select(
                    String.Format("Flag='{0}' and ModifiTime<'{1:d}' and state in('{2}') and Type in( '{3}')", dsDictTask.Tables[0].Rows[i]["Flag"].ToString(),
                                  DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-(1)), dsDictTask.Tables[0].Rows[i]["State"].ToString(),
                                  dsDictTask.Tables[0].Rows[i]["Type"].ToString()));
            for (int j = drs.Length-1; j >=0 ; j--)
                dt.Rows.Add(drs[j].ItemArray);
        }
        return dt;
    }

    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        if (e.CommandName == "edit1")
        {
            this.Response.Redirect("NewsEdit.aspx?id=" + strID);
        }
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    //protected string getUrl(string flag, string state, string strType)
    //{
    //    string rtn = "";
    //    SZMA.DataLayer.User.SECU_OBJDAL obj = new SZMA.DataLayer.User.SECU_OBJDAL();
    //    if (flag == "0")
    //    {
    //        switch (state)
    //        {
    //            case "0":
    //                rtn = "../workaround/FirstAuditing.aspx?tid=" + strType + "&sid=" + obj.selectObjIDbyUrl("workaround/FirstAuditing.aspx");
    //                break;
    //            case "1":
    //                rtn = "../workaround/FirstCheck.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/FirstCheck.aspx");
    //                break;
    //            case "11":
    //                rtn = "../workaround/FirstCheck.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/FirstCheck.aspx");
    //                break;
    //            case "12":
    //                rtn = "../workaround/FirstCheck.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/FirstCheck.aspx");
    //                break;
    //            case "2":
    //                rtn = "../workaround/syndic.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/syndic.aspx");
    //                break;
    //            case "3":
    //                rtn = "../workaround/Result.aspx" + "&sid=" + obj.selectObjIDbyUrl("workaround/Result.aspx");
    //                break;
    //            case "4":
    //                rtn = "../workaround/PromotionDeal.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/PromotionDeal.aspx");
    //                break;
    //            case "5":
    //                rtn = "../workaround/lastApprove.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/lastApprove.aspx");
    //                break;
    //            case "6":
    //                rtn = "../CertNO/default.aspx?" + "&sid=" + obj.selectObjIDbyUrl("CertNO/default.aspx");
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    else
    //        if (flag == "1")
    //        {
    //            rtn = "../workaround/Complain.aspx?" + "&sid=" + obj.selectObjIDbyUrl("workaround/Complain.aspx");
    //        }
    //    return rtn;
    //}
    protected string getUrl(string flag, string state, string strType)
    {
        string rtn = "";
        if (flag == "0")
        {
            switch (state)
            {
                case "0":
                    rtn = "../workaround/FirstAuditing.aspx?tid=" + strType;
                    break;
                case "1":
                    rtn = "../workaround/FirstCheck.aspx";
                    break;
                case "11":
                    rtn = "../workaround/FirstCheck.aspx";
                    break;
                case "12":
                    rtn = "../workaround/FirstCheck.aspx";
                    break;
                case "2":
                    rtn = "../workaround/syndic.aspx";
                    break;
                case "3":
                    rtn = "../workaround/Result.aspx";
                    break;
                case "4":
                    rtn = "../workaround/PromotionDeal.aspx";
                    break;
                case "5":
                    rtn = "../workaround/approve.aspx";
                    break;
                case "6":
                    rtn = "../CertNO/default.aspx";
                    break;
                default:
                    break;
            }
        }
        else
            if (flag == "1")
            {
                rtn = "../workaround/Complain.aspx";
            }
        return rtn;
    }
    protected string getState(string flag, string state, string strType)
    {
        string rtn = "";
        if (flag == "0")
        {
            switch (state)
            {
                case "0":
                    if (strType=="1")
                    rtn = "网上申请初审";
                    else

                    if (strType == "2")
                        rtn = "网上晋级申请初审";
                    break;
                case "1":
                    rtn = "书面资料审核";
                    break;
                case "11":
                    rtn = "书面资料审核(未通过)";
                    break;
                case "12":
                    rtn = "书面资料审核(通过)";
                    break;
                case "2":
                    rtn = "现场评审";
                    break;
                case "3":
                    rtn = "评审结论";
                    break;
                case "4":
                    rtn = "处理通知书";
                    break;
                case "5":
                    rtn = "企业报批申请";
                    break;
                case "6":
                    rtn = "证书发放";
                    break;
                default:
                    break;
            }
        }
        else
            if (flag == "1")
            {
                switch (state)
                {
                    case "1":
                        rtn = "网上投诉审核";
                        break;
                    case "2":
                        rtn = "投诉处理";
                        break;
                    default:
                        break;
                }
            }
        return rtn;
    }
}
