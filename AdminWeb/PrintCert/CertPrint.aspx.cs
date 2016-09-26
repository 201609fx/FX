using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using SZMA.AdminWeb;
using SZMA.DataLayer;

public partial class PrintCert_CertPrint : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(20))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7725))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        setCertReport();
        SetCert();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SetCert();
        this.CertReport1.Report.Print();
    }

    protected void SetCert()
    {
        int recc = 0;
        DataSet ds = Common.Pager("MainSCTemp],[cert", "MainSCTemp.*,cert.StartTime,cert.EndTime", "MainSCTemp.ID", 10, 1, true, " cert.MainSCID=MainSCTemp.ID and  MainSCTemp.ID='" + Request.QueryString["ID"] + "'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {

            string PrinterName = System.Configuration.ConfigurationManager.AppSettings["Printer"];
            SZMA.AdminWeb.CertReport Cobj = new CertReport();

            Cobj.xrLabel1.Visible = false;
            Cobj.xrLabel2.Visible = false;
            Cobj.xrLabel3.Visible = false;
            Cobj.xrLabel4.Visible = false;
            Cobj.xrLabel5.Visible = false;

            Cobj.xrlblLevel.Text = getLevel(ds.Tables[0].Rows[0]["CertNO"].ToString());
            Cobj.xrlblCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            Cobj.xrlblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();

            DateTime InvalTime = getDate(ds.Tables[0].Rows[0]["EndTime"].ToString());
            Cobj.xrlblInvalTime.Text = InvalTime.Year + "    " + InvalTime.Month + "    " + InvalTime.Day;
            DateTime StartTime = getDate(ds.Tables[0].Rows[0]["StartTime"].ToString());
            Cobj.xrlblStartTime.Text = StartTime.Year + "    " + StartTime.Month + "    " + StartTime.Day;

            Cobj.xrlblOperation.Text = "";
            OperationMainDAL objopMain = new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainIDMainSC(Request.QueryString["ID"]);
            for (int i = 0; i < dsOperationMain.Tables[0].Rows.Count; i++)
            {
                if (dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim() != "")
                    Cobj.xrlblOperation.Text += "、" + dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim();
            }
            Cobj.xrlblOperation.Text = Cobj.xrlblOperation.Text.Trim().TrimStart("、".ToCharArray());


            Cobj.xrlblCompany.Font = SetLblFont(Cobj.xrlblCompany.Text);
            Cobj.xrlblOperation.Font = SetLblFont(Cobj.xrlblOperation.Text);
            this.CertReport2.Report = Cobj;

        }
        else
        {
            this.Response.Write("<script language='javascript'>alert('未找到企业信息!!!')</script>");
            return;
        }
    }
    
    protected void setCertReport()
    {
        SZMA.AdminWeb.CertReport Cobj = new CertReport();
        int recc = 0;
        DataSet ds = Common.Pager("MainSC],[cert", "MainSC.*,cert.StartTime,cert.EndTime", "MainSC.MainSCID", 10, 1, true, " cert.MainSCID=MainSC.MainSCID and MainSC.MainSCID='" + Request.QueryString["ID"] + "'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {

            Cobj.xrlblLevel.Text = getLevel(ds.Tables[0].Rows[0]["CertNO"].ToString());
            Cobj.xrlblCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            Cobj.xrlblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();

            DateTime InvalTime = getDate(ds.Tables[0].Rows[0]["EndTime"].ToString());
            Cobj.xrlblInvalTime.Text = InvalTime.Year + " 年 " + InvalTime.Month + " 月 " + InvalTime.Day+" 日";
            DateTime StartTime = getDate(ds.Tables[0].Rows[0]["StartTime"].ToString());
            Cobj.xrlblStartTime.Text = StartTime.Year + " 年 " + StartTime.Month + " 月 " + StartTime.Day + " 日";


            Cobj.xrlblOperation.Text = "";
            OperationMainDAL objopMain = new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainIDMainSC(Request.QueryString["ID"]);
            for (int i = 0; i < dsOperationMain.Tables[0].Rows.Count; i++)
            {
                if (dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim() != "")
                    Cobj.xrlblOperation.Text += "、" + dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim();
            }
            Cobj.xrlblOperation.Text = Cobj.xrlblOperation.Text.Trim().TrimStart("、".ToCharArray());
            Cobj.xrlblCompany.Font = SetLblFont(Cobj.xrlblCompany.Text);
            Cobj.xrlblOperation.Font = SetLblFont(Cobj.xrlblOperation.Text);
            this.CertReport1.Report = Cobj;
        }
        else
        {
            this.Response.Write("<script language='javascript'>alert('未找到企业信息!!!')</script>");
            return;
        }
    }
    protected System.Drawing.Font SetLblFont(string str)
    {
        System.Drawing.Font Font1=new Font("宋体", 35, FontStyle.Bold);
        if (str.Length > 23)
        {
            Font1 = new Font("宋体", (1100 / str.Length)-12, FontStyle.Bold);
        }
        return Font1;
    }
}
