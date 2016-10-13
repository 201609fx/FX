using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SZMA.DataLayer;

public partial class Cert_CertApply : SZMA.Core.Client.BasePage
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
        //if (!IsPostBack)
        //{
        //    #region 尝试从session中获取申请单号 null则重新创建一个 #存在问题，一直获取不到Session的值#
        //    if (null != this.Session["mid"]
        //            && this.Session["mid"].ToString() != ""
        //            && (null == Request.QueryString["staus"] || Request.QueryString["staus"] == ""))
        //    {
        //        lblID.Text = this.Session["mid"].ToString();
        //    }
        //    else
        //    {
        //        Session["mid"] = "";
        //        MainSCTempDAL obj = new MainSCTempDAL();
        //        DataSet ds = obj.Insert();
        //        lblID.Text = ds.Tables[0].Rows[0][0].ToString();
        //        Session.Add("mid",lblID.Text.Trim());
        //    } 
        //    #endregion

        //    if (lblID.Text != "")
        //    {
        //        //iframe src
        //        strMemployee = "Memployee.aspx?id=" + lblID.Text;
        //        strWemployee = "Wemployee.aspx?id=" + lblID.Text;
        //        strEList = "EList.aspx?id=" + lblID.Text;
        //        strEList2 = "EList2.aspx?id=" + lblID.Text;
        //        strCSFil = "CSFil.aspx?id=" + lblID.Text;
        //        strOp = "Op.aspx?id=" + lblID.Text;
        //        strOperation = "Operation.aspx?id=" + lblID.Text;


        //        string MID = lblID.Text;
        //        int recc;
        //        DataSet ds =
        //           Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'",
        //                        out recc);
        //        if (recc < 1)
        //            return;
        //        //lable:申请类型 及编号
        //        lblSortName.Text = "编号：" + getMainNO(lblID.Text, (null == Request.QueryString["type"] || Request.QueryString["type"] == "") ? ds.Tables[0].Rows[0]["type"].ToString() : Request.QueryString["type"]);

        //        //存储编号到页面，供前端调用
        //        litApplyNo.Text = lblID.Text.Trim().PadLeft(5, '0');
        //    }


            
        //}
    }






    public string getMainNO(string mid, string tid)
    {
        return "(" + (tid == "2" ? "晋" : "申") + ")" + mid.PadLeft(5, '0');
    }
}