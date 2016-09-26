<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lastApprove_Print.aspx.cs"
    Inherits="workaround_lastApprove_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印审批表</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
    <style media="print">  
/*
* @breif: 用本样式在打印时隐藏非打印项目
*/
.Noprint
{
 display:none;
}
/*
* @breif: 控制分页
*/
.PageNext
{
 page-break-after: always;
}
</style>

    <script language="javascript">
var HKEY_root,HKEY_Path,HKEY_Key; 
HKEY_Root="HKEY_CURRENT_USER"; 
HKEY_Path="\\Software\\microsoft\\Internet Explorer\\PageSetup\\"; 
//设置网页打印的页眉页脚为空 
function PageSetup_Null() 
{ 
try
{
  document.all.factory.printing.portrait = true;
}
catch(e)
{
 alert(e.message)
}
 try 
 { 
  var Wsh=new ActiveXObject("WScript.shell"); 
  HKEY_Key="header"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,""); 
  HKEY_Key="footer"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,""); 
 } 
 catch(e)
 {
  alert(e.message);
 } 
} 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
            
            <tr><td colspan="3" align="center" class="Print-bt"  > <br/>
                    《维修企业技术等级证书》发放审批表<br/>
                    </td>
            </tr>
            <tr>
                <td colspan="3" align="right" class='Print-text'>
                    编号：<font style="font-size: 13; font-weight: bold;"><asp:Label runat="server" ID="lblAPPNO"></asp:Label></font></td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                 <span class="Noprint"><a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)"
                        style="cursor: hand">〖打 印〗</a>&nbsp;<a style="cursor: hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预
                            览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)"
                                style="cursor: hand">〖打印设置〗</a></span>
                </td>
            </tr>
        </table>
           
        <table width='96%' border='1' align='center' cellpadding='0' cellspacing='1' style='white-space: normal;
            word-break: break-all; background-color: White; border-width: 1px; border-style: Solid;
            border-color: Black; border-collapse: collapse; page-break-after: always;' class='Print-text'>
            <tr>
                <td width="10%">
                    初审记录</td>
                <td width="90%" colspan="3">
                    <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr height="30">
                            <td width="100">
                                企业名称：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtCompany" Width="200" CssClass="inputline-Print2"> 深圳市商业有限公司 </asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30">
                            <td width="100">
                                申请书编号：
                            </td>
                            <td>
                                <asp:CheckBox ID="chkF" TextAlign="Right" runat="server" />申<asp:TextBox runat="server"
                                    ID="txtMainNO" Width="100" CssClass="inputline-Print2"></asp:TextBox>
                                &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="chkS" TextAlign="Right" runat="server" />晋<asp:TextBox
                                    runat="server" ID="txtMainNO1" Width="100" CssClass="inputline-Print2"></asp:TextBox>
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
                                            CssClass="Print-text" Text='<%# ((System.Data.DataRowView)Container.DataItem)["Name"] %>' />
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
                                <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='Print-text'>
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
                <td width="10%">
                    拟参加评审专家组成员
                </td>
                <td width="43%">
                    <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr height="50">
                            <td align="left">
                                &nbsp;评审组长：<asp:Label runat="server" ID="lblLeader" CssClass="Print-text"></asp:Label><br />
                            </td>
                        </tr>
                        <tr height="100">
                            <td align="left">
                                &nbsp;评审组员：<asp:Label runat="server" ID="lblS" CssClass="Print-text"></asp:Label><br />
                            </td>
                        </tr>
                        <tr height="50">
                            <td align="left">
                                &nbsp;盖章：<br />
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td>
                        </tr>
                    </table>
                </td>
                <td width="4%">
                    认监处确认</td>
                <td align="left" width="43%">
                    <table width='100%' height="230"  border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr><td>&nbsp;</td></tr>
                        <tr height="100">
                            <td align="left" valign="bottom">
                                &nbsp;签名：<asp:Label runat="server" ID="lblConfirm" CssClass="Print-text"></asp:Label><br />
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right" valign="bottom">
                                年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="400">
            <td>评审组意见及结论</td>
            <td colspan="3">
             <table width='100%' height="330"  border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr  height="270" ><td valign="top" align="left"><br /> &nbsp; &nbsp;<asp:Label CssClass='Print-text' runat="server" ID="lblSyndicResult"></asp:Label>
                        &nbsp;</td></tr>
                         <tr height="30">
                            <td align="left" valign="bottom">
                                &nbsp;结论：该企业评定为 <asp:TextBox runat="server" ID="txtCertLv" Width="30" CssClass="inputline-Print2"></asp:TextBox>维修技术等级。
                            </td>
                        </tr>
                        <tr height="30">
                        <td align="left" valign="bottom">&nbsp;评审组成员签名：<asp:Label CssClass='Print-text' runat="server" ID="lblSyndicors"></asp:Label></td>
                            <td align="right" valign="bottom">
                                年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td>
             </table>
            </td>
            </tr>
        </table>
        <table width='96%' border='1' align='center' cellpadding='0' cellspacing='1' style='white-space: normal;
            word-break: break-all; background-color: White; border-width: 1px; border-style: Solid;
            border-color: Black; border-collapse: collapse; ' class='Print-text'>
            <tr  height="200">
            <td align="center" width="10%">认监处承办人意见</td>
            <td align="left"  width="90%">
            
             <table width='100%'  height="200"  border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr><td colspan="2" align="left" valign="top"><asp:Label ID="lblPsuggest" runat="server" ></asp:Label></td></tr>
                        <tr><td align="left" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;签名：<asp:Label ID="lblPromoter" runat="server" ></asp:Label></td>
                        <td align="right" valign="bottom">年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td></tr>
              </table>
            </td>
            </tr>
             <tr height="200">
            <td align="center" >认监处意见</td>
            <td align="left">
            
             <table width='100%'  height="200"  border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr><td colspan="2" align="left" valign="top"><br />&nbsp;&nbsp;<asp:Label ID="lblSsuggest" CssClass="Print-text" runat="server" ></asp:Label></td></tr>
                        <tr><td align="left" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;签名：</td>
                        <td align="right" valign="bottom">年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td></tr>
              </table>
            </td>
            </tr>
             <tr height="200">
            <td align="center" >局领导意见</td>
            <td align="left">
                  <table width='100%'  height="200"  border='0' align='center' cellpadding='0' cellspacing='0' style='white-space: normal;
                        word-break: break-all; background-color: White; border-width: 0px;' class='Print-text'>
                        <tr><td colspan="2" align="left" valign="top"><br />&nbsp;&nbsp;<asp:Label ID="lblLsuggest" CssClass="Print-text" runat="server" ></asp:Label></td></tr>
                        <tr><td align="left" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;签名：</td>
                        <td align="right" valign="bottom">年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td></tr>
              </table>
            </td>
            </tr>
             <tr height="300">
            <td align="center" >备注</td>
            <td align="left"><br />&nbsp;&nbsp;<asp:Label CssClass="Print-text" ID="lblRemark" runat="server" ></asp:Label></td>
            </tr>
            </table>
        <object id="factory" viewastext name="factory" style="display: none; width: 1px;
            height: 1px" codebase="../scriptx/smsx.cab#Version=6,3,436,14" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">
        </object>
        <object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">
            <param name="Offline" value="0" />
        </object>
    </form>
</body>
</html>
