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

public partial class CertNO_CertNOList : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(21))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma_proSearch, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7725))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
            show(1);

    }
    public void show(int PageIndex)
    {
        int recc;
        DataSet ds = Common.Pager("MainSC", "MainSC.*,(select  MainSCTemp.ID from MainSCTemp where MainSCTemp.ID=MainSC.MainSCID) as MainSCTempID", "ID", AspNetPager1.PageSize, PageIndex, true, Buildcondition(), out recc);

        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString()+ "页显示。";
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSC.InsertFlag not in(0)  ";
        if (ddlState.SelectedIndex == 1)
        {
            rtn += " and MainSC.MainSCID in( select MainSCTemp.ID from MainSCTemp where MainSCTemp.state=6)";
        }
        if (ddlState.SelectedIndex == 2)
        {
            rtn += " and MainSC.MainSCID not in( select MainSCTemp.ID from MainSCTemp where MainSCTemp.state=6)";
        }
        if (ddlType.SelectedIndex != 0)
        {
            rtn += " and MainSC.Type=" + ddlType.SelectedValue;
        }
        if (txtCompany.Text != "")
        {
            rtn += " and MainSC.Company like '%" + txtCompany.Text + "%'";
        }
        if (txtMainSCNO.Text != "")
        {
            string MainSCNO =
                txtMainSCNO.Text.Replace("(", "").Replace(")", "").Replace("申", "").Replace("晋", "").TrimStart(
                    "0".ToCharArray());
            rtn += " and MainSC.ID like '%" + MainSCNO + "%'";
        }
        if (txtNoteNum.Text != "")
        {
            rtn += " and MainSC.NoteNum like '%" + txtNoteNum.Text + "%'";
        }
        if (dpFtime.Date != "")
        {
            rtn += " and MainSC.CreateTime > '" + dpFtime.Date + "'";
        }
        if (dpTotime.Date != "")
        {
            rtn += " and MainSC.CreateTime < '" + dpTotime.Date + "'";
        }
        if (dpCFtime.Date != "")
        {
            rtn += " and (select StartTime from cert where MainSCID=MainSC.MainSCID) > '" + dpCFtime.Date + "'";
        }
        if (dpCTotime.Date != "")
        {
            rtn += " and (select StartTime from cert where MainSCID=MainSC.MainSCID) < '" + dpCTotime.Date + "'";
        }
        if (txtCertNO.Text != "")
        {
            rtn += " and MainSC.CertNO like '%" + txtCertNO.Text + "%'";
        }
        if (txtOldCertNO.Text != "")
        {
            rtn += " and MainSC.oldCertNO like '%" + txtOldCertNO.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {

        string state = "";
        string[] strID = e.CommandArgument.ToString().Split(",,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        if (e.CommandName == "see")
        {
            int recc = 0;
            DataSet ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + strID[0], out recc);
            DropDownList ddl = gvList.Rows[int.Parse(strID[1])].FindControl("ddlState") as DropDownList;
            state = ddl.SelectedValue;
            if (recc > 0)
            {
                btnsee(strID[0], state);
            }
        }
    }
    protected void btnsee(string MainSCID, string state)
    {
        DataSet ds;
        int recc = 0;
        string Url;
        switch (state)
        {
            case "0":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + MainSCID, out recc);
                Url = "../CertNO/CompanyShow.aspx?mid=" + MainSCID + "&tid=" +
                      ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("800", "900", "10", "10", "申请表明细", Url);
                break;
            case "1":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + MainSCID, out recc);
                Url = "../workaround/FirstCheckDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "11":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + MainSCID, out recc);
                Url = "../workaround/FirstCheckDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "12":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + MainSCID, out recc);
                Url = "../workaround/FirstCheckDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "2":
                ds = Common.Pager("assess", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                string assessPlateID = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    assessPlateID = ds.Tables[0].Rows[0]["assessPlateID"].ToString();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["Totle"].ToString() != "")
                        {
                            assessPlateID = ds.Tables[0].Rows[i]["assessPlateID"].ToString();
                        }
                    }

                    Url = "../workaround/syndicDetail.aspx?mid=" + MainSCID + "&aid=" + assessPlateID;
                    OpenWindow("200", "600", "400", "300", "评审表明细", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的评审表!')</script>");
                }
                break;
            case "3":
                ds = Common.Pager("examineResult", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "../workaround/resultDetail.aspx?id=" + MainSCID;
                    OpenWindow("700", "800", "50", "50", "评审结论明细", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的评审结论表!')</script>");
                }
                break;
            case "4":
                ds = Common.Pager("PromotionDeal", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "../workaround/PromotionDealDetail.aspx?id=" + MainSCID;
                    OpenWindow("500", "800", "50", "50", "评审处理打印", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的处理通知表!')</script>");
                }
                break;
            case "5":
                ds = Common.Pager("approve", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "../workaround/approveDetail.aspx?id=" + MainSCID;
                    OpenWindow("700", "800", "50", "50", "审批表打印", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的报批申请表!')</script>");
                }
                break;
            case "6":
                ds = Common.Pager("cert", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "CompanyShowDetail.aspx?id=" + MainSCID;
                    OpenWindow("350", "800", "250", "150", "领证回执", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的领证记录表!')</script>");
                }
                break;
            default:
                break;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        show(1);
    }
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show(AspNetPager1.CurrentPageIndex);
    }

}
/*
 * 
 * 
 *     protected void Data_Clear()
    {
        lblCertNO.Text = "";
        txtCompany1.Text = "";
        txtMainSCNO1.Text = "";
        ddlState1.SelectedValue = "";
        lblMainSCID.Text = "";
    }
 * protected void btnSee_Click(object sender, EventArgs e)
    {
        DataSet ds;
        int recc = 0;
        string Url;
        switch (ddlState1.SelectedValue)
        {
            case "0":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                this.Response.Redirect("../CertNO/CompanyShow.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString());
                break;
            case "1":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                Url = "../workaround/FirstCheckPrint.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("700", "640", "50", "250", "初审记录打印", Url);
                break;
            case "11":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                Url = "../workaround/FirstCheckPrint.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("700", "640", "50", "250", "初审记录打印", Url);
                break;
            case "12":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                Url = "../workaround/FirstCheckPrint.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("700", "640", "50", "250", "初审记录打印", Url);
                break;
            case "2":
                ds = Common.Pager("assess", "*", "ID", 10, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                string assessPlateID = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    assessPlateID = ds.Tables[0].Rows[0]["assessPlateID"].ToString();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["Totle"].ToString() != "")
                        {
                            assessPlateID = ds.Tables[0].Rows[i]["assessPlateID"].ToString();
                        }
                    }

                    Url = "../workaround/syndic_AnswerView.aspx?mid=" + lblMainSCID.Text + "&aid=" + assessPlateID;
                    OpenWindow("700", "1000", "50", "10", "评审表答案打印", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的评审表!')</script>");
                }
                break;
            case "3":
                Url = "../workaround/result_Print.aspx?id=" + lblMainSCID.Text;
                OpenWindow("700", "800", "50", "50", "评审表答案打印", Url);
                break;
            case "4":
                ds = Common.Pager("PromotionDeal", "*", "ID", 10, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "../workaround/PromotionDeal_print.aspx?id=" + lblMainSCID.Text;
                    OpenWindow("700", "800", "50", "50", "评审表处理打印", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的处理通知表!')</script>");
                }
                break;
            case "5":
                ds = Common.Pager("approve", "*", "ID", 10, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "../workaround/approve_Print.aspx?id=" + lblMainSCID.Text;
                    OpenWindow("700", "800", "50", "50", "审批表打印", Url);
                }
                break;
            case "6":
                ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                this.Response.Redirect("CertNO_Edit.aspx?id=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString());
                break;
                break;
            default:
                break;
        }
    }
 */