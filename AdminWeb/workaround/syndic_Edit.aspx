<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_Edit.aspx.cs" Inherits="workaround_syndic_Edit" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
       <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">      
          <tr> 
          <td colspan="3">&nbsp;</td>
            
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">评审</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
        <tr> 
          <td colspan="3">
      
      
      <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text">
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" width="15%"></td>
        <td bgColor="#f5f5f1" width="35%" align="left"></td>
          <td class="leftTitle" bgColor="#f9f9f0" width="15%"></td>
        <td bgColor="#f5f5f1" width="35%" align="left"></td>
    </tr>
      
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0">
            公司名称:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:Label runat="server" ID="lblName" CssClass="main-text"></asp:Label>
        </td>
    </tr>
    <tr>
      <td class="leftTitle" bgColor="#f9f9f0">
            申请书编号:</td>
        <td bgColor="#f5f5f1" align="left">
               <asp:Label runat="server" ID="lblNO" CssClass="main-text"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="#f9f9f0">
            考核总分:</td>
        <td bgColor="#f5f5f1" align="left">
         <asp:Label runat="server" ID="lblTotle" CssClass="main-text"></asp:Label>   
                 
        </td>
    </tr> 
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0">
            评审员:</td>
        <td bgColor="#f5f5f1" align="left">
               <asp:TextBox ID="txtSyndic" runat="server" Width="95%"></asp:TextBox>
        </td>
        <td class="leftTitle" bgColor="#f9f9f0">
            考核时间:</td>
        <td bgColor="#f5f5f1" align="left">
            <cc1:DatePicker ID="dpPStime" runat="server" />                 
        </td>
    </tr> 
    <tr>
        <td bgColor="#f5f5f1" colspan="4" align=center>
            <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" Class="button" id="btnBack" onclick="location.href='syndic.aspx'" />            
       
        </td>
    </tr>
    <tr height="6"></tr>
     <tr bgcolor="#E7E2D6"> 
                <td height="1" colspan="2" ></td>               
              </tr>                
</TABLE>            
      
      
            </td>
            </tr>           
              <tr> 
                <td height="6"></td>
                <td height="6"></td>
                <td height="6"></td>
              </tr>
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>
              <tr> 
                <td colspan="3"></td>
              </tr>
            </table>    
   
    </td>
  </tr>
</table>
    </form>
</body>
</html>
