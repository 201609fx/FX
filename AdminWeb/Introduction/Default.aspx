<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Introduction_Default" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<html  >
<head runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
   <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top"><table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td>&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;机构简介</td>
        </tr>
		<tr> 
          <td height="8"></td>
        </tr>
        <tr> 
          <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt">&nbsp;</td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"><asp:Label ID="lblID" runat="server" Visible="false"></asp:Label></td>
              </tr>
              <tr> 
                <td align="center" bgcolor="#ECEAE3"></td>
                <td bgcolor="#ECEAE3">
                
              
    <table width="96%" border="0" cellspacing="0" cellpadding="0" class="main-text">
										<tr>
											<td height="200" width="10%">概&nbsp;&nbsp;&nbsp;&nbsp;要：<font color="red">*</font></td>
											<td valign="middle" width="90%">
											<FTB:FreeTextBox id="ftbContent1"  runat="server" Width="90%" Height="100%" AutoConfigure="Default" HelperFilesPath="../Control/FreeTexoBox/ftb/HelperScripts/"  ButtonPath="../Images/ftb/office2003/" ImageGalleryPath="/UploadFiles/FTBimages/"></FTB:FreeTextBox>
											</td>
										</tr>
										<tr height="5"></tr>
										<tr>
											<td height="600" width="10%">内&nbsp;&nbsp;&nbsp;&nbsp;容：<font color="red">*</font></td>
											<td valign="middle" width="90%">
											<FTB:FreeTextBox id="ftbContent"  runat="server" Width="90%" Height="100%" AutoConfigure="EnableAll" HelperFilesPath="../Control/FreeTexoBox/ftb/HelperScripts/"  ButtonPath="../Images/ftb/office2003/" ImageGalleryPath="/UploadFiles/FTBimages/"></FTB:FreeTextBox>
											 	</td>
										</tr>
										</table>
										</td>
                <td bgcolor="#ECEAE3">&nbsp;</td>
                
              </tr>
              
										
              <tr> 
                <td height="2"></td>
                <td height="2"></td>
                <td height="2"></td>
              </tr>             
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>
              <tr> 
                <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="main-text">
                      <td align="center"><asp:Button  ID="btnOK" runat="server" CssClass="" Text="提交" OnClick="btnOK_Click"/>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" runat="server" Text="清空" OnClick="btnClear_Click" /></td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>
