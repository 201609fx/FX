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

public partial class workaround_Search :SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(18))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Search, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7723))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            show();
            Data_bind();
        }
    }
    #region//初始化
    protected  void Data_bind()
    {
        dictAreaDAL obj = new dictAreaDAL();
        DataSet ds = obj.Select();
        ddlAreaID.DataSource = ds;
        ddlAreaID.DataBind();
        ddlAreaID.Items.Insert(0, new ListItem("所属区域", "0"));


        ProductDAL pobj = new ProductDAL();
        DataSet DsDropDown = pobj.Select();
        for (int i = 0; i < DsDropDown.Tables[0].Rows.Count; i++)
            ddlOperation.Items.Insert(0, new ListItem(DsDropDown.Tables[0].Rows[i]["EN_Name"].ToString() + "[" + DsDropDown.Tables[0].Rows[i]["CN_Name"].ToString() + "]", DsDropDown.Tables[0].Rows[i]["ID"].ToString()));
        ddlOperation.Items.Insert(0, new ListItem("请选择范围", "0"));


        //dictbrandDAL objBrand = new dictbrandDAL();
        //DataSet dsBrand = objBrand.SelectAll();
        //for (int i = 0; i < dsBrand.Tables[0].Rows.Count; i++)
        //    ddlBrand.Items.Insert(0, new ListItem(dsBrand.Tables[0].Rows[i]["EName"].ToString() + "[" + dsBrand.Tables[0].Rows[i]["Name"].ToString() + "]", dsBrand.Tables[0].Rows[i]["ID"].ToString()));
        //ddlBrand.Items.Insert(0, new ListItem("请选择品牌", "0"));
    }
    #endregion
    public void show() 
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;

        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);


        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSCTemp.InsertFlag not in(0)  ";
        if (ddlState.SelectedIndex!=0)
        {
            rtn += " and MainSCTemp.state=" +ddlState.SelectedValue ;
        }
        if (ddlType.SelectedIndex != 0)
        {
            rtn += " and MainSCTemp.Type=" + ddlType.SelectedValue;
        }
        if (txtCompany.Text != "")
        {
            rtn += " and MainSCTemp.Company like '%" + txtCompany.Text + "%'";
        }
        if (txtMainSCNO.Text != "")
        {
            string MainSCNO =
                txtMainSCNO.Text.Replace("(", "").Replace(")", "").Replace("申", "").Replace("晋", "").TrimStart(
                    "0".ToCharArray());
            rtn += " and MainSCTemp.ID like '%" + MainSCNO + "%'";
        }
        if (txtNoteNum.Text != "")
        {
            rtn += " and MainSCTemp.NoteNum like '%" + txtNoteNum.Text + "%'";
        }
        if(dpFtime.Date!="")
        {
            rtn += " and MainSCTemp.CreateTime > '" + dpFtime.Date + "'";
        }
        if(dpTotime.Date!="")
        {
            rtn += " and MainSCTemp.CreateTime < '" + dpTotime.Date + "'";
        }
        if(txtCertNO.Text!="")
        {
            rtn += " and MainSCTemp.CertNO like '%" + txtCertNO.Text + "%'";
        }
        if (txtOldCertNO.Text != "")
        {
            rtn += " and MainSCTemp.oldCertNO like '%" + txtOldCertNO.Text + "%'";
        }

        if (ddlCertLevel.SelectedIndex>0)
        {
            rtn += " and MainSCTemp.CertNO like '%" + ddlCertLevel.SelectedValue.Trim() + "%'";
        }
        if (ddlAreaID.SelectedIndex > 0)
        {
            rtn += " and MainSCTemp.AreaID = '" + ddlAreaID.SelectedValue + "'";
        }
        //if (ddlBrand.SelectedIndex > 0)
        //{
        //    rtn += " and Exists( select * from Operation where Operation.brand= '" + ddlBrand.SelectedValue + "' and Operation.MainSCID=MainSCTemp.ID)";
        //}
        if (ddlOperation.SelectedIndex > 0)
        {
            rtn += " and Exists( select * from OperationMain where OperationMain.ProductID= '" + ddlOperation.SelectedValue + "' and OperationMain.MainSCID=MainSCTemp.ID)";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
       
        string[] strID = e.CommandArgument.ToString().Split(",,".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
        string state = "";
        switch(e.CommandName)
        {
            case"see":
                    int recc = 0;
                    DataSet ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + strID[0], out recc);
                    DropDownList ddl = gvList.Rows[int.Parse(strID[1])].FindControl("ddlState") as DropDownList;
                    state = ddl.SelectedValue;
                    if(recc>0)
                    {
                        btnsee(strID[0],state);
                    }
                    break;
            case "ok":
                if (!CheckAdminRight(19))
                {
                    this.Response.Redirect("../NoRight.aspx");
                    return;
                }
                //if (!CheckRight(SZMA.BLL.Rights.szma_work_Search, Common.opt_ma))
                //{
                //    this.Response.Redirect("../NoRight.aspx");
                //    return;
                //}

                //if (!checkYUright(7724))
                //{
                //    this.Response.Redirect("../NoRight.aspx");
                //    return;
                //}

                DropDownList ddl1 = gvList.Rows[int.Parse(strID[1])].FindControl("ddlState") as DropDownList;
                state = ddl1.SelectedValue;
                if (Common.Update("MainSCTemp", "ID", strID[0], new string[] { "state", "UserName" }, new string[] { state, AdminUser.Username }))
                {
                    show();
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                }
                break;
            default:
                break;
        }
    }


    private void ddldataInit( DropDownList ddl)
    {
        ddl.Items.Clear();
        for (int i = 0; i < ddlState.Items.Count; i++)
            ddl.Items.Add(new ListItem(ddlState.Items[i].Text, ddlState.Items[i].Value));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
    }
    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    protected void btnsee(string MainSCID, string state)
    {
        DataSet ds;
        int recc = 0;
        string Url;
        switch (state)
        {
            case "0":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + MainSCID, out recc);
                Url = "FirstAuditingDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("800", "900", "10", "10", "申请书明细", Url);
                break;
            case "1":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + MainSCID, out recc);
                Url = "FirstCheckDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "11":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + MainSCID, out recc);
                Url = "FirstCheckDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "12":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + MainSCID, out recc);
                Url = "FirstCheckDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
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

                    Url = "syndicDetail.aspx?mid=" + MainSCID + "&aid=" + assessPlateID;
                    OpenWindow("200", "600", "400", "300", "现场评审表明细", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的现场评审表!')</script>");
                }
                break;
            case "3":

                ds = Common.Pager("examineResult", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "resultDetail.aspx?id=" + MainSCID;
                    OpenWindow("700", "800", "50", "50", "评审结论明细", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的结论表!')</script>");
                }
                break;
            case "4":
                ds = Common.Pager("PromotionDeal", "*", "ID", 10, 1, true, "MainSCID=" + MainSCID, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "PromotionDealDetail.aspx?id=" + MainSCID;
                    OpenWindow("500", "800", "50", "50", "处理通知打印", Url);
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
                    Url = "lastApproveDetail.aspx?id=" + MainSCID;
                    OpenWindow("700", "800", "50", "50", "报批申请打印", Url);
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
                    Url = "../CertNO/CompanyShowDetail.aspx?id=" + MainSCID;
                    OpenWindow("350", "800", "250", "150", "领证回执", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的领证记录表!')</script>");
                }
                break;
            case "7":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + MainSCID, out recc);
                Url = "FirstAuditingDetail.aspx?mid=" + MainSCID + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("800", "900", "10", "10", "申请书明细", Url);
                break;
            default:
                break;
        }
    }
    protected void gvList_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            DropDownList ddl = e.Row.FindControl("ddlState") as DropDownList;
            ddldataInit(ddl);
            ddl.SelectedValue = drv["state"].ToString();
            for (int i = ddl.SelectedIndex + 1; i < ddl.Items.Count; i++)
            {
                ddl.Items.RemoveAt(i);
                i--;
            }
        }
    }
}
#region //备份
/*
 *     protected void Data_Clear()
    {
        txtNoteNum1.Text ="";
        txtCompany1.Text = "";
        txtMainSCNO1.Text = "";
        ddlState1.SelectedValue = "";
        lblMainSCID.Text = "";
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string strID = e.CommandArgument.ToString();
        if (e.CommandName == "see")
        {
            pnlSee.Visible = true;
            int recc = 0;
            DataSet ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + strID, out recc);
            if(recc>0)
            {
                txtNoteNum1.Text = ds.Tables[0].Rows[0]["NoteNum"].ToString();
                txtCompany1.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                lblMainSCID.Text = e.CommandArgument.ToString();
                txtMainSCNO1.Text = getMainNO(e.CommandArgument.ToString(), ds.Tables[0].Rows[0]["Type"].ToString());
                ddlState1_dataInit();
                ddlState1.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
                for (int i = ddlState1.SelectedIndex + 1; i < ddlState1.Items.Count; i++)
                {
                    ddlState1.Items.RemoveAt(i);
                    i--;
                }
            }
        }
    }
 * 
 * 
 * 
    protected void btnSee_Click(object sender, EventArgs e)
    {
        DataSet ds;
        int recc = 0;
        string Url;
        switch(ddlState1.SelectedValue)
        {
            case "0":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + lblMainSCID.Text, out recc);
                this.Response.Redirect("FirstAuditingDetail.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString());
                break;
            case "1":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + lblMainSCID.Text, out recc);
                Url = "FirstCheckDetail.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "11":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + lblMainSCID.Text, out recc);
                Url = "FirstCheckDetail.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
                break;
            case "12":
                ds = Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID=" + lblMainSCID.Text, out recc);
                Url = "FirstCheckDetail.aspx?mid=" + lblMainSCID.Text + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
                OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
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

                    Url = "syndicDetail.aspx?mid=" + lblMainSCID.Text + "&aid=" + assessPlateID;
                    OpenWindow("200", "600", "400", "300", "评审表明细", Url);
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('找不到属于该企业的评审表!')</script>");
                }
                break;
            case "3":
                Url = "resultDetail.aspx?id=" + lblMainSCID.Text;
                OpenWindow("700", "800", "50", "50", "评审结论明细", Url);
                break;
            case "4":
                ds = Common.Pager("PromotionDeal", "*", "ID", 10, 1, true, "MainSCID=" + lblMainSCID.Text, out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Url = "PromotionDealDetail.aspx?id=" + lblMainSCID.Text;
                    OpenWindow("500", "800", "50", "50", "评审处理打印", Url);
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
                    Url = "approveDetail.aspx?id=" + lblMainSCID.Text;
                    OpenWindow("700", "800", "50", "50", "审批表打印", Url);
                }
                break;
            case "6":
                break;
            default:
                break;
        }
    }
 *     protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(34))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        if (Common.Update("MainSCTemp", "ID", lblMainSCID.Text, new string[] { "state","UserName" }, new string[] {ddlState1.SelectedValue,AdminUser.Username }))
        {
            show(false);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
        }
    }
 *     private void ddlState1_dataInit()
    {
        ddlState1.Items.Clear();
        for(int i=0;i<ddlState.Items.Count;i++)
            ddlState1.Items.Add(new ListItem(ddlState.Items[i].Text, ddlState.Items[i].Value));
    }
*/
#endregion