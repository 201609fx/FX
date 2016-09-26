<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approve_Print.aspx.cs" Inherits="workaround_approve_Print" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title>打印审批表</title>
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

 <script language="javascript" >
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
  alert(e.message);
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

       <tr><td colspan="3" align="center" class="Print-bt"><br/>维修企业技术等级证书审批表<br/><br/></td></tr>
       <tr><td colspan="3" align="right">
       <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>       
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">  
        <tr> 
          <td colspan="3" align="center">
      
      <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-Main1"> 
      
    <tr height="40">
        <td class="Print-Main1" bgColor="White" align="center">
            企业名称</td>
        <td bgColor="White" align="left" colspan="3">
        <asp:Label runat="server" ID="lblCompany" CssClass="Print-Main1"></asp:Label>&nbsp;
        </td>
    </tr>
    <tr  height="40">
      <td class="Print-Main1" bgColor="White" align="center" width="20%">
            评定分数</td>
        <td bgColor="White" align="center" width="30%">
               <asp:Label runat="server" ID="lblTotle" CssClass="Print-Main1"></asp:Label>&nbsp;  
        </td>
        <td class="Print-Main1" bgColor="White" align="center" width="20%">
            评定等级</td>
        <td bgColor="White" align="center" width="30%">
         <asp:Label runat="server" ID="lblCertNO" CssClass="Print-Main1"></asp:Label> &nbsp;  
                 
        </td>       
    </tr> 
    <tr  height="360">    
        <td class="Print-Main1" bgColor="White" align="right" colspan="6">&nbsp;
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="Print-Main1" bgcolor="white">
            <tr  bgColor="White" height="30">
            <td align="left" colspan="2">&nbsp;深圳市协会秘书处意见：</td>
            </tr>
            <tr  bgColor="White"  height="280">
            <td align="left" colspan="2" valign="top">&nbsp;&nbsp;<asp:Label runat="server" ID="txtSuggest"></asp:Label>              
            </td>
            </tr>
            <tr bgColor="White"  height="30">
            <td align="left">  
                  &nbsp;会长签名：<asp:TextBox runat="server" ID="txtSuperintendent"  Width="200" CssClass="inputline-Print">  </asp:TextBox>&nbsp;&nbsp;&nbsp;
                    </td>
            <td align="right"> 
                  年&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;日&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>       
            </tr>           
            </table>                  
        </td>
    </tr>      
    <tr  bgColor="white" height="360">    
        <td class="Print-Main1"align="left" colspan="6" valign="top">
         <table border="0" cellpadding="0" cellspacing="0" width="100%" class="Print-Main1" bgcolor="white">
            <tr  bgColor="White" >
            <td align="left" colspan="2"><br/><br/> &nbsp;备注：</td>
            </tr>
            <tr  bgColor="White" >
            <td align="left" width="30">&nbsp;&nbsp;</td>
            <td>
             <asp:Label runat="server" ID="txtRemark" Width="100%" TextMode="MultiLine"></asp:Label>                
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

