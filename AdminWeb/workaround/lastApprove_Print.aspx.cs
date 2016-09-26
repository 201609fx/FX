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

public partial class workaround_lastApprove_Print : SZMA.Core.Admin.PageBase
{
    public string strOpID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckRight(SZMA.BLL.Rights.szma_work_approve, Common.opt_see))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
            Data_bind();
    }
    protected void Data_bind()
    {
        int recc;
        ///初审
        ///
        lblAPPNO.Text = getAPPNumNO(Request.QueryString["id"]);
        MainSCTempDAL objmain = new MainSCTempDAL();
        OperationMainDAL objOp = new OperationMainDAL();
        DataSet dsMain = Common.Pager("MainSCTemp", "*", "ID", 99, 1, true, " ID='" + SZMA.BLL.Utility.SqlStr2(Request.QueryString["id"]) + "'", out recc);
        if (dsMain.Tables[0].Rows.Count > 0)
        {
            txtCompany.Text = dsMain.Tables[0].Rows[0]["Company"].ToString();
            switch (dsMain.Tables[0].Rows[0]["Type"].ToString())
            {
                case "1":

                    txtMainNO.Text = getSimpleMainNO(Request.QueryString["id"], dsMain.Tables[0].Rows[0]["Type"].ToString());
                    chkF.Checked = true;
                    chkS.Checked = false;
                    txtMainNO1.Text = "";
                    break;
                case "2":
                    txtMainNO.Text = "";
                    chkF.Checked = false;
                    chkS.Checked = true;
                    txtMainNO1.Text = getSimpleMainNO(Request.QueryString["id"], dsMain.Tables[0].Rows[0]["Type"].ToString());
                    break;
                default:
                    txtMainNO.Text = "";
                    chkF.Checked = false;
                    chkS.Checked = false;
                    txtMainNO1.Text = "";
                    break;
            }

        }
        chkReslt.Checked = true;
        chkReslt1.Checked = false;
        DataSet dsOp = objOp.SelectPruductByMainID(Request.QueryString["id"]);
        dtOperation.DataSource = dsOp.Tables[0].DefaultView;
        dtOperation.DataBind();

        /// 拟参加评审专家组成员 
        /// 

        ///评审组意见
        examineResultDAL obj = new examineResultDAL();
        DataSet dsEx = obj.SelectByMID(Request.QueryString["id"]);
        if (dsEx.Tables[0].Rows.Count > 0)
        {
            lblSyndicResult.Text = dsEx.Tables[0].Rows[0]["Suggest"].ToString();
        }
        if (dsMain.Tables[0].Rows.Count > 0)
        {
            txtCertLv.Text = getLevel(dsMain.Tables[0].Rows[0]["CertNO"].ToString());
        }
        ///
    }
}
