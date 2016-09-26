<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result_Print.aspx.cs" Inherits="workaround_result_Print" %>

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
 try 
 {
  document.all.factory.printing.portrait = false;
  }
  catch(e)
  {
  alert(e.message);}
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
       <tr><td colspan="3" align="center" class="Print-bt"><asp:Label runat="server" ID="lblTitle" CssClass="Print-bt2">维修企业技术等级评审结论</asp:Label><br/><br/></td></tr>
       <tr height="20"><td colspan="3" align="right">
       <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>       
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">  
        <tr> 
          <td colspan="3" align="center">
          <table width="99%" border="1.5" align="center" cellpadding="0" cellspacing="0" height="500" style="border-color:Black;"><tr><td align="center" valign="middle">  
      <table cellspacing="0" cellpadding="0" rules="all" border="1" class="Print-Main1" width="98%" height="480"  style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;">
    <tr height="40">
        <td class="Print-Main1" bgColor="White" align="center">
            企业名称</td>
        <td bgColor="White" align="left" colspan="3">
        <asp:Label runat="server" ID="lblCompany" CssClass="Print-Main1"></asp:Label>&nbsp;
        </td>
    </tr>
    <tr height="40">
      <td class="Print-Main1" bgColor="White" align="center" width="15%">
            申请书编号</td>
        <td bgColor="White" align="center" width="35%>
               <asp:Label runat="server" ID="lblNO" CssClass="Print-Main1"></asp:Label>&nbsp;    
        </td>
        <td class="Print-Main1" bgColor="White" align="center" width="20%">
            评审日期</td>
        <td bgColor="White" align="center" width="30%">
         <asp:Label runat="server" ID="lblPSTime" CssClass="Print-Main1"></asp:Label>&nbsp;   
                 
        </td>
    </tr> 
     <tr height="40">
      <td class="Print-Main1" bgColor="White" align="center">
            维修范围</td>
        <td bgColor="White" align="left" colspan="3">
               <asp:Label runat="server" ID="lblOperation" CssClass="Print-Main1"></asp:Label>&nbsp;    
        </td>
    </tr> 
    <tr  height="250">    
        <td class="Print-Main1" bgColor="White" align="center">
            评<br/><br/>审<br/><br/>组<br/><br/>意<br/><br/>见</td>
        <td bgColor="White" align="left" colspan="3">
        &nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="txtSuggest" ></asp:Label>&nbsp;              
        </td>
    </tr>
       <tr height="110">    
        <td class="Print-Main1" bgColor="White" align="center">
            评<br/>审<br/>结<br/>论</td>
        <td bgColor="White" align="left" colspan="3">
        &nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="txtResult"></asp:Label>              
        </td>
    </tr>                    
</TABLE> 
</td></tr></table>        
 </td>
            </tr>
            <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="../scriptx/smsx.cab#Version=6,3,436,14" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
  </OBJECT>
                          <object  id="WebBrowser"  width="0"  height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
 <PARAM NAME="Offline" VALUE="0">
</object>
 <tr bgcolor="white" height="25"> 
                <td  colspan="3" align="left" class="Print-text" valign="middle">&nbsp;&nbsp;&nbsp;注：一级技术等级１００－９１分，二级技术等级９０－８１分；三级技术等级７９－７１分
         </td>             
             </tr> 
              <tr bgcolor="white" height="4"> 
                <td  colspan="3" align="left" class="Print-text" valign="middle">&nbsp;&nbsp;
         </td>             
             </tr> 
           <tr bgcolor="white" height="30"> 
                <td height="6" colspan="3" align="left"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="Print-Main1"><tr><td width="65%">评审组成员签名：<asp:Label runat="server" ID="lblMember"></asp:Label></td><td>
         评审组组长：<asp:Label runat="server" ID="lblLeader"></asp:Label></td></tr>
         <tr><td>企业确认：<asp:Label runat="server" ID="lblCompanyConfirm"></asp:Label> </td></tr>
         </table>
         </td>             
             </tr>  
         </table>
         </form>

</body>
</html>