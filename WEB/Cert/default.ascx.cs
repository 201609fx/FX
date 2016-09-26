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

public partial class Cert_default : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            show(true);

    }
    public void show(bool IsFirst)
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        if (IsFirst)
            pageindex = 1;
        int recc;
        DataSet ds = Common.Pager("MainSC", "MainSC.*,(select  MainSCTemp.ID from MainSCTemp where MainSCTemp.ID=MainSC.MainSCID) as MainSCTempID"
            , "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
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
        if (null != Request.QueryString["key"] && Request.QueryString["key"] != "")
        {
            string key = Request.QueryString["key"];
            rtn += " and( MainSC.oldCertNO like '%" + key + "%' or MainSC.CertNO like '%" + key + "%' or MainSC.Company like '%" + key + "%')";
        }
        return rtn;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show(true);
    }
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show(false);
    }
}
