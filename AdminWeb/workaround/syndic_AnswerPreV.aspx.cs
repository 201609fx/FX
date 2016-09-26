using System;
using System.Collections.Generic;
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

public partial class workaround_syndic_AnswerPreV : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(9))
        {
            this.Response.Redirect("../NoRight.aspx");
            return;
        }
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndicCheck, Common.opt_see))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        //if (!checkYUright(7715))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        if (!IsPostBack)
        {
            data_bind();
        }

      
    }

    override protected void OnInit(EventArgs e)
    {
        Data_Init();
        setTotle();
        base.OnInit(e);
    }
    protected bool setAsscee(string MID)
    {
        assessPlateDAL obj = new assessPlateDAL();
        DataSet ds = obj.SelectActive();
        if (ds.Tables[0].Rows.Count < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!没有一个激活的模版!')</script>");
            return false;
        }
        AssessDAL aobj = new AssessDAL();
        int rtn = aobj.Insert(MID, ds.Tables[0].Rows[0]["ID"].ToString(),AdminUser.Username);
        if (rtn < 1)
        {
            this.Response.Write("<script language='javascript'>alert('生成审核表失败!')</script>");
            return false;
        }
        return true;
    }
    private void data_bind()
    {
        AssessDAL obj = new AssessDAL();
        DataSet ds = obj.Select(Request.QueryString["mid"], Request.QueryString["aid"]);
        if(ds.Tables[0].Rows.Count>0)
        {
            lblMainName.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblSyndic.Text = ds.Tables[0].Rows[0]["PSUserName"].ToString();
            lblTime.Text = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
            lblTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            lblNO.Text = ds.Tables[0].Rows[0]["ID"].ToString();
        }
    }

    protected void Data_Init()
    {
        ProblemSortDAL obj = new ProblemSortDAL();
        DataSet ds = obj.SelectByAssessIDandMainSCID(Request.QueryString["aid"], Request.QueryString["mid"]);
        FProblemSort_Init(ds);
    }

    #region //生成1级类型
    protected void FProblemSort_Init(DataSet ds)
    {

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Label lblTemp1 = new Label();
            lblTemp1.Text = "<tr bgcolor='#F2F2F2'><td colspan='3'><font style='font-size:16;font-weight:bold;'>" + ds.Tables[0].Rows[i]["OrderNum"].ToString() + "." 
                            + ds.Tables[0].Rows[i]["Name"].ToString()
                            +"("+ds.Tables[0].Rows[i]["Totle"].ToString()+"分)"
                            + (ds.Tables[0].Rows[i]["Remark"].ToString() == "" ? "" : "【" + ds.Tables[0].Rows[i]["Remark"].ToString() + "】")
                            + "</font></td><td align='center'>" + (ds.Tables[0].Rows[i]["AllTotle"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["AllTotle"].ToString()) + "分</td></tr>";
            ph.Controls.Add(lblTemp1);
            
            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet Sds = obj.SelectByMIDandPID(ds.Tables[0].Rows[i]["ID"].ToString(), Request.QueryString["mid"]);
            SProblemSort_Init(Sds);
        }
    }
    #endregion
    #region //生成2级类型
    protected void SProblemSort_Init(DataSet ds)
    {
   //        <tr bgcolor="#F2F2F2" valign="top">
   //<td>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Pordernum")%>.<%#DataBinder.Eval(Container.DataItem, "OrderNum")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Name")%>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "Totle")%>分)<%# DataBinder.Eval(Container.DataItem, "Remark").ToString() == "" ? "" : "【" + DataBinder.Eval(Container.DataItem, "Remark").ToString() + "】"%></td>
   // <td>

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Label lblTemp1 = new Label();
            string strText;
            strText = "<tr bgcolor='#F2F2F2' valign='top'><td>" + ds.Tables[0].Rows[i]["Pordernum"].ToString() +
                            "." + ds.Tables[0].Rows[i]["OrderNum"].ToString() + " "
                            + ds.Tables[0].Rows[i]["Name"].ToString()
                            + "(" + ds.Tables[0].Rows[i]["Totle"].ToString() + "分)";
          
                strText += (ds.Tables[0].Rows[i]["Remark"].ToString() == ""
                                ? ""
                                : (ds.Tables[0].Rows[i]["hasChild"].ToString() == "0" ? ("<br>&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i]["Remark"].ToString()) : "【" + ds.Tables[0].Rows[i]["Remark"].ToString() + "】"));

                strText += "</font></td><td>";
                            //+ ds.Tables[0].Rows[i]["AllTotle"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["AllTotle"].ToString() + "分</td></tr>";
            lblTemp1.Text = strText;
            ph.Controls.Add(lblTemp1);
            
            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet Tds = obj.SelectByMIDandPID(ds.Tables[0].Rows[i]["ID"].ToString(), Request.QueryString["mid"]);
  
            
            ProblemDAL Pobj = new ProblemDAL();
            DataSet Pds = Pobj.SelectByPID(ds.Tables[0].Rows[i]["ID"].ToString());

            Problem_init(Pds);
            
            Label lblTemp3 = new Label();
            string Temp3Text;
            Temp3Text = "</td><td></td><td align='center'>" ;
            if (ds.Tables[0].Rows[i]["IsATotle"].ToString() == "0")
            {
                Temp3Text += (ds.Tables[0].Rows[i]["AllTotle"].ToString() == ""
                                  ? "0"
                                  : ds.Tables[0].Rows[i]["AllTotle"].ToString()) + "分</td></tr>";
                lblTemp3.Text = Temp3Text;
                ph.Controls.Add(lblTemp3);
            }
            else
            {
                lblTemp3.Text = Temp3Text;
                TextBox tb1=new TextBox();
                tb1.ID = "txtTotle" + ds.Tables[0].Rows[i]["ID"].ToString();
                tb1.Width = 40;
                tb1.Text = "";
                Label lblTemp4 = new Label();
                lblTemp4.Text = "分</td></tr>";
                ph.Controls.Add(lblTemp3);
                ph.Controls.Add(tb1);
                ph.Controls.Add(lblTemp4);
            }
            TProblemSort_Init(Tds);
           
            
         
        }
    }
    #endregion
    #region //生成3级类型
    protected void TProblemSort_Init(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Label lblTemp1 = new Label();
            lblTemp1.Text = "<tr bgcolor='#F2F2F2' valign='top'><td >" + 
                             ds.Tables[0].Rows[i]["OrderNum"].ToString() + ") "
                            + ds.Tables[0].Rows[i]["Name"].ToString()
                            + "(" + ds.Tables[0].Rows[i]["Totle"].ToString() + "分)"
                            + (ds.Tables[0].Rows[i]["Remark"].ToString() == "" ? "" : "<br> &nbsp;&nbsp;" + ds.Tables[0].Rows[i]["Remark"].ToString())
                            + "</font></td><td>";
            //+ ds.Tables[0].Rows[i]["AllTotle"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["AllTotle"].ToString() + "分</td></tr>";
            ph.Controls.Add(lblTemp1);

            ProblemDAL Pobj = new ProblemDAL();
            DataSet Pds = Pobj.SelectByPID(ds.Tables[0].Rows[i]["ID"].ToString());

            Problem_init(Pds);

            Label lblTemp3 = new Label();
            string Temp3Text;
            Temp3Text = "</td><td></td><td align='center'>";
            if (ds.Tables[0].Rows[i]["IsATotle"].ToString() == "0")
            {
                Temp3Text += (ds.Tables[0].Rows[i]["AllTotle"].ToString() == ""
                                  ? "0"
                                  : ds.Tables[0].Rows[i]["AllTotle"].ToString()) + "分</td></tr>";
                lblTemp3.Text = Temp3Text;
                ph.Controls.Add(lblTemp3);
            }
            else
            {
                lblTemp3.Text = Temp3Text;
                TextBox tb1 = new TextBox();
                tb1.ID = "txtTotle" + ds.Tables[0].Rows[i]["ID"].ToString();
                tb1.Width = 40;
                tb1.Text = "";
                Label lblTemp4 = new Label();
                lblTemp4.Text = "分</td></tr>";
                ph.Controls.Add(lblTemp3);
                ph.Controls.Add(tb1);
                ph.Controls.Add(lblTemp4);
            }



        }
    }
    #endregion
    #region //生成问题
    protected void Problem_init(DataSet ds )
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow drv = ds.Tables[0].Rows[i];
            switch (drv["ProblemTypeID"].ToString())
            {
                case "1":
                    lblProblemsInfo.Text += drv["ID"] + ".1,";
                    ProblemType1Init(drv);
                    break;

                case "2":
                    lblProblemsInfo.Text += drv["ID"] + ".2,";
                    ProblemType2Init(drv);
                    break;

                case "3":
                    lblProblemsInfo.Text += drv["ID"] + ".3." + ProblemType3Init(drv).ToString() + ",";
                    break;

                case "4":
                    lblProblemsInfo.Text += drv["ID"] + ".4." + ProblemType4Init(drv).ToString() + ",";
                    break;

                case "5":
                    lblProblemsInfo.Text += drv["ID"] + ".5." + ProblemType5Init(drv).ToString() + ",";
                    break;

                case "6":
                    lblProblemsInfo.Text += drv["ID"] + ".6." + ProblemType6Init(drv).ToString() + ",";
                    break;
            }
        }
    }
    #endregion
    #region //生成问题
    /// <summary>
    /// 单选
    /// </summary>
    /// <param name="dr"></param>
    private void ProblemType1Init(DataRow dr)
    {
        //生成单选题
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%''  border='0'' align='center'' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='black' class='main-text'>"+
                       "<tr bgcolor='#F2F2F2'><td valign='top'><table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='#F2F2F2' class='main-text'><tr><td class='main-text'valign='top' align='left'>" + dr["ProblemContent"].ToString();
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());

        CheckBoxList rblTemp = new CheckBoxList();
        rblTemp.ID = "cbl" + dr["ID"].ToString();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            rblTemp.Items.Add(new ListItem(ds.Tables[0].Rows[i]["OptionContent"].ToString() + "", ds.Tables[0].Rows[i]["ID"].ToString()));
            rblTemp.Items[i].Attributes.Add("onclick", "CheckBoxList_Click(this)");
        }
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        if (dsAnswer.Tables[0].Rows.Count > 0)
            rblTemp.SelectedValue = dsAnswer.Tables[0].Rows[0]["OptionID"].ToString();
        rblTemp.CssClass = "main-text";
        rblTemp.RepeatColumns = ds.Tables[0].Rows.Count;
        rblTemp.RepeatLayout = RepeatLayout.Flow;
        rblTemp.TextAlign = TextAlign.Left;
        ph.Controls.Add(rblTemp);
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr></table></td></tr></table>";
        ph.Controls.Add(lblTemp2);
    }


    /// <summary>
    /// 多选
    /// </summary>
    /// <param name="dr"></param>
    private void ProblemType2Init(DataRow dr)
    {
        //生成多选题
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%''  border='0'' align='center'' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='black' class='main-text'>" +
                      "<tr bgcolor='#F2F2F2'><td valign='top'><table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='#F2F2F2' class='main-text'><tr><td class='main-text'valign='top' align='left'>" + dr["ProblemContent"].ToString();
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        DataSet ds = obj.Select(dr["ID"].ToString());

        CheckBoxList cblTemp = new CheckBoxList();
        cblTemp.ID = "cbl" + dr["ID"].ToString();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cblTemp.Items.Add(new ListItem(ds.Tables[0].Rows[i]["OptionContent"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));
        }


        ///初始化多个答案
       for(int i=0;i<dsAnswer.Tables[0].Rows.Count;i++)
       {
           cblTemp.Items[int.Parse(dsAnswer.Tables[0].Rows[i]["OptionAnswer"].ToString()) - 1].Selected = true;
        }
        
        cblTemp.CssClass = "main-text";
        cblTemp.RepeatColumns = ds.Tables[0].Rows.Count;
        cblTemp.RepeatLayout = RepeatLayout.Flow;
        cblTemp.TextAlign = TextAlign.Left;
        ph.Controls.Add(cblTemp);

        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr></table></td></tr></table>";
        ph.Controls.Add(lblTemp2);
    }

    /// <summary>
    /// 单行填空:返回题目所需textbox数目
    /// </summary>
    /// <param name="dr"></param>
    /// <returns></returns>
    private int ProblemType3Init(DataRow dr)
    {
        //生成单行填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%''  border='0'' align='center'' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='black' class='main-text'>" +
                     "<tr bgcolor='#F2F2F2'><td valign='top'><table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='#F2F2F2' class='main-text'><tr><td class='main-text'valign='top' align='left'>" + dr["ProblemContent"].ToString(); 
        ph.Controls.Add(lblTemp1);
        string strContent = dr["ProblemContent"].ToString();
        string[] strBuf;
        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        DataSet ds = obj.Select(dr["ID"].ToString());
       
        int sum = 0;
        string writeAnswer;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ///初始化答案
            writeAnswer = "";
            List<string> MyStrList=new List<string>();
            int WAsum = 0;
            for (int j = 0; j < dsAnswer.Tables[0].Rows.Count;j++ )
            {
                if(dsAnswer.Tables[0].Rows[j]["OptionID"].ToString()==ds.Tables[0].Rows[i]["ID"].ToString())
                {
                    writeAnswer = dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString();
                    while (writeAnswer.IndexOf(",.") > -1)
                    {
                        MyStrList.Add(writeAnswer.Substring(0, writeAnswer.IndexOf(",.")));
                        writeAnswer = writeAnswer.Remove(0, writeAnswer.IndexOf(",.") + 2);
                    }
                }
            }
            
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
                        tb1.ID = "txt" + dr["ID"].ToString() + "_" + sum.ToString();
                        if (MyStrList.Count > WAsum)
                        {
                            tb1.Text = MyStrList[WAsum];
                            WAsum++;
                        }
                        ph.Controls.Add(tb1);
                        j = j + 2;
                    }
                }
                else
                {
                    Label lbl1 = new Label();
                    lbl1.Text = strBuf[j];
                    ph.Controls.Add( lbl1);
                }
            }
        }
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr></table></td></tr></table>";
        ph.Controls.Add(lblTemp2);
        return sum;
    }

    /// <summary>
    /// 多行填空
    /// </summary>
    /// <param name="dr"></param>
    private int ProblemType4Init(DataRow dr)
    {
        //生成多行填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%''  border='0'' align='center'' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='black' class='main-text'>" +
                  "<tr bgcolor='#F2F2F2'><td valign='top'><table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='#F2F2F2' class='main-text'><tr><td class='main-text'valign='top' align='left'>" + dr["ProblemContent"].ToString();
        ph.Controls.Add(lblTemp1);

        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());

        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label lbl1 = new Label();
            lbl1.Text = ds.Tables[0].Rows[0]["OptionContent"].ToString();
            ph.Controls.Add(lbl1);
        }

        TextBox tb = new TextBox();
        tb.ID = "txt" + dr["ID"].ToString() + "_1" ;
        tb.Width = 300;
        tb.Height = 80;
        tb.TextMode = TextBoxMode.MultiLine;
        for (int j = 0; j < dsAnswer.Tables[0].Rows.Count; j++)
        {
            if(dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString().IndexOf(",.") > -1)
            {
                tb.Text =
                    dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString().Substring(0,
                                                                                   dsAnswer.Tables[0].Rows[j][
                                                                                       "WriteAnswer"].ToString().IndexOf
                                                                                       (",."));
            }
        }
        ph.Controls.Add(tb);
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr></table></td></tr></table>";
        ph.Controls.Add(lblTemp2);
        return 1;
    }

    /// <summary>
    /// 单选+填空
    /// </summary>
    /// <param name="dr"></param>
    private int ProblemType5Init(DataRow dr)
    {
        //生成单选+填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%''  border='0'' align='center'' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='black' class='main-text'>" +
                     "<tr bgcolor='#F2F2F2'><td valign='top'><table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='#F2F2F2' class='main-text'><tr><td class='main-text'valign='top' align='left'>" + dr["ProblemContent"].ToString(); 
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        lblProblemsInfo.Text += ds.Tables[0].Rows.Count.ToString() + ",";
        string strContent;
        string[] strBuf;
        int sum = 0;


        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        string writeAnswer;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            CheckBox rbTemp = new CheckBox();
            rbTemp.Text = "&nbsp;&nbsp;&nbsp;";
            rbTemp.ID = "rbGroup" + dr["ID"].ToString() + ds.Tables[0].Rows[i]["ID"].ToString().PadLeft(8, '0');
            rbTemp.CssClass = "main-text";
            rbTemp.Attributes.Add("onclick", "CheckBoxList2_Click(this)");
            rbTemp.TextAlign = TextAlign.Left;

            strContent = ds.Tables[0].Rows[i]["OptionContent"].ToString();
            strBuf = strContent.Split("@输入框".ToCharArray());

            ///初始化答案
            writeAnswer = "";
            List<string> MyStrList = new List<string>();
            int WAsum = 0;
            for (int j = 0; j < dsAnswer.Tables[0].Rows.Count; j++)
            {
                if (dsAnswer.Tables[0].Rows[j]["OptionID"].ToString() == ds.Tables[0].Rows[i]["ID"].ToString())
                {
                    rbTemp.Checked = true;
                    writeAnswer = dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString();
                    while (writeAnswer.IndexOf(",.") > -1)
                    {
                        MyStrList.Add(writeAnswer.Substring(0, writeAnswer.IndexOf(",.")));
                        writeAnswer = writeAnswer.Remove(0, writeAnswer.IndexOf(",.") + 2);
                    }
                }
            }
            
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
                        tb1.ID = "txt" + dr["ID"].ToString() + "_" + sum.ToString();
                        ///初始化答案
                        if (MyStrList.Count > WAsum)
                        {
                            tb1.Text = MyStrList[WAsum];
                            WAsum++;
                        }
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

        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr></table></td></tr></table>";
        ph.Controls.Add(lblTemp2);
        return sum;
    }

    /// <summary>
    /// 多选+填空
    /// </summary>
    /// <param name="dr"></param>
    private int ProblemType6Init(DataRow dr)
    {
        //生成多选+填空
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%''  border='0'' align='center'' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='black' class='main-text'>" +
                       "<tr bgcolor='#F2F2F2'><td valign='top'><table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='#F2F2F2' class='main-text'><tr><td class='main-text'valign='top' align='left'>" + dr["ProblemContent"].ToString(); 
        ph.Controls.Add(lblTemp1);
        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());
        lblProblemsInfo.Text += ds.Tables[0].Rows.Count.ToString() + ",";
        int sum = 0;

        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        string writeAnswer;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            CheckBox cbTemp = new CheckBox();
            cbTemp.Text = "&nbsp;&nbsp;";
            cbTemp.CssClass = "main-text";
            cbTemp.TextAlign = TextAlign.Left;
            cbTemp.ID = "rbGroup" + dr["ID"].ToString() + ds.Tables[0].Rows[i]["ID"].ToString().PadLeft(8, '0');

            string strContent;
            string[] strBuf;



            strContent = ds.Tables[0].Rows[i]["OptionContent"].ToString();
            strBuf = strContent.Split("@输入框".ToCharArray());




            ///初始化答案
            writeAnswer = "";
            List<string> MyStrList = new List<string>();
            int WAsum = 0;
            for (int j = 0; j < dsAnswer.Tables[0].Rows.Count; j++)
            {
                if (dsAnswer.Tables[0].Rows[j]["OptionID"].ToString() == ds.Tables[0].Rows[i]["ID"].ToString())
                {
                    cbTemp.Checked = true;
                    writeAnswer = dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString();
                    while (writeAnswer.IndexOf(",.") > -1)
                    {
                        MyStrList.Add(writeAnswer.Substring(0, writeAnswer.IndexOf(",.")));
                        writeAnswer = writeAnswer.Remove(0, writeAnswer.IndexOf(",.") + 2);
                    }
                }
            }
            
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
                        tb1.ID = "txt" + dr["ID"].ToString() + "_" + sum.ToString();
                        ///初始化答案
                        if (MyStrList.Count > WAsum)
                        {
                            tb1.Text = MyStrList[WAsum];
                            WAsum++;
                        }
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

        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='10'></td></tr></table></td></tr></table>";
        ph.Controls.Add(lblTemp2);
        return sum;
    }
    #endregion

    #region //获取答案
    private bool GetAnswer(string[] ProblemBuf)
    {
        switch (ProblemBuf[1])
        {
            case "1":
                GetType1Answer(ProblemBuf);
                break;
            case "2":
                GetType2Answer(ProblemBuf);
                break;
            case "3":
                 GetType3Answer(ProblemBuf);
                break;
            case "4":
                GetType4Answer(ProblemBuf);
                break;
            case "5":
                GetType5Answer(ProblemBuf);
                break;
            case "6":
                GetType6Answer(ProblemBuf);
                break;
            default:
                break;
        }
        return true;
    }
    
    private bool GetType1Answer(string[] ProblemBuf)
    {
        string UserName =AdminUser.Username;
        int rtn=0;
        int deleteFlag = 0;
        string Answer = "";

        AnswerDAL Aobj = new AnswerDAL();
       CheckBoxList ckb1=ph.FindControl( "cbl" + ProblemBuf[0]) as CheckBoxList;
       for (int i = 0; i < ckb1.Items.Count; i++)
       {
           if (ckb1.Items[i].Selected)
           {
               if (deleteFlag == 0)
               {
                   Aobj.Delete(ProblemBuf[0], Request.QueryString["mid"]);
                   deleteFlag++;
               }
                   rtn = rtn + Aobj.Insert(Request.QueryString["mid"], ProblemBuf[0], ckb1.Items[i].Value, (i + 1).ToString(), Answer, "", UserName);
           }
       } 
       return true;
    }

    private bool GetType2Answer(string[] ProblemBuf)
    {
        string UserName = AdminUser.Username;
        int rtn=0;
        string Answer = "";
        int deleteFlag = 0;
        
        AnswerDAL Aobj = new AnswerDAL();
        CheckBoxList ckb1 = ph.FindControl("cbl" + ProblemBuf[0]) as CheckBoxList;
        for (int i = 0; i < ckb1.Items.Count; i++)
        {
            if (ckb1.Items[i].Selected)
            {
                if (deleteFlag == 0)
                {
                    Aobj.Delete(ProblemBuf[0], Request.QueryString["mid"]);
                    deleteFlag++;
                }
               rtn = rtn + Aobj.Insert(Request.QueryString["mid"], ProblemBuf[0], ckb1.Items[i].Value, (i + 1).ToString(), Answer, "", UserName);
            }
        }
        return true;
    }
    private bool GetType3Answer(string[] ProblemBuf)
    {

        string UserName = AdminUser.Username;
        int txtsum = int.Parse(ProblemBuf[2]);
        int txtCount = 0, rtn = 0;
        TextBox txtAnswer;
        int deleteFlag = 0;
        string Answer = "";

        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        string OptionContent;
        DataSet dsOption = obj.Select(ProblemBuf[0]);
        int Prtn = 0;
        for (int j = 0; j < dsOption.Tables[0].Rows.Count; j++)
        {
            
            
            OptionContent = dsOption.Tables[0].Rows[j]["OptionContent"].ToString();
            while (OptionContent.LastIndexOf("@输入框") > -1)
            {
                OptionContent = OptionContent.Remove(OptionContent.LastIndexOf("@输入框"));
                txtCount++;
                txtAnswer = ph.FindControl("txt" +ProblemBuf[0]+"_"+ txtCount.ToString()) as TextBox;
                Answer += txtAnswer.Text + ",.";
            }

            if (deleteFlag == 0)
            {
                Aobj.Delete(ProblemBuf[0], Request.QueryString["mid"]);
                deleteFlag++;
            }
            rtn = rtn + Aobj.Insert(Request.QueryString["mid"], ProblemBuf[0], dsOption.Tables[0].Rows[j]["ID"].ToString(), (j + 1).ToString(), Answer, "", UserName);

        }
        return rtn>0;
    }

    private bool GetType4Answer(string[] ProblemBuf)
    {
        string UserName = AdminUser.Username;
        int txtsum = int.Parse(ProblemBuf[2]);
        int txtCount = 0, rtn = 0;
        TextBox txtAnswer;
        string Answer = "";
        int deleteFlag = 0;

        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        string OptionContent;
        DataSet dsOption = obj.Select(ProblemBuf[0]);
        int Prtn = 0;
        for (int j = 0; j < dsOption.Tables[0].Rows.Count; j++)
        {
                txtCount++;
                txtAnswer = ph.FindControl("txt" + ProblemBuf[0] + "_" + txtCount.ToString()) as TextBox;
                Answer += txtAnswer.Text.Replace("\r\n", "<br>") + ",.";
            

            if (deleteFlag == 0)
            {
                Aobj.Delete(ProblemBuf[0], Request.QueryString["mid"]);
                deleteFlag++;
            }
             rtn = rtn + Aobj.Insert(Request.QueryString["mid"], ProblemBuf[0], dsOption.Tables[0].Rows[j]["ID"].ToString(), (j + 1).ToString(), Answer, "", UserName);

        }
        return rtn > 0;
    }
    private bool GetType5Answer(string[] ProblemBuf)
    {
        string UserName = AdminUser.Username;
        int txtsum = int.Parse(ProblemBuf[2]);
        int txtCount = 0, rtn = 0;
        TextBox txtAnswer;
        string Answer = "";
        int deleteFlag = 0;

        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        string OptionContent;
        DataSet dsOption = obj.Select(ProblemBuf[0]);
        
        string strID;
        CheckBox checktemp;
        for (int i = 0; i < dsOption.Tables[0].Rows.Count; i++)
        {
            strID = "rbGroup" + ProblemBuf[0].ToString() + dsOption.Tables[0].Rows[i]["ID"].ToString().PadLeft(8, '0');
            checktemp = ph.FindControl(strID) as CheckBox;
           
            if(checktemp.Checked)
            {
                OptionContent = dsOption.Tables[0].Rows[i]["OptionContent"].ToString();
                while (OptionContent.LastIndexOf("@输入框") > -1)
                {
                    OptionContent = OptionContent.Remove(OptionContent.LastIndexOf("@输入框"));
                    txtCount++;
                    txtAnswer = ph.FindControl("txt" + ProblemBuf[0] + "_" + txtCount.ToString()) as TextBox;
                    Answer += txtAnswer.Text + ",.";
                }
                if (deleteFlag == 0)
                {
                    Aobj.Delete(ProblemBuf[0], Request.QueryString["mid"]);
                    deleteFlag++;
                }
                    rtn = rtn + Aobj.Insert(Request.QueryString["mid"], ProblemBuf[0], dsOption.Tables[0].Rows[i]["ID"].ToString(), (i + 1).ToString(), Answer, "", UserName);
            }
            else
            {
                OptionContent = dsOption.Tables[0].Rows[i]["OptionContent"].ToString();
                while (OptionContent.LastIndexOf("@输入框") > -1)
                {
                    OptionContent = OptionContent.Remove(OptionContent.LastIndexOf("@输入框"));
                    txtCount++;
                }
            }
        }
        return true;
    }
    private bool GetType6Answer(string[] ProblemBuf)
    {
        string UserName = AdminUser.Username;
        int txtsum = int.Parse(ProblemBuf[2]);
        int txtCount = 0, rtn = 0;
        TextBox txtAnswer;
        string Answer = "";
        int deleteFlag = 0;

        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        string OptionContent;
        DataSet dsOption = obj.Select(ProblemBuf[0]);

        string strID;
        CheckBox checktemp;
        for (int i = 0; i < dsOption.Tables[0].Rows.Count; i++)
        {
            strID = "rbGroup" + ProblemBuf[0].ToString() + dsOption.Tables[0].Rows[i]["ID"].ToString().PadLeft(8, '0');
            checktemp = ph.FindControl(strID) as CheckBox;
            if (checktemp.Checked)
            {
                OptionContent = dsOption.Tables[0].Rows[i]["OptionContent"].ToString();
                while (OptionContent.LastIndexOf("@输入框") > -1)
                {
                    OptionContent = OptionContent.Remove(OptionContent.LastIndexOf("@输入框"));
                    txtCount++;
                    txtAnswer = ph.FindControl("txt" + ProblemBuf[0] + "_" + txtCount.ToString()) as TextBox;
                    Answer += txtAnswer.Text + ",.";
                }

                if (deleteFlag == 0)
                {
                    Aobj.Delete(ProblemBuf[0], Request.QueryString["mid"]);
                    deleteFlag++;
                }
                    rtn = rtn + Aobj.Insert(Request.QueryString["mid"], ProblemBuf[0], dsOption.Tables[0].Rows[i]["ID"].ToString(), (i + 1).ToString(), Answer, "", UserName);
            }
            else
            {
                OptionContent = dsOption.Tables[0].Rows[i]["OptionContent"].ToString();
                while (OptionContent.LastIndexOf("@输入框") > -1)
                {
                    OptionContent = OptionContent.Remove(OptionContent.LastIndexOf("@输入框"));
                    txtCount++;
                }
            }
        }
        return true;
    }
    #endregion

    /// <summary>
    /// 提交答案
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndicCheck, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string[] ProblemBuf;
        string[] strAnswer = lblProblemsInfo.Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        ///问题计数
        for (int i = 0; i < strAnswer.Length; i++)
        {
            ProblemBuf = strAnswer[i].Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            GetAnswer(ProblemBuf);
        }
            data_bind();
    }
    /// <summary>
    /// 提交评分
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTotleOK_Click(object sender, EventArgs e)
    {
        //if (!CheckRight(SZMA.BLL.Rights.szma_work_syndicCheck, Common.opt_ma))
        //{
        //    this.Response.Redirect("../NoRight.aspx");
        //    return;
        //}
        string UserName = AdminUser.Username;
        ProblemSortDAL obj=new ProblemSortDAL();
        DataSet ds = obj.SelectTotleByAssessID(Request.QueryString["aid"],Request.QueryString["mid"] );
        getTotle(ds, UserName);
        data_bind();
    }

    #region //获取分数
    protected void getTotle(DataSet ds,string Username)
    {
        AnswerToltleDAL obj=new AnswerToltleDAL();
        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            if(ds.Tables[0].Rows[i]["IsATotle"].ToString()=="1")
            {
                string txtID = "txtTotle" + ds.Tables[0].Rows[i]["ID"].ToString();
                TextBox txtTotle = ph.FindControl(txtID) as TextBox;
               if(obj.Update(txtTotle.Text,DateTime.Now,Username,ds.Tables[0].Rows[i]["ID"].ToString(),Request.QueryString["mid"])<1)
               {
                   if(obj.Insert(txtTotle.Text, Request.QueryString["mid"], ds.Tables[0].Rows[i]["ID"].ToString(), Username)<1)
                   {
                       this.Response.Write("<script language='javascript'>alert('提交" + ds.Tables[0].Rows[i]["Name"].ToString() + "失败')</script>");
                       return;
                   }
               }
            }
        }
        AssessDAL aobj=new AssessDAL();
        if (aobj.UpdateTotle(Request.QueryString["mid"], Request.QueryString["aid"]) < 1)
        {
            this.Response.Write("<script language='javascript'>alert('更新总分失败!')</script>");
            return;
        }
    }
    #endregion

    #region //初始化分数
    protected void setTotle()
    {

        ProblemSortDAL obj = new ProblemSortDAL();
        DataSet ds = obj.SelectTotleByAssessID( Request.QueryString["aid"],Request.QueryString["mid"]);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["IsATotle"].ToString() == "1")
            {
                string txtID = "txtTotle" + ds.Tables[0].Rows[i]["ID"].ToString();
                TextBox txtTotle = ph.FindControl(txtID) as TextBox;
                txtTotle.Text = (ds.Tables[0].Rows[i]["AllTotle"].ToString() == ""
                                ? "0"
                                : ds.Tables[0].Rows[i]["AllTotle"].ToString());
            }
        }
    }
    #endregion
}
