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

public partial class workaround_result  : SZMA.Core.Admin.PageBase
{
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(12))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }

        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Result, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7717))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
            show();
    }
    public void show()
    {
        int pageindex = (AspNetPager1.StartRecordIndex - 1) / AspNetPager1.PageSize + 1;
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "MainSCTemp.*,(select assess.PSTime from assess where MainSCTemp.ID=assess.MainSCID) as PSTime,(select examineResult.ID from examineResult where MainSCTemp.ID=examineResult.MainSCID) as ResultID", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);


        AspNetPager1.RecordCount = recc;
        lblNum.Text = "共" + recc.ToString() + "条，分" + AspNetPager1.PageCount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = " MainSCTemp.state =3 and MainSCTemp.InsertFlag not in(0)  ";
        if (null != Request.QueryString["TID"])
        {
            rtn += " and MainSCTemp.type=" + Request.QueryString["TID"];
        }
        if (txtKey.Text != "")
        {
            rtn += " and MainSCTemp.Company like '%" + txtKey.Text + "%'";
        }
        return rtn;
    }
    public void gvList_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(13))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_Result, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7718))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;
        if (e.CommandName == "pass")
        {
            string[] strBuf = strID.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            AssessDAL obj=new AssessDAL();
            DataSet ds = obj.SelectCertNO(strBuf[0]);
            string Totle = "";
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                if(ds.Tables[0].Rows[i]["totle"].ToString()!="")
                {
                    Totle = ds.Tables[0].Rows[i]["totle"].ToString();
                }
            }
           if (CheckTotle(Totle))
            {
                if (Common.Update("MainSCTemp", "ID", strBuf[0], new string[] { "state", "UserName" }, new string[] { "5", UserName }))
                {
                    show();
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                }
            }
            else 
            {
                if (Common.Update("MainSCTemp", "ID", strBuf[0], new string[] { "state", "UserName" }, new string[] { "4", UserName }))
                {
                    show();
                }
                else
                {
                    this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                }
            }
        }
        else if (e.CommandName == "set")
        {
            examineResultDAL obj=new examineResultDAL();

            if (obj.SelectByMID(strID).Tables[0].Rows.Count > 0)
            {
                show();
                return;
            }
            AssessDAL aobj=new AssessDAL();
            DataSet dsa = aobj.SelectCertNO(strID);
            if (dsa.Tables[0].Rows.Count<1)
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                return;
            }
            if (obj.Insert(strID, dsa.Tables[0].Rows[0]["PSUserName"].ToString(), UserName) < 1)
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                
            }
            else
                show();
        }
        else if (e.CommandName == "del")
        {
            if (!Common.Delete("examineResult","MainSCID",strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
            }
            else
                show();
        }
    }

    protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
    {
        show();
    }
    private bool CheckTotle(string totle)
    {
        try
        {
            float f = float.Parse(totle);
            if(f>=70)
            {
                return true;
            }
        }
        catch
        {
        }
        return false;
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
        int rtn = 0;
        try
        {
            rtn = aobj.Insert(MID, ds.Tables[0].Rows[0]["ID"].ToString(),AdminUser.Username);
        }
        catch
        {
        }
        if (rtn < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!')</script>");
            return false;
        }
        return true;
    }
    protected bool setCertNO(string MID)
    {
        AssessDAL obj=new AssessDAL();
        DataSet ds = obj.SelectCertNO(MID);
        if(ds.Tables[0].Rows.Count>0)
        {
           string CertNO= ds.Tables[0].Rows[0]["oldCertNO"].ToString();
            if(CertNO!="")
            {
                CertNO = CertNO.Substring(0, CertNO.Length - 1);
                CertNO += getLevelABC(ds.Tables[0].Rows[0]["Totle"].ToString());
            }
        }
        return false;
    }

    private string getLevelABC(string  s)
    {
        string rtn = "";
        try
        {
            float sf=float.Parse(s);
            if(sf>90)
            {
                rtn="A";
            }else if(sf>80)
            {
                rtn = "B";
            }
            else if (sf > 70)
            {
                rtn = "C";
            }
        }
        catch
        {
        }
        return rtn;
        
    }

    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认完成吗？')";
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        show();
    }
}
