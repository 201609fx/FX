<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complain_Print.aspx.cs" Inherits="workaround_Complain_Print" %>
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

       <tr><td colspan="3" align="center" class="Print-bt3"><br/>深圳市认证与维修质量监督处投诉处理表<br/><br/>
       <asp:Label runat="server" id="lblNO"></asp:Label>
       </td></tr>
       <tr><td colspan="3" align="right">
       <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>       
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">  
        <tr> 
          <td colspan="3" align="center">
      
<TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 
      
    <tr height="25">
        <td class="leftTitle" bgColor="White" align="center">
            投诉日期</td>
        <td bgColor="White" align="left">
        <asp:Label runat="server" ID="lblCTime" CssClass="Print-text2"></asp:Label>
        </td>
         <td class="leftTitle" bgColor="White" align="center" colspan="2">
            投诉单位(人)</td>
        <td bgColor="White" align="left" colspan="2">
        <asp:Label runat="server" ID="lblComplainer" CssClass="Print-text2"></asp:Label>
        </td>
    </tr>
    <tr height="25">
      <td class="leftTitle" bgColor="White" align="center" width="150">
            地址</td>
        <td bgColor="White" align="left" width="200">
               <asp:Label runat="server" ID="lblCaddresstou" CssClass="Print-text2"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="White" width="50" align="center">
            电话</td>
        <td bgColor="White" align="left" width="150">
         <asp:Label runat="server" ID="lblTel" CssClass="Print-text2"></asp:Label>                   
        </td>  
          <td class="leftTitle" bgColor="White" align="center" width="120">
            投诉方式</td>
        <td bgColor="White" align="left" width="200">
         <asp:Label runat="server" ID="lblInsertFlag" CssClass="Print-text2"></asp:Label>                  
        </td>        
    </tr> 
     <tr height="40">
      <td class="leftTitle" bgColor="White" align="center">
            被投诉单位(人)</td>
        <td bgColor="White" align="left">
               <asp:Label runat="server" ID="lblBComplainer" CssClass="Print-text2"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="White" align="center">
            电话</td>
        <td bgColor="White" align="left">
         <asp:Label runat="server" ID="lblBCTel" CssClass="Print-text2"></asp:Label>                   
        </td>  
          <td class="leftTitle" bgColor="White" align="center">
            联系人</td>
        <td bgColor="White" align="left">
         <asp:Label runat="server" ID="lblBContact" CssClass="Print-text2"></asp:Label>                  
        </td>        
    </tr> 
      <tr height="25">
      <td class="leftTitle" bgColor="White" align="center">
            地址</td>
        <td bgColor="White" align="left" colspan="5">
               <asp:Label runat="server" ID="lblBAddress" CssClass="Print-text2"></asp:Label>    
        </td>          
    </tr> 
       <tr height="25">
      <td class="leftTitle" bgColor="White" align="center">案件名称</td>
        <td bgColor="White" align="left" colspan="5">
               <asp:Label runat="server" ID="lblName" CssClass="Print-text2"></asp:Label>    
        </td>          
    </tr> 
         <tr height="200">
      <td class="leftTitle" bgColor="White" align="center">内容</td>
        <td bgColor="White" align="left" colspan="5" >
               <asp:Label runat="server" ID="lblcontent" CssClass="Print-text"></asp:Label>    
        </td>          
    </tr> 
     <tr height="150">
      <td class="leftTitle" bgColor="White" align="center">处理意见</td>
        <td bgColor="White" align="left" colspan="5"> 
        <table border="0" cellpadding="0" cellspacing="0" height="100%"  bgColor="White" width="100%">           
            <tr  bgColor="White" height="110" >
            <td align="left" colspan="2">&nbsp;&nbsp;<asp:Label runat="server" ID="txtsuggest" CssClass="Print-text" ></asp:Label>              
            </td>
            </tr>
             <tr bgColor="White" Height="16"><td colspan="6"></td></tr>
            <tr bgColor="White" >
            <td align="right" colspan="2" height="24">  
                  签名:<asp:TextBox runat="server" ID="txtsuggester"  Width="120" CssClass="inputline-Print2">  </asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日&nbsp;&nbsp;
            </td>       
            </tr>           
            </table>  
        </td>          
    </tr> 
     <tr height="150">
      <td class="leftTitle" bgColor="White" valign="top" align="center">领导批示</td>
        <td bgColor="White" align="left" colspan="3" > 
        <table border="0" cellpadding="0" height="100%" cellspacing="0"  bgColor="White" width="100%" class="Print-text2">           
            <tr  bgColor="White" height="120">
            <td align="left" colspan="2" >&nbsp;&nbsp;<asp:Label runat="server" ID="txtLSuggest"  CssClass="Print-text"></asp:Label>              
            </td>
            </tr>
             <tr bgColor="White" Height="5" colspan="2"><td >&nbsp;</td></tr>
            <tr bgColor="White" >
            <td align="left"  height="24" >  
                  签名:<asp:TextBox runat="server" ID="txtLeader"  Width="100" CssClass="inputline-Print2">  </asp:TextBox></td><td align="right">&nbsp;&nbsp;&nbsp;年&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;日
            </td>       
            </tr>           
            </table>  
        </td>  
          <td bgColor="White" align="left" colspan="2"> 
        <table border="0" cellpadding="0" cellspacing="0" height="100%"  bgColor="White" width="100%" class="Print-text2">           
            <tr  bgColor="White"  height="90">
            <td align="left" >&nbsp;&nbsp;<asp:Label runat="server" ID="txtLSuggest1"  CssClass="Print-text"></asp:Label>              
            </td>
            </tr>
             <tr bgColor="White" Height="5"><td>&nbsp;</td></tr>
            <tr bgColor="White" >
            <td align="left" height="24">  
                  签名:<asp:TextBox runat="server" ID="txtLeader1"  Width="100" CssClass="inputline-Print2">  </asp:TextBox></td><td align="right">&nbsp;&nbsp;&nbsp;年&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;日
            </td>       
            </tr>           
            </table>  
        </td>         
    </tr> 
    <tr height="120">
      <td class="leftTitle" bgColor="White" valign="top" align="center">处理结果</td>
        <td bgColor="White" align="left" colspan="5" >
        <asp:Label runat="server" ID="txtResult"  CssClass="Print-text"></asp:Label>     
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
