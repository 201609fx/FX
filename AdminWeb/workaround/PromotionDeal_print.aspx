<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionDeal_print.aspx.cs" Inherits="workaround_PromotionDeal_print" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
        <style media=print>  
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
  document.all.factory.printing.portrait = true;

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

       <tr><td colspan="3" align="center" class="Print-bt"><br/>  <asp:Label runat="server" ID="lblTitle" CssClass="Print-bt">晋级材料处理通知书</asp:Label><br/></td></tr>
       <tr height="20"><td colspan="3" align="right">
        <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
  </td></tr>
       </table>       
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">  
        <tr> 
          <td colspan="3" align="center">
      
          <TABLE cellSpacing="0" cellPadding="0" bgcolor="black" width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" class="Print-Main1"> 
      
    <tr height="40">
        <td class="Print-Main1" bgColor="white" align="left">
            企业名称</td>
        <td bgColor="white" align="left" colspan="5">
        <asp:Label runat="server" ID="lblCompany" CssClass="Print-Main1"></asp:Label>&nbsp;
        </td>
    </tr>
    
    <tr height="40">
        <td class="Print-Main1" bgColor="white" align="left">
            企业地址</td>
        <td bgColor="white" align="left" colspan="5">
        <asp:Label runat="server" ID="lblAddress" CssClass="Print-Main1"></asp:Label>&nbsp;
        </td>
    </tr>
    <tr height="40">
      <td class="Print-Main1" bgColor="white" align="left" width="20%">
            联系电话</td>
        <td bgColor="white" align="center" width="25%">
               <asp:Label runat="server" ID="lblTel" CssClass="Print-Main1"></asp:Label>&nbsp;   
        </td>
        <td class="Print-Main1" bgColor="white" align="center" width="20%">
            联系人</td>
        <td bgColor="white" align="center" width="35%">
         <asp:Label runat="server" ID="lblcontact" CssClass="Print-Main1"></asp:Label>&nbsp;   
                 
        </td>
    </tr> 
   
     <tr height="40">
      <td class="Print-Main1" bgColor="white" align="left">
           企业等级证书号</td>
        <td bgColor="white" align="center" >
               <asp:Label runat="server" ID="lblOldCertNO" CssClass="Print-Main1"></asp:Label>&nbsp;    
        </td>
          <td class="Print-Main1" bgColor="white" align="center">
           企业技术等级</td>
        <td bgColor="white" align="center" colspan="3">
               <asp:Label runat="server" ID="lblLevel" CssClass="Print-Main1"></asp:Label>&nbsp;   
        </td>
    </tr> 
       <tr height="40">
      <td class="Print-Main1" bgColor="white" align="left">
           现场评审日期</td>
        <td bgColor="white" align="center" >
               <asp:Label runat="server" ID="lblPSTime" CssClass="Print-Main1"></asp:Label>&nbsp;    
        </td>
          <td class="Print-Main1" bgColor="white" align="center">
           评审人员</td>
        <td bgColor="white" align="center" colspan="3">
               <asp:Label runat="server" ID="LblPS" CssClass="Print-Main1"></asp:Label>&nbsp;   
        </td>
    </tr> 
    <tr height="300">    
        <td class="Print-Main1" bgColor="white" align="right" colspan="6">&nbsp;
            <table border="0" cellpadding="0" cellspacing="0"  bgColor="white" width="100%" class="Print-Main1">
            <tr  bgColor="white" height="50">
            <td align="left" colspan="2">&nbsp;现场评审结论:</td>
            </tr>
            <tr  bgColor="white" height="190" >
            <td width="20"></td>
            <td align="left" valign="top"><asp:Label runat="server" ID="txtResult"></asp:Label>              
            </td>
            </tr>
            <tr bgColor="white" height="30" >
            <td align="right" colspan="2">  
                  签名:<asp:TextBox runat="server" ID="txtLeader"  Width="120" CssClass="inputline-Print">  </asp:TextBox>
            </td>
            </tr>
            <tr bgColor="white" height="30">
             <td align="right" colspan="2">  
                  日期:<asp:TextBox runat="server" ID="dpLTime"  Width="120" CssClass="inputline-Print">  </asp:TextBox>
            </td>
            </tr>
            </table>                  
        </td>
    </tr>
     
</TABLE>       
 </td>
            </tr>
                 <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="../scriptx/smsx.cab#Version=6,3,436,14" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
  </OBJECT>
                          <object  id="WebBrowser"  width="0"  height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
 <PARAM NAME="Offline" VALUE="0">
</object>
           <tr bgcolor="white"> 
                <td height="6"></td>
                <td height="6"></td>
                <td height="6"></td>
              </tr>
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>       
         </table>
         </form>

</body>
</html>

