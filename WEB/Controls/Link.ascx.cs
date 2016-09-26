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

public partial class Controls_Link : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int recc;
            rptAlinkData_init();
            //DataSet dsConcact =
            //    Common.Pager("News", "*", "ID", 100, 1, true, "ID=1", out recc);
            //if(recc>0)
            //    lblConcact.Text = dsConcact.Tables[0].Rows[0]["Refer"].ToString();
        }
    }


    protected void rptAlinkData_init()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.ReadXml(MapPath(System.Configuration.ConfigurationManager.AppSettings["AlinkXML"]));
        rptlink.DataSource = ds;
        rptlink.DataBind();
    }
}
