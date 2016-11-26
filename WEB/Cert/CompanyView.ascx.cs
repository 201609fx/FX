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

public partial class Cert_CompanyView : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string save = Request["save"];
            
            if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
            {
                string MID = Request.QueryString["id"];
                int recc;
                DataSet ds =
                   Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'",
                                out recc);
                if (recc < 1)
                    return;
                //lblShow.Text = getNoteNum(ds.Tables[0].Rows[0]["ID"].ToString());
                //lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();

                string noStr = getNoteNum(ds.Tables[0].Rows[0]["ID"].ToString());
                string cName = ds.Tables[0].Rows[0]["Company"].ToString();
                if (save == "0")
                {
                    //保存
                    litSaveType.Text = @"您的资料已经<font style='font-size: 15px;font-weight: bolder;' class='text-red'>保存</font>成功。您的记录号是 <font style='font-size: 15px;font-weight: bolder;' class='text-red'>" + noStr + "</font>，您的公司名称是<font  style='font-size: 15px;font-weight: bolder;'  class='text-red'>" + cName + "</font>，请注意保存以备查询。";
                }
                else
                {
                    //提交
                    litSaveType.Text = @"您的资料已经<font style='font-size: 15px;font-weight: bolder;' class='text-red'>提交</font>成功。您的记录号是 <font style='font-size: 15px;font-weight: bolder;' class='text-red'>" + noStr + "</font>，您的公司名称是<font  style='font-size: 15px;font-weight: bolder;'  class='text-red'>" + cName + "</font>，请注意保存以备查询。";
                }
            }
        }
    }
}
