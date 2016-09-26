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

public partial class Cert_testPrint : SZMA.Core.Client.BasePageByPage
{
    protected int Totle;
    protected void Page_Load(object sender, EventArgs e)
    {
        PageTitle = "申请书打印";
        if (null != Request.QueryString["id"] && Request.QueryString["id"] != "")
        {
            lblID.Text = Request.QueryString["id"];
            Data_Init();
        }
    }
    private void Data_Init()
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;
            DataSet ds =
               Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + MID + "'",
                            out recc);
            if (recc < 1)
                return;
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtAnum.Text = ds.Tables[0].Rows[0]["Anum"].ToString();
            txtArea.Text = ds.Tables[0].Rows[0]["Area"].ToString();
            txtBnum.Text = ds.Tables[0].Rows[0]["Bnum"].ToString();
            txtCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
            txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
            txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtFrdb.Text = ds.Tables[0].Rows[0]["Frdb"].ToString();
            txtFtel.Text = ds.Tables[0].Rows[0]["Ftel"].ToString();
            txtMnum.Text = ds.Tables[0].Rows[0]["Mnum"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtSummary.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
            Totle = ds.Tables[0].Rows[0]["type"].ToString() == "1" ? 780 : 960;
            PH_Init();
            lblNO.Text = getMainNO(ds.Tables[0].Rows[0]["ID"].ToString(), ds.Tables[0].Rows[0]["type"].ToString());
            lblApplyName.Text = ds.Tables[0].Rows[0]["type"].ToString() == "1" ? "申请表" : "晋级申请表";
            pnlSummary.Visible = (ds.Tables[0].Rows[0]["type"].ToString() == "2");
        }
    }

    private void PH_Init()
    {
        int Height = 0;
        Height = phListData_Init(Height);
        Height = phOperationData_Init(Height);
        Height=phMemployeeData_Init(Height);
        Height=phWemployeeData_Init(Height);
        Height=phEListData_Init(Height);
        Height=phCSFileData_init(Height);
    }



    protected int phMemployeeData_Init(int Height)
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;
            DataSet dsMemployee =
                Common.Pager("employee", "ID,Name,educational,Eposition,certName,remark", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                             out recc);
            if (dsMemployee.Tables[0].Rows.Count < 1)
            {
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsMemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
            }


            Literal ltl = new Literal();
            ltl.Text = "<tr><td valign='top'>  <TABLE  width='850' border='1'style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'> ";


            if (PageNext(ref Height, ltl,80))
            {
            }
            Height = Height - 40;
            ltl.Text += "<tr height='40'><td align='center' width='150' rowspan='" + (dsMemployee.Tables[0].Rows.Count + 1) + "'>管理人员/专业技术人员状况</td>";
            ltl.Text += @"<td  align='center' width='100'>姓名</td><td align='center'  width='80'>学历</td><td align='center'  width='150'>岗位</td>
            <td align='center'  width='220'>持有证书名称</td><td align='center'  width='150'>备注</td> </tr>";

            
            for (int i = 0; i < dsMemployee.Tables[0].Rows.Count; i++)
            {

                if (PageNext(ref Height, ltl,40))
                {
                    Height += 40;
                    ltl.Text += "<tr height='40'><td align='center' width='150' rowspan='" + (dsMemployee.Tables[0].Rows.Count-i + 1) + "'>管理人员/专业技术人员状况</td>";
                    ltl.Text += @"<td  align='center' width='100'>姓名</td><td align='center'  width='80'>学历</td><td align='center'  width='150'>岗位</td>
                    <td align='center'  width='220'>持有证书名称</td><td align='center'  width='150'>备注</td> </tr>";
                }
                
                ltl.Text += "    <tr height='40'>";
                ltl.Text += "   <td  align='center'>" + dsMemployee.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsMemployee.Tables[0].Rows[i]["educational"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsMemployee.Tables[0].Rows[i]["Eposition"].ToString() + "</td>";
                DataSet ds =
               Common.Pager("employee", "ID,CertType,(select CertName from Dict_Cert where ID=employee.CertType) as Name", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                            out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[i]["CertType"].ToString() == "0")
                    {
                        ltl.Text += "<td align='left'>" + dsMemployee.Tables[0].Rows[i]["certName"].ToString() + "</td>";
                    }
                    else
                    {
                        ltl.Text += "<td align='left'>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                    }
                }
                ltl.Text += "<td align='left'>" + dsMemployee.Tables[0].Rows[i]["remark"].ToString() + "</td></tr>";

            }
            ltl.Text += "</TABLE></td></tr>";
            if (!PageNext(ref Height, ltl, 20))
                ltl.Text += "<tr height='20'><td> &nbsp;</td></tr>";

            phMemployee.Controls.Add(ltl);
        }
        return Height;
    }

    protected int phWemployeeData_Init(int Height)
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsWemployee =
                Common.Pager("employee", "ID,Name,educational,Eposition,certName,remark", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                             out recc);
            if (dsWemployee.Tables[0].Rows.Count < 1)
            {
                dsWemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsWemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsWemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsWemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
                dsWemployee.Tables[0].Rows.Add(new string[] { "0", "", "", "", "", "" });
            }


            Literal ltl = new Literal();
            ltl.Text = " <tr><td valign='top'><TABLE  width='850' border='1'style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'> ";


            if (PageNext(ref Height, ltl, 80))
            {
            }
            Height = Height - 40;
            ltl.Text += "<tr height='40'><td align='center' width='150' rowspan='" + (dsWemployee.Tables[0].Rows.Count + 1) + "'>安装/维修人员状况</td>";
            ltl.Text += @"<td  align='center' width='100'>姓名</td><td align='center'  width='80'>学历</td><td align='center'  width='150'>岗位</td>
            <td align='center'  width='220'>持有证书名称</td><td align='center'  width='150'>备注</td> </tr>";

            for (int i = 0; i < dsWemployee.Tables[0].Rows.Count; i++)
            {

                if (PageNext(ref Height, ltl, 40))
                {
                    Height += 40;
                    ltl.Text += "<tr height='40'><td align='center' width='150' rowspan='" + (dsWemployee.Tables[0].Rows.Count-i + 1) + "'>安装/维修人员状况</td>";
                    ltl.Text += @"<td  align='center' width='100'>姓名</td><td align='center'  width='80'>学历</td><td align='center'  width='150'>岗位</td>
                       <td align='center'  width='220'>持有证书名称</td><td align='center'  width='150'>备注</td> </tr>";
                }
                ltl.Text += "    <tr height='40'>";
                ltl.Text += "   <td  align='center'>" + dsWemployee.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsWemployee.Tables[0].Rows[i]["educational"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsWemployee.Tables[0].Rows[i]["Eposition"].ToString() + "</td>";
                DataSet ds =
              Common.Pager("employee", "ID,CertType,(select CertName from Dict_Cert where ID=employee.CertType) as Name", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                           out recc);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[i]["CertType"].ToString() == "0")
                    {
                        ltl.Text += "<td align='left'>" + dsWemployee.Tables[0].Rows[i]["certName"].ToString() + "</td>";
                    }
                    else
                    {
                        ltl.Text += "<td align='left'>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                    }
                }
                //ltl.Text += "<td align='left'>" + dsWemployee.Tables[0].Rows[i]["certName"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsWemployee.Tables[0].Rows[i]["remark"].ToString() + "</td></tr>";

            }
            ltl.Text += "</TABLE></td></tr>";
            if (!PageNext(ref Height, ltl, 20))
            ltl.Text += "<tr height='20' ><td> &nbsp;</td></tr>";

            phWemployee.Controls.Add(ltl);
        }
        return Height;
    }
    protected int phEListData_Init(int Height)
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsElist2 =
                Common.Pager("equipment", "ID,Model,Num,des,MainSCID", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=2 and InsertFlag=1",
                             out recc);
            if (dsElist2.Tables[0].Rows.Count < 1)
            {
                dsElist2.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
                dsElist2.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
                dsElist2.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
                dsElist2.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
                dsElist2.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }

            DataSet dsElist1 =
             Common.Pager("equipment", "ID,Model,Num,des,MainSCID", "ID", 100, 1, false, "MainSCID='" + MID + "' and Type=1 and InsertFlag=1",
                          out recc);
            if (dsElist1.Tables[0].Rows.Count < 1)
            {
                dsElist1.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
                dsElist1.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
                dsElist1.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }

            Literal ltl = new Literal();
            ltl.Text = " <tr><td valign='top'> <TABLE  width='850' border='1'style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'> ";

            if (PageNext(ref Height, ltl, 80))
            {
            }
            Height = Height - 40;
            ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (dsElist1.Tables[0].Rows.Count + dsElist2.Tables[0].Rows.Count + 1) + "'>维修安装作业设备</td>";
            ltl.Text += "    <td align='center' width='100' valign='middle' rowspan='" + (dsElist1.Tables[0].Rows.Count + 1) + "'>交通工具</td>";
            ltl.Text += "  <td align='center'  width='250'>名称</td><td align='center'  width='250'>型号</td><td align='center'  width='100'>数量</td></tr>";

            for (int i = 0; i < dsElist1.Tables[0].Rows.Count; i++)
            {

                if (PageNext(ref Height, ltl, 40))
                {
                    Height += 40;
                    ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (dsElist1.Tables[0].Rows.Count + dsElist2.Tables[0].Rows.Count-i + 1) + "'>维修安装作业设备</td>";
                    ltl.Text += "    <td align='center' width='100' valign='middle' rowspan='" + (dsElist1.Tables[0].Rows.Count - i + 1) + "'>交通工具</td>";
                    ltl.Text += "  <td align='center'  width='250'>名称</td><td align='center'  width='250'>型号</td><td align='center'  width='100'>数量</td></tr>";
                }
                ltl.Text += "    <tr height='40'>";
                ltl.Text += "<td align='left'>" + dsElist1.Tables[0].Rows[i]["des"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsElist1.Tables[0].Rows[i]["Model"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsElist1.Tables[0].Rows[i]["Num"].ToString() + "</td></tr>";

            }
            int dsElist2i = 0;
            if (PageNext(ref Height, ltl, 40))
            {
                ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (dsElist2.Tables[0].Rows.Count + 1) + "'>维修安装作业设备</td>";
                ltl.Text += "    <td align='center' width='100' valign='middle' rowspan='" + (dsElist2.Tables[0].Rows.Count + 1) + "'>其它仪器设备</td>";
                ltl.Text += "  <td align='center'  width='250'>名称</td><td align='center'  width='250'>型号</td><td align='center'  width='100'>数量</td></tr>";
                dsElist2i = 0;
            }
            else
            {
                ltl.Text += "    <tr height='40'><td align='center' width='100' valign='middle' rowspan='" + (dsElist2.Tables[0].Rows.Count) + "'>其它仪器设备</td>";
                ltl.Text += "<td align='left'>" + dsElist2.Tables[0].Rows[0]["des"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsElist2.Tables[0].Rows[0]["Model"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsElist2.Tables[0].Rows[0]["Num"].ToString() + "</td></tr>";
                dsElist2i = 1;
            }
            for (int i=dsElist2i; i < dsElist2.Tables[0].Rows.Count; i++)
            {

                if (PageNext(ref Height, ltl, 40))
                {
                    Height += 40;
                    ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (dsElist2.Tables[0].Rows.Count-i + 1) + "'>维修安装作业设备</td>";
                    ltl.Text += "    <td align='center' width='100' valign='middle' rowspan='" + (dsElist2.Tables[0].Rows.Count-i + 1) + "'>其它仪器设备</td>";
                    ltl.Text += "  <td align='center'  width='250'>名称</td><td align='center'  width='250'>型号</td><td align='center'  width='100'>数量</td></tr>";
                }
                ltl.Text += "    <tr height='40'>";
                ltl.Text += "<td align='left'>" + dsElist2.Tables[0].Rows[i]["des"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsElist2.Tables[0].Rows[i]["Model"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsElist2.Tables[0].Rows[i]["Num"].ToString() + "</td></tr>";

            }
            ltl.Text += " </TABLE></td></tr>";

            if (!PageNext(ref Height, ltl, 20))
            ltl.Text += "<tr height='20'><td> &nbsp;</td></tr>";

            phEList.Controls.Add(ltl);
        }
        return Height;
    }

    protected int phCSFileData_init(int Height)
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name,CSFileDict.ID as cID", "cID", 100, 1, false, "CSlist.MainSCID='" + MID + "' and CSlist.CSFileID=CSFileDict.ID ",
                                            out recc);
            if (dsCSFile.Tables[0].Rows.Count < 1)
            {
                dsCSFile.Tables[0].Rows.Add(new string[] { "0", "", "", "0" });
            }

            Literal ltl = new Literal();
            ltl.Text = "  <tr><td valign='top'><TABLE  width='850' border='1'style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'> ";

            if (PageNext(ref Height, ltl, 80))
            {
            }
            Height = Height - 40;
            ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (dsCSFile.Tables[0].Rows.Count + 1) + "'>送审资料</td>";
            ltl.Text += "   <td  align='center' width='60'>序号</td><td align='center'  width='540'>目录</td><td align='center'  width='100'>份数</td></tr>";

            for (int i = 0; i < dsCSFile.Tables[0].Rows.Count; i++)
            {

                if (PageNext(ref Height, ltl, 40))
                {
                    Height += 40;
                    ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (dsCSFile.Tables[0].Rows.Count-i + 1) + "'>送审资料</td>";
                    ltl.Text += "   <td  align='center' width='60'>序号</td><td align='center'  width='540'>目录</td><td align='center'  width='100'>份数</td></tr>";
                }
                ltl.Text += "    <tr height='40'>";
                ltl.Text += "   <td  align='center'>" + (i + 1) + "</td>";
                ltl.Text += "<td align='left'>" + dsCSFile.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                ltl.Text += "<td align='left'>" + dsCSFile.Tables[0].Rows[i]["Num"].ToString() + "</td></tr>";

            }
            ltl.Text += "</TABLE></td></tr>";
            if (!PageNext(ref Height, ltl, 20))
                ltl.Text += "<tr height='20'><td> &nbsp;</td></tr>";
            phCSFile.Controls.Add(ltl);
        }
        return Height;
    }

    protected int phListData_Init(int Height)
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet ds =
                Common.Pager("Operation", "ID,SortID,brand,Content,MainSCID,(select EN_Name+'['+CN_Name+']' from dict_product where ID=Operation.SortID) as SortName,(select Name from dict_brand where ID=Operation.brand) as brandName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                             out recc);
            if (ds.Tables[0].Rows.Count < 1)
            {
                pnlOperation.Visible = false;
                return Height;
            }
            Literal ltl=new Literal();
            ltl.Text = "<tr><td valign='top'>  <TABLE  width='850' border='1' style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'> ";


             if (PageNext(ref Height, ltl, 80))
             {
             }
             Height = Height - 40;
            ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (ds.Tables[0].Rows.Count + 1) + "'>特约维修业务</td>";
            ltl.Text += "   <td  align='center' width='50'>序号</td><td align='center'  width='450'>类别</td><td align='center'  width='200'>品牌</td></tr>";

           for(int i=0;i<ds.Tables[0].Rows.Count;i++)
           {

               if (PageNext(ref Height, ltl, 40))
               {
                   Height += 40;
                   ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (ds.Tables[0].Rows.Count + 1) + "'>特约维修业务</td>";
                   ltl.Text += "   <td  align='center' width='50'>序号</td><td align='center'  width='450'>类别</td><td align='center'  width='200'>品牌</td></tr>";
               }
               ltl.Text += "    <tr height='40'>";
               ltl.Text += "   <td  align='center'>" + (i + 1) + "</td>";
               ltl.Text += "<td align='left'>" + ds.Tables[0].Rows[i]["SortName"].ToString() + "</td>";
               ltl.Text += "<td align='left'>" + ds.Tables[0].Rows[i]["brandName"].ToString() + "</td></tr>";

           }
           ltl.Text += "</TABLE></td></tr>";

           if (!PageNext(ref Height, ltl, 20))
           ltl.Text += "<tr height='20'><td> &nbsp;</td></tr>";

           phList.Controls.Add(ltl);
        }
        return Height;
    }


    protected int phOperationData_Init(int Height)
    {
        if (lblID.Text != "")
        {
            string MID = lblID.Text;
            int recc;

            DataSet ds =
                Common.Pager("OperationMain", "ID,MainSCID,(select EN_Name+'['+CN_Name+']' from dict_product where ID=OperationMain.ProductID) as SortName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                             out recc);
            if (ds.Tables[0].Rows.Count < 1)
            {
                pnlOperation.Visible = false;
                return Height;
            }
            Literal ltl = new Literal();
            ltl.Text = "<tr><td valign='top'>  <TABLE  width='850' border='1' style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'> ";


            if (PageNext(ref Height, ltl, 80))
            {
            }
            Height = Height - 40;
            ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (ds.Tables[0].Rows.Count + 1) + "'>维修范围</td>";
            ltl.Text += "   <td  align='center' width='50'>序号</td><td align='center'  width='650'>类别</td></tr>";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (PageNext(ref Height, ltl, 40))
                {
                    Height += 40;
                    ltl.Text += "    <tr height='40'><td align='center' width='150' rowspan='" + (ds.Tables[0].Rows.Count + 1) + "'>维修范围</td>";
                    ltl.Text += "   <td  align='center' width='50'>序号</td><td align='center'  width='650'>类别</td></tr>";
                }
                ltl.Text += "    <tr height='40'>";
                ltl.Text += "   <td  align='center'>" + (i + 1) + "</td>";
                DataSet dst =
                Common.Pager("OperationMain", "ID,MainSCID,ProductID,(select operation from MainSCTemp where ID=OperationMain.MainSCID) as OperationName", "ID", 100, 1, false, "MainSCID='" + MID + "'",
                            out recc);
                if (dst.Tables[0].Rows[i]["ProductID"].ToString() == "0")
                {
                    ltl.Text += "<td align='left'>" + dst.Tables[0].Rows[i]["OperationName"].ToString() + "</td></tr>";
                }
                else
                {
                    ltl.Text += "<td align='left'>" + ds.Tables[0].Rows[i]["SortName"].ToString() + "</td></tr>";
                }
            }
            ltl.Text += "</TABLE></td></tr>";

            if (!PageNext(ref Height, ltl, 20))
                ltl.Text += "<tr height='20'><td> &nbsp;</td></tr>";

            phOperation.Controls.Add(ltl);
        }
        return Height;
    }
    protected bool PageNext(ref int Height,Literal ltl,int AddHegiht)
    {
        if (Height + AddHegiht > Totle)
        {
            ltl.Text += @"</TABLE><table border='0' cellpadding='0' cellspacing='0' class='PageNext'></table>
                        <TABLE  width='850' border='1' style='background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;' cellpadding='0' cellspacing='0' class='Print-text2'>";
            Height = AddHegiht;
            Totle = 960;
            return true;
        }
        else
        {
            Height += AddHegiht;
            return false;
        }
    }
    
}
