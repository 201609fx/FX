<%@ Page Language="C#"  Theme="Home" StylesheetTheme="Home"   MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Contact_Default" Title="Untitled Page" %>
<%@ Register TagName="LeftMenu" Src="LeftMenu.ascx" TagPrefix="uu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
      <td width="193" valign="top"> 
             <uu1:LeftMenu ID="LeftMenu" runat="server"/>            
             </td>
            <td valign="top">               
<asp:PlaceHolder runat="server" ID="phContent"></asp:PlaceHolder>       
             </td>
</asp:Content>
