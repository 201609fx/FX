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

public partial class Cert_EList : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            gvEListData_Init();
    }
    #region //交通工具
    protected void gvEListData_Init()
    {
        if (null != Request.QueryString["staus"] && Request.QueryString["staus"] != "")
        {
            gvEList.Enabled = false;
        }
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
        {
            string MID = Request.QueryString["id"];
            int recc;

            DataSet dsElist1 =
                Common.Pager("equipment", "ID,Num,des,Type,Model,MainSCID", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
            if (dsElist1.Tables[0].Rows.Count < 1)
            {
                dsElist1.Tables[0].Rows.Add(new string[] { "0", "", "","0","", "0" });
            }
            gvEList.DataSource = dsElist1;
            gvEList.DataBind();
        }
    }

    protected void gvEList_RowCommand(object sender, GridViewCommandEventArgs e)
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
        equipmentDAL MyDAL = new equipmentDAL();
        int rtn = 0;
        int RowsIndex = -1;
        switch (e.CommandName)
        {
            case "del":
                {
                    rtn = MyDAL.Delete(e.CommandArgument.ToString());
                    if (rtn > 0)
                    {
                        gvEListData_Init();
                    }
                    else
                    {
                        this.Response.Write("<script language=javascript>alert('删除失败')</script>");
                    }
                    break;
                }
            case "myadd":
                TextBox txtFdes = (gvEList.FooterRow.FindControl("txtFdes") as TextBox);
                TextBox txtFModel = (gvEList.FooterRow.FindControl("txtFModel") as TextBox);
                TextBox txtFNum = (gvEList.FooterRow.FindControl("txtFNum") as TextBox);
                string AddFdes = txtFdes.Text;
                string AddFNum = txtFNum.Text;
                string AddFModel = txtFModel.Text.Trim();
                if (AddFdes.Trim() == "" )
                {
                    this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                    return;
                }
                rtn = MyDAL.Insert(AddFdes, AddFNum, AddFModel, "1", Request.QueryString["id"]);
                if (rtn > 0)
                {
                    gvEListData_Init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('添加失败')</script>");
                }
                break;
            case "ok":
                string[] str = e.CommandArgument.ToString().Split(",,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                RowsIndex = int.Parse(str[1]);
                TextBox txtdes = (gvEList.Rows[RowsIndex].FindControl("txtdes") as TextBox);
                TextBox txtModel = (gvEList.Rows[RowsIndex].FindControl("txtModel") as TextBox);
                TextBox txtNum = (gvEList.Rows[RowsIndex].FindControl("txtNum") as TextBox);
                string des = txtdes.Text;
                string Num = txtNum.Text;
                string Model = txtModel.Text;
                if (des.Trim() == "")
                {
                    this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                    return;
                }

                rtn = MyDAL.Update(des, Num,Model, str[0]);

                if (rtn > 0)
                {
                    gvEListData_Init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('更新失败')</script>");
                }
                break;
            case "myedit":
                RowsIndex = int.Parse(e.CommandArgument.ToString());


                Label lbldes = (gvEList.Rows[RowsIndex].FindControl("lbldes") as Label);
                Label lblNum = (gvEList.Rows[RowsIndex].FindControl("lblNum") as Label);
                Label lblModel = (gvEList.Rows[RowsIndex].FindControl("lblModel") as Label);
                lbldes.Visible = false;
                lblNum.Visible = false;
                lblModel.Visible = false;

                TextBox Etxtdes = (gvEList.Rows[RowsIndex].FindControl("txtdes") as TextBox);
                TextBox EtxtModel = (gvEList.Rows[RowsIndex].FindControl("txtModel") as TextBox);
                TextBox EtxtNum = (gvEList.Rows[RowsIndex].FindControl("txtNum") as TextBox);

                Etxtdes.Visible = true;
                EtxtModel.Visible = true;
                EtxtNum.Visible = true;

                LinkButton lnkEbtnEdit = (gvEList.Rows[RowsIndex].FindControl("lnkbtnEdit") as LinkButton);
                LinkButton lnkEbtnOK = (gvEList.Rows[RowsIndex].FindControl("lnkbtnOK") as LinkButton);
                LinkButton lnkEbtndel = (gvEList.Rows[RowsIndex].FindControl("lnkbtndel") as LinkButton);
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
