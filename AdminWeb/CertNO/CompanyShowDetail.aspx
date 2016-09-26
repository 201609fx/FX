<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyShowDetail.aspx.cs" Inherits="CertNO_CompanyShowDetail" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">领证信息</asp:Label></td>
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
            证书编号:</td>
        <td bgColor="#f5f5f1" align="left">
         <asp:Label runat="server" ID="lblCertNO" CssClass="main-text"></asp:Label>   
                 
        </td>
    </tr> 
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="right">
            有效期限:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3" class="main-text">
              <asp:Label ID="dpStartTime" runat="server" />至 <asp:Label runat="server" ID="dpEndTime" />
        </td>
    </tr> 
    <tr>    
        <td class="leftTitle" bgColor="#f9f9f0" align="right">
            领证人:</td>
        <td bgColor="#f5f5f1" align="left" colspan="3" class="main-text">
        <asp:Label runat="server" ID="txtLZR"  Width="150"></asp:Label>              
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

