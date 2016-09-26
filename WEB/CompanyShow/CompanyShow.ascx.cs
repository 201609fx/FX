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

public partial class CompanyShow_CompanyShow : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            show();

    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSC", "*,(select  MainSCTemp.ID from MainSCTemp where MainSCTemp.ID=MainSC.MainSCID) as MainSCTempID"
            , "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);

        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSC.InsertFlag not in(0)  ";
        if (txtCompany.Text != "")
        {
            rtn += " and MainSC.Company like '%" +  SZMA.BLL.Utility.SqlStr(txtCompany.Text) + "%'";
        }
        if (txtCertNO.Text != "")
        {
            rtn += " and MainSC.CertNO like '%" +  SZMA.BLL.Utility.SqlStr(txtCertNO.Text) + "%'";
        }
        if (null != Request.QueryString["key"] && Request.QueryString["key"] != "")
        {
            string key =  SZMA.BLL.Utility.SqlStr( Request.QueryString["key"]);
            rtn += " and (MainSC.oldCertNO like '%" + key + "%' or MainSC.CertNO like '%" + key + "%' or MainSC.Company like '%" + key + "%')";
        }

        if (dpCFtime.Date != "")
        {
            rtn += " and (select StartTime from cert where MainSCID=MainSC.MainSCID) > '" + dpCFtime.Date + "'";
        }
        if (dpCTotime.Date != "")
        {
            rtn += " and (select StartTime from cert where MainSCID=MainSC.MainSCID) < '" + dpCTotime.Date + "'";
        }


        if (ddlLevel.SelectedIndex >0)
        {
            rtn += " and MainSC.CertNO like  '%" + ddlLevel.SelectedValue + "%'";
        }
        return rtn;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }
    protected void LinkCategory_Load(object sender, EventArgs e)
    {
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
}
