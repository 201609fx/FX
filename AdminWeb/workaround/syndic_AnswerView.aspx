<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_AnswerView.aspx.cs" Inherits="workaround_syndic_AnswerView" %>
<html>
<head id="Head1" runat="server">
    <title>现场评审表打印</title>
 <link href="../styles/style.css" rel="stylesheet" type="text/css"/>
   <script language="javascript">
       function CheckBoxList_Click(sender) 
    {
        var container = sender.parentNode;        
        if(container.tagName.toUpperCase() == "TD") { // 服务器控件设置呈现为 table 布局（默认设置），否则使用流布局
            container = container.parentNode.parentNode; // 层次： <table><tr><td><input />
        }        
        var chkList = container.getElementsByTagName("input");
        var senderState = sender.checked;
        for(var i=0; i<chkList.length;i++) {
            chkList[i].checked = false;
        }     
        sender.checked = senderState;          
    }
    function CheckBoxList2_Click(sender) 
    {
        var strid=sender.id;
        strid=strid.substring(1,strid.length-8);
        var container = sender.parentNode;        
        if(container.tagName.toUpperCase() == "SPAN") { // 服务器控件设置呈现为 table 布局（默认设置），否则使用流布局
            container = container.parentNode; // 层次： <table><tr><td><input />
        }        
        var chkList = container.getElementsByTagName("input");
        var senderState = sender.checked;
        for(var i=0; i<chkList.length;i++) {
        if(chkList[i].id.indexOf(strid)>0)
            chkList[i].checked = false;
        }     
        sender.checked = senderState;          
    }
   </script>

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
  document.all.factory.printing.portrait = false;

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
       <tr><td colspan="3" align="right">
       <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>   
          
   <table width="960"  border="1" align="center" cellpadding="0" cellspacing="1" style="page-break-after: always;background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" class="print-main">
   <tr  bgcolor="White" height="40">
   <td colspan="4" align="center" >
   <font style="font-size:20; font-weight:bold;">深圳市维修企业技术等级考核评审表</font>
   </td>
   </tr>
     <tr  bgcolor="White" height="16">
   <td  align="center" colspan="4">&nbsp;</td>   
   </tr>
   <tr  bgcolor="White"  height="40">
   <td >企业名称:<font style="font-size:13; font-weight:bold;"><asp:Label ID="lblMainName" runat="server" CssClass="bt-Firm"></asp:Label></font></td>
   <td>申请编号:&nbsp;&nbsp;<asp:Label ID="lblNO" runat="server" ></asp:Label>  &nbsp;&nbsp;&nbsp;评审日期:<asp:Label ID="lblTime" runat="server"></asp:Label><br/>评审员:<asp:Label ID="lblSyndic" runat="server"></asp:Label></td>
    <td colspan="2">考核总分:<font style="font-size:16; font-weight:bold;"><asp:Label ID="lblTotle" runat="server" ></asp:Label></font></td>    
   </tr>
   <tr  bgcolor="White"  height="20">
   <td width="360" align="center">考核要求</td>   
    <td width="440" align="center">考核记录</td> 
    <td width="100" align="center">备注</td>
    <td width="60" align="center">总分
  <asp:Label ID="lblProblemsInfo" runat='server' Text="" Visible='false'></asp:Label></td>
   </tr>
   <asp:PlaceHolder runat="server" ID="ph"></asp:PlaceHolder>
    </table>
    
    
    <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="../scriptx/smsx.cab#Version=6,3,436,14" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
  </OBJECT>
 <object  id="WebBrowser"  width="0"  height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
 <PARAM NAME="Offline" VALUE="0">
</object>
    </form>
</body>
</html>
