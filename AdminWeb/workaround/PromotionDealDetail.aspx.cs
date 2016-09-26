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

public partial class workaround_PromotionDealDetail : SZMA.Core.Admin.PageBase
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
        PromotionDealDAL obj = new PromotionDealDAL();
        DataSet ds = obj.Select(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lblTel.Text = ds.Tables[0].Rows[0]["phone"].ToString();
            lblcontact.Text = ds.Tables[0].Rows[0]["contact"].ToString();
            lblOldCertNO.Text = ds.Tables[0].Rows[0]["oldCertNO"].ToString();
            lblLevel.Text = getLevel(ds.Tables[0].Rows[0]["oldCertNO"].ToString());
            txtLeader.Text = ds.Tables[0].Rows[0]["leader"].ToString();
            dpLTime.Text = getTime(ds.Tables[0].Rows[0]["lTime"].ToString());
            lblPSTime.Text = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
            LblPS.Text = ds.Tables[0].Rows[0]["PSUserName"].ToString();


            dictresuleDAL objPro = new dictresuleDAL();
            

            DataSet dsDdl = objPro.SelectByID(ds.Tables[0].Rows[0]["Result"].ToString().Trim());
            if(dsDdl.Tables[0].Rows.Count>0)
            {
                txtResult.Text = dsDdl.Tables[0].Rows[0]["des"].ToString() + ds.Tables[0].Rows[0]["Level"].ToString();
            }
          
        }
    }
}
