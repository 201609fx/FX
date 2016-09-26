<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approveDetail.aspx.cs" Inherits="workaround_approveDetail" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
             <script language="javascript" >
               function OpenCheck(id)
                {
	                var features = 'width=800,height=700,scrollbars=yes,left=50,top=50,resizable=yes';
	                var winName = '企业报批申请';
	                var Url = 'approve_Print.aspx?id=' + id;
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">报批申请明细</asp:Label></td>
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
            企业名称</td>
        <td bgColor="#f5f5f1" align="left" colspan="3">
        <asp:Label runat="server" ID="lblCompany" CssClass="main-text"></asp:Label>
        </td>
    </tr>
    <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left" width="10%">
            评定分数</td>
        <td bgColor="#f5f5f1" align="left" width="40%">
               <asp:Label runat="server" ID="lblTotle" CssClass="main-text"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="#f9f9f0" align="left" width="10%">
            评定等级</td>
        <td bgColor="#f5f5f1" align="left" width="40%">
         <asp:Label runat="server" ID="lblCertNO" CssClass="main-text"></asp:Label>   
                 
        </td>       
    </tr> 
    <tr height="200">    
        <td class="leftTitle" bgColor="#f5f5f1" align="right" colspan="6">&nbsp;
            <table border="0" cellpadding="0" cellspacing="0"  bgColor="#f5f5f1" width="100%" class="main-text">
            <tr  bgColor="#f9f9f0" >
            <td align="left" colspan="2">深圳市协会秘书处意见:</td>
            </tr>
            <tr  bgColor="#f5f5f1" >
            <td align="left" colspan="2">&nbsp;&nbsp;<asp:Label runat="server" ID="txtSuggest" TextMode="MultiLine" Height="80" Width="98%"></asp:Label>              
            </td>
            </tr>
              <tr bgColor="#f5f5f1" Height="16"><td colspan="6"></td></tr>
            <tr bgColor="#f5f5f1" >
            <td align="right" colspan="2">  
                  会长:<asp:Label runat="server" ID="txtSuperintendent"  Width="120" CssClass="input-line">  </asp:Label>&nbsp;<asp:Label ID="dpSTime" runat="server" Width="120"/>&nbsp;&nbsp;
            </td>       
            </tr>           
            </table>                  
        </td>
    </tr>      
    <tr height="100">    
        <td class="leftTitle" bgColor="#f9f9f0" align="left">
            备&nbsp;&nbsp;&nbsp;注</td>
        <td bgColor="#f5f5f1" align="left" colspan="5">
        <asp:Label runat="server" ID="txtRemark" Width="100%" TextMode="MultiLine"></asp:Label>              
        </td>
    </tr>
    <tr>
        <td bgColor="#f5f5f1" colspan="6" align="center">
        <input type="button" id="btnPrint" value="打 印" onclick="OpenCheck('<%=Request.QueryString["id"] %>')" />
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


