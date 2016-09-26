<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_problemAdd.aspx.cs" Inherits="workaround_syndic_problemAdd" %>

<html >
<head runat="server">
    <title>无标题页</title>
   <link href="../styles/style.css" rel="stylesheet" type="text/css">
   <script language="javascript">
   window.onload=function(){
   parent.window.document.getElementById("FrameProblem").height=window.document.body.scrollHeight;
   }
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="plQuestion" runat="server" Visible="false">
<TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text">
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" width="20%">题目标题<asp:Label ID="lblProblemID" runat=server Visible=false></asp:Label></td>
        <td bgColor="#f5f5f1" width="80%" align="left"><asp:TextBox ID="txtProblemContent" runat=server Width="90%" Height="50" TextMode=MultiLine></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" width="20%">总&nbsp;&nbsp;&nbsp;分</td>
        <td bgColor="#f5f5f1" width="80%" align="left"><asp:TextBox ID="txtTotle" runat="server" Width="90%" ></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" width="20%">备&nbsp;&nbsp;&nbsp;注</td>
        <td bgColor="#f5f5f1" width="80%" align="left"><asp:TextBox ID="txtRemark" runat=server Width="90%" Height="50" TextMode=MultiLine></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0">题目类型</td>
        <td bgColor="#f5f5f1" align="left">
            <asp:RadioButtonList ID="rdoltProblemType" runat="server" RepeatColumns="6" CssClass="main-text">
                <asp:ListItem Selected=True Value="1" Text="单选题"></asp:ListItem>
                <asp:ListItem Value="2" Text="多选题"></asp:ListItem>
                <asp:ListItem Value="3" Text="单行填空"></asp:ListItem>
                <asp:ListItem Value="4" Text="多行填空"></asp:ListItem>
                <asp:ListItem Value="5" Text="单选＋填空"></asp:ListItem>
                <asp:ListItem Value="6" Text="多选＋填空"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td bgColor="#f5f5f1" colspan="2" align=Center>
          &nbsp;&nbsp;
            <asp:Button ID="btnUpdateProblem" OnClick="btnUpdateProblem_Click" Text="确 定" CssClass="button" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDeleteProblem" OnClick="btnDeleteProblem_Click" Text="返 回" CssClass="button" runat="server" />
        </td>
    </tr>
</TABLE>
</asp:Panel>
    </form>
</body>
</html>
