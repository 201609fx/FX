<%@ Page Language="C#" Theme="Pop" StylesheetTheme="Pop" AutoEventWireup="true" CodeFile="testPrint.aspx.cs" Inherits="Cert_testPrint" %>

<html>
<head id="Head1" runat="server">
    <title>申请书打印</title>
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
.PageNextBefore
{
 page-break-before: always;
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
 div1.style.display="none";
 try 
 { 
  var Wsh=new ActiveXObject("WScript.shell"); 
  HKEY_Key="header"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"&w&b页码，&p/&P"); 
  HKEY_Key="footer"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"&b&d"); 
  hkey_key="margin_bottom";
   Wsh.RegWrite(HKEY_Root+HKEY_Path+hkey_key,"0.55"); //0.39相当于把页面设置里面的边距设置为10
   hkey_key="margin_left";
   Wsh.RegWrite(HKEY_Root+HKEY_Path+hkey_key,"0.40");
   hkey_key="margin_right";
   Wsh.RegWrite(HKEY_Root+HKEY_Path+hkey_key,"0.40");
   hkey_key="margin_top";
   Wsh.RegWrite(HKEY_Root+HKEY_Path+hkey_key,"0.55");
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
    <tr><td>    <div id="div1">
    <font color='#FF00FF' size='2px'>如打印控件未安装!点击这里<a href='.\smsxw.msi'>执行安装</a>,安装后请刷新页面。<br />
    如无法预览打印请把浏览器工具--》Internet选项--》安全--》自定义级别--》对未标记为可安全执行脚本的ActiveX控件初始化并执行脚本--》提示。<br /> 请用IE8以上版本的浏览器打印此页</font></div></td></tr>
       <tr><td colspan="3" align="center" class="Print-bt3"><br/>
       <asp:Label runat="server" Visible="false" id="lblID"></asp:Label>
       </td></tr>
       <tr><td colspan="3" align="right">
       <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>       

<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">  
        <tr> 
          <td colspan="3" align="center" valign="top">
      
<TABLE  width="100%" border="0"  cellpadding="0" cellspacing="0" class="Print-text2"> 

         <tr><td valign="top">
         <TABLE  width="100%" border="0" cellpadding="0" cellspacing="0" class="Print-text2"> 
             <tr><td colspan="3" align="right"  class="print-mainbt">编号:<asp:Label runat="server" ID="lblNO"></asp:Label></td></tr>
            <tr height="300"><td colspan="3" valign="middle" align="center" class="Print-btmain"><br/><br/>维修企业技术等级证书<br/><br/><br/><asp:Label runat="server" ID="lblApplyName"></asp:Label></td></tr>
              <tr height="400">
                 <td></td>
                 <td align="left">&nbsp;</td>
                 <td></td>
             </tr> 
             <tr>
                 <td width="20%">&nbsp;</td>
                 <td align="left" class="Print-Main1">企业名称（盖章）：</td>
                 <td></td>
             </tr> 
                <tr height="30">
                 <td></td>
                 <td align="left">&nbsp;</td>
                 <td></td>
             </tr> 
             <tr>
                 <td></td>
                 <td align="left" class="Print-Main1">申请日期：</td>
                 <td></td>
             </tr>
                <tr height="30">
                 <td></td>
                 <td align="left">&nbsp;</td>
                 <td></td>
             </tr> 
             <tr>
                 <td></td>
                 <td align="left" class="Print-Main1">交表日期：</td>
                 <td></td>
             </tr>
        </TABLE>
       </td>
        </tr>
        <tr height="30" class="PageNext"><td> &nbsp;</td></tr>
        <tr><td valign="top">
         <TABLE  width="850" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 
  
          <tr height="40">
          <td   align="center" colspan="2">企业名称(全称)</td>
          <td colspan="6" align="left"><asp:Label runat="server" ID="txtCompany" Width="100%"></asp:Label></td>
          </tr>
          
          <tr height="40">
          <td  align="center">经营地址</td>
          <td colspan="5"  align="left"><asp:Label runat="server" ID="txtAddress" Width="100%"></asp:Label></td>
          <td  align="center">邮编</td>
          <td  align="center"><asp:Label runat="server" ID="txtCode" Width="100%"></asp:Label></td>
          </tr>
          <tr height="40">
          <td width="12%"  align="center">联系人</td>
          <td width="10%"  align="center"><asp:Label runat="server" ID="txtContact" Width="100%"></asp:Label></td>
          <td  width="12%" align="center">固定电话</td>
          <td width="15%"  align="center"><asp:Label runat="server" ID="txtPhone" Width="100%"></asp:Label></td>
          <td  width="12%" align="center">移动电话</td>
          <td width="12%"  align="center"><asp:Label runat="server" ID="txtMobile" Width="100%"></asp:Label></td>
          <td  width="15%" align="center">传真</td>
          <td width="10%"  align="center"><asp:Label runat="server" ID="txtFax" Width="100%"></asp:Label></td>
          </tr>
          
          <tr height="40">
          <td  align="center">法人代表</td>
          <td colspan="2"  align="center"><asp:Label runat="server" ID="txtFrdb" Width="100%"></asp:Label></td>
          <td  align="center">联系电话</td>
          <td colspan="2"  align="center"><asp:Label runat="server" ID="txtFtel" Width="100%"></asp:Label></td>
          <td  align="center">营业面积</td>
          <td  align="center"><asp:Label runat="server" ID="txtArea" Width="100%"></asp:Label></td>       
          </tr>
          
         <tr height="40">
          <td  align="center">企业总人数</td>
          <td colspan="2"  align="center"><asp:Label runat="server" ID="txtAnum" Width="100%"></asp:Label></td>
          <td  align="center">维修人员人数</td>
          <td colspan="2"  align="center"><asp:Label runat="server" ID="txtMnum" Width="100%"></asp:Label></td>
          <td  align="center">安装人员人数</td>
          <td  align="center"><asp:Label runat="server" ID="txtBnum" Width="100%"></asp:Label></td>       
          </tr>      
         
         
          </TABLE>          
          </td></tr>
          
          <tr height="20" ><td> &nbsp;</td></tr>
         
   
      
         <asp:Panel ID="pnlSummary" runat="server" Visible="true">
        <tr>
          	 	 <td>
			 <TABLE  width="850" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 

           <tr height="500" id="trSummary">
          <td   width="15%" align="center">企业总结</td>
          <td width="85%" ><asp:Label runat="server" ID="txtSummary" ></asp:Label></td>
        </tr>
        </TABLE>
        </td>
        </tr>
        
          <tr height="20" class="PageNext"><td> &nbsp;</td></tr>
          </asp:Panel>
                                                       
        <asp:PlaceHolder runat="server" ID="phOperation"></asp:PlaceHolder>	
        <asp:Panel runat="server" ID="pnlOperation"> 
          
          <asp:PlaceHolder runat="server" ID="phList"></asp:PlaceHolder>
          </asp:Panel>
          <asp:PlaceHolder runat="server" ID="phMemployee"></asp:PlaceHolder>		
	 
			  <asp:PlaceHolder runat="server" ID="phWemployee"></asp:PlaceHolder>

			 
			 	
	  
			  <asp:PlaceHolder runat="server" ID="phEList"></asp:PlaceHolder>
        
          	
      
       		

<asp:PlaceHolder runat="server" ID="phCSFile"></asp:PlaceHolder>
    
</TABLE>   
 </td>
            </tr>
                <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="http://www.meadroid.com/scriptx/smsx.cab#Version=5,60,0,360" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
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


