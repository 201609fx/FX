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

public partial class workaround_FirstCheckPrint : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(7))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Check, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7713))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            data_bind();
        }
    }

    private void data_bind()
    {
        if (null != Request.QueryString["mid"])
        {
            int recc;
            string MID = Request.QueryString["mid"];

            lblMainSCNO.Text = getMainNO(MID, Request.QueryString["tid"]);
            DataSet ds2 =
           Common.Pager("MainSCTemp", "Company,NoteNum,state", "ID", 100, 1, true, " ID='" + MID + "'", out recc);
            if(ds2.Tables[0].Rows.Count<1)
            {
                ds2 =
                Common.Pager("MainSC", "Company,NoteNum", "ID", 100, 1, true, " MainSCID='" + MID + "'", out recc);

                lblState.Text = lblState1.Text = "合格";
            }
            else
            {

                lblState.Text = lblState1.Text = getFstate(ds2.Tables[0].Rows[0]["state"].ToString());
            }
            
            DataSet ds3 =
       Common.Pager("CSList", "MainSCID,CheckUser", "ID", 100, 1, true, " MainSCID='" + MID + "'", out recc);
            string CheckUserName = "";
            if (ds3.Tables[0].Rows.Count>0)
            {
                CheckUserName = ds3.Tables[0].Rows[0]["CheckUser"].ToString();
            }
            lblCompany.Text = ds2.Tables[0].Rows[0]["Company"].ToString();
            lblNoteNO.Text = ds2.Tables[0].Rows[0]["NoteNum"].ToString() == "" ? getNoteNum(MID) : ds2.Tables[0].Rows[0]["NoteNum"].ToString();
            CSFileDAL obj = new CSFileDAL();
            DataSet ds = new DataSet();
            if (Request.QueryString["tid"] == "1")
            {
                ds = obj.SelectByMainSCID1(MID);
            }
            else if (Request.QueryString["tid"] == "2")
            {
                ds = obj.SelectByMainSCID2(MID);
            }
            ///判断公章是否加盖;CSFileDict."Name",a.ISCheck ,'提交' as des,a."ID",a.Remark,CSFileDict.Isneed

            DataSet ds1 =
            Common.Pager("CSList", "*", "ID", 100, 1, true, " MainSCID='" + MID + "'" + " and CSFileID=0", out recc);
            if (recc > 0)
            {
                ds.Tables[0].Rows.Add(new object[] { "企业所提供资料有无加盖公章", 1, "盖章", 0, "", 1 });
            }
            else
            {
                ds.Tables[0].Rows.Add(new object[] { "企业所提供资料有无加盖公章", 0, "盖章", 0, "", 1 });
            }
            lblCheckTime3.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblMainSCNO1.Text = lblMainSCNO.Text;
            lblNoteNO1.Text = lblNoteNO.Text;
            lblState1.Text = lblState.Text;
            lblCompany1.Text = lblCompany.Text;
            lblCheckTime1.Text = lblCheckTime2.Text = lblCheckTime3.Text;
            lblCheckUser.Text = CheckUserName;
            gvList.DataSource = ds;
            gvList.DataBind();
            gvList2.DataSource = ds;
            gvList2.DataBind();
        }
    }

    private string getFstate(string s)
    {
        string rtn = "";
        switch(s)
        {
            case "0":
                rtn = "未开始";
                break;
            case"1":
                rtn = "开始";
                break;
            case "11":
                rtn = "不合格";
                break;
            case "12":
                rtn = "合格";
                break;
            default:
                rtn = "合格";
                break;
        }
        return rtn;
    }
}
