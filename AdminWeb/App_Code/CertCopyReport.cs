using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Xml.Schema;
using DevExpress.XtraReports.UI;
using System.Drawing;
using DevExpress.XtraPrinting.Drawing;

/// <summary>
/// CertCopyReport 的摘要说明
/// </summary>
public class CertCopyReport :DevExpress.XtraReports.UI.XtraReport
{
    public CertCopyReport()
    {
       
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>

            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
    }
    private DetailBand Detail;
    public XRLabel xrlblCertNO;
    public XRLabel xrlblCompany;
    public XRLabel xrlblLevel;
    public XRLabel xrlbloperation;
    public XRLabel xrlblfrdb;
    public XRLabel xrlblphone;
    public XRLabel xrlblinvalTime;
    public XRLabel xrlbladdress;
    public XRLabel xrlstartTime;
    public XRLabel xrLabel1;
    public XRLabel xrLabel2;
    public XRLabel xrLabel3;
    public XRLabel xrLabel4;
    public XRLabel xrLabel5;
    public XRLabel xrLabel6;
    public XRLabel xrLabel7;
    public XRLabel xrLabel8;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null; 
    

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "CertCopyReport.resx";
            DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlstartTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblphone = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblinvalTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlbladdress = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblfrdb = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlbloperation = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblLevel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblCompany = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblCertNO = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrlstartTime,
            this.xrlblphone,
            this.xrlblinvalTime,
            this.xrlbladdress,
            this.xrlblfrdb,
            this.xrlbloperation,
            this.xrlblLevel,
            this.xrlblCompany,
            this.xrlblCertNO});
            this.Detail.Height = 800;
            this.Detail.Name = "Detail";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel8.Location = new System.Drawing.Point(58, 784);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(100, 25);
            this.xrLabel8.Text = "有效期限:";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel7.Location = new System.Drawing.Point(58, 735);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(100, 25);
            this.xrLabel7.Text = "联系电话:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel6.Location = new System.Drawing.Point(58, 687);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(100, 25);
            this.xrLabel6.Text = "联系地址:";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel5.Location = new System.Drawing.Point(58, 639);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(100, 25);
            this.xrLabel5.Text = "法人代表:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel4.Location = new System.Drawing.Point(58, 589);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 25);
            this.xrLabel4.Text = "业务范围:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel3.Location = new System.Drawing.Point(58, 544);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 25);
            this.xrLabel3.Text = "技术等级:";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel2.Location = new System.Drawing.Point(58, 493);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(100, 25);
            this.xrLabel2.Text = "单位名称:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel1.Location = new System.Drawing.Point(58, 443);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 25);
            this.xrLabel1.Text = "证书编号:";
            // 
            // xrlstartTime
            // 
            this.xrlstartTime.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlstartTime.Location = new System.Drawing.Point(868, 800);
            this.xrlstartTime.Name = "xrlstartTime";
            this.xrlstartTime.ParentStyleUsing.UseFont = false;
            this.xrlstartTime.Size = new System.Drawing.Size(200, 25);
            this.xrlstartTime.Text = "1007            11            12";
            // 
            // xrlblphone
            // 
            this.xrlblphone.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblphone.Location = new System.Drawing.Point(205, 735);
            this.xrlblphone.Name = "xrlblphone";
            this.xrlblphone.ParentStyleUsing.UseFont = false;
            this.xrlblphone.Size = new System.Drawing.Size(484, 33);
            this.xrlblphone.Text = "110755-1112121345";
            // 
            // xrlblinvalTime
            // 
            this.xrlblinvalTime.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblinvalTime.Location = new System.Drawing.Point(230, 784);
            this.xrlblinvalTime.Name = "xrlblinvalTime";
            this.xrlblinvalTime.ParentStyleUsing.UseFont = false;
            this.xrlblinvalTime.Size = new System.Drawing.Size(467, 25);
            this.xrlblinvalTime.Text = "1010      12      14";
            // 
            // xrlbladdress
            // 
            this.xrlbladdress.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlbladdress.Location = new System.Drawing.Point(205, 687);
            this.xrlbladdress.Name = "xrlbladdress";
            this.xrlbladdress.ParentStyleUsing.UseFont = false;
            this.xrlbladdress.Size = new System.Drawing.Size(484, 33);
            this.xrlbladdress.Text = "1深圳市福田区无委大厦14楼西";
            // 
            // xrlblfrdb
            // 
            this.xrlblfrdb.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblfrdb.Location = new System.Drawing.Point(205, 639);
            this.xrlblfrdb.Name = "xrlblfrdb";
            this.xrlblfrdb.ParentStyleUsing.UseFont = false;
            this.xrlblfrdb.Size = new System.Drawing.Size(484, 33);
            this.xrlblfrdb.Text = "某某某1";
            // 
            // xrlbloperation
            // 
            this.xrlbloperation.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlbloperation.Location = new System.Drawing.Point(205, 589);
            this.xrlbloperation.Name = "xrlbloperation";
            this.xrlbloperation.ParentStyleUsing.UseFont = false;
            this.xrlbloperation.Size = new System.Drawing.Size(750, 33);
            this.xrlbloperation.Text = "";
            // 
            // xrlblLevel
            // 
            this.xrlblLevel.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblLevel.Location = new System.Drawing.Point(205, 544);
            this.xrlblLevel.Name = "xrlblLevel";
            this.xrlblLevel.ParentStyleUsing.UseFont = false;
            this.xrlblLevel.Size = new System.Drawing.Size(484, 33);
            this.xrlblLevel.Text = "一级1";
            // 
            // xrlblCompany
            // 
            this.xrlblCompany.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblCompany.Location = new System.Drawing.Point(205, 493);
            this.xrlblCompany.Name = "xrlblCompany";
            this.xrlblCompany.ParentStyleUsing.UseFont = false;
            this.xrlblCompany.Size = new System.Drawing.Size(592, 33);
            this.xrlblCompany.Text = "深圳市测试公司1";
            // 
            // xrlblCertNO
            // 
            this.xrlblCertNO.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblCertNO.Location = new System.Drawing.Point(205, 443);
            this.xrlblCertNO.Name = "xrlblCertNO";
            this.xrlblCertNO.ParentStyleUsing.UseFont = false;
            this.xrlblCertNO.Size = new System.Drawing.Size(134, 25);
            this.xrlblCertNO.Text = "07-0629A1";
            // 
            // CertCopyReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HtmlCharSet = "UTF-8";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            xrControlStyle1.BackColor = System.Drawing.Color.Transparent;
            this.StyleSheet.Add("Style1", xrControlStyle1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void lbShipCityRegionPostalCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
        private void lbCityRegionPostalCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        private void clTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private System.Resources.ResourceManager GetResourceManager()
        {
            return Resources.CertReport.ResourceManager;

        }
}
