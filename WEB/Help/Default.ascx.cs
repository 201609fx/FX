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

public partial class Help_Default : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            data_init();
        }

    }
    protected void data_init()
    {
        int recc = 0;
        NewsDAL obj = new NewsDAL();
        obj.AddClickTime("6");
        DataSet ds =
            Common.Pager("News", "*", "ID", 100, 1, true, "ID='6'", out recc);
        lblContent.Text = ds.Tables[0].Rows[0]["Content"].ToString();

        int recc_dot = 0;
        DataSet ds_Dot = Common.Pager("VIEWFile", "*", "ID", 999, 1, true, "FileSortID=1 and MainID=" + ds.Tables[0].Rows[0]["ID"].ToString(), out recc_dot);
        if (recc_dot > 0)
        {
            this.rptListDots.DataSource = ds_Dot;
            this.rptListDots.DataBind();
            this.pnlFile.Visible = true;
        }
        else
        {
            this.pnlFile.Visible = false;
        }

    }
}
