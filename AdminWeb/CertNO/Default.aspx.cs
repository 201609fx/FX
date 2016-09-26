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

public partial class CertNO_Default : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(20))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7725))
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
        DataSet ds = Common.Pager("MainSCTemp", "MainSCTemp.*,(select MainSC.ID  from MainSC where MainSCTemp.ID=MainSC.MainSCID) as NewMainSCID", "ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
    public string Buildcondition()
    {
        string rtn = "MainSCTemp.state =6 and MainSCTemp.InsertFlag not in(0)  ";
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
        string strID = e.CommandArgument.ToString();
        string UserName = AdminUser.Username;

        if (!CheckAdminRight(20))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_certma, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7726))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (e.CommandName == "pass")
        {
            if (Common.Delete("MainSCTemp", "ID", strID))
            {
                show();
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
        else if (e.CommandName == "set")
        {
            MainSCDAL obj = new MainSCDAL();
            CertNODAL Cobj=new CertNODAL();
            if (obj.Select(strID).Tables[0].Rows.Count>0)
            {
                if (Cobj.Select(strID).Tables[0].Rows.Count>0)
                {
                    show();
                    return;
                }
                else
                {
                    int i = 1;
                    try 
                    {
                        i = int.Parse(System.Configuration.ConfigurationManager.AppSettings["InvailTime"]);
                    }
                    catch
                    {
                    }
                    if (Cobj.Insert(strID, UserName, DateTime.Now, DateTime.Now.AddYears(i))<1)
                    {
                        this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                    }
                    else
                        show();
                }
            }
            if (obj.Insert(strID)<1)
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
            else
            {
                if (Cobj.Select(strID).Tables[0].Rows.Count > 0)
                {
                    show();
                    return;
                }
                else
                {
                    int i = 1;
                    try
                    {
                        i = int.Parse(System.Configuration.ConfigurationManager.AppSettings["InvailTime"]);
                    }
                    catch
                    {
                    }
                    if (Cobj.Insert(strID, UserName, DateTime.Now, DateTime.Now.AddYears(i)) < 1)
                    {
                        this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
                    }
                    else
                        show();
                }
            }
        }
        else if (e.CommandName == "del")
        {
            if (!Common.Delete("MainSC", "MainSCID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
                return;
            }
            if (!Common.Delete("Cert", "MainSCID", strID))
            {
                this.Response.Write("<script language='javascript'> alert('删除失败!')</script>");
                return;
            }
            show();
        }
    }
    protected void LinkCategory_Load1(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认完成吗？')";
    }
    protected void LinkCategory_Load2(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('确认删除吗？')";
    }
    protected void AspNetPager1_OnPageChanging(object sender, EventArgs e)
    {
        show();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        show(1);
    }
    public void show(int pageindex)
    {
        int recc;
        DataSet ds = Common.Pager("MainSCTemp", "MainSCTemp.*,(select Approve.ID from Approve where MainSCTemp.ID=Approve.MainSCID) as NewMainSCID", "MainSCTemp.ID", AspNetPager1.PageSize, pageindex, true, Buildcondition(), out recc);
        int pagecount = recc % AspNetPager1.PageSize > 0
                            ? ((int)(recc / AspNetPager1.PageSize)) + 1
                            : (int)(recc / AspNetPager1.PageSize);

        lblNum.Text = "共" + recc.ToString() + "条，分" + pagecount.ToString() + "页显示。";
        AspNetPager1.RecordCount = recc;
        gvList.DataSource = ds;
        gvList.DataBind();
    }
}
