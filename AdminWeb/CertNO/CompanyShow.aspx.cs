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

public partial class CertNO_CompanyShow : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(21))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7725))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
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
               Common.Pager("MainSC", "*", "ID", 100, 1, true, "MainSCID='" + MID + "'",
                            out recc);
            if (recc < 1)
                return;
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
            lblTitle.Text = "申请表审核  " + getMainNO(MID, Request.QueryString["tid"]);
        }
    }
    private void GVData_Init()
    {

        if (null != Request.QueryString["MID"])
        {
            int recc;
            string MID = Request.QueryString["MID"];
            DataSet dsMemployee =
                Common.Pager("employee", "*", "ID", 100, 1, true, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
            gvMemployee.DataSource = dsMemployee;
            gvMemployee.DataBind();

            DataSet dsWemployee =
               Common.Pager("employee", "*", "ID", 100, 1, true, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                            out recc);
            gvWemployee.DataSource = dsWemployee;
            gvWemployee.DataBind();

            DataSet dsElist1 =
              Common.Pager("equipment", "*", "ID", 100, 1, true, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                           out recc);
            gvEList.DataSource = dsElist1;
            gvEList.DataBind();

            DataSet dsElist2 =
             Common.Pager("equipment", "*", "ID", 100, 1, true, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                          out recc);
            gvElist2.DataSource = dsElist2;
            gvElist2.DataBind();

            DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name", "CSlist.ID", 100, 1, true, "CSlist.MainSCID='" + MID + "' and CSlist.CSFileID=CSFileDict.ID ",
                            out recc);
            gvCSFile.DataSource = dsCSFile;
            gvCSFile.DataBind();

            DataSet dsOperationMain =
                Common.Pager("OperationMain", "ID,ProductID,MainSCID,(select CN_Name from dict_product where ID=OperationMain.ProductID) as ProductName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
             out recc);
            gvOperationMain.DataSource = dsOperationMain;
            gvOperationMain.DataBind();


            DataSet dsOperation =
              Common.Pager("Operation", "ID,SortID,brand,Content,MainSCID,(select CN_Name from dict_product where ID=Operation.SortID) as SortName,(select Name from dict_brand where ID=Operation.brand) as BrandName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                           out recc);
            if (dsOperation.Tables[0].Rows.Count > 0)
            {
                pnlOperation.Visible = true;
            }
            gvOperation.DataSource = dsOperation;
            gvOperation.DataBind();
        }
    }
}
