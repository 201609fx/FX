using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Xml.Schema;
using DevExpress.XtraReports.UI;
using System.Drawing;
using DevExpress.XtraPrinting.Drawing;

/// <summary>
/// CertReport 的摘要说明
/// </summary>
namespace SZMA.AdminWeb
{
    public class CertReport : DevExpress.XtraReports.UI.XtraReport
    {
        private DetailBand Detail;
        public XRLabel xrlblCompany;
        public XRLabel xrlblLevel;
        public XRLabel xrlblCertNO;
        public XRLabel xrlblOperation;
        public XRLabel xrlblInvalTime;
        public XRLabel xrlblStartTime;
        public XRLabel xrLabel1;
        public XRLabel xrLabel2;
        public XRLabel xrLabel3;
        public XRLabel xrLabel4;
        public XRLabel xrLabel5;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CertReport()
        {
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>

            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public CertReport(bool flag)
        {
            
            //xrLabel1.Visible = flag;
            //xrLabel2.Visible = flag;

        }

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
            string resourceFileName = "CertReport.resx";
            DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrlblStartTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblInvalTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblOperation = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblCertNO = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblLevel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblCompany = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrlblStartTime,
            this.xrlblInvalTime,
            this.xrlblOperation,
            this.xrlblCertNO,
            this.xrlblLevel,
            this.xrlblCompany});
            this.Detail.Height = 1169;
            this.Detail.Name = "Detail";
            // 
            // xrlblStartTime
            // 
            this.xrlblStartTime.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.xrlblStartTime.Location = new System.Drawing.Point(1150, 970);
            this.xrlblStartTime.Name = "xrlblStartTime";
            this.xrlblStartTime.ParentStyleUsing.UseFont = false;
            this.xrlblStartTime.Size = new System.Drawing.Size(400, 42);
            this.xrlblStartTime.Text = "2007    11    12";
            // 
            // xrlblInvalTime
            // 
            this.xrlblInvalTime.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.xrlblInvalTime.Location = new System.Drawing.Point(300, 972);
            this.xrlblInvalTime.Name = "xrlblInvalTime";
            this.xrlblInvalTime.ParentStyleUsing.UseFont = false;
            this.xrlblInvalTime.Size = new System.Drawing.Size(500, 34);
            this.xrlblInvalTime.Text = "2012      11      12";
            // 
            // xrlblOperation
            // 
            this.xrlblOperation.Font = new System.Drawing.Font("华文宋体", 35F, System.Drawing.FontStyle.Bold);
            this.xrlblOperation.Location = new System.Drawing.Point(400, 750);
            this.xrlblOperation.Name = "xrlblOperation";
            this.xrlblOperation.ParentStyleUsing.UseFont = false;
            this.xrlblOperation.Size = new System.Drawing.Size(1225, 92);
            this.xrlblOperation.Text = "";
            // 
            // xrlblCertNO
            // 
            this.xrlblCertNO.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.xrlblCertNO.Location = new System.Drawing.Point(300, 930);
            this.xrlblCertNO.Name = "xrlblCertNO";
            this.xrlblCertNO.ParentStyleUsing.UseFont = false;
            this.xrlblCertNO.Size = new System.Drawing.Size(1000, 33);
            this.xrlblCertNO.Text = "07-0001A";
            // 
            // xrlblLevel
            // 
            this.xrlblLevel.Font = new System.Drawing.Font("华文宋体", 35F, System.Drawing.FontStyle.Bold);
            this.xrlblLevel.Location = new System.Drawing.Point(400, 658);
            this.xrlblLevel.Name = "xrlblLevel";
            this.xrlblLevel.ParentStyleUsing.UseFont = false;
            this.xrlblLevel.Size = new System.Drawing.Size(1225, 75);
            this.xrlblLevel.Text = "一级";
            // 
            // xrlblCompany
            // 
            this.xrlblCompany.Font = new System.Drawing.Font("华文宋体", 35F, System.Drawing.FontStyle.Bold);
            this.xrlblCompany.Location = new System.Drawing.Point(400, 575);
            this.xrlblCompany.Name = "xrlblCompany";
            this.xrlblCompany.ParentStyleUsing.UseFont = false;
            this.xrlblCompany.Size = new System.Drawing.Size(1225, 75);
            this.xrlblCompany.Text = "深圳市宝时商业机器有限公司测试测试测试测试测试1测试测试1测试测试1测试测试1测试";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("宋体", 40F);
            this.xrLabel1.Location = new System.Drawing.Point(108, 575);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(275, 83);
            this.xrLabel1.Text = "单位名称:";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("宋体", 40F);
            this.xrLabel2.Location = new System.Drawing.Point(108, 658);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(275, 84);
            this.xrLabel2.Text = "技术等级:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("宋体", 40F);
            this.xrLabel3.Location = new System.Drawing.Point(108, 750);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(275, 83);
            this.xrLabel3.Text = "业务范围:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("宋体", 23F);
            this.xrLabel4.Location = new System.Drawing.Point(108, 930);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(167, 42);
            this.xrLabel4.Text = "证书编号:";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("宋体", 25F);
            this.xrLabel5.Location = new System.Drawing.Point(108, 972);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(167, 50);
            this.xrLabel5.Text = "有效期限:";
            // 
            // CertReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HtmlCharSet = "UTF-8";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
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
}
