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

public partial class Cert_Search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if(txtNO.Text==""||txtCompany.Text=="")
        {
            this.Response.Write("<script language=javascript>alert('记录号和公司名称都不能为空!!')</script>");
            return;
        }
        string no = getno(txtNO.Text.Trim());
        string Company = txtCompany.Text.Trim();
        int recc = 0;
       DataSet ds= Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, " NoteNum = '" + no + "' and Company ='" + Company + "'",
                     out recc);
        if(recc==0)
        {
            this.Response.Write("<script language=javascript>alert('" + no + "企业信息未找到!!')</script>");
            return;
        }
        else
        {
            if (null == Session["mid"])
            {
                Session.Add("mid", ds.Tables[0].Rows[0]["ID"].ToString());
            }
            else
                Session["mid"] = ds.Tables[0].Rows[0]["ID"].ToString();
            this.Response.Redirect("Default.aspx?m=FirstTimeApplyQ&ID=" + ds.Tables[0].Rows[0]["ID"].ToString() + "&type=" + ds.Tables[0].Rows[0]["Type"].ToString());
        }
    }

    private string getno(string text)
    {
        string rtn = "";
        text = text.Replace("记", "").Replace("录", "").Replace("(", "").Replace(")", "");
        text = "记录" + text;
        return text;
    }
}
