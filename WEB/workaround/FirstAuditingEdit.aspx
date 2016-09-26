<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstAuditingEdit.aspx.cs" Inherits="workaround_FirstAuditing" %>

 <html>
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form2" runat="server">
   <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">初审</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"><asp:Label id="lblTitle" runat="server">申请表审核</asp:Label></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
        <tr> 
          <td colspan="3">
          
          <table  width="100%" border="0" align="center" cellpadding="1" cellspacing="3" BackColor="#9D9DA1" class="main-text">
          <tr>
          <td  bgcolor="#f9f9f0">企业名称(全称)</td>
          <td colspan="7" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCompany" Width="100%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0">经营地址</td>
          <td colspan="5" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtAddress" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0">邮编</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCode" Width="100%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td width="10%" bgcolor="#f9f9f0">联系人</td>
          <td width="10%" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtContact" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%">固定电话</td>
          <td bgColor="#f5f5f1" width="10%"><asp:TextBox runat="server" ID="txtPhone" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%">移动电话</td>
          <td bgColor="#f5f5f1" width="20%"><asp:TextBox runat="server" ID="txtMobile" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%">传真</td>
          <td bgColor="#f5f5f1" width="20%"><asp:TextBox runat="server" ID="txtFax" Width="100%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0">法人代表</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtFrdb" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0">联系电话</td>
          <td bgColor="#f5f5f1"colspan="2"><asp:TextBox runat="server" ID="txtFtel" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0">营业面积</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtArea" Width="100%"></asp:TextBox></td>       
          </tr>
          
         <tr>
          <td bgcolor="#f9f9f0">企业总人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtAnum" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0">维修人员人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtMnum" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0">安装人员人数</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtBnum" Width="100%"></asp:TextBox></td>       
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100">维修业务范围(有特约维修业务的请注明)</td>
          <td bgcolor="#f9f9f0" colspan="6"><asp:TextBox runat="server" ID="txtOperation" Height="90" Width="100%" TextMode="MultiLine"></asp:TextBox></td>               
          </tr>
          
          </table>
          
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