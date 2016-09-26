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
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System.Drawing;
using SZMA.AdminWeb;
using SZMA.DataLayer;

public partial class PrintCert_testPrint : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckRight(SZMA.BLL.Rights.szma_certma, Common.opt_ma))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        setCertCopyReport();
        setCopy();
    }

    protected void setCopy()
    {
        int recc = 0;
        DataSet ds = Common.Pager("MainSCTemp],[cert", "MainSCTemp.*,cert.StartTime,cert.EndTime", "MainSCTemp.ID", 10, 1, true, " cert.MainSCID=MainSCTemp.ID and  MainSCTemp.ID='" + Request.QueryString["ID"] + "'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string PrinterName = System.Configuration.ConfigurationManager.AppSettings["Printer"];
            CertCopyReport Cobj = new CertCopyReport();


            Cobj.xrLabel1.Visible = false;
            Cobj.xrLabel2.Visible = false;
            Cobj.xrLabel3.Visible = false;
            Cobj.xrLabel4.Visible = false;
            Cobj.xrLabel5.Visible = false;
            Cobj.xrLabel6.Visible = false;
            Cobj.xrLabel7.Visible = false;
            Cobj.xrLabel8.Visible = false;

            Cobj.xrlbladdress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            Cobj.xrlblCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            Cobj.xrlblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            Cobj.xrlblfrdb.Text = ds.Tables[0].Rows[0]["frdb"].ToString();

            DateTime InvalTime = getDate(ds.Tables[0].Rows[0]["EndTime"].ToString());
            Cobj.xrlblinvalTime.Text = InvalTime.Year + "   " + InvalTime.Month + "  " + InvalTime.Day;
            DateTime StartTime = getDate(ds.Tables[0].Rows[0]["StartTime"].ToString());
            Cobj.xrlstartTime.Text = StartTime.Year + "  " + StartTime.Month + "  " + StartTime.Day;
            Cobj.xrlblLevel.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();



            Cobj.xrlbloperation.Text = "";

            OperationMainDAL objopMain = new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainIDMainSC(Request.QueryString["ID"]);
            for (int i = 0; i < dsOperationMain.Tables[0].Rows.Count; i++)
            {
                if (dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim() != "")
                    Cobj.xrlbloperation.Text += "," + dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim();
            }
            Cobj.xrlbloperation.Text = Cobj.xrlbloperation.Text.Trim().TrimStart(",".ToCharArray());

            Cobj.xrlblphone.Text = ds.Tables[0].Rows[0]["phone"].ToString();

            Cobj.xrlblCompany.Font = SetLblFont(Cobj.xrlblCompany.Text);
            Cobj.xrlbloperation.Font = SetLblFont(Cobj.xrlbloperation.Text);
            Cobj.xrlbladdress.Font = SetLblFont(Cobj.xrlbladdress.Text);
            this.CertReport2.Report = Cobj;


            Cobj.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            Cobj.HtmlCharSet = "UTF-8";
            Cobj.Landscape = true;
            Cobj.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            Cobj.PageHeight = 1169;
            Cobj.PageWidth = 827;
            Cobj.PaperKind = System.Drawing.Printing.PaperKind.A4;
            DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            xrControlStyle1.BackColor = System.Drawing.Color.Transparent;
            Cobj.StyleSheet.Add("Style1", xrControlStyle1);

            Cobj.ShowPreview();
            //Cobj.Print();
        }
        else
        {
            this.Response.Write("<script language='javascript'>alert('未找到企业信息!!!')</script>");
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        setCopy();
        this.CertReport1.Report.Print();
    }


    protected void setCertCopyReport()
    {
        int recc = 0;
        DataSet ds = Common.Pager("MainSCTemp],[cert", "MainSCTemp.*,cert.StartTime,cert.EndTime", "MainSCTemp.ID", 10, 1, true, " cert.MainSCID=MainSCTemp.ID and  MainSCTemp.ID='" + Request.QueryString["ID"] + "'", out recc);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string PrinterName = System.Configuration.ConfigurationManager.AppSettings["Printer"];
            CertCopyReport Cobj = new CertCopyReport();

            Cobj.xrlbladdress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            Cobj.xrlblCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            Cobj.xrlblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            Cobj.xrlblfrdb.Text = ds.Tables[0].Rows[0]["frdb"].ToString();

            DateTime InvalTime = getDate(ds.Tables[0].Rows[0]["EndTime"].ToString());
            Cobj.xrlblinvalTime.Text = InvalTime.Year + "年 " + InvalTime.Month + "月 " + InvalTime.Day + "日";
            DateTime StartTime = getDate(ds.Tables[0].Rows[0]["StartTime"].ToString());
            Cobj.xrlstartTime.Text = StartTime.Year + "年 " + StartTime.Month + "月 " + StartTime.Day + "日";
            Cobj.xrlblLevel.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();




            Cobj.xrlbloperation.Text = "";

            OperationMainDAL objopMain = new OperationMainDAL();
            DataSet dsOperationMain = objopMain.SelectByMainIDMainSC(Request.QueryString["ID"]);
            for (int i = 0; i < dsOperationMain.Tables[0].Rows.Count; i++)
            {
                if (dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim() != "")
                    Cobj.xrlbloperation.Text += "," + dsOperationMain.Tables[0].Rows[i]["ProductName"].ToString().Trim();
            }
            Cobj.xrlbloperation.Text = Cobj.xrlbloperation.Text.Trim().TrimStart(",".ToCharArray());

            Cobj.xrlblphone.Text = ds.Tables[0].Rows[0]["phone"].ToString();

            Cobj.xrlblCompany.Font = SetLblFont(Cobj.xrlblCompany.Text);
            Cobj.xrlbloperation.Font = SetLblFont(Cobj.xrlbloperation.Text);
            Cobj.xrlbladdress.Font = SetLblFont(Cobj.xrlbladdress.Text);
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
        System.Drawing.Font Font1 = new Font("宋体", 14, FontStyle.Bold);
        if (str.Length > 45)
        {
            Font1 = new Font("宋体", (809 / str.Length) - 4, FontStyle.Bold);
        }
        return Font1;
    }
}
