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

public partial class Cert_Op : SZMA.Core.Admin.PageBase
{
    protected DataSet DsDropDown;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            gvListData_Init();
    }


    override protected void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ProductDAL pobj = new ProductDAL();
        DsDropDown = pobj.Select();
    }
    
    #region //特约维修
    protected void gvListData_Init()
    {
        if (null != Request.QueryString["staus"] && Request.QueryString["staus"] != "")
        {
            gvList.Enabled = false;
        }
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
        {
            string MID = Request.QueryString["id"];
            int recc;

            DataSet ds =
                Common.Pager("OperateSA", "ID,brand,MainSCID", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                             out recc);
            if (ds.Tables[0].Rows.Count < 1)
            {
                ds.Tables[0].Rows.Add(new string[] { "0", "", "0" });
            }
            gvList.DataSource = ds;
            gvList.DataBind();
        }
    }

    protected void gvEList2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (!CheckAdminRight(11))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_CompanyAdd, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7732))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        OperateSADAL MyDAL = new OperateSADAL();
        int rtn = 0;
        int RowsIndex = -1;
        switch (e.CommandName)
        {
            case "del":
                {
                    rtn = MyDAL.Delete(e.CommandArgument.ToString());
                    if (rtn > 0)
                    {
                        gvListData_Init();
                    }
                    else
                    {
                        this.Response.Write("<script language=javascript>alert('删除失败')</script>");
                    }
                    break;
                }
            case "myadd":
                TextBox txtFBrand = (gvList.FooterRow.FindControl("txtFBrand") as TextBox);
                string AddFbrand = txtFBrand.Text;
                if (AddFbrand.Trim() == "" )
                {
                    this.Response.Write("<script language=javascript>alert('请填写品牌!')</script>");
                    return;
                }
                rtn = MyDAL.Insert(Request.QueryString["id"], AddFbrand );
                if (rtn > 0)
                {
                    gvListData_Init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('添加失败')</script>");
                }
                break;
            case "ok":
                string[] str = e.CommandArgument.ToString().Split(",,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                RowsIndex = int.Parse(str[1]);


                TextBox txtBrand = (gvList.Rows[RowsIndex].FindControl("txtBrand") as TextBox);
                string brand = txtBrand.Text;
                if ( brand.Trim() == "")
                {
                    this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                    return;
                }

                rtn = MyDAL.Update(brand, str[0]);

                if (rtn > 0)
                {
                    gvListData_Init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('更新失败')</script>");
                }
                break;
            case "myedit":
                RowsIndex = int.Parse(e.CommandArgument.ToString());


                Label lblbrand = (gvList.Rows[RowsIndex].FindControl("lblbrand") as Label);
                lblbrand.Visible = false;
                TextBox EtxtBrand = (gvList.Rows[RowsIndex].FindControl("txtBrand") as TextBox);

                EtxtBrand.Visible = true;

                LinkButton lnkEbtnEdit = (gvList.Rows[RowsIndex].FindControl("lnkbtnEdit") as LinkButton);
                LinkButton lnkEbtnOK = (gvList.Rows[RowsIndex].FindControl("lnkbtnOK") as LinkButton);
                LinkButton lnkEbtndel = (gvList.Rows[RowsIndex].FindControl("lnkbtndel") as LinkButton);
                
                lnkEbtnOK.Visible = true;
                lnkEbtndel.Visible = false;
                lnkEbtnEdit.Visible = false;
                break;
            default:
                break;
        }

    }

    #endregion
    #region //共用
    /// <summary>
    /// 确认删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DeleteCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('真的要删除这条记录？')";
    }

    /// <summary>
    /// 确认修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('真的要修改这条记录？')";
    }
    /// <summary>
    /// 确认添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('真的要添加这条记录？')";
    }
    #endregion
}
