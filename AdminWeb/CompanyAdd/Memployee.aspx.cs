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

public partial class Cert_Memployee : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            gvMemployeeData_Init();
    }

    #region //技术人员
    protected void gvMemployeeData_Init()
    {
        if (null != Request.QueryString["staus"] && Request.QueryString["staus"] != "")
        {
            gvMemployee.Enabled = false;
        }
        if (null!=Request.QueryString["id"]&&Request.QueryString["id"] != "") 
        {
            string MID = Request.QueryString["id"];
            int recc;
            DataSet dsMemployee =
                Common.Pager("employee", "ID,Name,educational,Eposition,certNO,remark,CertName,CertType,(select CertName from Dict_Cert where Dict_Cert.ID=employee.CertType) as dictCertName", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
            if (dsMemployee.Tables[0].Rows.Count < 1)
            {
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
            }
            gvMemployee.DataSource = dsMemployee;
            gvMemployee.DataBind();
        }
    }
    protected void gvMemployee_RowCommand(object sender, GridViewCommandEventArgs e)
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
        EmployeeDAL MyDAL = new EmployeeDAL();
        int rtn = 0;
        int RowsIndex = -1;
        switch (e.CommandName)
        {
            case "del":
                {
                    rtn = MyDAL.Delete(e.CommandArgument.ToString());
                    if (rtn > 0)
                    {
                        gvMemployeeData_Init();
                    }
                    else
                    {
                        this.Response.Write("<script language=javascript>alert('删除失败')</script>");
                    }
                    break;
                }
            case "myadd":
                TextBox txtFName = (gvMemployee.FooterRow.FindControl("txtFName") as TextBox);
                TextBox txtFEducational = (gvMemployee.FooterRow.FindControl("txtFEducational") as TextBox);
                TextBox txtFEposition = (gvMemployee.FooterRow.FindControl("txtFEposition") as TextBox);
                TextBox txtFcertNO = (gvMemployee.FooterRow.FindControl("txtFcertNO") as TextBox);
                TextBox txtFremark = (gvMemployee.FooterRow.FindControl("txtFremark") as TextBox);

                DropDownList ddlFCertName = (gvMemployee.FooterRow.FindControl("ddlFCertName") as DropDownList);
                TextBox txtFCertName = (gvMemployee.FooterRow.FindControl("txtFCertName") as TextBox);
                string AddFName = txtFName.Text.Trim();
                string AddFEducational = txtFEducational.Text.Trim();
                string AddFEposition = txtFEposition.Text.Trim();
                string AddFcertNO = txtFcertNO.Text.Trim();
                string AddFremark = txtFremark.Text.Trim();
                if (AddFName.Trim() == "" || AddFEducational.Trim() == "" || AddFEposition.Trim() == "" || ddlFCertName.SelectedValue=="0")
                {
                    this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                    return;
                }

                if (ddlFCertName.SelectedValue == "abc")
                {
                    if (txtFCertName.Text.Trim() == "")
                    {
                        this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                        return;
                    }
                    //if (MyDAL.SelectByCertNO("0", txtFCertName.Text.Trim(), AddFcertNO, AddFName).Tables[0].Rows.Count > 0)
                    //{
                    //    this.Response.Write("<script language=javascript>alert('该证书资料已经有人使用!')</script>");
                    //    return;
                    //}
                    rtn = MyDAL.Insert(AddFName, AddFEducational, AddFEposition, AddFcertNO, txtFCertName.Text.Trim(), "0", AddFremark, "1", Request.QueryString["id"]);

                }
                else
                {
                    //if (MyDAL.SelectByCertNO(ddlFCertName.SelectedValue, txtFCertName.Text.Trim(), AddFcertNO, AddFName).Tables[0].Rows.Count > 0)
                    //{
                    //    this.Response.Write("<script language=javascript>alert('该证书资料已经有人使用!')</script>");
                    //    return;
                    //}
                    rtn = MyDAL.Insert(AddFName, AddFEducational, AddFEposition, AddFcertNO, txtFCertName.Text.Trim(), ddlFCertName.SelectedValue, AddFremark, "1", Request.QueryString["id"]);

                }
                  if (rtn > 0)
                {
                    gvMemployeeData_Init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('添加失败')</script>");
                }
                break;
            case "ok":
                string[] str = e.CommandArgument.ToString().Split(",,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                RowsIndex = int.Parse(str[1]);
                TextBox txtName = (gvMemployee.Rows[RowsIndex].FindControl("txtName") as TextBox);
                TextBox txtEducational = (gvMemployee.Rows[RowsIndex].FindControl("txtEducational") as TextBox);
                TextBox txtEposition = (gvMemployee.Rows[RowsIndex].FindControl("txtEposition") as TextBox);
                TextBox txtCertName = (gvMemployee.Rows[RowsIndex].FindControl("txtCertName") as TextBox);
                
                TextBox txtcertNO = (gvMemployee.Rows[RowsIndex].FindControl("txtcertNO") as TextBox);
                TextBox txtremark = (gvMemployee.Rows[RowsIndex].FindControl("txtremark") as TextBox);

                DropDownList ddlCertName = (gvMemployee.Rows[RowsIndex].FindControl("ddlCertName") as DropDownList);
                string Name = txtName.Text.Trim();
                string Educational = txtEducational.Text.Trim();
                string Eposition = txtEposition.Text.Trim();
                string certNO = txtcertNO.Text.Trim();
                string remark = txtremark.Text.Trim();
                if (Name.Trim() == "" || Educational.Trim() == "" || Eposition.Trim() == "" || ddlCertName.SelectedValue=="0")
                {
                    this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                    return;
                }
                if (ddlCertName.SelectedValue == "abc")
                {
                    if (txtCertName.Text.Trim()=="")
                    {
                        this.Response.Write("<script language=javascript>alert('填写不完全!')</script>");
                        return;
                    }
                    //if (MyDAL.SelectByCertNO("0", txtCertName.Text.Trim(), certNO, Name).Tables[0].Rows.Count > 0)
                    //{
                    //    this.Response.Write("<script language=javascript>alert('该证书资料已经有人使用!')</script>");
                    //    return;
                    //}
                    rtn = MyDAL.Update(Name, Educational, Eposition, certNO, "0",txtCertName.Text.Trim(), remark, str[0]);
                }
                else
                {
                    //if (MyDAL.SelectByCertNO(ddlCertName.SelectedValue, txtCertName.Text.Trim(), certNO, Name).Tables[0].Rows.Count > 0)
                    //{
                    //    this.Response.Write("<script language=javascript>alert('该证书资料已经有人使用!')</script>");
                    //    return;
                    //}
                    rtn = MyDAL.Update(Name, Educational, Eposition, certNO, ddlCertName.SelectedValue, txtCertName.Text, remark, str[0]);
                }
                if (rtn > 0)
                {
                    gvMemployeeData_Init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('更新失败')</script>");
                }
                break;
            case "myedit":
                RowsIndex = int.Parse(e.CommandArgument.ToString());


                Label lblName = (gvMemployee.Rows[RowsIndex].FindControl("lblName") as Label);
                Label lblEducational = (gvMemployee.Rows[RowsIndex].FindControl("lblEducational") as Label);
                Label lblEposition = (gvMemployee.Rows[RowsIndex].FindControl("lblEposition") as Label);
                Label lblcertNO = (gvMemployee.Rows[RowsIndex].FindControl("lblcertNO") as Label);
                Label lblremark = (gvMemployee.Rows[RowsIndex].FindControl("lblremark") as Label);
                Label lblcertName = (gvMemployee.Rows[RowsIndex].FindControl("lblcertName") as Label);
                lblName.Visible = false;
                lblEducational.Visible = false;
                lblEposition.Visible = false;
                lblcertNO.Visible = false;
                lblremark.Visible = false;
                lblcertName.Visible = false;

                TextBox EtxtName = (gvMemployee.Rows[RowsIndex].FindControl("txtName") as TextBox);
                TextBox EtxtEducational = (gvMemployee.Rows[RowsIndex].FindControl("txtEducational") as TextBox);
                TextBox EtxtEposition = (gvMemployee.Rows[RowsIndex].FindControl("txtEposition") as TextBox);

                DropDownList EddlCertName = (gvMemployee.Rows[RowsIndex].FindControl("ddlCertName") as DropDownList);
                if(EddlCertName.SelectedValue=="abc")
                {
                    TextBox EtxtcertName = (gvMemployee.Rows[RowsIndex].FindControl("txtcertName") as TextBox);
                    EtxtcertName.Attributes.Add("style","display:inline");
                }
                TextBox EtxtcertNO = (gvMemployee.Rows[RowsIndex].FindControl("txtcertNO") as TextBox);
                TextBox Etxtremark = (gvMemployee.Rows[RowsIndex].FindControl("txtremark") as TextBox);

                EtxtName.Visible = true;
                EddlCertName.Visible = true;
                EtxtEducational.Visible = true;
                EtxtEposition.Visible = true;
                EtxtcertNO.Visible = true;
                Etxtremark.Visible = true;

                LinkButton lnkEbtnEdit = (gvMemployee.Rows[RowsIndex].FindControl("lnkbtnEdit") as LinkButton);
                LinkButton lnkEbtnOK = (gvMemployee.Rows[RowsIndex].FindControl("lnkbtnOK") as LinkButton);
                LinkButton lnkEbtndel = (gvMemployee.Rows[RowsIndex].FindControl("lnkbtndel") as LinkButton);
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
        DataSet DsDropDown;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DictCertDAL Cobj = new DictCertDAL();
            DsDropDown = Cobj.Select();
            DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
            DropDownList ddlCertName = e.Row.FindControl("ddlCertName") as DropDownList;
            for (int i = 0; i < DsDropDown.Tables[0].Rows.Count; i++)
                ddlCertName.Items.Insert(0, new ListItem(DsDropDown.Tables[0].Rows[i]["CertName"].ToString() , DsDropDown.Tables[0].Rows[i]["ID"].ToString()));
            ddlCertName.Items.Insert(0, new ListItem("请选择证书", "0"));
            ddlCertName.Items.Insert(DsDropDown.Tables[0].Rows.Count + 1, new ListItem("其他证书", "abc"));


            ddlCertName.SelectedValue = dr["CertType"].ToString();
            if (dr["CertType"].ToString() == "0")
            {
                ddlCertName.SelectedValue = "abc";
                Label lblCertName = e.Row.FindControl("lblCertName") as Label;
                lblCertName.Text = dr["CertName"].ToString();
            }

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {

            DictCertDAL Cobj = new DictCertDAL();
            DsDropDown = Cobj.Select();
            DropDownList ddlFCertName = e.Row.FindControl("ddlFCertName") as DropDownList;
            for (int i = 0; i < DsDropDown.Tables[0].Rows.Count; i++)
                ddlFCertName.Items.Insert(0, new ListItem(DsDropDown.Tables[0].Rows[i]["CertName"].ToString(), DsDropDown.Tables[0].Rows[i]["ID"].ToString()));
            ddlFCertName.Items.Insert(0, new ListItem("请选择证书", "0"));
            ddlFCertName.Items.Insert(DsDropDown.Tables[0].Rows.Count + 1, new ListItem("其他证书", "abc"));

        }
    }
}
