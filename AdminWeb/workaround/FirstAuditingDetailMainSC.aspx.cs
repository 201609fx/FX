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

public partial class workaround_FirstAuditingDetailMainSC :SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Data_Init();
        }
    }
    private void Data_Init()
    {
        GVData_Init();
        if (null != Request.QueryString["mid"])
        {
            string MID = Request.QueryString["MID"];
            int recc;
            DataSet ds =
                Common.Pager("MainSC", "*,(select Name from dict_area where MainSC.AreaID=dict_area.ID) as Name", "ID", 100, 1, true, "MainSC.MainSCID='" + MID + "' ",
                             out recc);
            if (recc < 1)
                return;
            lblAreaID.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblAnum.Text = ds.Tables[0].Rows[0]["Anum"].ToString();
            lblArea.Text = ds.Tables[0].Rows[0]["Area"].ToString();
            lblBnum.Text = ds.Tables[0].Rows[0]["Bnum"].ToString();
            lblCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
            lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            lblFrdb.Text = ds.Tables[0].Rows[0]["Frdb"].ToString();
            lblFtel.Text = ds.Tables[0].Rows[0]["Ftel"].ToString();
            lblMnum.Text = ds.Tables[0].Rows[0]["Mnum"].ToString();
            lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            lblSummary.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
            lblTitle.Text = "申请表  " + getMainNO(MID, Request.QueryString["tid"]);
        }
    }
    private void GVData_Init()
    {

        if (null != Request.QueryString["MID"])
        {
            int recc;
            string MID = Request.QueryString["MID"];
            EmployeeDAL Emobj = new EmployeeDAL();

            DataSet dsMemployee = Emobj.SelectByMainSCID(MID, 1);
            gvMemployee.DataSource = dsMemployee;
            gvMemployee.DataBind();

            DataSet dsWemployee = Emobj.SelectByMainSCID(MID, 2);
            gvWemployee.DataSource = dsWemployee;
            gvWemployee.DataBind();

            DataSet dsElist1 =
              Common.Pager("equipment", "*", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                           out recc);
            gvEList.DataSource = dsElist1;
            gvEList.DataBind();

            DataSet dsElist2 =
             Common.Pager("equipment", "*", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                          out recc);
            gvElist2.DataSource = dsElist2;
            gvElist2.DataBind();

            DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name", "CSFileID", 100, 1, false, "CSlist.MainSCID='" + MID + "' and CSlist.CSFileID=CSFileDict.ID ",
                            out recc);
            gvCSFile.DataSource = dsCSFile;
            gvCSFile.DataBind();




            OperationMainDAL objopMain=new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainIDMainSC(MID);
            gvOperationMain.DataSource = dsOperationMain;
            gvOperationMain.DataBind();


            DataSet dsOperateSA =
              Common.Pager("OperateSA", "ID,brand,MainSCID", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                           out recc);
            if (dsOperateSA.Tables[0].Rows.Count > 0)
            {
                pnlOperation.Visible = true;
            }
            gvOperation.DataSource = dsOperateSA;
            gvOperation.DataBind();
        }
    }

    protected void lnkbtn1_Click(object sender, EventArgs e)
    {
        DataSet ds;
        int recc = 0;
        string Url;
        ds = Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSC.MainSCID=" + Request.QueryString["mid"], out recc);
        Url = "FirstCheckDetail.aspx?mid=" + Request.QueryString["mid"] + "&tid=" + ds.Tables[0].Rows[0]["Type"].ToString();
        OpenWindow("400", "640", "50", "250", "初审记录明细", Url);
    }
    protected void lnkbtn2_Click(object sender, EventArgs e)
    {
        DataSet ds;
        int recc = 0;
        string Url;
        ds = Common.Pager("assess", "*", "ID", 10, 1, true, "MainSCID=" + Request.QueryString["mid"], out recc);
        string assessPlateID = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            assessPlateID = ds.Tables[0].Rows[0]["assessPlateID"].ToString();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[0]["Totle"].ToString() != "")
                {
                    assessPlateID = ds.Tables[0].Rows[i]["assessPlateID"].ToString();
                }
            }

            Url = "syndicDetail.aspx?mid=" + Request.QueryString["mid"] + "&aid=" + assessPlateID;
            OpenWindow("200", "600", "400", "300", "现场评审表明细", Url);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('找不到属于该企业的现场评审表!')</script>");
        }

    }
    protected void lnkbtn3_Click(object sender, EventArgs e)
    {

        DataSet ds;
        int recc = 0;
        string Url;
        ds = Common.Pager("examineResult", "*", "ID", 10, 1, true, "MainSCID=" + Request.QueryString["mid"], out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Url = "resultDetail.aspx?id=" + Request.QueryString["mid"];
            OpenWindow("700", "800", "50", "50", "评审结论明细", Url);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('找不到属于该企业的结论表!')</script>");
        }
    }
    protected void lnkbtn4_Click(object sender, EventArgs e)
    {

        DataSet ds;
        int recc = 0;
        string Url;

        ds = Common.Pager("PromotionDeal", "*", "ID", 10, 1, true, "MainSCID=" + Request.QueryString["mid"], out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Url = "PromotionDealDetail.aspx?id=" + Request.QueryString["mid"];
            OpenWindow("500", "800", "50", "50", "评审处理打印", Url);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('找不到属于该企业的处理通知表!')</script>");
        }
    }
    protected void lnkbtn5_Click(object sender, EventArgs e)
    {

        DataSet ds;
        int recc = 0;
        string Url;
        ds = Common.Pager("approve", "*", "ID", 10, 1, true, "MainSCID=" + Request.QueryString["mid"], out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Url = "approveDetail.aspx?id=" + Request.QueryString["mid"];
            OpenWindow("700", "800", "50", "50", "报批表打印", Url);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('找不到属于该企业的报批申请表!')</script>");
        }
    }
    protected void lnkbtn6_Click(object sender, EventArgs e)
    {

        DataSet ds;
        int recc = 0;
        string Url;
        ds = Common.Pager("cert", "*", "ID", 10, 1, true, "MainSCID=" + Request.QueryString["mid"], out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Url = "../CertNO/CompanyShowDetail.aspx?id=" + Request.QueryString["mid"];
            OpenWindow("350", "800", "250", "150", "领证回执", Url);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('找不到属于该企业的领证记录表!')</script>");
        }
    }
}
