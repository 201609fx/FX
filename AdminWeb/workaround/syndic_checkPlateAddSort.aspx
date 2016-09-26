<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_checkPlateAddSort.aspx.cs" Inherits="workaround_syndic_checkPlateAddSort" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加题目类型</title>

    <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                  <td background="../img/tc_3.gif" class="body-bt"><asp:Label runat="server" ID="lblSortName"></asp:Label></td>
                  <td width="14"><img src="../img/tc_2.gif" width="14" height="29"></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td bgColor="#f5f5f1">
       <asp:Panel ID="pnlAll" runat="server">
    <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
        <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text"  bgcolor="#F0EEE9" height="100">
         <tr>
        <td class="leftTitle">题 目</td>
        <td >
            <asp:TextBox ID="txtName" runat="server" Width="90%" Height="50" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
           <tr>
        <td class="leftTitle">分 数</td>
        <td>
            <asp:TextBox ID="txtTotle" runat="server" Width="90%" ></asp:TextBox></td>
        </tr>
        <tr>
        <td class="leftTitle">是否为评分类型</td>
        <td>
        <asp:RadioButtonList runat="server" RepeatColumns="2" ID="rbnlIsATotle" CssClass="main-text">
        <asp:ListItem Selected="True" Text="否" Value="0"></asp:ListItem>
           <asp:ListItem Text="是" Value="1"></asp:ListItem>
        </asp:RadioButtonList>
            </td>
        </tr>
         <tr>
        <td class="leftTitle" bgColor="#f9f9f0" width="20%">备 注</td>
        <td bgColor="#f5f5f1" width="80%" align="left"><asp:TextBox ID="txtRemark" runat=server Width="90%" Height="50" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
         <tr><td align="center" colspan="2" >&nbsp;&nbsp;&nbsp;&nbsp; </td></tr>
              
</TABLE>
</asp:Panel>
</td>
          </tr>
         
          <tr>
          <td align="center" bgcolor="#F0EEE9">
              <asp:Button ID="btnOK" Text="确定" CssClass="button" runat="server" OnClick="btnAddT_Click" />&nbsp;&nbsp;<object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object><input type="button" onclick="window.close()" value="关闭" /></td>
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
    </div>
    </form>
</body>
</html>
