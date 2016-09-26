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

public partial class workaround_syndicDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            data_init();
        }

    }

    private void data_init()
    {
        AssessDAL obj = new AssessDAL();
        DataSet ds = obj.Select(Request.QueryString["mid"],Request.QueryString["aid"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblNO.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            lblTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            txtSyndic.Text = ds.Tables[0].Rows[0]["PSUserName"].ToString();
            dpPStime.Text = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
        }
    }



    protected DateTime getDate(string dt)
    {
        DateTime rtn = new DateTime(0);
        try
        {
            rtn = DateTime.Parse(dt);
        }
        catch
        {
        }
        return rtn;
    }

    protected string getTime(string DS)
    {
        string rtn = "";
        try
        {
            rtn = DateTime.Parse(DS).ToString("yyyy/MM/dd");
        }
        catch
        {
        }
        return rtn;
    }
}
