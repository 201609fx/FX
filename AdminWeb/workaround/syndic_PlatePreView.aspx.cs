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

public partial class workaround_syndic_PlatePreView : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(11))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndic, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7715))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if(!IsPostBack)
        {
            Data_Init();
            data_bind();
        }
    }

    private void data_bind()
    {
        for(int i=0;i<rptFProblemSort.Items.Count;i++)
        {
            
        }
        
    }
    
    protected  void Data_Init()
    {
        ProblemSortDAL obj = new ProblemSortDAL();
        DataSet ds = obj.SelectByAssessID(Request.QueryString["id"]);
        rptFProblemSort.DataSource = ds;
        rptFProblemSort.DataBind();
    }


    protected void rptFProblemSort_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Repeater rptSProblemSort = e.Item.FindControl("rptSProblemSort") as Repeater;
            DataRowView drv = (DataRowView)e.Item.DataItem;
            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet ds = obj.SelectForPlate(drv["ID"].ToString());
            rptSProblemSort.DataSource = ds.Tables[0].DefaultView;
            rptSProblemSort.DataBind();
        }
        catch (Exception e1)
        {
        }

    }
    protected void rptSProblemSort_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Repeater rptTProblemSort = e.Item.FindControl("rptTProblemSort") as Repeater;
            DataRowView drv = (DataRowView)e.Item.DataItem;
            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet ds = obj.SelectForPlate(drv["ID"].ToString());
            rptTProblemSort.DataSource = ds.Tables[0].DefaultView;
            rptTProblemSort.DataBind();
        }
        catch (Exception e1)
        {
        }
        try
        {
            Repeater rptSProblem = e.Item.FindControl("rptSProblem") as Repeater;
            DataRowView drv = (DataRowView)e.Item.DataItem;
            ProblemDAL obj = new ProblemDAL();
            DataSet ds = obj.SelectByPID(drv["ID"].ToString());
            rptSProblem.DataSource = ds.Tables[0].DefaultView;
            rptSProblem.DataBind();
        }
        catch (Exception e1)
        {
        }

    }
    protected void rptTProblemSort_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Repeater rptTProblem = e.Item.FindControl("rptTProblem") as Repeater;
            DataRowView drv = (DataRowView)e.Item.DataItem;
            ProblemDAL obj = new ProblemDAL();
            DataSet ds = obj.SelectByPID(drv["ID"].ToString());
            rptTProblem.DataSource = ds.Tables[0].DefaultView;
            rptTProblem.DataBind();
        }
        catch (Exception e1)
        {
        }

    }

    protected void rptSProblem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
            DataRowView drv = (DataRowView)e.Item.DataItem;
            PlaceHolder ph = e.Item.FindControl("phOption") as PlaceHolder;
            switch (drv["ProblemTypeID"].ToString())
            {
                case "1":
                    lblProblemsInfo.Text += drv["ID"] + ".1,";
                    ProblemType1Init(drv,ph);
                    break;

                case "2":
                    lblProblemsInfo.Text += drv["ID"] + ".2,";
                    ProblemType2Init(drv, ph);
                    break;

                case "3":
                    lblProblemsInfo.Text += drv["ID"] + ".3." + ProblemType3Init(drv, ph).ToString()+",";
                    break;

                case "4":
                    lblProblemsInfo.Text += drv["ID"] + ".4,";
                    ProblemType4Init(drv, ph);
                    break;

                case "5":
                    lblProblemsInfo.Text += drv["ID"] + ".5.";
                    ProblemType5Init(drv, ph);
                    break;

                case "6":
                    lblProblemsInfo.Text += drv["ID"] + ".6.";
                    ProblemType6Init(drv, ph);
                    break;
            }

        }


  #region //生成问题
    /// <summary>
    /// 单选
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="ph"></param>
    private void ProblemType1Init(DataRowView dr, PlaceHolder ph)
    {
        //生成单选题
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<tr><td class='main-text' valign='top' align='left'>" + dr["ProblemContent"];
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());

        CheckBoxList rblTemp = new CheckBoxList();
        rblTemp.ID = "cbl1";
      
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            rblTemp.Items.Add(new ListItem( ds.Tables[0].Rows[i]["OptionContent"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));
            rblTemp.Items[i].Attributes.Add("onclick", "CheckBoxList_Click(this)");
        }
        
        rblTemp.CssClass = "main-text";
        rblTemp.RepeatColumns = ds.Tables[0].Rows.Count;
        rblTemp.RepeatLayout = RepeatLayout.Flow;
        rblTemp.TextAlign = TextAlign.Left;
        ph.Controls.Add(rblTemp);
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr>";
        ph.Controls.Add(lblTemp2);
    }


    /// <summary>
    /// 多选
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="ph"></param>
    private void ProblemType2Init(DataRowView dr, PlaceHolder ph)
    {
        //生成多选题
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<tr><td class='main-text' valign='top' align='left'>" + dr["ProblemContent"];
        
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        CheckBoxList cblTemp = new CheckBoxList();
        cblTemp.ID = "cbl1";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cblTemp.Items.Add(new ListItem( ds.Tables[0].Rows[i]["OptionContent"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));
        }
        cblTemp.CssClass = "main-text";
        cblTemp.RepeatColumns = ds.Tables[0].Rows.Count;
        cblTemp.RepeatLayout = RepeatLayout.Flow;
        cblTemp.TextAlign = TextAlign.Left;
        ph.Controls.Add(cblTemp);
     
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr>";
        ph.Controls.Add(lblTemp2);
    }

    /// <summary>
    /// 单行填空:返回题目所需textbox数目
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="ph"></param>
    /// <returns></returns>
    private int ProblemType3Init(DataRowView dr, PlaceHolder ph)
    {
        //生成单行填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<tr><td class='main-text' valign='top' align='left'>" + dr["ProblemContent"];
        ph.Controls.Add(lblTemp1);
        string strContent = dr["ProblemContent"].ToString();
        string[] strBuf;
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        
        int sum = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strContent=ds.Tables[0].Rows[i]["OptionContent"].ToString();
            strBuf = strContent.Split("@输入框".ToCharArray());
      
            for(int j=0;j<strBuf.Length;j++)
            {
                if(strBuf[j]=="")
                {
                    if (j < strBuf.Length - 2 && strBuf[j + 1] == "" && strBuf[j + 2] == "")
                    {
                        TextBox tb1 = new TextBox();
                        tb1.Width = 80;
                        tb1.CssClass = "input-line";
                        sum++;
                        tb1.ID = "txt" + sum.ToString();
                        ph.Controls.Add(tb1);
                        j = j + 2;
                    }
                }
                else
                {
                    Label lbl1=new Label();
                    lbl1.Text = strBuf[j];
                    ph.Controls.Add(lbl1);
                }
            }
        }
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr>";
        ph.Controls.Add(lblTemp2);
        return sum;
    }

    /// <summary>
    /// 多行填空
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="ph"></param>
    private void ProblemType4Init(DataRowView dr, PlaceHolder ph)
    {
        //生成多行填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<tr><td class='main-text' valign='top' align='left'>" + dr["ProblemContent"];
        ph.Controls.Add(lblTemp1);

        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label lbl1 = new Label();
            lbl1.Text = ds.Tables[0].Rows[0]["OptionContent"].ToString();
            ph.Controls.Add(lbl1);
        }
        
        TextBox tb = new TextBox();
        tb.Width = 500;
        tb.Height = 80;
        tb.TextMode = TextBoxMode.MultiLine;
        ph.Controls.Add(tb);
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr>";
        ph.Controls.Add(lblTemp2);
    }

    /// <summary>
    /// 单选+填空
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="ph"></param>
    private int ProblemType5Init(DataRowView dr, PlaceHolder ph)
    {
        //生成单选+填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<tr><td class='main-text' valign='top' align='left'>" + dr["ProblemContent"];
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        lblProblemsInfo.Text += ds.Tables[0].Rows.Count.ToString() + ",";
        string strContent;
        string[] strBuf;
        int sum=0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            CheckBox rbTemp = new CheckBox();
            rbTemp.Text = "&nbsp;&nbsp;&nbsp;";
            rbTemp.ID = "rbGroup" + dr["ID"].ToString() + ds.Tables[0].Rows[i]["ID"].ToString().PadLeft(8,'0');
            rbTemp.CssClass = "main-text";
            rbTemp.Attributes.Add("onclick", "CheckBoxList2_Click(this)");
            rbTemp.TextAlign = TextAlign.Left;
            
            strContent = ds.Tables[0].Rows[i]["OptionContent"].ToString();
            strBuf = strContent.Split("@输入框".ToCharArray());

            for (int j = 0; j < strBuf.Length; j++)
            {
                if (strBuf[j] == "")
                {
                    if (j < strBuf.Length - 2 && strBuf[j + 1] == "" && strBuf[j + 2] == "")
                    {
                        TextBox tb1 = new TextBox();
                        tb1.Width = 80;
                        tb1.CssClass = "input-line";
                        sum++;
                        tb1.ID = "txt" + sum.ToString();
                        ph.Controls.Add(tb1);
                        j = j + 2;
                    }
                }
                else
                {
                    Label lbl1 = new Label();
                    lbl1.Text = strBuf[j];
                    ph.Controls.Add(lbl1);
                }
            }
            
            Label lblValue = new Label();
            lblValue.Text = ds.Tables[0].Rows[i]["ID"].ToString();
            lblValue.Visible = false;
            Label lblFormat = new Label();
            lblFormat.Text = "<br>";
            ph.Controls.Add(rbTemp);
            ph.Controls.Add(lblValue);
            ph.Controls.Add(lblFormat);
        }
        return sum;
    }
    
    /// <summary>
    /// 多选+填空
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="ph"></param>
    private void ProblemType6Init(DataRowView dr, PlaceHolder ph)
    {
        //生成多选+填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<tr><td class='main-text' valign='top' align='left'>" + dr["ProblemContent"];
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        lblProblemsInfo.Text += ds.Tables[0].Rows.Count.ToString() + ",";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            CheckBox cbTemp = new CheckBox();
            cbTemp.Text =  "&nbsp;";
            cbTemp.CssClass = "main-text";
            cbTemp.TextAlign = TextAlign.Left;
            cbTemp.ID = "rbGroup" + dr["ID"].ToString() + ds.Tables[0].Rows[i]["ID"].ToString().PadLeft(8, '0');
            
            string strContent;
            string[] strBuf;
            int sum = 0;


            strContent = ds.Tables[0].Rows[i]["OptionContent"].ToString();
            strBuf = strContent.Split("@输入框".ToCharArray());

            for (int j = 0; j < strBuf.Length; j++)
            {
                if (strBuf[j] == "")
                {
                    if (j < strBuf.Length - 2 && strBuf[j + 1] == "" && strBuf[j + 2] == "")
                    {
                        TextBox tb1 = new TextBox();
                        tb1.Width = 80;
                        tb1.CssClass = "input-line";
                        sum++;
                        tb1.ID = "txt" + sum.ToString();
                        ph.Controls.Add(tb1);
                        j = j + 2;
                    }
                }
                else
                {
                    Label lbl1 = new Label();
                    lbl1.Text = strBuf[j];
                    ph.Controls.Add(lbl1);
                }
            }
            
           
            Label lblValue = new Label();
            lblValue.Text = ds.Tables[0].Rows[i]["ID"].ToString();
            lblValue.Visible = false;
            Label lblFormat = new Label();
            lblFormat.Text = "<br>";
            ph.Controls.Add(cbTemp);
            ph.Controls.Add(lblValue);
            ph.Controls.Add(lblFormat);
        }
    }
  #endregion
    
    #region //获取答案
    
    #endregion
}
