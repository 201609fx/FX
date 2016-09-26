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

public partial class PopWindow_ShowNews : SZMA.Core.Client.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            switch (Request.QueryString["PID"])
            {
                case "1":
                    pnlNew.Visible = false;
                    lblSortName.Text = "机构介绍";
                    break;
                case "2":
                    pnlNew.Visible = true;
                    lblSortName.Text = "政策法规";
                    break;
                case "3":
                    pnlNew.Visible = true;
                    lblSortName.Text = "公告栏";
                    break;
                default:
                    break;
            }
            if (null != Request.QueryString["id"] && Request.QueryString["id"]!="")
            {
                data_init();

            }
        }
      
    }
    protected void data_init()
    {
        if(null!=Request.QueryString["id"])
        {
            int recc = 0;
            NewsDAL obj = new NewsDAL();
            DataSet ds =
                Common.Pager("News", "*", "ID", 100, 1, true, "ID='" + Request.QueryString["id"] + "'", out recc);

            if (recc > 0)
            {
                if (ds.Tables[0].Rows[0]["IsSys"].ToString() == "1")///判断是系统文档还是新闻公告
                {
                    lblSortName.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                    lblContent.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                    pnlNew.Visible = false;
                    Label1.Text = "办证指南";

                }
                else
                {
                    lblContent.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                    labTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                    labRefer.Text = ds.Tables[0].Rows[0]["Refer"].ToString();
                    labIssueDate.Text = ds.Tables[0].Rows[0]["IssueDate"].ToString();
                    labClickTimes.Text = ds.Tables[0].Rows[0]["ClickTimes"].ToString();
                    obj.AddClickTime(Request.QueryString["id"]);
                    Label1.Text = "公告栏";

                }

                int recc_dot = 0;
                DataSet ds_Dot = Common.Pager("VIEWFile", "*", "ID", 999, 1, true, "FileSortID=1 and MainID=" + ds.Tables[0].Rows[0]["ID"].ToString(), out recc_dot);
                if (recc_dot > 0)
                {
                    this.rptListDots.DataSource = ds_Dot;
                    this.rptListDots.DataBind();
                    this.pnlFile.Visible = true;
                }
                else
                {
                    this.pnlFile.Visible = false;
                }
            }
        }
    }
}
