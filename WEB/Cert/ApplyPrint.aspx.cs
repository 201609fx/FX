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

public partial class Cert_ApplyPrint : SZMA.Core.Client.BasePageByPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PageTitle = "申请书打印";
        if(null!=Request.QueryString["id"]&&Request.QueryString["id"]!="")
        {
            lblID.Text = Request.QueryString["id"];
            Data_Init();
        }
    }
    private void Data_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;
            DataSet ds =
               Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'",
                            out recc);
            if (recc < 1)
                return;
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtAnum.Text = ds.Tables[0].Rows[0]["Anum"].ToString();
            txtArea.Text = ds.Tables[0].Rows[0]["Area"].ToString();
            txtBnum.Text = ds.Tables[0].Rows[0]["Bnum"].ToString();
            txtCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
            txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtFrdb.Text = ds.Tables[0].Rows[0]["Frdb"].ToString();
            txtFtel.Text = ds.Tables[0].Rows[0]["Ftel"].ToString();
            txtMnum.Text = ds.Tables[0].Rows[0]["Mnum"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtOperation.Text = ds.Tables[0].Rows[0]["Operation"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtSummary.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
            GV_Init();
            lblNO.Text = getMainNO(ds.Tables[0].Rows[0]["ID"].ToString(), ds.Tables[0].Rows[0]["type"].ToString());
            lblApplyName.Text = ds.Tables[0].Rows[0]["type"].ToString() == "1" ? "申请表" : "晋级申请表";
            pnlSummary.Visible = (ds.Tables[0].Rows[0]["type"].ToString() == "2"); 
        }
    }

    private void GV_Init()
    {
        gvMemployeeData_Init();
        gvWemployeeData_Init();
        gvEList2Data_Init();
        gvEListData_Init();
        gvCSFileData_init();
        gvListData_Init();
    }

    protected void gvMemployeeData_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;
            DataSet dsMemployee =
                Common.Pager("employee", "ID,Name,educational,Eposition,certName,remark", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
            if (dsMemployee.Tables[0].Rows.Count < 1)
            {
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
            }
            gvMemployee.DataSource = dsMemployee;
            gvMemployee.DataBind();
        }
    }

    protected void gvWemployeeData_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsWemployee =
                Common.Pager("employee", "ID,Name,educational,Eposition,certName,remark", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                             out recc);
            if (dsWemployee.Tables[0].Rows.Count < 1)
            {
                dsWemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
            }
            gvWemployee.DataSource = dsWemployee;
            gvWemployee.DataBind();
        }
    }

    protected void gvEListData_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsElist1 =
                Common.Pager("equipment", "ID,Num,des,MainSCID", "ID", 100, 1, true, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
            if (dsElist1.Tables[0].Rows.Count < 1)
            {
                dsElist1.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }
            gvEList.DataSource = dsElist1;
            gvEList.DataBind();
        }
    }

    protected void gvEList2Data_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsElist2 =
                Common.Pager("equipment", "ID,Num,des,MainSCID", "ID", 100, 1, true, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                             out recc);
            if (dsElist2.Tables[0].Rows.Count < 1)
            {
                dsElist2.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }
            gvElist2.DataSource = dsElist2;
            gvElist2.DataBind();
        }
    }

    protected void gvCSFileData_init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name,CSFileDict.ID as cID", "cID", 100, 1, false, "CSlist.MainSCID='" + MID + "' and CSlist.CSFileID=CSFileDict.ID ",
                                            out recc);
            if (dsCSFile.Tables[0].Rows.Count < 1)
            {
                dsCSFile.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }
            gvCSFile.DataSource = dsCSFile;
            gvCSFile.DataBind();
        }
    }

    protected void gvListData_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet ds =
                Common.Pager("Operation", "ID,SortID,brand,Content,MainSCID,(select name from dict_product where ID=Operation.SortID) as SortName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                             out recc);
            if(ds.Tables[0].Rows.Count<1)
            {
                pnlOperation.Visible = false;
            }
            gvList.DataSource = ds;
            gvList.DataBind();
        }
    }
}
