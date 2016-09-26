<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complain_Edit.aspx.cs" Inherits="workaround_Complain_Edit" %>
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">投诉受理</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center">
<a id="a41" href="javascript:setUrl('workaround/Complain.aspx')" class="link-04" >投诉列表</a></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
        <tr> 
          <td colspan="3">
      
      
    <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text">       
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" align="left">
            投诉日期</td>
        <td bgColor="#f5f5f1" align="left">
        <asp:Label runat="server" ID="lblCTime" CssClass="main-text"></asp:Label>
        </td>
         <td class="leftTitle" bgColor="#f9f9f0" align="left">
            投诉人</td>
        <td bgColor="#f5f5f1" align="left">
        <asp:Label runat="server" ID="lblComplainer" CssClass="main-text"></asp:Label>
        </td>
    </tr>
    <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left" width="10%">
            地址</td>
        <td bgColor="#f5f5f1" align="left" width="30%">
               <asp:Label runat="server" ID="lblCaddresstou" CssClass="main-text"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="#f9f9f0" align="left" width="10%">
            电话</td>
        <td bgColor="#f5f5f1" align="left" width="20%">
         <asp:Label runat="server" ID="lblTel" CssClass="main-text"></asp:Label>                   
        </td>  
          <td class="leftTitle" bgColor="#f9f9f0" align="left" width="10%">
            投诉方式</td>
        <td bgColor="#f5f5f1" align="left" width="20%">
         <asp:Label runat="server" ID="lblType" CssClass="main-text"></asp:Label>                  
        </td>        
    </tr> 
        <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">
            被投诉单位(人)</td>
        <td bgColor="#f5f5f1" align="left">
               <asp:Label runat="server" ID="lblBComplainer" CssClass="main-text"></asp:Label>    
        </td>
        <td class="leftTitle" bgColor="#f9f9f0" align="left">
            电话</td>
        <td bgColor="#f5f5f1" align="left">
         <asp:Label runat="server" ID="lblBCTel" CssClass="main-text"></asp:Label>                   
        </td>  
          <td class="leftTitle" bgColor="#f9f9f0" align="left">
            联系人</td>
        <td bgColor="#f5f5f1" align="left">
         <asp:Label runat="server" ID="lblBContact" CssClass="main-text"></asp:Label>                  
        </td>        
    </tr> 
      <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">
            地址</td>
        <td bgColor="#f5f5f1" align="left" colspan="5">
               <asp:Label runat="server" ID="lblBAddress" CssClass="main-text"></asp:Label>    
        </td>          
    </tr> 
       <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">案件名称</td>
        <td bgColor="#f5f5f1" align="left" colspan="5">
               <asp:Label runat="server" ID="lblName" CssClass="main-text"></asp:Label>    
        </td>          
    </tr> 
         <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">内容</td>
        <td bgColor="#f5f5f1" align="left" colspan="5" height="150">
               <asp:Label runat="server" ID="lblcontent" CssClass="main-text"></asp:Label>    
        </td>          
    </tr> 
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">处理意见</td>
        <td bgColor="#f5f5f1" align="left" colspan="5" height="80"> 
        <table border="0" cellpadding="0" cellspacing="0"  bgColor="#f5f5f1" width="100%" class="main-text">           
            <tr  bgColor="#f5f5f1" >
            <td align="left" colspan="2">&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtsuggest" TextMode="MultiLine" Height="60" Width="98%"></asp:TextBox>              
            </td>
            </tr>
             <tr bgColor="#f5f5f1" Height="16"><td colspan="6"></td></tr>
            <tr bgColor="#f5f5f1" >
            <td align="right" colspan="2">  
                  签名:<asp:TextBox runat="server" ID="txtsuggester"  Width="120" CssClass="input-line">  </asp:TextBox>&nbsp;<cc1:DatePicker ID="dpSTime" runat="server" Width="120"/>&nbsp;&nbsp;
            </td>       
            </tr>           
            </table>  
        </td>          
    </tr> 
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">领导批示</td>
        <td bgColor="#f5f5f1" align="left" colspan="2" height="80"> 
        <table border="0" cellpadding="0" cellspacing="0"  bgColor="#f5f5f1" width="100%" class="main-text">           
            <tr  bgColor="#f5f5f1" >
            <td align="left" colspan="2">&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtLSuggest" TextMode="MultiLine" Height="60" Width="98%"></asp:TextBox>              
            </td>
            </tr>
             <tr bgColor="#f5f5f1" Height="16"><td colspan="6"></td></tr>
            <tr bgColor="#f5f5f1" >
            <td align="left" colspan="2">  
                  签名:<asp:TextBox runat="server" ID="txtLeader"  Width="120" CssClass="input-line">  </asp:TextBox>&nbsp;<cc1:DatePicker ID="dpLTime" runat="server" Width="120"/>&nbsp;&nbsp;
            </td>       
            </tr>           
            </table>  
        </td>  
          <td bgColor="#f5f5f1" align="left" colspan="3" height="80"> 
        <table border="0" cellpadding="0" cellspacing="0"  bgColor="#f5f5f1" width="100%" class="main-text">           
            <tr  bgColor="#f5f5f1" >
            <td align="left" colspan="2">&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtLSuggest1" TextMode="MultiLine" Height="60" Width="98%"></asp:TextBox>              
            </td>
            </tr>
             <tr bgColor="#f5f5f1" Height="16"><td colspan="6"></td></tr>
            <tr bgColor="#f5f5f1" >
            <td align="left" colspan="2">  
                  签名:<asp:TextBox runat="server" ID="txtLeader1"  Width="120" CssClass="input-line">  </asp:TextBox>&nbsp;<cc1:DatePicker ID="dpLTime1" runat="server" Width="120"/>&nbsp;&nbsp;
            </td>       
            </tr>           
            </table>  
        </td>         
    </tr> 
    <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="left">处理结果</td>
        <td bgColor="#f5f5f1" align="left" colspan="5" height="150">
        <asp:TextBox runat="server" ID="txtResult" Width="100%" Height="60" TextMode="MultiLine"></asp:TextBox>     
        </td>          
    </tr>    
  
    <tr>
        <td bgColor="#f5f5f1" colspan="6" align="center">
        
            <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPass" Text="立 案" CssClass="button" runat="server" OnClick="btnPass_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" Class="button" id="btnBack" onclick="location.href='Complain.aspx'" />&nbsp;&nbsp;
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
