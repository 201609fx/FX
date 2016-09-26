<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstCheckPrint.aspx.cs" Inherits="workaround_FirstCheckPrint" %>
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
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,''); 
  HKEY_Key="footer"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,''); 
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
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">     

       <tr><td colspan="3" align="center" class="Print-bt3"><br/>初审记录表<br/><br/></td></tr>
       <tr><td colspan="3" align="right">
       <span class="Noprint">
       <a onclick="javascript:document.all.WebBrowser.ExecWB(45,1)" style="cursor:hand">〖关 闭〗</a>
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,1)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>   
       <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="13"></td>
    </tr>
	<tr>
      <td><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left">
                  <table width="550" border="0" cellspacing="0" cellpadding="0" class="Print-text2">
                  <tr>
                  <td align="left">申请书编号:<font style="font-size:16px; font-weight:bold;"><asp:Label runat="server" ID="lblMainSCNO"></asp:Label></font></td>
                  <td align="right">编号:<asp:Label runat="server" ID="lblNoteNO"></asp:Label></td>
                  </tr>
                  </table>

                  </td>
                  <td width="14" align="right" class="body-bt"  ></td>
                </tr>
              </table></td>
          </tr>
          <tr height='10'><td>&nbsp;</td></tr>
          <tr>
            <td bgcolor="White"><table width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" align="center" cellpadding="0" cellspacing="0" class="main-text">
                <tr height="25">
                  <td  width="15%" class="Print-text2" bgColor="White">&nbsp;企业名称:<font style="font-size:16px; font-weight:bold;"><asp:Label runat="server" ID="lblCompany"></asp:Label></font></td>
                </tr>
             
              <tr>
                  <td >
                  <asp:GridView ID="gvList" runat="server" Width="100%" BorderWidth="1" cellpadding="0" cellspacing="1"
	            BackColor="White" style="font-size:14px;background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="White" HorizontalAlign="center" Font-Size="14px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="White" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="10%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%# Container.DataItemIndex+1%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <asp:BoundField ItemStyle-Width="45%" HeaderText="项目" DataField="Name" />		           
		               <asp:TemplateField HeaderText="提交情况">
			            <ItemStyle Width="25%" HorizontalAlign="center" />
			            <ItemTemplate>
			            <table  border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
			            <tr>
			            <td onclick=""><asp:CheckBox Enabled="false" TextAlign="Left" ID="chk1"  runat="server"  Checked='<%#((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"?true:false %>' onclick="setchk(this)"/>
                 已<%#((System.Data.DataRowView)Container.DataItem)["des"]%></td>
			            <td onclick=""><asp:CheckBox Enabled="false"  TextAlign="Left" ID="chk2"  runat="server" Checked='<%#((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"?false:true %>' onclick="setchk(this)" />未<%#((System.Data.DataRowView)Container.DataItem)["des"]%>
                         </td>
			            </tr>
			            </table>
			           
			            </ItemTemplate>
		            </asp:TemplateField> 
		               <asp:BoundField ItemStyle-Width="25%" HeaderText="初审情况" DataField="Remark" />         
	            </Columns>
            </asp:GridView>
                  </td>
                </tr>
                  <tr height="40">
                  <td  width="15%" class="Print-text2" bgColor="White">&nbsp;初审结果:<font style="font-size:16px; font-weight:bold;"><asp:Label runat="server" ID="lblState1"></asp:Label></font></td>
                </tr>
              </table></td>
          </tr>     
         
            
        </table></td>
    </tr>
	<tr height="40">
      <td>&nbsp;</td>
    </tr>
	<tr>
      <td>
      <table border='0' cellpadding='0' cellspacing='0' width="100%" class="Print-text2">
      <tr><td width="60%">评审员：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(签名)</td><td  width="40%">校核人：<asp:Label runat="server" ID="lblCheckUser"></asp:Label></td></tr>      
      <tr><td width="60%">日&nbsp;&nbsp;期：<asp:Label runat="server" ID="lblCheckTime1"></asp:Label></td><td  width="40%">日&nbsp;&nbsp;期：<asp:Label runat="server" ID="lblCheckTime2"></asp:Label></td></tr>
      </table>
      </td>
    </tr>
	<tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
  <td width="100%"><hr style="border:1px dashed Black;"/></td>
  </tr>
  </table>
<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="13"></td>
    </tr>
	<tr>
      <td><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left">
                  <table width="97%" border="0" cellspacing="0" cellpadding="0" class="Print-text2">
                  <tr>
                  <td align="left">申请书编号:<font style="font-size:16px; font-weight:bold;"><asp:Label runat="server" ID="lblMainSCNO1"></asp:Label></font></td>
                  <td align="right">编号:<asp:Label runat="server" ID="lblNoteNO1"></asp:Label></td>
                  </tr>
                  </table>

                  </td>
                  <td width="14" align="right" class="body-bt"  ></td>
                </tr>
              </table></td>
          </tr>
          <tr height='10'><td>&nbsp;</td></tr>
          <tr>
            <td bgcolor="White"><table width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" align="center" cellpadding="0" cellspacing="0" class="main-text">
                <tr height="25">
                  <td  width="15%" class="Print-text2" bgColor="White">&nbsp;企业名称:<font style="font-size:16px; font-weight:bold;"><asp:Label runat="server" ID="lblCompany1"></asp:Label></font></td>
                </tr>
             
              <tr>
                  <td >
                  <asp:GridView ID="gvList2" runat="server" Width="100%" BorderWidth="1" cellpadding="0" cellspacing="1"
	            BackColor="White" style="font-size:14px;background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="White" HorizontalAlign="center" Font-Size="14px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="White" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="10%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%# Container.DataItemIndex+1%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <asp:BoundField ItemStyle-Width="45%" HeaderText="项目" DataField="Name" />		           
		               <asp:TemplateField HeaderText="提交情况">
			            <ItemStyle Width="25%" HorizontalAlign="center" />
			            <ItemTemplate>
			            <table  border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
			            <tr>
			            <td onclick=""><asp:CheckBox  Enabled="false"  ID="chk1" TextAlign="Left"  runat="server"  Checked='<%#((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"?true:false %>' onclick="setchk(this)"/>
                 已<%#((System.Data.DataRowView)Container.DataItem)["des"]%></td>
			            <td onclick=""><asp:CheckBox  Enabled="false"  ID="chk2" TextAlign="Left"  runat="server" Checked='<%#((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"?false:true %>' onclick="setchk(this)" />未<%#((System.Data.DataRowView)Container.DataItem)["des"]%>
                         </td>
			            </tr>
			            </table>
			           
			            </ItemTemplate>
		            </asp:TemplateField> 
		               <asp:BoundField ItemStyle-Width="25%" HeaderText="初审情况" DataField="Remark" />         
	            </Columns>
            </asp:GridView>
                  </td>
                </tr>
                 <tr height="40">
                  <td  width="15%" class="Print-text2" bgColor="White">&nbsp;初审结果:<font style="font-size:16px; font-weight:bold;"><asp:Label runat="server" ID="lblState"></asp:Label></font></td>
                </tr>
              </table></td>
          </tr>     
         
            
        </table></td>
    </tr>
	<tr height="40">
      <td>&nbsp;</td>
    </tr>
	<tr>
      <td>
      <table border='0' cellpadding='0' cellspacing='0' width="100%" class="Print-text2">
      <tr><td >评审员：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(签名)</td></tr>      
      <tr><td >日&nbsp;&nbsp;期：<asp:Label runat="server" ID="lblCheckTime3"></asp:Label></td></tr>
      <tr><td>注：所缺资料的请于五个工作日内交齐，凭此单取《维修企业技术等级证书》</td></tr>
      </table>
      </td>
    </tr>
	<tr>
      <td>&nbsp;</td>
    </tr>
  </table>

  <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="../scriptx/smsx.cab#Version=6,3,436,14" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
  </OBJECT>
 <object  id="WebBrowser"  width="0"  height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
 <PARAM NAME="Offline" VALUE="0">
</object>    
         </form>

</body>
</html>

