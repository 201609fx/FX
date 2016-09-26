﻿using System;
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
public partial class workaround_Complain_EditFirst : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(21))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //} 
        //if (!checkYUright(7728))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}

        btnSubmit.OnClientClick = "return confirm('您确定要保存操作吗?')";
        if (!IsPostBack)
        {
            if(null!=Request.QueryString["id"]&&Request.QueryString["id"]!="")
            data_init();
            else
            {
               string strID=Common.Insert("complain", "InsertFlag", "CreateTime");
                if(strID!="")
                    this.Response.Redirect("Complain_EditFirst.aspx?id=" + strID);
            }
        }

    }

    private void data_init()
    {
        ComplainerDAL obj = new ComplainerDAL();
        DataSet ds = obj.SelectByID(Request.QueryString["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtContent.Text = ds.Tables[0].Rows[0]["content"].ToString().Replace( "<br>","\r\n");
            txtComplainer.Text = ds.Tables[0].Rows[0]["Complainer"].ToString();
            txtCtel.Text = ds.Tables[0].Rows[0]["Ctel"].ToString();
            txtCaddresstou.Text = ds.Tables[0].Rows[0]["Caddresstou"].ToString();
            txtBCTel.Text = ds.Tables[0].Rows[0]["BCTel"].ToString();
            txtBContact.Text = ds.Tables[0].Rows[0]["BContact"].ToString();
            txtBComplainer.Text = ds.Tables[0].Rows[0]["BComplainer"].ToString();
            txtBAddress.Text = ds.Tables[0].Rows[0]["BAddress"].ToString();
            dpCTime.Date = getTime(ds.Tables[0].Rows[0]["CTime"].ToString());
            ddlCType.SelectedValue = ds.Tables[0].Rows[0]["InsertFlag"].ToString();
        }
    }

      protected void  btnPass_Click(object sender, EventArgs e)
      {
          if (!CheckAdminRight(21))
          {
              this.Response.Redirect("../NoRight.aspx");
              return;
          }
          //if (!CheckRight(SZMA.BLL.Rights.szma_work, Common.opt_ma))
          //{
          //    this.Response.Redirect("../NoRight.aspx");
          //    return;
          //}
          //if (!checkYUright(7728))
          //{
          //    this.Response.Redirect("../NoRight.aspx");
          //    return;
          //}
          string UserName = AdminUser.Username;
          ComplainerDAL obj = new ComplainerDAL();
          if (!Common.Update("complain", "ID", Request.QueryString["id"], new string[] { "InsertFlag", "UserName" }, new string[] { "2", UserName }))
          {
              this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
              return;
          }
          CertDictDAL Cobj=new CertDictDAL();
          Cobj.Add("3");
         DataSet ds=Cobj.SelectByID("3");
          if(ds.Tables[0].Rows.Count>0)
          {
              Common.Update("complain", "ID", Request.QueryString["id"], new string[] {"CNO"},
                            new string[] {ds.Tables[0].Rows[0]["C_value"].ToString().PadLeft(5, '0')});
              this.Response.Redirect("Complain_Edit.aspx?id="+Request.QueryString["id"]);
          }
      }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckAdminRight(21))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7728))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string UserName = AdminUser.Username;
        ComplainerDAL obj = new ComplainerDAL();
        if (obj.UpdateFirst(getDate(dpCTime.Date),txtComplainer.Text,txtCaddresstou.Text,txtCtel.Text,
                            txtBComplainer.Text,txtBCTel.Text,txtBContact.Text,txtBAddress.Text,
                            txtName.Text, txtContent.Text.Replace("\r\n", "<br>"),
        ddlCType.SelectedValue,1, Request.QueryString["id"],UserName) < 1)
        {
            this.Response.Write("<script language='javascript'> alert('操作失败!')</script>");
            return;
        }
    }
}
