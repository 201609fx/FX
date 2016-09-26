<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstAuditing_PopWindow.aspx.cs" Inherits="workaround_FirstAuditing_PopWindow" %>

<html>
<head><link href="../styles/style.css" rel="stylesheet" type="text/css">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>退回意见</title>
</head>

<body>
<form name="form1" runat="server">
  <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="13"></td>
    </tr>
	<tr>
      <td><table width="570" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="570" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_1.gif" width="14" height="29"></td>
                  <td background="../img/tc_3.gif" class="body-bt">退回意见</td>
                  <td width="14"><img src="../img/tc_2.gif" width="14" height="29"></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td bgcolor="#F0EEE9"><table width="542" border="0" align="center" cellpadding="0" cellspacing="3" class="main-text">
                <tr>
                  <td  height="200" width="15%">&nbsp;修改意见</td>
                  <td  bgColor="#f5f5f1" ><asp:TextBox runat="server" ID="txtSummary" Width="95%" Height="200" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
             
              </table></td>
          </tr>
         
          <tr>
          <td align="center">
              <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" />&nbsp;&nbsp;<object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object><input type="button" onclick="window.close()" value="关闭" /></td>
          </tr>
          <tr>
            <td><table width="570" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_4.gif" width="14" height="10"></td>
                  <td width="542" background="../img/tc_6.gif"></td>
                  <td width="14"><img src="../img/tc_5.gif" width="14" height="10"></td>
                </tr>
              </table></td>
          </tr>
        </table></td>
    </tr>
	<tr>
      <td>&nbsp;</td>
    </tr>
	<tr>
      <td>&nbsp;</td>
    </tr>
	<tr>
      <td>&nbsp;</td>
    </tr>
  </table>
</form>
</body>
</html>
