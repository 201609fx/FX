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
using System.IO;

public partial class FileUpLoad_UpLoadFile : SZMA.Core.Admin.PageBase
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        if (!this.IsPostBack)
        {
            if (Request.QueryString["SortID"] != null)
                show();
        }
    }

    #region show
    public void show()
    {
        int recc;

        DataSet ds = Common.Pager("viewFile", "*", "ID", 999, 1, true, "FileSortID=" + Request.QueryString["SortID"].ToString() + " and MainID=" + Request.QueryString["MainID"].ToString(), out recc);
        rptList.DataSource = ds;
        rptList.DataBind();
        if (recc > 0)
        {
            rptList.Visible = true;
        }
        else
            rptList.Visible = false;
    }
    #endregion


    #region UpLoad
    protected void btn_upload_Click(object sender, System.EventArgs e)
    {
        string UserName = "double";
        if (txtFileName.Text.Trim().Length < 1)
        {
            lblFileName.Visible = true;
            return;
        }
        else
        {
            if (myFile.PostedFile != null && myFile.Value.Length != 0)
            {
                string nam = myFile.PostedFile.FileName;

                int i = nam.LastIndexOf(".");
                if (i < 1)
                {
                    Response.Write("<script language='javascript'>alert('未知文件类型！')</script>");
                    return;
                }
                int k = nam.LastIndexOf("/");

                string filePostfix = nam.Substring(i);
                string filePostfix2 = nam.Substring(i + 1).ToLower();
                string newFile = nam.Substring(k + 1);

                int totalRecord;
                DataSet ds = Common.Pager("FileFormat", "*", "ID", 10, 1, false, "Name ='" + filePostfix2.ToLower() + "'", out totalRecord);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    Response.Write("<script language='javascript'>alert('所选文件类型不正确！')</script>");
                    return;
                }

                DateTime now = DateTime.Now;

                string newname = now.Year.ToString() + now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString() + now.Millisecond.ToString();

                ds = Common.Pager("FileSort", "*", "ID", 10, 1, false, "ID =" + Request.QueryString["SortID"].ToString(), out totalRecord);

                string strFileFolder = System.Configuration.ConfigurationManager.AppSettings["FileLocationString"].ToString();
                try
                {
                    strFileFolder = MapPath(strFileFolder);
                }
                catch
                {
                }
                if (!Directory.Exists(strFileFolder))
                {
                    Directory.CreateDirectory(strFileFolder);
                }
                strFileFolder = strFileFolder + "\\" + ds.Tables[0].Rows[0]["TableName"].ToString();
                if (!Directory.Exists(strFileFolder))
                {
                    Directory.CreateDirectory(strFileFolder);
                }
                strFileFolder = strFileFolder + "\\" + ds.Tables[0].Rows[0]["SortName"].ToString();
                if (!Directory.Exists(strFileFolder))
                {
                    Directory.CreateDirectory(strFileFolder);
                }
                myFile.PostedFile.SaveAs((strFileFolder) + "\\" + newname + filePostfix);

                FIleDAL MyDAL = new FIleDAL();

                if (MyDAL.File_Insert(txtFileName.Text, filePostfix2, newname + filePostfix, UserName, Int32.Parse(Request.QueryString["SortID"].ToString()), Int32.Parse(Request.QueryString["MainID"].ToString())) > 0)
                {
                    Response.Write("<script language=javascript>alert('上传成功！');</script>");
                }
                show();
            }
        }

    }
    #endregion

    protected void DeleteCategory_Load(object sender, EventArgs e)
    {
        ((LinkButton)sender).Attributes["onclick"] = "return confirm('真的要删除这条记录吗?')";
    }

    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        FIleDAL MyDAL = new FIleDAL();
        switch (e.CommandName)
        {
            case "delete":
                if (MyDAL.File_Delete(Int32.Parse(e.CommandArgument.ToString())) == 2)
                {
                    Response.Write("<script language=javascript>alert('删除成功！');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('删除失败！');</script>");
                }
                break;
        }
        show();
    }
}
