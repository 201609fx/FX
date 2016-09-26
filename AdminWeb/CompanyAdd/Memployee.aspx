<%@ Page Language="C#" Theme="Pop" StylesheetTheme="Pop"  AutoEventWireup="true" CodeFile="Memployee.aspx.cs" Inherits="Cert_Memployee" %>
<script language="javascript">
window.onload=function(){
   window.parent.document.getElementById("FrameMemployee").style.height = document.body.scrollHeight;
} 
function checkDrop(a,stra,strb)
{
var c=a.id.replace(stra,strb)
var b=window.document.getElementById(c);
 if(a.value=='abc')
 {   
   b.style.display='inline';   
   window.parent.document.getElementById("FrameMemployee").style.height = document.body.scrollHeight;
 }
 else
 {
    b.style.display='none';     
   window.parent.document.getElementById("FrameMemployee").style.height = document.body.scrollHeight;
 }
}
</script>
<html>
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:GridView ID="gvMemployee" runat="server" AutoGenerateColumns="false" BorderWidth="0" BackColor="#979797" cellspacing="1" cellpadding="0" Width="100%" OnRowCommand="gvMemployee_RowCommand" ShowHeader="true"  ShowFooter="true" OnRowDataBound="gvList_RowDataBound"  >
	          <HeaderStyle HorizontalAlign="center"  Height="23"  CssClass="bt-huihead" />
	            <RowStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center" />
	            <FooterStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center"  />
			 
			  <Columns>	
			
			 <asp:TemplateField  HeaderText="姓名" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100">
			 <ItemTemplate>
			 <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' Width="90"></asp:Label>
			  <asp:TextBox ID="txtName" runat="server" Width="97%" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' Visible="false" ></asp:TextBox>
			</ItemTemplate>
			 <FooterTemplate>
			  <asp:TextBox ID="txtFName" runat="server" Width="97%"></asp:TextBox>
			  </FooterTemplate>
			</asp:TemplateField> 			 
			  <asp:TemplateField HeaderText="学历" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			  <asp:Label ID="lblEducational" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "educational")%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtEducational" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "educational")%>' Visible="false"   Width="97%" ></asp:TextBox>			  
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFEducational" runat="server"  Width="97%" ></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>	
			  <asp:TemplateField HeaderText="岗位" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblEposition" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Eposition").ToString()%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtEposition" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Eposition")%>' Visible="false"  Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFEposition" runat="server"   Width="97%"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>	
			  
	            <asp:TemplateField HeaderText="证书名" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250">        
		      
			  <ItemTemplate>
			   <asp:Label ID="lblCertName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dictCertName").ToString()%>' Visible="true"></asp:Label>
			 <asp:DropDownList ID="ddlCertName" runat="server"  Visible="false" Width="150" onchange="javascript:checkDrop(this,'ddlCertName','txtCertName')"></asp:DropDownList>
			 <asp:TextBox ID="txtCertName" runat="server" Width="100" style="display:none" Text='<%# DataBinder.Eval(Container.DataItem, "CertName").ToString()%>'></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			 <asp:DropDownList ID="ddlFCertName" runat="server"  Width="150" onchange="javascript:checkDrop(this,'ddlFCertName','txtFCertName')"></asp:DropDownList>
			 <asp:TextBox ID="txtFCertName" runat="server" Width="150" style="display:none"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>	
			  <asp:TemplateField HeaderText="证书编号" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblcertNO" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "certNO").ToString()%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtcertNO" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "certNO")%>' Visible="false"    Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFcertNO" runat="server" Width="100%"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>		
			  <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblremark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "remark").ToString()%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtremark" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "remark")%>' Visible="false"  Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFremark" runat="server"  Width="97%"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>			
			  <asp:TemplateField HeaderText="管理" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120">
			  <ItemTemplate>  
			  <asp:LinkButton ID="lnkbtnEdit" CommandName="myedit" CommandArgument="<%#Container.DataItemIndex%>" Visible=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"%> runat=server Text="编辑" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtnOK" CommandName="ok" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()+",,"+Container.DataItemIndex.ToString()%> Visible=false runat=server Text="确定" OnLoad="EditCategory_Load" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtndel" CommandName="del" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' Visible=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"%> runat=server Text="删除" OnLoad="DeleteCategory_Load" ></asp:LinkButton>
			  </ItemTemplate>
			  <FooterTemplate>			  
			   <asp:LinkButton ID="lnkbtnadd" CommandName="myadd" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' Visible=true runat=server Text="添加" OnLoad="AddCategory_Load" ></asp:LinkButton>
			  </FooterTemplate>
			  
			  </asp:TemplateField>	
			 </Columns>			 
			 </asp:GridView>
			  <table border="0" cellpadding="0" cellspacing="0" bgColor="#f5f5f1">
			 <tr height="20" bgColor="#f5f5f1">
			 <td bgColor="#f5f5f1" width="100%">&nbsp;</td>
			 </tr>
			 </table>
		
    </form>
</body>
</html>
