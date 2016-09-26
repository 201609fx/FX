<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="Law_NewsEdit" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<html>
<head runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">政策法规</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"><asp:Label ID="lblID" Visible="false" runat="server"></asp:Label></td>
        </tr>
          <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%">&nbsp;</td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
        <tr> 
          <td colspan="3">
    <table width="96%" border="0" cellspacing="0" cellpadding="0" class="main-text">
    	<asp:Panel ID="pnlNewEdit" runat="server">
										<tr>
											<td width="10%" height="28">标&nbsp;&nbsp;&nbsp;&nbsp;题：<font color="red">*</font></td>
											<td width="90%">
											    <asp:TextBox ID="txtTitle" runat="server" Width="90%"></asp:TextBox>
											</td>
										</tr>
									
							    <TR>
									<TD class="text-gray" >摘&nbsp;&nbsp;&nbsp;&nbsp;要：</TD>
									<TD>
										<asp:textbox id="txtAbstract" runat="server" Width="90%" ></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="text-gray" >关 键 字：</TD>
									<TD>
										<asp:textbox id="txtKeyword" runat="server" Width="90%" ></asp:textbox></TD>
								</TR>								
								<TR>
									<TD class="text-gray" >原文作者：</TD>
									<TD>
										<asp:textbox id="txtAuthor" runat="server" Width="90%" ></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="text-gray" >原文出处：</TD>
									<TD>
										<asp:textbox id="txtRefer" runat="server" Width="90%" ></asp:textbox></TD>
								</TR>
								</asp:Panel>
										<tr>
											<td height="400" width="10%">内&nbsp;&nbsp;&nbsp;&nbsp;容：<font color="red">*</font></td>
											<td valign="middle" width="90%">
											 <ftb:FreeTextBox id="content"  AutoConfigure="EnableAll" height="400"  runat="server" Width="100%" HelperFilesPath="../Control/FreeTexoBox/ftb/HelperScripts/"  ButtonPath="../Images/ftb/office2003/" ImageGalleryPath="/UploadFiles/FTBimages/"></ftb:FreeTextBox>
											  </td>
										</tr>
											<tr >
											<td height="110">附&nbsp;&nbsp;&nbsp;&nbsp;件：<font color="red"></font></td>
											<td valign="middle">
											  <iframe name="Myiframe" src="<%=strFileUrl %>" scrolling="no" id="Myiframe" frameborder="0" width="90%"></iframe>
											</td>
										</tr>
	</table>
	</td>
	</tr>
        
	<tr><td align="center" colspan="3"><asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" /> </td></tr>
	</table>
	</td>
	</tr>
	</table>
    </div>
    </form>
</body>
</html>
