<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_PlatePreView.aspx.cs" Inherits="workaround_syndic_PlatePreView" %>

<html>
<head runat="server">
    <title>评审表打印</title>
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
</head>
<body>
    <form id="form1" runat="server">
    
      <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">        
          <tr> 
          <td colspan="3">&nbsp;</td>            
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">评审</asp:Label></td>
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
          
   <table width="100%"  border="1" align="center" cellpadding="3" cellspacing="1" style="border-color:Black"  bgcolor="Black" class="main-text">
   <tr  bgcolor="#F2F2F2">
   <td colspan="4" align="center" >
   <font style="font-size:20; font-weight:bold;">深圳市维修企业技术等级考核评审表</font>
   </td>
   </tr>
   <tr  bgcolor="#F2F2F2">
   <td>企业名称:<font style="font-size:13; font-weight:bold;">*********</font></td>
   <td>申请编号:&nbsp;&nbsp;***  &nbsp;&nbsp;&nbsp;评审日期:****/**/**<br/>评审员:****,****,****</td>
    <td colspan="2">考核总分:<font style="font-size:16; font-weight:bold;">**.*</font></td>    
   </tr>
   <tr  bgcolor="#F2F2F2">
   <td width="240">考核要求</td>   
    <td width="300">考核记录</td> 
    <td width="100">备注</td>
    <td width="60">总分</td>
   </tr>
   <tr>
   <td colspan="4">
  <asp:Label ID="lblProblemsInfo" runat='server' Text="" Visible='false'></asp:Label>
   </td>
   </tr>
   <asp:Repeater runat="server" ID="rptFProblemSort" OnItemDataBound="rptFProblemSort_ItemDataBound">
   
   <ItemTemplate>
   <tr bgcolor="#F2F2F2"><td colspan="3"><font style="font-size:16;font-weight:bold;"><%# DataBinder.Eval(Container.DataItem, "OrderNum")%>.<%# DataBinder.Eval(Container.DataItem, "Name")%>&nbsp;(<%# DataBinder.Eval(Container.DataItem, "Totle")%>分)<%# DataBinder.Eval(Container.DataItem, "Remark").ToString() == "" ? "" : "【" + DataBinder.Eval(Container.DataItem, "Remark").ToString() + "】"%>
   </font>
   </td>
   <td>得分</td>
   </tr>
  <asp:Repeater runat="server" ID="rptSProblemSort" OnItemDataBound="rptSProblemSort_ItemDataBound">
    
   <ItemTemplate>
   <tr bgcolor="#F2F2F2" valign="top">
   <td>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Pordernum")%>.<%#DataBinder.Eval(Container.DataItem, "OrderNum")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Name")%>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "Totle")%>分)<%# (DataBinder.Eval(Container.DataItem, "Remark").ToString() == ""
                                ? ""
                                : (DataBinder.Eval(Container.DataItem, "hasChild").ToString() == "0" ? ("<br>&nbsp;&nbsp;&nbsp;" + DataBinder.Eval(Container.DataItem, "Remark").ToString()) : "【" + DataBinder.Eval(Container.DataItem, "Remark").ToString() + "】"))%>
      </td>
    <td>
    <asp:Repeater runat="server" ID="rptSProblem" OnItemDataBound="rptSProblem_ItemDataBound">
    <ItemTemplate>
    <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0" style="border-color:Black"  bgcolor="Black" class="main-text">
     <tr bgcolor="#F2F2F2">
    <td valign="top" align="left" style="display:table-row;"><table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0" style="border-color:Black"  bgcolor="#F2F2F2" class="main-text"><asp:PlaceHolder runat="server" ID="phOption"></asp:PlaceHolder></table></td>
     </tr>
     </table>
    </ItemTemplate>
    </asp:Repeater>
    
  </td>
   <td></td>
   <td></td>
   </tr>
   <asp:Repeater runat="server" ID="rptTProblemSort" OnItemDataBound="rptTProblemSort_ItemDataBound">
   <ItemTemplate>
  <tr bgcolor="#F2F2F2"  valign="top">
  <td>&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "OrderNum")%>)&nbsp;<%# DataBinder.Eval(Container.DataItem, "Name")%>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "Totle")%>分)<%# DataBinder.Eval(Container.DataItem, "Remark").ToString() == "" ? "" : "<br>&nbsp;&nbsp;&nbsp;" + DataBinder.Eval(Container.DataItem, "Remark").ToString()%></td>
   <td>
   <asp:Repeater runat="server" ID="rptTProblem" OnItemDataBound="rptSProblem_ItemDataBound">
    <ItemTemplate>
    <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0" style="border-color:Black"  bgcolor="Black" class="main-text">
    <tr bgcolor="#F2F2F2">
    <td valign="top" align="left" style="display:table-row;"><table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0"  bgcolor="#F2F2F2" class="main-text"><asp:PlaceHolder runat="server" ID="phOption"></asp:PlaceHolder></table></td>
  
     </tr>
     </table>
    </ItemTemplate>
    </asp:Repeater>
   
   </td>
   <td></td>
   <td></td>
   </tr>

   </ItemTemplate>
   <FooterTemplate></FooterTemplate>
   </asp:Repeater>
 

  
   
   
   </ItemTemplate>
   </asp:Repeater>
   
   </ItemTemplate>   
   </asp:Repeater>
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
