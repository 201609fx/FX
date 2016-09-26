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
    public class testRe : DevExpress.XtraReports.UI.XtraReport
    {
        private DetailBand Detail;
        public XRLabel xrlblCompany;
        public XRLabel xrlblLevel;
        public XRLabel xrlblCertNO;
        public XRLabel xrlblOperation;
        public XRLabel xrlblInvalTime;
        public XRLabel xrlblStartTime;
        public XRLabel xrLabel1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public testRe()
        {
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>

            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public testRe(bool flag)
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
            string resourceFileName = "testRe.resx";

            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.Detail.Height = 700;
            this.Detail.Name = "Detail";

            this.xrLabel1.Font = new System.Drawing.Font("宋体", 14F);
            this.xrLabel1.Location = new System.Drawing.Point(58, 500);
            this.xrLabel1.Name = "xrLabel8";
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 25);
            this.xrLabel1.Text = "有效期限:";
            // 

            // testRe
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
}
