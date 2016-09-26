<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_optionEdit.aspx.cs" Inherits="workaround_syndic_optionEdit" %>

<html  >
<head runat="server">
    <title>编辑选项</title>
       <link href="../styles/style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    
      <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="13"></td>
    </tr>

	<tr>
      <td><table width="690" border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
          <tr>
            <td colspan="3"><table width="690" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_1.gif" width="14" height="29"></td>
                  <td background="../img/tc_3.gif" class="body-bt"><asp:Label runat="server" ID="lblSortName">编辑选项</asp:Label></td>
                  <td width="14"><img src="../img/tc_2.gif" width="14" height="29"></td>
                </tr>
              </table></td>
          </tr>          
 <tr>
      <td height="13" colspan="3" width="100%">
      
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="main-text">
	<tr>
		<td class="subtitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProblemInfo" runat='server'></asp:Label></td>
	</tr>
	<tr>
		<td><hr size="1" class="dotline">
		</td>
	</tr>
</table>
<asp:GridView cellpadding='3' cellspacing='0' ID="gdvOption" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" OnRowDeleting="gdvOption_RowDeleting" OnRowDataBound="gdvOption_RowDataBound" AllowPaging="True" OnSelectedIndexChanging="gdvOption_SelectedIndexChanging" PageSize="12" OnPageIndexChanging="gdvOption_PageIndexChanging" OnRowCommand="gdvOption_RowCommand" CssClass="main-text">
    <HeaderStyle HorizontalAlign='Center' />
    <SelectedRowStyle BackColor="#FFFFFF" />
        <Columns>
            <asp:TemplateField  HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="center" HeaderText="ID">
                <ItemTemplate>
                <%# Container.DisplayIndex + gdvOption.PageIndex * gdvOption.PageSize + 1%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderStyle-Width="360px" ItemStyle-HorizontalAlign="left"  HeaderText="选项内容" DataField="OptionContent" />
            <asp:TemplateField  HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="是否带输入框">
                <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "IsWrite").ToString() == "0" ? "否" : "是"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="center"  HeaderText="排序">
                <ItemTemplate>
                <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CssClass="link-02" CommandName="up" Runat="server" text="上移" ID="Linkbutton4"></asp:LinkButton>&nbsp;
                <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CssClass="link-02" CommandName="down" Runat="server" text="下移" ID="Linkbutton5"></asp:LinkButton>&nbsp;
                <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CssClass="link-02" CommandName="top" Runat="server" text="置顶" ID="Linkbutton6"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="center" HeaderText="选择"  ShowSelectButton="True" />
            <asp:CommandField  HeaderStyle-Width="30px" ShowDeleteButton="True" HeaderText="删除"  />
        </Columns>
</asp:GridView>
<TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text">
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" width="20%">选项标题<asp:Label ID="lblOptionID" runat='server' Visible='false'></asp:Label></td>
        <td bgColor="#f5f5f1" width="80%" align="left"><asp:TextBox ID="txtOptionContent" runat='server' Width="90%"></asp:TextBox><br><asp:Label ID="lblTishi" runat='server'>(输入框以'@输入框'表示)</asp:Label></td>
    </tr>
    <asp:Panel ID="plIsCheck" runat='server'>
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0">是否带输入框</td>
        <td bgColor="#f5f5f1" align="left">
            <asp:RadioButtonList ID="rdoltIsWrite" runat='server' RepeatColumns="6" CssClass='main-text'>
                <asp:ListItem  Value="0" Text="否"></asp:ListItem>
                <asp:ListItem Selected='True' Value="1" Text="是"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    </asp:Panel>
    <tr>
        <td bgColor="#f5f5f1" colspan="2" align="center">
            <asp:Button ID="btnAddOption" OnClick="btnAddOption_Click" Text="新 增" CssClass="button" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdateOption" OnClick="btnUpdateOption_Click" Text="更 新" CssClass="button" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" onclick="location.href='syndic_problemList.aspx?id=<%=Request.QueryString["pid"] %>'" />&nbsp;&nbsp;&nbsp;&nbsp;
            <object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object><input type="button" onclick="window.close()" value="关 闭" />
        </td>
    </tr>
</TABLE>


</td>
          </tr>
          <tr>
            <td colspan="3"><table width="690" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_4.gif" width="14" height="10"></td>
                  <td width="662" background="../img/tc_6.gif"></td>
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
