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

public partial class Introduction_default : System.Web.UI.UserControl
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
            DataSet ds =
                Common.Pager("Sort", "*", "ID", 100, 1, true, "ID=1", out recc);
            lblContent.Text = ds.Tables[0].Rows[0]["des"].ToString();
    }
}
