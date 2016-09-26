<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstCheck_Pop.aspx.cs" Inherits="workaround_FirstCheck_Pop" %>

<html>
<head><link href="../styles/style.css" rel="stylesheet" type="text/css">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>初审记录</title>
<script language="javascript">
function setchk(a)
{
var s=a.id;
s=s.replace("chk1", "chk2");
if(s==a.id)
{
s=s.replace("chk2", "chk1");
}
document.getElementById(s).checked=!(a.checked);

}
</script>
</head>

<body>
<form id="Form1" name="form1" runat="server">
  <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="13"></td>
    </tr>
	<tr>
      <td><table width="570" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="570" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_1.gif" width="14" height="29"></td>
                  <td background="../img/tc_3.gif" class="body-bt" align="left">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="body-bt">
                  <tr>
                  <td align="left">申请书编号:<asp:Label runat="server" ID="lblMainSCNO"></asp:Label></td>
                  <td align="right">编号:<asp:Label runat="server" ID="lblNoteNO"></asp:Label></td>
                  </tr>
                  </table>

                  </td>
                  <td width="14" align="right" class="body-bt"  ><img src="../img/tc_2.gif" width="14" height="29"></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td bgcolor="#F0EEE9"><table width="542" border="0" align="center" cellpadding="0" cellspacing="3" class="main-text">
                <tr>
                  <td  width="15%">&nbsp;企业名称:</td>
                  <td  bgColor="#f5f5f1" ><asp:Label runat="server" ID="lblCompany"></asp:Label></td>
                </tr>
             
              <tr>
                  <td colspan="2">
                  <asp:GridView ID="gvList" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="10%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%# Container.DataItemIndex+1%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <asp:BoundField ItemStyle-Width="45%" HeaderText="项目" DataField="Name" />		           
		               <asp:TemplateField HeaderText="提交情况">
			            <ItemStyle Width="25%" HorizontalAlign="center" />
			            <ItemTemplate>
			            <table  border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
			            <tr>
			            <td onclick=""><asp:CheckBox ID="chk1"  runat="server"  Checked='<%#((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"?true:false %>' onclick="setchk(this)"/>
                 已<%#((System.Data.DataRowView)Container.DataItem)["des"]%></td>
			            <td onclick=""><asp:CheckBox ID="chk2"  runat="server" Checked='<%#((System.Data.DataRowView)Container.DataItem)["IsCheck"].ToString()=="1"?false:true %>' onclick="setchk(this)" />未<%#((System.Data.DataRowView)Container.DataItem)["des"]%>
                         </td>
			            </tr>
			            </table>
			           
			            </ItemTemplate>
		            </asp:TemplateField> 
		               <asp:BoundField ItemStyle-Width="25%" HeaderText="初审情况" DataField="Remark" />         
	            </Columns>
            </asp:GridView>
                  </td>
                </tr>
              </table></td>
          </tr>
         
          <tr>
          <td align="center" bgcolor="#F0EEE9">
              <asp:Button ID="btnOK" runat="server" Text="合格" OnClick="btnOK_Click" />&nbsp;&nbsp;
              <asp:Button ID="btnUnPass" runat="server" Text="不合格" OnClick="btnUnPass_Click"  />&nbsp;&nbsp;<object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object><input type="button" onclick="window.close()" value="关闭" /></td>
          </tr>
          <tr>
            <td><table width="570" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_4.gif" width="14" height="10"></td>
                  <td width="542" background="../img/tc_6.gif"></td>
                  <td width="14"><img src="../img/tc_5.gif" width="14" height="10"></td>
                </tr>
              </table></td>
          </tr>
        </table></td>
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
  </table>
</form>
</body>
</html>
