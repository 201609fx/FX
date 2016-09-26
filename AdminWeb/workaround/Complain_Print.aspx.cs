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

public partial class workaround_Complain_Print :SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(27))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        data_init();
    }

    private void data_init()
    {
        ComplainerDAL obj = new ComplainerDAL();
        DataSet ds = obj.SelectByID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblcontent.Text = ds.Tables[0].Rows[0]["content"].ToString();
            lblComplainer.Text = ds.Tables[0].Rows[0]["Complainer"].ToString();
            lblTel.Text = ds.Tables[0].Rows[0]["Ctel"].ToString();
            lblCaddresstou.Text = ds.Tables[0].Rows[0]["Caddresstou"].ToString();
            lblBCTel.Text = ds.Tables[0].Rows[0]["BCTel"].ToString();
            lblBContact.Text = ds.Tables[0].Rows[0]["BContact"].ToString();
            lblBComplainer.Text = ds.Tables[0].Rows[0]["BComplainer"].ToString();
            lblBAddress.Text = ds.Tables[0].Rows[0]["BAddress"].ToString();
            lblCTime.Text = getTime(ds.Tables[0].Rows[0]["CTime"].ToString());
            lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtsuggest.Text = ds.Tables[0].Rows[0]["suggest"].ToString().Replace("<br>", "\t\n");
            txtResult.Text = ds.Tables[0].Rows[0]["suggest"].ToString().Replace("<br>", "\t\n");
            txtLSuggest.Text = ds.Tables[0].Rows[0]["LSuggest"].ToString().Replace("<br>", "\t\n");
            txtLSuggest1.Text = ds.Tables[0].Rows[0]["LSuggest1"].ToString().Replace("<br>", "\t\n");
            lblNO.Text = "受［"+DateTime.Now.Year.ToString()+"］第"+ds.Tables[0].Rows[0]["CNO"].ToString().PadLeft(5,'0')+"号";
        }
    }
}
