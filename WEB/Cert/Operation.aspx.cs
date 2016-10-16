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

public partial class Cert_Operation : SZMA.Core.Client.BasePageByPage
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
                Common.Pager("OperationMain", "ID,ProductID,MainSCID,(select CN_Name from dict_product where ID=OperationMain.ProductID) as ProductName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                             out recc);
            if (ds.Tables[0].Rows.Count < 1)
            {
                ds.Tables[0].Rows.Add(new string[] { "0", "0", "0", ""});
            }
            gvList.DataSource = ds;
            gvList.DataBind();
        }
    }

    protected void gvEList2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        OperationMainDAL MyDAL = new OperationMainDAL();
        int rtn = 0;
        int RowsIndex = -1;
        switch (e.CommandName)
        {
            case "del":
                {
                    rtn = MyDAL.Delete(e.CommandArgument.ToString());
                   // Common.Update("MainSCTemp", "ID", Request.QueryString["id"], new string[] { "operation" }, new string[] { "" });
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
                DropDownList ddlFSortID = (gvList.FooterRow.FindControl("ddlFSortID") as DropDownList);
                TextBox txtFSortName = (gvList.FooterRow.FindControl("txtFSortName") as TextBox);
                string AddSortID = ddlFSortID.SelectedValue;
                string AddSortName = txtFSortName.Text;
                if (AddSortID.Trim() == "0" )
                {
                    this.Response.Write("<script language=javascript>alert('请先选择类别!')</script>");
                    return;
                }
                if (AddSortID.Trim() == "abc")
                {
                    if (MyDAL.SelectOther(Request.QueryString["id"]).Tables[0].Rows.Count>0)
                    {
                        this.Response.Write("<script language=javascript>alert('只能存在一个其他类!!!')</script>");
                        break;
                    }
                    if (AddSortName == "")
                    {
                        this.Response.Write("<script language=javascript>alert('请输入维修业务名称!!!')</script>");
                        break;
                    }
                    if (Common.Update("MainSCTemp", "ID", Request.QueryString["id"], new string[] { "operation" }, new string[] { AddSortName }))
                    {
                        rtn = MyDAL.Insert(Request.QueryString["id"], "0", "", DateTime.Now);
                    }
                    else
                    {

                        this.Response.Write("<script language=javascript>alert('添加失败')</script>");
                        break;
                    }
                }
                else
                {
                    rtn = MyDAL.Insert(Request.QueryString["id"], AddSortID, "", DateTime.Now);
                }
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

                DropDownList ddlSortID = (gvList.Rows[RowsIndex].FindControl("ddlSortID") as DropDownList);
                TextBox txtSortName = (gvList.Rows[RowsIndex].FindControl("txtSortName") as TextBox);

                string SortID = ddlSortID.SelectedValue;
                string SortName = txtSortName.Text;
                if (SortID.Trim() == "0")
                {
                    this.Response.Write("<script language=javascript>alert('请先选择类别!')</script>");
                    return;
                }
                if (SortID.Trim() == "abc")
                {
                    if (Common.Update("MainSCTemp", "ID", Request.QueryString["id"], new string[] { "operation" }, new string[] { SortName }))
                    {
                        rtn = MyDAL.Update("0", "", DateTime.Now, str[0]);
                    }
                    else
                    {

                        this.Response.Write("<script language=javascript>alert('添加失败')</script>");
                        break;
                    }
                }
                else
                {
                    rtn = MyDAL.Update(SortID, "", DateTime.Now, str[0]);
                }

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


                Label lblSort = (gvList.Rows[RowsIndex].FindControl("lblSortID") as Label);
                lblSort.Visible = false;
                
                DropDownList EddlSortID = (gvList.Rows[RowsIndex].FindControl("ddlSortID") as DropDownList);
                EddlSortID.Visible = true;
                this.RegisterStartupScript("settxt", "<script langauge='javascript'>checkDrop(window.document.getElementById('" + EddlSortID.ClientID + "'),'ddlSortID','txtSortName')</script>");

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
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ProductDAL pobj = new ProductDAL();
            DsDropDown = pobj.Select();
            DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
            DropDownList ddlPType = e.Row.FindControl("ddlSortID") as DropDownList;
            for (int i = 0; i < DsDropDown.Tables[0].Rows.Count; i++)
                ddlPType.Items.Insert(0, new ListItem(DsDropDown.Tables[0].Rows[i]["EN_Name"].ToString() + "[" + DsDropDown.Tables[0].Rows[i]["CN_Name"].ToString() + "]", DsDropDown.Tables[0].Rows[i]["ID"].ToString()));
            ddlPType.Items.Insert(0, new ListItem("请选择类别", "0"));
            ddlPType.Items.Insert(DsDropDown.Tables[0].Rows.Count + 1, new ListItem("其他类", "abc"));


            ddlPType.SelectedValue = dr["ProductID"].ToString();
            if (dr["ProductID"].ToString()=="0")
            {
                ddlPType.SelectedValue = "abc";

                Label lblSortID = e.Row.FindControl("lblSortID") as Label;
                TextBox txtSortName = e.Row.FindControl("txtSortName") as TextBox;
               int recc;
               DataSet ds= Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "MainSCTemp.ID='" + Request.QueryString["id"] + "' ",
                             out recc);
               if (recc > 0)
                   txtSortName.Text = lblSortID.Text = ds.Tables[0].Rows[0]["operation"].ToString();
            }

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {

            ProductDAL pobj = new ProductDAL();
            DsDropDown = pobj.Select();
            DropDownList ddlPType = e.Row.FindControl("ddlFSortID") as DropDownList;
            for (int i = 0; i < DsDropDown.Tables[0].Rows.Count; i++)
                ddlPType.Items.Insert(0, new ListItem(DsDropDown.Tables[0].Rows[i]["EN_Name"].ToString() + "[" + DsDropDown.Tables[0].Rows[i]["CN_Name"].ToString() + "]", DsDropDown.Tables[0].Rows[i]["ID"].ToString()));
            ddlPType.Items.Insert(0, new ListItem("请选择类别", "0"));
            ddlPType.Items.Insert(DsDropDown.Tables[0].Rows.Count + 1, new ListItem("其他类", "abc"));

        }
    }
}
