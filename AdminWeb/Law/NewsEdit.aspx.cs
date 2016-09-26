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
using FreeTextBoxControls;

public partial class Law_NewsEdit : SZMA.Core.Admin.PageBase
{
    public string strFileUrl;
    int obj_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (null == Request.QueryString["ID"] || Request.QueryString["ID"]=="")
            {
                lblID.Text = Common.Insert("News", "InsertFlag", "CreateTime");
                if(!Common.Update("News", "ID", lblID.Text, new string[] { "SortID" }, new string[] { Request.QueryString["PID"] }))
                {
                    this.Response.Write("<script language='javascript'> alert('插入数据库失败!')</script>");
                    return;
                }
                this.Response.Redirect("NewsEdit.aspx?pid=" + Request.QueryString["PID"] + "&id=" + lblID.Text);
            }
            else
            {
                lblID.Text = Request.QueryString["ID"];
            }
            Data_Init();
        }
        if (lblID.Text != "")
        {
            strFileUrl = "../UploadFile/UpLoadFile.aspx?SortID=1&MainID=" + lblID.Text;
        }
    }

    private void Data_Init()
    {
        if (null != Request.QueryString["PID"])
        {
            switch( Request.QueryString["PID"])
            {
                case "1":
                    lblSortName.Text = "机构介绍";
                    if (!CheckAdminRight(1))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_Int, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7702))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}

                    break;
                case "2":
                    lblSortName.Text = "政策法规";
                    if (!CheckAdminRight(3))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7708))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                case "3":
                    lblSortName.Text = "公告";
                    if (!CheckAdminRight(3))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7710))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                case "4":
                    lblSortName.Text = "办证指南";
                    if (!CheckAdminRight(1))
                    {
                        this.Response.Redirect("../NoRight.aspx");
                        return;
                    }
                    //if (!CheckRight(SZMA.BLL.Rights.szma_note, Common.opt_ma))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    //if (!checkYUright(7704))
                    //{
                    //    this.Response.Redirect("../NoRight.aspx");
                    //    return;
                    //}
                    break;
                default:
                    break;
            }
        }
        if (lblID.Text != "")
       {
           int recc;
           DataSet ds =
               Common.Pager("News", "*", "ID", 1, 1, true,
                            " ID='" + lblID.Text + "'", out recc);
           if(ds.Tables[0].Rows.Count>0)
           {
               string right = "0";
               switch(ds.Tables[0].Rows[0]["SortID"].ToString())
               {
                   case "0":
                       right = "7";
                       break;
                   case "1":
                       right = "1";
                       break;
                   case "2":
                       right = "3";
                       break;
                   case "3":
                       right = "5";
                       break;
                   case "4":
                       right = "6";
                       break;
                   default:
                       break;
               }
               txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
               content.Text = ds.Tables[0].Rows[0]["Content"].ToString();
               txtRefer.Text = ds.Tables[0].Rows[0]["Refer"].ToString();
               txtKeyword.Text = ds.Tables[0].Rows[0]["Keyword"].ToString();
               txtAuthor.Text = ds.Tables[0].Rows[0]["Author"].ToString();
               txtAbstract.Text = ds.Tables[0].Rows[0]["Abstract"].ToString();
               if(ds.Tables[0].Rows[0]["IsSys"].ToString()=="1")
               {
                   pnlNewEdit.Visible = false;
                   txtTitle.Enabled = false;
                   lblSortName.Text = ds.Tables[0].Rows[0]["Title"].ToString();
               }
               switch(ds.Tables[0].Rows[0]["SortID"].ToString())
               {
                   case "2":
                       lblSortName.Text = "政策法规";
                       break;
                   case "3":
                       lblSortName.Text = "公告";
                       break;
                   default:
                       break;
               }
           }
       }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (lblID.Text!="")
        {
            string UserName = this.AdminUser.Username;
            NewsDAL obj = new NewsDAL();
           int rtn= obj.UpdateByID(txtTitle.Text, txtAbstract.Text, txtKeyword.Text, txtAuthor.Text, txtRefer.Text,
                           content.Text, 1, UserName, DateTime.Now, lblID.Text);
            if(rtn>0)
            {
                this.Response.Write("<script language='javascript'> alert('操作成功!')</script>");
            }
            else
            {
                this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("default.aspx");
    }
}
