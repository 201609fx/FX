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

public partial class workaround_lastApproveDetail : SZMA.Core.Admin.PageBase
{
    public string strOpID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
            Data_bind();
    }
    protected void Data_bind()
    {
        int recc;
        ///初审
        ///
        lblNumNo.Text = getAPPNumNO(Request.QueryString["id"]);
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
            lblsyndicer.Text = dsMain.Tables[0].Rows[0]["checkuser"].ToString();
            lblFistDate.Text = getstrdate(dsMain.Tables[0].Rows[0]["checktime"].ToString());

        }
        chkReslt.Checked = true;
        chkReslt1.Checked = false;
        DataSet dsOp = objOp.SelectPruductByMainID(Request.QueryString["id"]);
        dtOperation.DataSource = dsOp.Tables[0].DefaultView;
        dtOperation.DataBind();

      

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

        /// 拟参加评审专家组成员        
        if (dsEx.Tables[0].Rows.Count > 0)
        {
            this.lblSLeader.Text = dsEx.Tables[0].Rows[0]["Leader"].ToString();
        }
        AssessDAL objAs = new AssessDAL();
        DataSet dsAs = objAs.SelectByID(Request.QueryString["id"]);
        if (dsAs.Tables[0].Rows.Count > 0)
        {
            lblS.Text = dsAs.Tables[0].Rows[0]["PSUserName"].ToString();
            lblsyndicer.Text = lblS.Text;
        }

        ///意见以及备注
        ApproveDAL objApp = new ApproveDAL();
        DataSet dsApp = objApp.SelectAllByMID(Request.QueryString["id"]);
        if (dsApp.Tables[0].Rows.Count > 0)
        {
            lblPsuggest.Text = dsApp.Tables[0].Rows[0]["Psuggest"].ToString();
            this.lblPromoter.Text=dsApp.Tables[0].Rows[0]["promoter"].ToString();
            this.lblPTime.Text = getstrdate(dsApp.Tables[0].Rows[0]["Ptime"].ToString());

            
            this.lblLeader.Text=dsApp.Tables[0].Rows[0]["leader"].ToString();
            this.lblLsuggest.Text=dsApp.Tables[0].Rows[0]["Lsuggest"].ToString();
            this.lblLTime.Text = getstrdate(dsApp.Tables[0].Rows[0]["Ltime"].ToString());
            
            this.lblSuperintendent.Text=dsApp.Tables[0].Rows[0]["superintendent"].ToString();
            this.lblSsuggest.Text=dsApp.Tables[0].Rows[0]["suggest"].ToString();
            this.lblSTime.Text = getstrdate(dsApp.Tables[0].Rows[0]["Stime"].ToString());

            this.lblRemark.Text = dsApp.Tables[0].Rows[0]["Remark"].ToString();
        }

    }

   protected string getstrdate( string str)
        {
            string rtn = "年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日";
            try
            {
                DateTime dt=DateTime.Parse(str);
                rtn=dt.Year+"年&nbsp;"+dt.Month+"月&nbsp;"+dt.Day+"日";
            }
            catch
            {}
            return rtn;
        }
   
}
