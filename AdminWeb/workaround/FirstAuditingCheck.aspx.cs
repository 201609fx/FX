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

public partial class workaround_FirstAuditingCheck :SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(5))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_First, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7711))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if(!IsPostBack)
        {
            Data_Init();
        }
    }
    private void Data_Init()
    {
        GVData_Init();
        if(null!=Request.QueryString["mid"])
        {
           string MID = Request.QueryString["MID"];
           int recc;
             DataSet ds =
                Common.Pager("MainSCTemp", "*,(select Name from dict_area where MainSCTemp.AreaID=dict_area.ID) as Name", "ID", 100, 1, true, "MainSCTemp.ID='" + MID + "' ",
                             out recc);
             if (recc <1)
                 return;
             lblAreaID.Text = ds.Tables[0].Rows[0]["Name"].ToString();
             lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
             lblAnum.Text = ds.Tables[0].Rows[0]["Anum"].ToString();
             lblArea.Text = ds.Tables[0].Rows[0]["Area"].ToString();
             lblBnum.Text = ds.Tables[0].Rows[0]["Bnum"].ToString();
             lblCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
             lblCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
             lblContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
             lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
             lblFrdb.Text = ds.Tables[0].Rows[0]["Frdb"].ToString();
             lblFtel.Text = ds.Tables[0].Rows[0]["Ftel"].ToString();
             lblMnum.Text = ds.Tables[0].Rows[0]["Mnum"].ToString();
             lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
             lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
             lblSummary.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
             lblTitle.Text = "申请表审核  " + getMainNO(MID,Request.QueryString["tid"] );
        }
    }
    private void GVData_Init()
    {
            
        if(null!=Request.QueryString["MID"])
        {
            int recc;
            string MID = Request.QueryString["MID"];
            EmployeeDAL Emobj = new EmployeeDAL();

            DataSet dsMemployee = Emobj.SelectByMainSCID(MID,1);
            gvMemployee.DataSource = dsMemployee;
            gvMemployee.DataBind();

            DataSet dsWemployee = Emobj.SelectByMainSCID(MID, 2);
            gvWemployee.DataSource = dsWemployee;
            gvWemployee.DataBind();
            
              DataSet dsElist1 =
                Common.Pager("equipment", "*", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
              gvEList.DataSource = dsElist1;
              gvEList.DataBind();
            
               DataSet dsElist2 =
                Common.Pager("equipment", "*", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                             out recc);
               gvElist2.DataSource = dsElist2;
               gvElist2.DataBind();

               DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name", "CSFileID", 100, 1, false, "CSlist.MainSCID='" + MID + "' and CSlist.CSFileID=CSFileDict.ID ",
                               out recc);
               gvCSFile.DataSource = dsCSFile;
               gvCSFile.DataBind();



               OperationMainDAL objopMain=new OperationMainDAL();
               DataSet dsOperationMain = objopMain.SelectByMainID1(MID);
               gvOperationMain.DataSource = dsOperationMain;
               gvOperationMain.DataBind();


            DataSet dsOperateSA =
              Common.Pager("OperateSA", "ID,brand,MainSCID", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                           out recc);
            if (dsOperateSA.Tables[0].Rows.Count > 0)
            {
                pnlOperation.Visible = true;
            }
            gvOperation.DataSource = dsOperateSA;
            gvOperation.DataBind();
        }
    }
    protected void btnPass_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(5))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_First, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7712))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (Common.Update("MainSCTemp", "ID", Request.QueryString["mid"], new string[] { "state", "checkUser", "InsertFlag" }, new string[] { "1", AdminUser.Username, "3" }))
        {
            this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
            this.Response.Redirect("FirstAuditing.aspx?tid="+Request.QueryString["tid"]);
        }
        else
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("FirstAuditing.aspx?tid=" + Request.QueryString["tid"]);
    }
    

}
