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

public partial class Home_Default : SZMA.Core.Client.BasePageByPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            rptViewData_init();
            //rptLawData_init();
            rptNoteData_init();
            //rptAlinkData_init();
            
            //int recc = 0;
            //DataSet ds =
            //    Common.Pager("Sort", "*", "ID", 100, 1, true, "ID=1", out recc);
            //lblIntroduction.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
            //DataSet dsConcact =
            //    Common.Pager("News", "*", "ID", 100, 1, true, "ID=1", out recc);
            //lblConcact.Text = dsConcact.Tables[0].Rows[0]["Abstract"].ToString();
        }
    }
    #region //公示
    protected void rptViewData_init()
    {
        int recc = 0;
        DataSet ds = Common.Pager("MainSC", "*", "CreateTime", 7, 1, true, " CertNo>''", out recc);
        rptView.DataSource = ds;
        rptView.DataBind();
    }
    #endregion
    //#region //法律
    //protected void rptLawData_init()
    //{
    //    int recc = 0;
    //    DataSet ds = Common.Pager("News", "*", "CreateTime", 5, 1, true, " SortID=2 and InsertFlag=1", out recc);
    //    rptLaw.DataSource = ds;
    //    rptLaw.DataBind();
    //}
    //#endregion
    #region //公告
    protected void rptNoteData_init()
    {
        int recc = 0;
        DataSet ds = Common.Pager("News", "*", "CreateTime", 5, 1, true, " SortID=3 and InsertFlag=1 and IsSys=0", out recc);
        rptNote.DataSource = ds;
        rptNote.DataBind();
    }
    #endregion
    //#region //相关链接
    //protected void rptAlinkData_init()
    //{
    //    DataSet ds=new DataSet();
    //    DataTable dt=new DataTable();
    //    ds.ReadXml(MapPath(System.Configuration.ConfigurationManager.AppSettings["AlinkXML"]));
    //    rptAlink.DataSource = ds;
    //    rptAlink.DataBind();
    //}
    //#endregion
}
