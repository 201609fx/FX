<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSimple.aspx.cs" Inherits="CompanyAdd_AddSimple" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
    <style>
.text-star-12 {
	font-family:"宋体";
	font-size: 12px;
	color: #ff0000;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="97%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top" align="left">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName" CssClass="main-text">企业数据简易添加</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="97%" align="center"></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
          <tr><td colspan="3"  height="10"></td></tr>
          <tr><td colspan="3" align="left">
<table width="97%" border="0" align="right" cellpadding="0" cellspacing="0" class="main-text">

                <tr> 
                  <td height="410" valign="top" background="../img/intro_body_5.gif"> 
                    <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td>&nbsp;<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label></td>
                      </tr>
                      <tr> 
                        <td align="left">
                        <table width="97%" border="0" align="center" cellpadding="1" cellspacing="1" class="main-text">
          <tr>
          <td  bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>企业名称(全称)</td>
          <td colspan="3" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCompany" Width="99%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">申请类型</td>
          <td bgColor="#f5f5f1">
          <asp:DropDownList runat="server" ID="ddlType" Width="120">
                 <asp:ListItem Text="初次申请" Value="1"></asp:ListItem>
                 <asp:ListItem Text="晋级申请" Value="2"></asp:ListItem>
                 </asp:DropDownList>
          </td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>经营地址</td>
          <td colspan="3" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtAddress" Width="99%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">联系人</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtContact" Width="97%"></asp:TextBox></td>
          </tr>
          <tr>
          <td bgcolor="#f9f9f0" width="12%" align="center">联系方式</td>
          <td bgColor="#f5f5f1" width="20%"><asp:TextBox runat="server" ID="txtPhone" Width="100"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="13%" align="center"><span class="text-star-12">*</span>证书号</td>
          <td bgColor="#f5f5f1" width="20%"><asp:TextBox runat="server" ID="txtCertNO" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="15%" align="center"></td>
          <td bgColor="#f5f5f1" width="20%">
          </td>
          </tr> 
       
         
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100" align="center"><span class="text-star-12">*</span>维修业务范围<br/></td>
          <td bgcolor="#f5f5f1" colspan="4">          
          <iframe id="FrameOperation" name="FrameOperation" height="100" src="<%=strOperation %>" width="97%" frameborder="0" scrolling="no"></iframe>
          </td>               
          </tr>
       
                          </table>
                           </td>
                      </tr>
                      <tr>
                      <td align="center"><asp:Label ID="Label1" runat="server" Text="需要添加的数据请确保添加成功，*号项为必填项，请填写完整再进行提交！" CssClass="text-star-12"></asp:Label></td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td align="center">
                         <%--<asp:Button ID="btnOK" runat="server" Text="保存并继续添加" OnClick="btnOK_Click" />--%>
                         <asp:Button ID="btnSum" runat="server" Text="提 交" OnClick="btnSum_Click" /></td>
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
                    </table></td>
                </tr>
                <tr> 
                  <td><img src="../img/intro_body_6.gif" width="787" height="10"></td>
                </tr>
              </table>
                      </td></tr>
                       </table>    
   
    </td>
  </tr>
</table>
    </form>
</body>
</html>
