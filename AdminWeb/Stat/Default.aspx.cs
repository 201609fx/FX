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
using System.Data;

public partial class Stat_Default : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(27))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_system_Dict, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7733))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            show();
        }
    }
    private void show()
    {
        statDAL obj = new statDAL();
        DataSet dsStat = obj.selectCountMainSCTemp();
        lblSQ.Text = dsStat.Tables[0].Rows[0][0].ToString();
        this.lblYH.Text = dsStat.Tables[1].Rows[0][0].ToString();
        this.lblGQ.Text = dsStat.Tables[2].Rows[0][0].ToString();
        this.lblYX.Text = dsStat.Tables[3].Rows[0][0].ToString();
        this.lblDX.Text = dsStat.Tables[4].Rows[0][0].ToString();
    }
}
