<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lastApproveDetail.aspx.cs" Inherits="workaround_lastApproveDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
 
 <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">      
          <tr> 
          <td colspan="3">&nbsp;</td>
            
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">报批申请明细</asp:Label><asp:Label runat="server" ID="lblNumNo"></asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
        <tr> 
          <td colspan="3">
      
      
       
            <table border="0" cellpadding="0" cellspacing="0"  bgColor="#f5f5f1" width="100%" class="main-text">
            <tr>
                <td width="10%" bgcolor="#F0EEE9">
                    初审记录</td>
                <td width="90%" colspan="3">
                    <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' style='
                        word-break: break-all; ' class='main-text'>
                        <tr height="30">
                            <td width="100">
                                企业名称：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtCompany" Width="200" CssClass="inputline-Print3"> 深圳市商业有限公司 </asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30">
                            <td width="100">
                                申请书编号：
                            </td>
                            <td>
                                <asp:CheckBox ID="chkF" TextAlign="Right" runat="server" />申<asp:TextBox runat="server"
                                    ID="txtMainNO" Width="100" CssClass="inputline-Print3"></asp:TextBox>
                                &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="chkS" TextAlign="Right" runat="server" />晋<asp:TextBox
                                    runat="server" ID="txtMainNO1" Width="100" CssClass="inputline-Print3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="100">
                            <td width="100">
                                维修范围：
                            </td>
                            <td>
                                <asp:DataList runat="server" ID="dtOperation" BorderWidth="0" CellPadding="0" CellSpacing="0"
                                    RepeatColumns="4" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkOp" Checked='<%# ((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"%> '
                                            CssClass="main-text" Text='<%# ((System.Data.DataRowView)Container.DataItem)["Name"] %>' />
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr height="30">
                            <td width="100">
                                初审结果：
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReslt" TextAlign="Right" Text="合格" runat="server" />
                                <asp:CheckBox ID="chkReslt1" TextAlign="Right" Text="不合格" runat="server" />
                            </td>
                        </tr>
                        <tr height="30">
                            <td width="100">
                                评审员：
                            </td>
                            <td>
                                <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='main-text'>
                                    <tr>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblsyndicer"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" ID="lblFistDate">
                              年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日
                                            </asp:Label>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="230">
                <td width="10%" bgcolor="#F0EEE9">
                    拟参加评审专家组成员
                </td>
                <td width="43%" colspan="3">
                    <table width='100%' height="230"  border='0' align='center' cellpadding='0' cellspacing='0' style='word-break: break-all; ' class='main-text'>
                        <tr height="50">
                            <td align="left">
                                &nbsp;评审组长：<asp:Label runat="server" ID="lblSLeader" CssClass="main-text"></asp:Label><br />
                            </td>
                        </tr>
                        <tr height="100">
                            <td align="left">
                                &nbsp;评审组员：<asp:Label runat="server" ID="lblS" CssClass="main-text"></asp:Label><br />
                            </td>
                        </tr>
                        <tr height="50">
                            <td align="left">
                                &nbsp;盖章：<br />
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                年&nbsp;&nbsp;月&nbsp;&nbsp;日</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="400">
            <td bgcolor="#F0EEE9">评审组意见及结论</td>
            <td colspan="3">
             <table width='100%' height="330"  border='0' align='center' cellpadding='0' cellspacing='0' style='
                        word-break: break-all; ' class='main-text'>
                        <tr  height="270" ><td valign="top" align="left"><br /> &nbsp; &nbsp;<asp:Label CssClass='main-text' runat="server" ID="lblSyndicResult"></asp:Label>
                        &nbsp;</td></tr>
                         <tr height="30">
                            <td align="left" valign="bottom">
                                &nbsp;结论：该企业评定为 <asp:TextBox runat="server" ID="txtCertLv" Width="30" CssClass="inputline-Print3"></asp:TextBox>维修技术等级。
                            </td>
                        </tr>
                        <tr height="30">
                        <td align="left" valign="bottom">&nbsp;评审组成员签名：<asp:Label CssClass='main-text' runat="server" ID="lblSyndicors"></asp:Label></td>
                            <td align="right" valign="bottom">
                                年&nbsp;&nbsp;月&nbsp;&nbsp;日</td>
             </table>
            </td>
            </tr>
            <tr  height="200">
            <td align="center" width="10%" bgcolor="#F0EEE9">认监处承办人意见</td>
            <td align="left"  width="90%">
            
             <table width='100%'  height="200"  border='0' align='center' cellpadding='0' cellspacing='0' style='
                        word-break: break-all; ' class='main-text'>
                        <tr><td colspan="2" align="left" valign="top"><asp:Label ID="lblPsuggest" runat="server" ></asp:Label></td></tr>
                        <tr><td align="left" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;签名：<asp:Label ID="lblPromoter" runat="server" ></asp:Label></td>
                        <td align="right" valign="bottom"><asp:Label ID="lblPTime" runat="server" CssClass="main-text">年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</asp:Label></td></tr>
              </table>
            </td>
            </tr>
             <tr height="200">
            <td align="center" bgcolor="#F0EEE9">认监处意见</td>
            <td align="left">
            
             <table width='100%'  height="200"  border='0' align='center' cellpadding='0' cellspacing='0' style='
                        word-break: break-all; ' class='main-text'>
                        <tr><td colspan="2" align="left" valign="top"><br />&nbsp;&nbsp;<asp:Label ID="lblSsuggest" CssClass="main-text" runat="server" ></asp:Label></td></tr>
                        <tr><td align="left" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;签名：<asp:Label ID="lblSuperintendent" runat="server" CssClass="main-text"></asp:Label></td>
                        <td align="right" valign="bottom"><asp:Label ID="lblSTime" runat="server" CssClass="main-text">年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</asp:Label></td></tr>
              </table>
            </td>
            </tr>
             <tr height="200">
            <td align="center" bgcolor="#F0EEE9">局领导意见</td>
            <td align="left">
                  <table width='100%'  height="200"  border='0' align='center' cellpadding='0' cellspacing='0' style='
                        word-break: break-all; ' class='main-text'>
                        <tr><td colspan="2" align="left" valign="top"><br />&nbsp;&nbsp;<asp:Label ID="lblLsuggest" CssClass="main-text" runat="server" ></asp:Label></td></tr>
                        <tr><td align="left" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;签名：<asp:Label ID="lblLeader" runat="server" CssClass="main-text"></asp:Label></td>
                        <td align="right" valign="bottom"><asp:Label ID="lblLTime" runat="server" CssClass="main-text">年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</asp:Label></td></tr>
              </table>
            </td>
            </tr>
             <tr height="300">
            <td align="center" bgcolor="#F0EEE9">备注</td>
            <td align="left"><br />&nbsp;&nbsp;<asp:Label CssClass="main-text" ID="lblRemark" runat="server" ></asp:Label></td>
            </tr>
            </table>         
      
      
            </td>
            </tr>           
              <tr> 
                <td height="6"></td>
                <td height="6"></td>
                <td height="6"></td>
              </tr>
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>
              <tr> 
                <td colspan="3"></td>
              </tr>
            </table>    
   
    </td>
  </tr>
</table>     
           
</form>
</body>
</html>
