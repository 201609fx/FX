﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskNateEdit.aspx.cs" Inherits="UserSysAdmin_TaskNateEdit" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">用户编辑</asp:Label></td>
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
      
      
      <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text"> 
      
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" align="left" width="15%">
            用户名</td>
        <td bgColor="#f5f5f1" align="left" width="35%">
        <asp:Label runat="server" ID="txtUserName"></asp:Label></td>
         <td class="leftTitle" bgColor="#f9f9f0" align="left" width="15%">
            </td>
        <td bgColor="#f5f5f1" align="left" width="35%">  
        </td>
    </tr>
        <tr>
        <td class="leftTitle" bgColor="#f9f9f0" align="left" >
            任务提示</td>
        <td bgColor="#f5f5f1" align="left" colspan="3" >
        <asp:DataList runat="server" ID="dlList" CellPadding="0" CellSpacing="2" BorderWidth="0" BackColor="#f5f5f1" RepeatColumns="3">
        <ItemTemplate>
        <asp:CheckBox ID="chk" runat="server" Text=<%#"["+Eval("ID").ToString()+"]."+Eval("des").ToString() %> Checked=<%# Eval("HasTask").ToString()=="1" %>  CssClass="main-text"/>
        </ItemTemplate>
        </asp:DataList>
        </td>
    </tr>    
    <tr>
        <td bgColor="#f5f5f1" colspan="6" align="center">
        <asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
            <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" Class="button" id="btnBack" onclick="location.href='TaskNote.aspx'" />&nbsp;&nbsp;
        </td>
    </tr>
    <tr ><td colspan="6" height="6"></td></tr>
     <tr bgcolor="#E7E2D6"> 
                <td height="1" colspan="6" ></td>               
              </tr>                
</TABLE>            
      
      
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

