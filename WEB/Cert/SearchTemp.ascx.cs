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

public partial class Cert_SearchTemp : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void show(bool IsFirst)
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        if (IsFirst)
            pageindex = 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "*", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
        if(pagecount>0)
        {
            search.Visible = true;
            gvList.Visible = true;
        }
        else
        {
            ShowAlert("提示","没有找到企业信息,请核对输入是否有误!!!");
            search.Visible = false;
        }
    }
    public string Buildcondition()
    {
        string rtn = " MainSCTemp.InsertFlag not in(0)  ";
        if (ddlState.SelectedIndex!=0)
        {
            rtn += " and MainSCTemp.state in('"+ddlState.SelectedValue+"')";
            
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
            rtn += " and MainSCTemp.NoteNum like '%" + getno(txtNoteNum.Text) + "%'";
        }
        if (dpFtime.Date != "")
        {
            rtn += " and MainSCTemp.CreateTime > '" + dpFtime.Date + "'";
        }
        if (dpTotime.Date != "")
        {
            rtn += " and MainSCTemp.CreateTime < '" + dpTotime.Date + "'";
        }
        if (txtCertNO.Text != "")
        {
            rtn += " and MainSCTemp.CertNO like '%" + txtCertNO.Text + "%'";
        }
        if (txtOldCertNO.Text != "")
        {
            rtn += " and MainSCTemp.oldCertNO like '%" + txtOldCertNO.Text + "%'";
        }
        return rtn;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
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
