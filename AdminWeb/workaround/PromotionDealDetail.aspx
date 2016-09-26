<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionDealDetail.aspx.cs" Inherits="workaround_PromotionDealDetail" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
                     <script language="javascript" >
               function OpenPrint(id)
                {
	                var features = 'width=800,height=700,scrollbars=yes,left=50,top=50,resizable=yes';
	                var winName = '评审结论';
	                var Url = 'PromotionDeal_print.aspx?id=' + id;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }
</script>
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">通知书明细</asp:Label></td>
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
        <td class="leftTitle" bgColor="#f9f9f0" align="left">
            公司名称</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:Label runat="server" ID="lblCompany" CssClass="main-text"></asp:Label>
        </td>
    </tr>
     <tr>
        <td class="leftTitle" bgColor="#f9f9f0" align="left">
            企业地址</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:Label runat="server" ID="lblAddress" CssClass="main-text"></asp:Label>
        </td>
    </tr>
    <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left" width="15%">
            电话号码</td>
        <td bgColor="#f5f5f1" align="left" width="35%">
               <asp:Label runat="server" ID="lblTel" CssClass="main-text"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="#f9f9f0" align="left" width="15%">
            联系人</td>
        <td bgColor="#f5f5f1" align="left" width="35%">
         <asp:Label runat="server" ID="lblcontact" CssClass="main-text"></asp:Label>   
                 
        </td>
    </tr> 
   
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">
           企业等级证书号</td>
        <td bgColor="#f5f5f1" align="left" >
               <asp:Label runat="server" ID="lblOldCertNO" CssClass="main-text"></asp:Label>    
        </td>
          <td class="leftTitle" bgColor="#f9f9f0" align="left">
           企业技术等级</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
               <asp:Label runat="server" ID="lblLevel" CssClass="main-text"></asp:Label>    
        </td>
    </tr>
    
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">
           现场评审日期</td>
        <td bgColor="#f5f5f1" align="left" >
               <asp:Label runat="server" ID="lblPSTime" CssClass="main-text"></asp:Label>    
        </td>
          <td class="leftTitle" bgColor="#f9f9f0" align="left">
           评审人员</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
               <asp:Label runat="server" ID="LblPS" CssClass="main-text"></asp:Label>    
        </td>
    </tr> 
    <tr>    
        <td class="leftTitle" bgColor="#f5f5f1" align="right" colspan="6">&nbsp;
            <table border="0" cellpadding="0" cellspacing="0"  bgColor="#f5f5f1" width="100%" class="main-text">
            <tr  bgColor="#f9f9f0" >
            <td align="left">现场评审结论:</td>
            </tr>
            <tr  bgColor="#f5f5f1" >
            <td align="left">&nbsp;&nbsp;<asp:Label runat="server" ID="txtResult" ></asp:Label>              
            </td>
            </tr>
              <tr bgColor="#f5f5f1" Height="16"><td colspan="6"></td></tr>
            <tr bgColor="#f5f5f1" >
            <td align="right">  
                  签名:<asp:TextBox runat="server" ID="txtLeader"  Width="120" CssClass="input-line">  </asp:TextBox>
            </td>
            </tr>
            <tr bgColor="#f5f5f1">
             <td align="right">  
                  日期:<asp:Label  ID="dpLTime" runat="server" Width="120"/>
            </td>
            </tr>
            </table>                  
        </td>
    </tr>
       
    <tr>
        <td bgColor="#f5f5f1" colspan="6" align=center>
            <input type="button" value="打印" Class="button" id="btnPrint" onclick="OpenPrint('<%=Request.QueryString["id"] %>')" />
        </td>
    </tr>
    <tr height="6"></tr>
     <tr bgcolor="#E7E2D6"> 
                <td height="1" colspan="6" ></td>               
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
