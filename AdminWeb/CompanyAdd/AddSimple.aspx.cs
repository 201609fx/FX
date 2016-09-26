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

public partial class CompanyAdd_AddSimple : SZMA.Core.Admin.PageBase
{
    protected string strOperation;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(26))
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
            if (null != Request.QueryString["id"] && Request.QueryString["id"] != "" && (null == Request.QueryString["staus"] || Request.QueryString["staus"] == ""))
                lblID.Text = this.Request.QueryString["id"];
            else
            {
                MainSCTempDAL obj = new MainSCTempDAL();
                DataSet ds = obj.Insert();
                lblID.Text = ds.Tables[0].Rows[0][0].ToString();
                strOperation = "Operation.aspx?id=" + lblID.Text;
            }

            Data_Init();
        }

        btnSum.OnClientClick = "return confirm('提交以后将无法修改资料,确认提交?')";
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
            txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtCertNO.Text = ds.Tables[0].Rows[0]["CertNO"].ToString();
            ddlType.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
         
        }
    }





    private int getTypeID()
    {
        int rtn = 1;
        try
        {
            rtn = int.Parse(this.ddlType.SelectedValue);
        }
        catch
        {
        }
        if (!CheckAdminRight(26))
        {
            this.Response.Redirect("../NoRight.aspx");
            return 0;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd_Simple, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx", true);
        //    return 0;
        //}
        //if (!checkYUright(7732))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return 0;
        //}
        return rtn;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(26))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd_Simple, Common.opt_ma))
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
        string Company = txtCompany.Text;
        string Contact = txtContact.Text;
        string Phone = txtPhone.Text;
        string CertNO = txtCertNO.Text;
        int TypeID = getTypeID();
        if (Company == "" || Address == "" || CertNO == "")
        {

            this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
            return;
        }
        MainSCTempDAL obj = new MainSCTempDAL();
        int i = getTypeID();
        if (obj.Update("", Company, Address, "", Contact, Phone, "", "",
                      "", "", "", "", "", "", TypeID, "",
                      DateTime.Now, 4, "7", "", "", lblID.Text)
                      > 0)
        {
            Common.Update("MainSCTemp", "ID", lblID.Text, new string[] { "CertNo" }, new string[] { CertNO });
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('保存失败!!!" + lblID.Text + "')</script>");
        }

        if (Common.Update("MainSCTemp", "ID", lblID.Text, new string[] { "InsertFlag" }, new string[] { "3" }))
        {
            CertNODAL objCert = new CertNODAL();
            //objCert.Insert(lblID.Text, AdminUser.GH,3);
            int i2 = 1;
            try
            {
                i2 = int.Parse(System.Configuration.ConfigurationManager.AppSettings["InvailTime"]);
            }
            catch
            {
            }
            if (objCert.Insert(lblID.Text, AdminUser.GH, DateTime.Now, DateTime.Now.AddYears(i2)) < 1)
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
            MainSCDAL mobj = new MainSCDAL();
            if (mobj.Insert(lblID.Text) > 0)
            {
                Common.Delete("MainSCTemp", "ID", lblID.Text);
            }
            this.Response.Redirect("AddSimple.aspx");
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('提交失败!!!" + lblID.Text + "')</script>");
        }

    }

    protected void btnSum_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(26))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd_Simple, Common.opt_ma))
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
        string Company = txtCompany.Text;
        string Contact = txtContact.Text;
        string Phone = txtPhone.Text;
        string CertNO = txtCertNO.Text;
        int TypeID = getTypeID();
        if (Company == "" || Address == ""||CertNO=="")
        {

            this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
            return;
        }
        MainSCTempDAL obj = new MainSCTempDAL();
        int i = getTypeID();
        if (obj.Update("", Company, Address, "", Contact, Phone, "", "",
                      "", "", "", "", "", "", TypeID, "",
                      DateTime.Now, 4, "6", "", "", lblID.Text)
                      > 0)
        {
            Common.Update("MainSCTemp", "ID", lblID.Text, new string[] { "CertNo" }, new string[] { CertNO });
         
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('保存失败!!!" + lblID.Text + "')</script>");
        }

        if (Common.Update("MainSCTemp", "ID", lblID.Text, new string[] { "InsertFlag" }, new string[] { "3" }))
        {
            CertNODAL objCert = new CertNODAL();
            //objCert.Insert(lblID.Text, AdminUser.GH, 3);
            int i2 = 1;
            try
            {
                i2 = int.Parse(System.Configuration.ConfigurationManager.AppSettings["InvailTime"]);
            }
            catch
            {
            }
            if (objCert.Insert(lblID.Text, AdminUser.GH, DateTime.Now, DateTime.Now.AddYears(i2)) < 1)
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
            MainSCDAL mobj = new MainSCDAL();
            if (mobj.Insert(lblID.Text) > 0)
            {
                Common.Delete("MainSCTemp", "ID", lblID.Text);
            }
            this.Response.Redirect("../CertNO/CertNOList.aspx?time=" + DateTime.Now.Ticks.ToString());
        }
        else
        {
            this.Response.Write("<script language=javascript>alert('提交失败!!!" + lblID.Text + "')</script>");
        }

    }
}
