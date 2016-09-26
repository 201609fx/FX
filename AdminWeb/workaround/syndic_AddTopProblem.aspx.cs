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
using SZMA.BLL;

public partial class workaround_syndic_AddTopProblem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       string userName = "double";
        if(null==Request.QueryString["tid"])
        {
            pnlAll.Visible = false;
            return;
        }
        if(Request.QueryString["tid"]=="1")
        { 
            ProblemSortDAL obj=new ProblemSortDAL();
            lblID.Text = obj.InsertNull(Request.QueryString["pid"], Request.QueryString["aid"], userName);
        }
        else
        {
            lblID.Text = Request.QueryString["id"];
        }
    }
    
    protected void btnAddT_Click(object sender, EventArgs e)
    {
        if(txtName.Text!=""&&txtTotle.Text!="")
        {
            string UserName = "";
            ProblemSortDAL obj=new ProblemSortDAL();
            obj.UpdateByID(lblID.Text.Trim(), "0", txtName.Text,Utility.getVal( txtTotle.Text), txtRemark.Text, UserName,"0");
            this.Response.Write("<script language='javascript'>parent.window.document.getElementById('trAdd').style.display='none';parent.window.location.href=parent.window.location.href;</script>");
        }
    }
}
