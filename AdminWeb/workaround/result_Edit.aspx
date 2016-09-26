<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result_Edit.aspx.cs" Inherits="workaround_result_Edit" %>


<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">评审结论</asp:Label></td>
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
        <td class="leftTitle" bgColor="#f9f9f0" width="10%"></td>
        <td bgColor="#f5f5f1" width="40%" align="left"></td>
          <td class="leftTitle" bgColor="#f9f9f0" width="10%"></td>
        <td bgColor="#f5f5f1" width="40%" align="left"></td>
    </tr>
      
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            公司名称:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:Label runat="server" ID="lblCompany" CssClass="main-text"></asp:Label>
        </td>
    </tr>
    <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="right">
            申请书编号:</td>
        <td bgColor="#f5f5f1" align="left">
               <asp:Label runat="server" ID="lblNO" CssClass="main-text"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            评审日期:</td>
        <td bgColor="#f5f5f1" align="left">
         <asp:Label runat="server" ID="lblPSTime" CssClass="main-text"></asp:Label>   
                 
        </td>
    </tr> 
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="right">
            维修范围:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
               <asp:Label runat="server" ID="lblOperation" CssClass="main-text"></asp:Label>    
        </td>
    </tr> 
    <tr>    
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            评审组意见:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:TextBox runat="server" ID="txtSuggest" TextMode="MultiLine" Height="80" Width="95%"></asp:TextBox>              
        </td>
    </tr>
       <tr>    
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            评审组结论:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:TextBox runat="server" ID="txtResult" TextMode="MultiLine" Height="50" Width="95%"></asp:TextBox>              
        </td>
    </tr>
    <tr>    
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            评审组成员:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:TextBox runat="server" ID="txtMember" Width="95%"></asp:TextBox>              
        </td>
    </tr>
        <tr>    
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            评审组长:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:TextBox runat="server" ID="txtLeader" Width="95%"></asp:TextBox>              
        </td>
    </tr>
    <tr>    
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            企业确认:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:TextBox runat="server" ID="txtCompConfirm" Width="95%"></asp:TextBox>              
        </td>
    </tr>
    <tr>
        <td bgColor="#f5f5f1" colspan="4" align=center>
            <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" Class="button" id="btnBack" onclick="location.href='result.aspx'" />
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

