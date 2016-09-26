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

public partial class CompanyAdd_Default : SZMA.Core.Admin.PageBase
{
    protected string strMemployee;
    protected string strWemployee;
    protected string strEList;
    protected string strEList2;
    protected string strCSFil;
    protected string strOp;
    protected string strOperation;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(23))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7732))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            GV_Init();
            if (null != Request.QueryString["id"] && Request.QueryString["id"] != "" && (null == Request.QueryString["staus"] || Request.QueryString["staus"] == ""))
                lblID.Text = this.Request.QueryString["id"];
            else
            {
                MainSCTempDAL obj = new MainSCTempDAL();
                DataSet ds = obj.Insert();
                lblID.Text = ds.Tables[0].Rows[0][0].ToString();
            }

            if (lblID.Text != "")
            {
                strMemployee = "Memployee.aspx?id=" + lblID.Text;
                strWemployee = "Wemployee.aspx?id=" + lblID.Text;
                strEList = "EList.aspx?id=" + lblID.Text;
                strEList2 = "EList2.aspx?id=" + lblID.Text;
                strCSFil = "CSFil.aspx?id=" + lblID.Text;
                strOp = "Op.aspx?id=" + lblID.Text;
                strOperation = "Operation.aspx?id=" + lblID.Text;
            }

            Data_Init();
        }

        cbOp.Attributes.Add("onclick", "javascript:cbop()");
        btnSum.OnClientClick = "return confirm('提交以后将无法修改资料,确认提交么?')";
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
            string AreaID = ds.Tables[0].Rows[0]["AreaID"].ToString().Trim();
            ddlAreaID.SelectedValue = (AreaID == "" ? "0" : AreaID);
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtSummary.Text = ds.Tables[0].Rows[0]["Summary"].ToString().Replace("<br>", "\r\n");
            lblSortName.Text = "编号：" + getMainNO(MID, (null == Request.QueryString["type"] || Request.QueryString["type"] == "") ? ds.Tables[0].Rows[0]["type"].ToString() : Request.QueryString["type"]);
            txtOldCertNO.Text = ds.Tables[0].Rows[0]["oldCertNO"].ToString();
            txtNewCertNO.Text = ds.Tables[0].Rows[0]["newCertNO"].ToString();
            pnlCert.Visible = false;
            pnlSummary.Visible = false;
            pnlSuggest.Visible = false;
            if (ds.Tables[0].Rows[0]["type"].ToString() == "2" || (null != Request.QueryString["type"] && Request.QueryString["type"] == "2"))
            {
                pnlCert.Visible = true;
                pnlSummary.Visible = true;
            }
            if (ds.Tables[0].Rows[0]["InsertFlag"].ToString() == "2")///审核通过后不能修改
            {
                pnlSuggest.Visible = true;
                lblSuggest.Text = ds.Tables[0].Rows[0]["Suggest"].ToString();
            }
            //if ((ds.Tables[0].Rows[0]["InsertFlag"].ToString() == "3" || ds.Tables[0].Rows[0]["InsertFlag"].ToString() == "1") && ds.Tables[0].Rows[0]["state"].ToString() != "")///审核通过后不能修改
            //{
            //    txtAddress.Enabled = false;
            //    txtAnum.Enabled = false;
            //    txtArea.Enabled = false;
            //    txtBnum.Enabled = false;
            //    txtCode.Enabled = false;
            //    txtCompany.Enabled = false;
            //    txtContact.Enabled = false;
            //    txtFax.Enabled = false;
            //    txtFrdb.Enabled = false;
            //    txtFtel.Enabled = false;
            //    txtMnum.Enabled = false;
            //    txtMobile.Enabled = false;
            //    txtPhone.Enabled = false;
            //    txtSummary.Enabled = false;
            //    lblSortName.Enabled = false;
            //    txtOldCertNO.Enabled = false;
            //    txtNewCertNO.Enabled = false;
            //    ddlAreaID.Enabled = false;
            //    strMemployee = "Memployee.aspx?id=" + lblID.Text + "&staus=1";
            //    strWemployee = "Wemployee.aspx?id=" + lblID.Text + "&staus=1";
            //    strEList = "EList.aspx?id=" + lblID.Text + "&staus=1";
            //    strEList2 = "EList2.aspx?id=" + lblID.Text + "&staus=1";
            //    strCSFil = "CSFil.aspx?id=" + lblID.Text + "&staus=1";
            //    strOp = "Op.aspx?id=" + lblID.Text + "&staus=1";
            //    strOperation = "Operation.aspx?id=" + lblID.Text + "&staus=1";
            //}
        }
    }

    private void GV_Init()
    {
        dictAreaDAL obj = new dictAreaDAL();
        DataSet ds = obj.Select();
        ddlAreaID.DataSource = ds;
        ddlAreaID.DataBind();
        ddlAreaID.Items.Insert(0, new ListItem("请选择所属区域", "0"));
    }




    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(23))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7732))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string Address = txtAddress.Text;
        string Anum = txtAnum.Text;
        string Area = txtArea.Text;
        string Bnum = txtBnum.Text;
        string Code = txtCode.Text;
        string Company = txtCompany.Text;
        string Contact = txtContact.Text;
        string Fax = txtFax.Text;
        string Frdb = txtFrdb.Text;
        string Ftel = txtFtel.Text;
        string Mnum = txtMnum.Text;
        string Mobile = txtMobile.Text;
        string Phone = txtPhone.Text;
        string Summary = txtSummary.Text.Replace("\r\n", "<br>");
        if (pnlCert.Visible && txtOldCertNO.Text == "")
        {
            this.Response.Write("<script language=javascript>alert('请填写证书信息!')</script>");
            return;
        }

        int TypeID = getTypeID();
        if (TypeID == 2)
        {
            MainSCDAL objMainSC = new MainSCDAL();
            if (objMainSC.SelectBYCertNO(txtOldCertNO.Text).Tables[0].Rows.Count < 1)
            {
                this.Response.Write("<script language=javascript>alert('您的原证书号不存在!')</script>");
                return;
            }
        }
        if (Company == "")
        {

            this.Response.Write("<script language=javascript>alert('请填写公司名称!')</script>");
            return;
        }

        if (Address == "")
        {

            this.Response.Write("<script language=javascript>alert('请填写公司地址!')</script>");
            return;
        }
        
        MainSCTempDAL obj = new MainSCTempDAL();
        int i = getTypeID();
        if (obj.Update(ddlAreaID.SelectedValue, Company, Address, Code, Contact, Phone, Mobile, Fax,
                      Frdb, Ftel, Area, Anum, Mnum, Bnum, getTypeID(), Summary,
                      DateTime.Now, 4, "", txtOldCertNO.Text, txtNewCertNO.Text, lblID.Text) > 0)
        {
            this.Response.Redirect("CompanyList.aspx");
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('保存失败!!!" + lblID.Text + "')</script>");
        }

    }

    private int getTypeID()
    {
        int rtn = 1;
        try
        {
            //rtn = int.Parse(Request.QueryString["type"]);
            if (pnlCert.Visible) 
            {
                rtn = 2;
            }
        }
        catch
        {
        }
        if (rtn == 1)
        {
            if (!CheckAdminRight(23))
            {
                this.Response.Redirect("../NoRight.aspx");
                return 0;
            }
            //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd_1, Common.opt_ma))
            //{
            //    this.Response.Redirect("../NoRight.aspx", true);
            //    return 0;
            //}
            //if (!checkYUright(7732))
            //{
            //    this.Response.Redirect("../NoRight.aspx");
            //    return 0;
            //}
        }
        else if(rtn==2)
        {
            if (!CheckAdminRight(23))
            {
                this.Response.Redirect("../NoRight.aspx");
                return 0;
            }
            //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd_2, Common.opt_ma))
            //{
            //    this.Response.Redirect("../NoRight.aspx", true);
            //    return 0;
            //} 
            //if (!checkYUright(7732))
            //{
            //    this.Response.Redirect("../NoRight.aspx");
            //    return 0;
            //}
        }
        return rtn;
    }

    protected void btnSum_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(23))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7732))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string Address = txtAddress.Text;
        string Anum = txtAnum.Text;
        string Area = txtArea.Text;
        string Bnum = txtBnum.Text;
        string Code = txtCode.Text;
        string Company = txtCompany.Text;
        string Contact = txtContact.Text;
        string Fax = txtFax.Text;
        string Frdb = txtFrdb.Text;
        string Ftel = txtFtel.Text;
        string Mnum = txtMnum.Text;
        string Mobile = txtMobile.Text;
        string Phone = txtPhone.Text;
        string Summary = txtSummary.Text.Replace("\r\n", "<br>");
        if (pnlCert.Visible && txtOldCertNO.Text == "")
        {
            this.Response.Write("<script language=javascript>alert('请填写证书信息!')</script>");
            return;
        }
        int TypeID = getTypeID();
        if (TypeID == 2)
        {
            MainSCDAL objMainSC = new MainSCDAL();
            if (objMainSC.SelectBYCertNO(txtOldCertNO.Text).Tables[0].Rows.Count < 1)
            {
                this.Response.Write("<script language=javascript>alert('您的原证书号不存在!')</script>");
                return;
            }
        }
        if (Company == "" || Address == "" || Contact == "" || Fax == "" || Mobile == "" || Phone == "" || Frdb == "" || Ftel == "")
        {

            this.Response.Write("<script language=javascript>alert('资料未填写完全!')</script>");
            return;
        }
        if (ddlAreaID.SelectedIndex == 0)
        {
            this.Response.Write("<script language=javascript>alert('请选择所属区域!')</script>");
            return;
        }
       
        MainSCTempDAL obj = new MainSCTempDAL();
        int i = getTypeID();
        if (obj.Update(ddlAreaID.SelectedValue, Company, Address, Code, Contact, Phone, Mobile, Fax,
                      Frdb, Ftel, Area, Anum, Mnum, Bnum, getTypeID(), Summary,
                      DateTime.Now, 0, "0", txtOldCertNO.Text, txtNewCertNO.Text, lblID.Text) > 0)
        {
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('保存失败!!!" + lblID.Text + "')</script>");
        }

        if (Common.Update("MainSCTemp", "ID", lblID.Text, new string[] { "InsertFlag" }, new string[] { "1" }))
        {
            if (TypeID == 2)
            {
                this.Response.Redirect("../workaround/FirstAuditing.aspx?tid=2");
            }
            else 
            {
                this.Response.Redirect("../workaround/FirstAuditing.aspx?tid=1");
            }
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('提交失败!!!" + lblID.Text + "')</script>");
        }

    }
}
