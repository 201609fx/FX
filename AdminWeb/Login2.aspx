<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login2.aspx.cs" Inherits="Login2" %>

<html>
<head><link href="styles/style_enter.css" rel="stylesheet" type="text/css">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>登陆</title>
</head>

<body>
<form id="form1" runat="server">
<table width="776" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr> 
    <td height="116">&nbsp;</td>
  </tr>
  <tr> 
    <td><table width="648" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="407" valign="bottom" background="img/login/e_bg.gif">
<table width="648" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="right"><table width="260" border="0" cellspacing="0" cellpadding="0" class="main-text">
                   
                    <tr> 
                      <td width="60" height="20">用户名：</td>
                      <td colspan="2"><asp:TextBox id="txtUserName" runat="server" CssClass="input-search-enter"></asp:TextBox></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr> 
                      <td width="60" height="20">密 &nbsp;码：</td>
                      <td colspan="2"><asp:TextBox id="txtPwd" TextMode="Password" runat="server" CssClass="input-search-enter"></asp:TextBox></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr> 
                      <td width="60" height="20">验证码：</td>
                      <td width="80"><asp:TextBox id="txtVailCode" runat="server" CssClass="input-search-enter" Width="80"></asp:TextBox></td>
                      <td width="50"><img src="validateimage.aspx" width="45" height="18"></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr> 
                      <td height="30">&nbsp;</td>
                      <td colspan="2">
                          <asp:Button ID="btnOK" runat="server" Text="登  陆" OnClick="btnOK_Click" /></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr> 
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td height="20" align="center" valign="top" class="main-text">深圳市认证与维修质量监督处</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table></td>
  </tr>
</table>
</form>
</body>
</html>

