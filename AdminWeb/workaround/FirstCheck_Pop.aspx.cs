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

public partial class workaround_FirstCheck_Pop:SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(7))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Check, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7714))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if(!IsPostBack)
        {
            data_bind();
        }
    }

    private void data_bind()
    {
        if(null!=Request.QueryString["mid"])
        {
            int recc;
            string MID = Request.QueryString["mid"];
            
            lblMainSCNO.Text = getMainNO(MID, Request.QueryString["tid"]);
             DataSet ds2 =
            Common.Pager("MainSCTemp", "Company,NoteNum", "ID", 100, 1, true, " ID='" + MID+"'" , out recc);
             lblCompany.Text = ds2.Tables[0].Rows[0]["Company"].ToString();
             lblNoteNO.Text = ds2.Tables[0].Rows[0]["NoteNum"].ToString() == "" ? getNoteNum(MID) : ds2.Tables[0].Rows[0]["NoteNum"].ToString();
            CSFileDAL obj=new CSFileDAL();
            DataSet ds=new DataSet();
            if(Request.QueryString["tid"]=="1")
            {
                ds = obj.SelectByMainSCID1(MID);
            }
            else if(Request.QueryString["tid"]=="2")
            {
                ds = obj.SelectByMainSCID2(MID);
            }
            ///判断公章是否加盖;CSFileDict."Name",a.ISCheck ,'提交' as des,a."ID",a.Remark,CSFileDict.Isneed
       
            DataSet ds1 =
            Common.Pager("CSList", "*", "ID", 100, 1, true, " MainSCID='" + MID + "'" + " and CSFileID=0", out recc);
            if (recc > 0)
            {
                ds.Tables[0].Rows.Add(new object[] { "企业所提供资料有无加盖公章", 1, "盖章", 0,"", 1 });
            }
            else
            {
                ds.Tables[0].Rows.Add(new object[] { "企业所提供资料有无加盖公章", 0, "盖章", 0,"", 1});
            }
            gvList.DataSource = ds;
            gvList.DataBind();
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (null != Request.QueryString["mid"])
        {
            if(!update())
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                return;
            }
            if (Common.Update("MainSCTemp", "ID", Request.QueryString["mid"], new string[] { "state","UserName" }, new string[] { "12",AdminUser.Username }))
            {
                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
                this.Response.Write("<script language='javascript'> window.opener.location.href=window.opener.location.href;window.close();</script>");
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
    }
    
    protected void btnUnPass_Click(object sender, EventArgs e)
    {
        if (null != Request.QueryString["mid"])
        {
            if (!update())
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                return;
            }
            if (Common.Update("MainSCTemp", "ID", Request.QueryString["mid"], new string[] { "state","UserName" }, new string[] { "11",AdminUser.Username }))
            {
                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
                this.Response.Write("<script language='javascript'> window.opener.location.href=window.opener.location.href;window.close();</script>");
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
    }
    
    public bool update()
    {
        CheckBox chk1;
        int IsCheck = 0;
         DataSet ds = new DataSet();
         CSFileDAL obj = new CSFileDAL();
        string MID;
        string CSFileID="7";
        string UserName = AdminUser.Username;
            
        if (null == Request.QueryString["mid"])
        {
            return false;
        }
        MID = Request.QueryString["mid"];

        if (Request.QueryString["tid"] == "1")
        {
            ds = obj.SelectByMainSCID1(MID);
            CSFileID = "7";
            
        }
        else if (Request.QueryString["tid"] == "2")
        {
            ds = obj.SelectByMainSCID2(MID);
                 CSFileID = "8";
        }
        for(int i=1;i<gvList.Rows.Count-1;i++)
        {
            IsCheck = 0;
           chk1=  gvList.Rows[i].FindControl("chk1") as CheckBox;
           
            if(chk1.Checked)
            {
                IsCheck = 1;
            }
            if(ds.Tables[0].Rows[i]["ISCheck"].ToString()!=IsCheck.ToString())
            {
                if(Common.UpdateByInt("CSlist", "ID", ds.Tables[0].Rows[i]["ID"].ToString(), new string[] { "ISCheck","CheckUser" },
                              new string[] {IsCheck.ToString(),UserName})<1)
                {
                    obj.Insert(MID, ds.Tables[0].Rows[i]["CSFDID"].ToString(), IsCheck.ToString(), "", UserName, DateTime.Now, UserName);
                }
            }
        }
        int recc;
        DataSet ds1 =
            Common.Pager("CSList", "*", "ID", 100, 1, true, " MainSCID='" + MID + "'" + " and CSFileID=0", out recc);
        if (recc <1)
        {
            chk1 = gvList.Rows[0].FindControl("chk1") as CheckBox;
            if (chk1.Checked)
            {
                IsCheck = 1;
            }
            obj.Insert(MID, CSFileID, IsCheck.ToString(), "", UserName, DateTime.Now, UserName);

            chk1 = gvList.Rows[gvList.Rows.Count - 1].FindControl("chk1") as CheckBox;
            if (chk1.Checked)
            {
                IsCheck = 1;
            }
            obj.InsertGongZhang(MID, IsCheck.ToString(), "", UserName, DateTime.Now, UserName);
        }
        return true;
            
    }

    protected bool setAsscee(string MID)
    {
        assessPlateDAL obj = new assessPlateDAL();
        DataSet ds = obj.SelectActive();
        if (ds.Tables[0].Rows.Count < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!没有一个激活的模版!')</script>");
            return false;
        }
        AssessDAL aobj = new AssessDAL();
        int rtn = aobj.Insert(MID, ds.Tables[0].Rows[0]["ID"].ToString(),AdminUser.Username);
        if (rtn < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!')</script>");
            return false;
        }
        return true;
    }
    
}
