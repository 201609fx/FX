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

public partial class workaround_lastApprove_edit : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckRight(SZMA.BLL.Rights.szma_work_approve, Common.opt_ma))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        btnSubmit.OnClientClick = "return confirm('您确定要保存操作吗?')";
        if (!IsPostBack)
        {
            data_init();
        }

    }

    private void data_init()
    {
        ApproveDAL obj = new ApproveDAL();
        DataSet ds = obj.SelectAllByMID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            string CertNO =
                getCertNO(ds.Tables[0].Rows[0]["CertNO"].ToString(), ds.Tables[0].Rows[0]["Type"].ToString(),
                          ds.Tables[0].Rows[0]["oldCertNO"].ToString(), Request.QueryString["id"]);
            lblCertNO.Text = (CertNO == "" ? "" : getLevel(CertNO));
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString() == ""
                                 ? "等级证书编号:" + CertNO
                                 : ds.Tables[0].Rows[0]["Remark"].ToString();
            txtSuggest.Text = ds.Tables[0].Rows[0]["suggest"].ToString();
            txtSuperintendent.Text = ds.Tables[0].Rows[0]["Superintendent"].ToString();
            dpSTime.Date = ds.Tables[0].Rows[0]["stime"].ToString() == "" ? DateTime.Now.ToString("yyyy-MM-dd") : getTime(ds.Tables[0].Rows[0]["stime"].ToString());
            txtCertNO.Text = CertNO;

             this.txtPromoter.Text=ds.Tables[0].Rows[0]["Promoter"].ToString();
            this.txtPsuggest.Text=ds.Tables[0].Rows[0]["Psuggest"].ToString();
            this.dpPTime.Date=getDate(ds.Tables[0].Rows[0]["Ptime"].ToString()).ToString("yyyy-MM-dd");

            this.txtLeader.Text = ds.Tables[0].Rows[0]["Leader"].ToString();
            this.txtLsuggest.Text=ds.Tables[0].Rows[0]["Lsuggest"].ToString();
            this.dpLTime.Date=getDate(ds.Tables[0].Rows[0]["Ltime"].ToString()).ToString("yyyy-MM-dd");
        }
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName = this.AdminUser.Username;
        ApproveDAL obj = new ApproveDAL();
        if (obj.UpdateAll(txtSuperintendent.Text, txtSuggest.Text.Replace("\r\n", "<br>"), getDate(dpSTime.Date),
            this.txtPromoter.Text, this.txtPsuggest.Text.Replace("\r\n", "<br>"), getDate(this.dpPTime.Date),
            this.txtLeader.Text, this.txtLsuggest.Text.Replace("\r\n", "<br>"), getDate(this.dpLTime.Date), 
            txtRemark.Text.Replace("\r\n", "<br>"), UserName, Request.QueryString["id"]) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
        this.Response.Redirect("lastApprove.aspx");
    }
    protected void btnCert_Click(object sender, EventArgs e)
    {
        string s = txtCertNO.Text.Trim();
        if (!CheckCertNO(ref s))
        {
            return;
        }
        txtCertNO.Text = s;
        CertNODAL objCert = new CertNODAL();
        DataSet dsMain = objCert.MainSC_SelectBYNEWCertNO(Request.QueryString["id"], txtCertNO.Text.Trim());
        if (dsMain.Tables[0].Rows.Count > 0)
        {
            this.Response.Write("<script language='javascript'> alert('该证书号已被" + dsMain.Tables[0].Rows[0]["Company"].ToString() + "使用!')</script>");
            return;
        }

        ApproveDAL obj = new ApproveDAL();
        DataSet ds = obj.SelectByMID(Request.QueryString["id"]);
        string CertNO =
            getCertNO(ds.Tables[0].Rows[0]["CertNO"].ToString(), ds.Tables[0].Rows[0]["Type"].ToString(),
                      ds.Tables[0].Rows[0]["oldCertNO"].ToString(), Request.QueryString["id"]);
        if (Common.Update("MainSCTemp", "ID", Request.QueryString["id"], new string[] { "CertNO" }, new string[] { txtCertNO.Text.Trim() }))
        {
            if (CertNO != txtCertNO.Text.Trim())
            {
                txtRemark.Text = txtRemark.Text.Replace(CertNO, txtCertNO.Text.Trim());
            }
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
    }

    private bool CheckCertNO(ref string s)
    {
        string str = s;
        if (str.Length != 8)
        {
            this.Response.Write("<script language='javascript'> alert('证书号长度应为8位!')</script>");
            s = str;
            return false;
        }
        string sa = str.Substring(str.Length - 1, 1);
        if (sa.ToLower() != "a" && sa.ToLower() != "b" && sa.ToLower() != "c")
        {
            this.Response.Write("<script language='javascript'> alert('证书号应以 A,B,C,a,b,c中的一个结尾!')</script>");
            s = str;
            return false;
        }
        s = str.Substring(0, str.Length - 1) + sa.ToUpper();
        return true;
    }
}
