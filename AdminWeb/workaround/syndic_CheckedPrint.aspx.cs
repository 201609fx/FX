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

public partial class workaround_syndic_CheckedPrint :SZMA.Core.Admin.PageBase
{
    protected int BodyHeight;
    protected Label ActiveLable;
    protected int PSCount = 22;
    protected int PCount = 37;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckAdminRight(9))
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
        if (!IsPostBack)
        {
            data_bind();
        }
    }

    override protected void OnInit(EventArgs e)
    {
        base.OnInit(e);
        BodyHeight = 70;
        Data_Init();
    }

    private void data_bind()
    {
        AssessDAL obj = new AssessDAL();
        DataSet ds = obj.Select(Request.QueryString["mid"], Request.QueryString["aid"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMainName.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            lblSyndic.Text = ds.Tables[0].Rows[0]["PSUserName"].ToString();
            lblTime.Text = getTime(ds.Tables[0].Rows[0]["PSTime"].ToString());
            lblTotle.Text = ds.Tables[0].Rows[0]["Totle"].ToString();
            lblNO.Text = ds.Tables[0].Rows[0]["ID"].ToString();
        }
    }

    private string getTime(string s)
    {
        string rtn = "";
        try
        {
            rtn = DateTime.Parse(s).ToString("yyyy/MM/dd");
        }
        catch
        {
        }
        return rtn;
    }

    protected void Data_Init()
    {
        ProblemSortDAL obj = new ProblemSortDAL();
        DataSet ds = obj.SelectByAssessIDandMainSCID(Request.QueryString["aid"], Request.QueryString["mid"]);
        FProblemSort_Init(ds);
    }
    #region //换页处理
    protected void PageChange()
    {
        Label lblTemp1 = new Label();
        if (ActiveLable != null)
        {
            lblTemp1.Text = ActiveLable.Text + @"</table><table width='960'  border='1' align='center' cellpadding='0' cellspacing='1' style='white-space:normal; word-break:break-all;page-break-after: always;background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' class='print-main'>
                               <tr  bgcolor='White'  height='20'>
                               <td width='360' align='center'>考核要求</td>   
                                <td width='440' align='center'>考核记录</td> 
                                <td width='100' align='center'>备注</td>
                                <td width='60' align='center'>总分</td>
                               </tr><tr  bgcolor='White'  height='20'>
                               <td ></td>   
                                <td >";
            ActiveLable = null;
        }
        else
        {
            lblTemp1.Text = @"</table><table width='960'  border='1' align='center' cellpadding='0' cellspacing='1' style='white-space:normal; word-break:break-all;page-break-after: always;background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' class='print-main'>
                               <tr  bgcolor='White'  height='20'>
                               <td width='360' align='center'>考核要求</td>   
                                <td width='440' align='center'>考核记录</td> 
                                <td width='100' align='center'>备注</td>
                                <td width='60' align='center'>总分</td>
                               </tr>";
        }
        ph.Controls.Add(lblTemp1);
        BodyHeight = 20;
    }
    protected void PageChange(int i)
    {
        Label lblTemp1 = new Label();

        lblTemp1.Text = @"</td></tr></table>" + ActiveLable.Text + @"</table><table width='960'  border='1' align='center' cellpadding='0' cellspacing='1' style='white-space:normal; word-break:break-all;page-break-after: always;background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' class='print-main'>
                               <tr  bgcolor='White'  height='20'>
                               <td width='360' align='center'>考核要求</td>   
                                <td width='440' align='center'>考核记录</td> 
                                <td width='100' align='center'>备注</td>
                                <td width='60' align='center'>总分</td>
                               </tr>";
        ActiveLable = null;
        ph.Controls.Add(lblTemp1);
        BodyHeight = 50;
    }
    #endregion
    #region //生成1级类型
    protected void FProblemSort_Init(DataSet ds)
    {

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ActiveLable = null;
            BodyHeight += 25;
            if (BodyHeight > 1100)
            {
                PageChange();
            }
            Label lblTemp1 = new Label();
            lblTemp1.Text = "<tr bgcolor='White' height='25'><td colspan='3'><font style='font-size:15;font-weight:bold;'>" + ds.Tables[0].Rows[i]["OrderNum"].ToString() + "."
                            + ds.Tables[0].Rows[i]["Name"].ToString()
                            + "(" + ds.Tables[0].Rows[i]["Totle"].ToString() + "分)"
                            + (ds.Tables[0].Rows[i]["Remark"].ToString() == "" ? "" : "【" + ds.Tables[0].Rows[i]["Remark"].ToString() + "】")
                            + "</font></td><td align='center'>" +  "</td></tr>";
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
        //        <tr bgcolor="White" valign="top">
        //<td>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Pordernum")%>.<%#DataBinder.Eval(Container.DataItem, "OrderNum")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Name")%>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "Totle")%>分)<%# DataBinder.Eval(Container.DataItem, "Remark").ToString() == "" ? "" : "【" + DataBinder.Eval(Container.DataItem, "Remark").ToString() + "】"%></td>
        // <td>

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ActiveLable = null;
            Label lblTemp1 = new Label();
            string strText;
            strText = "<tr bgcolor='White' valign='top' height='20'><td>" + ds.Tables[0].Rows[i]["Pordernum"].ToString() +
                            "." + ds.Tables[0].Rows[i]["OrderNum"].ToString() + " "
                            + ds.Tables[0].Rows[i]["Name"].ToString()
                            + "(" + ds.Tables[0].Rows[i]["Totle"].ToString() + "分)";

            strText += (ds.Tables[0].Rows[i]["Remark"].ToString() == ""
                            ? ""
                            : (ds.Tables[0].Rows[i]["hasChild"].ToString() == "0" ? ("<br>&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i]["Remark"].ToString()) : "【" + ds.Tables[0].Rows[i]["Remark"].ToString() + "】"));

            strText += "</font></td><td>";
            //+ ds.Tables[0].Rows[i]["AllTotle"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["AllTotle"].ToString() + "分</td></tr>";
            lblTemp1.Text = strText;
            ///分页判断
            int strLeght = removeHtml(strText).Length;
            BodyHeight += 20 * ((int)(strLeght / PSCount) + (strLeght / PSCount % PCount > 0 ? 1 : 0));
            if (BodyHeight > 1100)
            {
                PageChange();
            }
            ph.Controls.Add(lblTemp1);

            ProblemSortDAL obj = new ProblemSortDAL();
            DataSet Tds = obj.SelectByMIDandPID(ds.Tables[0].Rows[i]["ID"].ToString(), Request.QueryString["mid"]);


            ProblemDAL Pobj = new ProblemDAL();
            DataSet Pds = Pobj.SelectByPID(ds.Tables[0].Rows[i]["ID"].ToString());

            Label lblTemp3 = new Label();
            string Temp3Text;
            Temp3Text = "</td><td></td><td align='center'>";
            Temp3Text +=  "</td></tr>";
            lblTemp3.Text = Temp3Text;
            ActiveLable = lblTemp3;
            Problem_init(Pds);
            if (ActiveLable == null)
            {
                lblTemp3.Text = "</td><td></td><td align='center'></td></tr>";
            }
            ph.Controls.Add(lblTemp3);
            TProblemSort_Init(Tds);
        }
    }
    #endregion
    #region //生成3级类型
    protected void TProblemSort_Init(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ActiveLable = null;
            Label lblTemp1 = new Label();
            lblTemp1.Text = "<tr bgcolor='White' valign='top'height='20'><td >" +
                             ds.Tables[0].Rows[i]["OrderNum"].ToString() + ") "
                            + ds.Tables[0].Rows[i]["Name"].ToString()
                            + "(" + ds.Tables[0].Rows[i]["Totle"].ToString() + "分)"
                            + (ds.Tables[0].Rows[i]["Remark"].ToString() == "" ? "" : "<br> &nbsp;&nbsp;" + ds.Tables[0].Rows[i]["Remark"].ToString())
                            + "</font></td><td>";
            //+ ds.Tables[0].Rows[i]["AllTotle"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["AllTotle"].ToString() + "分</td></tr>";
            ///分页判断
            int strLeght = removeHtml(lblTemp1.Text).Length;
            BodyHeight += 20 * ((int)(strLeght / PSCount) + (strLeght / PSCount % PCount > 0 ? 1 : 0));
            if (BodyHeight > 1100)
            {
                PageChange();
            }
            ph.Controls.Add(lblTemp1);

            ProblemDAL Pobj = new ProblemDAL();
            DataSet Pds = Pobj.SelectByPID(ds.Tables[0].Rows[i]["ID"].ToString());

            Label lblTemp3 = new Label();
            string Temp3Text;
            Temp3Text = "</td><td></td><td align='center'>";
            Temp3Text +=  "</td></tr>";
            lblTemp3.Text = Temp3Text;
            ActiveLable = lblTemp3;
            Problem_init(Pds);
            if (ActiveLable == null)
            {
                lblTemp3.Text = "</td><td></td><td align='center'></td></tr>";
            }
            ph.Controls.Add(lblTemp3);



        }
    }
    #endregion
    #region //生成问题
    protected void Problem_init(DataSet ds)
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
        int PLength = 0;
        //生成单选题
        Label lblTemp1 = new Label();
        lblTemp1.Text = "<table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='White' class='main-text'><tr  height='20'> <td class='main-text'valign='top' align='left' style='white-space:normal; word-break:break-all;'>" + dr["ProblemContent"].ToString();

        PLength += dr["ProblemContent"].ToString().Length;
        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());

        CheckBoxList rblTemp = new CheckBoxList();
        rblTemp.ID = "cbl" + dr["ID"].ToString();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            rblTemp.Items.Add(new ListItem(ds.Tables[0].Rows[i]["OptionContent"].ToString() + "", ds.Tables[0].Rows[i]["ID"].ToString()));
            rblTemp.Items[i].Attributes.Add("onclick", "CheckBoxList_Click(this)");
            PLength += ds.Tables[0].Rows[i]["OptionContent"].ToString().Length + 2;
        }
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        if (dsAnswer.Tables[0].Rows.Count > 0)
            rblTemp.SelectedValue = dsAnswer.Tables[0].Rows[0]["OptionID"].ToString();
        rblTemp.CssClass = "main-text";
        rblTemp.RepeatColumns = ds.Tables[0].Rows.Count;
        rblTemp.RepeatLayout = RepeatLayout.Flow;
        rblTemp.TextAlign = TextAlign.Left;

        ///分页判断
        BodyHeight += 20 * ((PLength / PCount) + (PLength % PCount > 0 ? 1 : 0)) + 5;
        if (BodyHeight > 1100)
        {
            PageChange();
        }
        ph.Controls.Add(lblTemp1);
        ph.Controls.Add(rblTemp);
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='5'></td></tr></table>";
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
        lblTemp1.Text = "<table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='White' class='main-text'><tr  height='20'><td class='main-text'valign='top' align='left' style='white-space:normal; word-break:break-all;'>" + dr["ProblemContent"].ToString();

        int PLength = dr["ProblemContent"].ToString().Length;

        OptionDAL obj = new OptionDAL();
        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        DataSet ds = obj.Select(dr["ID"].ToString());

        CheckBoxList cblTemp = new CheckBoxList();
        cblTemp.ID = "cbl" + dr["ID"].ToString();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cblTemp.Items.Add(new ListItem(ds.Tables[0].Rows[i]["OptionContent"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));

            PLength += ds.Tables[0].Rows[i]["OptionContent"].ToString().Length + 2;
        }


        ///初始化多个答案
        for (int i = 0; i < dsAnswer.Tables[0].Rows.Count; i++)
        {
            cblTemp.Items[int.Parse(dsAnswer.Tables[0].Rows[i]["OptionAnswer"].ToString()) - 1].Selected = true;
        }

        cblTemp.CssClass = "main-text";
        cblTemp.RepeatColumns = ds.Tables[0].Rows.Count;
        cblTemp.RepeatLayout = RepeatLayout.Flow;
        cblTemp.TextAlign = TextAlign.Left;


        ///分页判断
        BodyHeight += 20 * ((PLength / PCount) + (PLength % PCount > 0 ? 1 : 0)) + 5;
        if (BodyHeight > 1100)
        {
            PageChange();
        }
        ph.Controls.Add(lblTemp1);
        ph.Controls.Add(cblTemp);

        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='5'></td></tr></table>";
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
        lblTemp1.Text = "<table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='White' class='main-text'><tr  height='20'><td class='main-text'valign='top' align='left' style='white-space:normal; word-break:break-all;'>" + dr["ProblemContent"].ToString();

        int PLength = dr["ProblemContent"].ToString().Length;
        if (BodyHeight + 60 > 1100)
        {
            PageChange();
        }
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
            List<string> MyStrList = new List<string>();
            int WAsum = 0;
            for (int j = 0; j < dsAnswer.Tables[0].Rows.Count; j++)
            {
                if (dsAnswer.Tables[0].Rows[j]["OptionID"].ToString() == ds.Tables[0].Rows[i]["ID"].ToString())
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
                        tb1.CssClass = "inputline-Print2";
                        sum++;
                        tb1.ID = "txt" + dr["ID"].ToString() + "_" + sum.ToString();
                        if (MyStrList.Count > WAsum)
                        {
                            tb1.Text = MyStrList[WAsum];
                            WAsum++;
                        }

                        PLength += 6;
                        ph.Controls.Add(tb1);
                        j = j + 2;

                    }
                }
                else
                {
                    Label lbl1 = new Label();
                    lbl1.Text = strBuf[j];
                    PLength += lbl1.Text.Length;
                    ph.Controls.Add(lbl1);
                }
            }
        }
        BodyHeight += 20 * ((PLength / PCount) + (PLength % PCount > 0 ? 1 : 0)) + 5;
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='5'></td></tr></table>";
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
        lblTemp1.Text = "<table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='White' class='main-text'><tr  height='20'><td class='main-text'valign='top' align='left' style='white-space:normal; word-break:break-all;'>" + dr["ProblemContent"].ToString();

        int PLength = dr["ProblemContent"].ToString().Length;

        OptionDAL obj = new OptionDAL();
        DataSet ds = obj.Select(dr["ID"].ToString());

        AnswerDAL Aobj = new AnswerDAL();
        DataSet dsAnswer = Aobj.SelectByProblem(Request.QueryString["mid"], dr["ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label lbl1 = new Label();
            lbl1.Text = ds.Tables[0].Rows[0]["OptionContent"].ToString();
            ph.Controls.Add(lbl1);
            PLength += lbl1.Text.Length;
        }
        TextBox tb = new TextBox();
        tb.ID = "txt" + dr["ID"].ToString() + "_1";
        tb.Width = 300;
        tb.Height = 80;
        tb.TextMode = TextBoxMode.MultiLine;
        for (int j = 0; j < dsAnswer.Tables[0].Rows.Count; j++)
        {
            if (dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString().IndexOf(",.") > -1)
            {
                tb.Text =
                    dsAnswer.Tables[0].Rows[j]["WriteAnswer"].ToString().Substring(0,
                                                                                   dsAnswer.Tables[0].Rows[j][
                                                                                       "WriteAnswer"].ToString().IndexOf
                                                                                       (",."));
            }
        }
        int sumHeight = 20 * ((PLength / PCount) + (PLength % PCount > 0 ? 1 : 0)) + 5;
        if (BodyHeight + sumHeight + 80 > 1100)
        {
            PageChange();
        }
        BodyHeight = BodyHeight + sumHeight + 80;
        ph.Controls.Add(lblTemp1);
        ph.Controls.Add(tb);
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='5'></td></tr></table>";
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
        lblTemp1.Text = "<table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='White' class='main-text'><tr  height='20'><td class='main-text'valign='top' align='left' style='white-space:normal; word-break:break-all;'>" + dr["ProblemContent"].ToString();

        int PLength = dr["ProblemContent"].ToString().Length;
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
            if (i > 0)
            {
                BodyHeight += 20 * ((PLength / PCount) + (PLength % PCount > 0 ? 1 : 0)) + 10;
                PLength = 0;
                if (BodyHeight + 60 > 1100)
                {
                    PageChange(1);
                }
            }
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
                        tb1.CssClass = "inputline-Print2";
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
                        PLength += 6;
                    }
                }
                else
                {
                    Label lbl1 = new Label();
                    lbl1.Text = strBuf[j];
                    ph.Controls.Add(lbl1);

                    PLength += lbl1.Text.Length;
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
            PLength += 2;
        }
        BodyHeight += 5;
        Label lblTemp2 = new Label();
        lblTemp2.Text = "</td></tr><tr><td height='5'></td></tr></table>";
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
        lblTemp1.Text = "<table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0' style='border-color:black'  bgcolor='White' class='main-text'><tr  height='20'><td class='main-text'valign='top' align='left' style='white-space:normal; word-break:break-all;'>" + dr["ProblemContent"].ToString();

        int PLength = dr["ProblemContent"].ToString().Length;
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
            if (i > 0)
            {
                BodyHeight += 20 * ((PLength / PCount) + (PLength % PCount > 0 ? 1 : 0)) + 10;
                PLength = 0;
                if (BodyHeight + 60 > 1100)
                {
                    PageChange(1);
                }
            }
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
                        tb1.CssClass = "inputline-Print2";
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
                        PLength += 6;
                    }
                }
                else
                {
                    Label lbl1 = new Label();
                    lbl1.Text = strBuf[j];
                    ph.Controls.Add(lbl1);

                    PLength += lbl1.Text.Length;
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
        BodyHeight += 5;
        lblTemp2.Text = "</td></tr><tr><td height='5'></td></tr></table>";
        ph.Controls.Add(lblTemp2);
        return sum;
    }
    #endregion

}
