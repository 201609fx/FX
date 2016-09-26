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

public partial class Cert_CSFil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            gvCSFileData_init();
    }

    #region//送审资料
    protected void gvCSFileData_init()
    {
        if (null != Request.QueryString["staus"] && Request.QueryString["staus"] != "")
        {
            gvCSFile.Enabled = false;
        }
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
        {
            string MID = Request.QueryString["id"];
            int recc;

            DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name,CSFileDict.ID as cID", "cID", 100, 1, false, "CSlist.MainSCID='" + MID + "' and CSlist.CSFileID=CSFileDict.ID ",
                                            out recc);
            if (dsCSFile.Tables[0].Rows.Count < 1)
            {
                dsCSFile.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }
            gvCSFile.DataSource = dsCSFile;
            gvCSFile.DataBind();
        }
    }
    protected void gvCSFile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CSFileDAL MyDAL = new CSFileDAL();
        int rtn = 0;
        int RowsIndex = -1;
        switch (e.CommandName)
        {
            case "del":
                {
                    rtn = MyDAL.Delete(e.CommandArgument.ToString());
                    if (rtn > 0)
                    {
                        gvCSFileData_init();
                    }
                    else
                    {
                        this.Response.Write("<script language=javascript>alert('删除失败')</script>");
                    }
                    break;
                }
            case "ok":
                string[] str = e.CommandArgument.ToString().Split(",,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                RowsIndex = int.Parse(str[1]);
                for (int i = 0; i < gvCSFile.Rows.Count; i++)
                {
                    TextBox txtNum = (gvCSFile.Rows[i].FindControl("txtNum") as TextBox);
                    Label lblID = (gvCSFile.Rows[i].FindControl("lblID") as Label);
                    string Num = txtNum.Text;
                    
                    if (Num.Trim() == "")
                    {
                        Num = "0";
                    }
                    try
                    {
                        Num = int.Parse(Num).ToString();
                    }
                    catch
                    {
                        this.Response.Write("<script language=javascript>alert('请输入一个数字')</script>");
                        return;
                    }
                   

                    rtn = MyDAL.Update(Num, lblID.Text.Trim());
                }

                if (rtn > 0)
                {
                    gvCSFileData_init();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('更新失败')</script>");
                }
                break;
            case "myedit":
                RowsIndex = int.Parse(e.CommandArgument.ToString());


                Label lblNum = (gvCSFile.Rows[RowsIndex].FindControl("lblNum") as Label);
                lblNum.Visible = false;

                TextBox EtxtNum = (gvCSFile.Rows[RowsIndex].FindControl("txtNum") as TextBox);

                EtxtNum.Visible = true;

                LinkButton lnkEbtnEdit = (gvCSFile.Rows[RowsIndex].FindControl("lnkbtnEdit") as LinkButton);
                LinkButton lnkEbtnOK = (gvCSFile.Rows[RowsIndex].FindControl("lnkbtnOK") as LinkButton);
                lnkEbtnOK.Visible = true;
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
