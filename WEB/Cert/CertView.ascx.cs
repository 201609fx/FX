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
using SZMA.BLL;

public partial class Cert_CertView : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(null!=Request.QueryString["id"]&&Request.QueryString["id"]!="")
        {
            Data_bind();
        }
    }
    protected void Data_bind()
    {
        int recc = 0;
        DataSet ds =
            Common.Pager("MainSC],[Cert", "MainSC.*,Cert.EndTime,Cert.StartTime,Cert.CertState", "MainSC.MainSCID", 100, 1, true, "MainSC.MainSCID=Cert.MainSCID and MainSC.MainSCID='" + Request.QueryString["id"] + "'", out recc);
       
        if(ds.Tables[0].Rows.Count>0)
        {
            OperationMainDAL objopMain = new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainID2(ds.Tables[0].Rows[0]["MainSCID"].ToString());

            string stroperation = "范围：";
            string stroperationO = "";
            if (dsOperationMain.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["operation"].ToString() != "")
                {
                    if (dsOperationMain.Tables[0].Rows[0]["productID"].ToString() == "0")
                        stroperationO += "<br/>&nbsp;其它：" + ds.Tables[0].Rows[0]["operation"].ToString();
                }
                else
                {
                    stroperation += dsOperationMain.Tables[0].Rows[0]["ProductName"].ToString() + ",";
                }
            }
            for (int i = 1; i < dsOperationMain.Tables[0].Rows.Count; i++)
            {
                stroperation += dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString() + ",";
            }
            stroperation=stroperation.TrimEnd(",".ToCharArray());

            if (dsOperationMain.Tables[0].Rows.Count == 0)
            {
                stroperation = "";
            }
            if (dsOperationMain.Tables[0].Rows.Count == 1  )
            {
                if(dsOperationMain.Tables[0].Rows[0]["productID"].ToString() == "0")
                stroperation = "";
            }

            stroperation += stroperationO;
            DataSet dsOperateSA =
              Common.Pager("OperateSA", "ID,brand,MainSCID", "ID", 100, 1, false, "MainSCID='" + ds.Tables[0].Rows[0]["MainSCID"].ToString() + "'",
                           out recc);
            string strSa = "<br/><br/>&nbsp;特约维修品牌：";
            for (int i = 0; i < dsOperateSA.Tables[0].Rows.Count; i++)
            {
                strSa += dsOperateSA.Tables[0].Rows[i]["brand"].ToString() + ",";
            }
            strSa = strSa.TrimEnd(",".ToCharArray());
            if (dsOperateSA.Tables[0].Rows.Count == 0)
                strSa = "";
            
            
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lblCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            ltLevel.Text =  getLevel(ds.Tables[0].Rows[0]["CertNO"].ToString()) ;
            lblEndTime.Text = getTime(ds.Tables[0].Rows[0]["EndTime"].ToString());
            lblStartTime.Text =getTime(ds.Tables[0].Rows[0]["StartTime"].ToString());
            lblOperation.Text = stroperation + strSa;
            lblState.Text = Utility.getState(getDate(ds.Tables[0].Rows[0]["EndTime"].ToString()), ds.Tables[0].Rows[0]["CertState"].ToString());
        }
    }
}
