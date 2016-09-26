<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Notes_Default" Title="深圳市市场监督管理局维修监管系统" %>
<%@ Register TagName="LeftMenu" Src="LeftMenu.ascx" TagPrefix="uu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<table width="966" border="0" cellspacing="0" cellpadding="0">
<tr>
      <td width="233" valign="top"> 
             <uu1:LeftMenu ID="LeftMenu" runat="server"/>            
      </td>
      <td valign="top">               
<asp:PlaceHolder runat="server" ID="phContent"></asp:PlaceHolder>       
             </td>
 </tr>
 </table>
</asp:Content>
