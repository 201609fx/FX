<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_AddTopProblem.aspx.cs" Inherits="workaround_syndic_AddTopProblem" %>

<html >
<head runat="server">
    <title>无标题页</title>
           <script language="javascript" type="text/javascript">
   window.onload=function(){
   parent.window.document.getElementById("FrameAdd").height=window.document.body.scrollHeight;
   }
   </script>
<link href="../styles/style.css" rel="stylesheet" type="text/css"/>

</head>
<body>
    <form id="form1" runat="server">
  
    <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
        <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text" bgColor="#f5f5f1" height="100" > 
         <asp:Panel ID="pnlAll" runat="server">
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
        <td class="leftTitle" bgColor="#f9f9f0" width="20%">备 注</td>
        <td bgColor="#f5f5f1" width="80%" align="left"><asp:TextBox ID="txtRemark" runat="server" Width="90%" Height="50" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
         <tr><td align="center" colspan="2" >&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnOK" Text="确定" CssClass="button" runat="server" OnClick="btnAddT_Click" /></td></tr>
       </asp:Panel>   
       <tr><td colspan="2"></td></tr>    
</TABLE>

    </form>
</body>
</html>
