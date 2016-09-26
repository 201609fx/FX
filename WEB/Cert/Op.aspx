<%@ Page Language="C#"  Theme="Pop" StylesheetTheme="Pop" AutoEventWireup="true" CodeFile="Op.aspx.cs" Inherits="Cert_Op" %>
<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
<script language="javascript">
window.onload=function(){
   window.parent.document.getElementById("FrameOp").style.height = document.body.scrollHeight;
} 
</script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:GridView ID="gvList"
          runat="server" AutoGenerateColumns="false" BorderWidth="0"  BackColor="#979797" cellspacing="1" ShowHeader="true" cellpadding="0" Width="100%" OnRowCommand="gvEList2_RowCommand" ShowFooter="true" >

	         <HeaderStyle HorizontalAlign="center"  Height="23"  CssClass="bt-huihead" />
	            <RowStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center" />
	            <FooterStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center"  />
	            <Columns>	    
	            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="50" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#DataBinder.Eval(Container.DataItem, "ID").ToString()=="0"?"":(Container.DataItemIndex+1).ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>	             
			   <asp:TemplateField HeaderText="特约维修业务品牌" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300">
			  <ItemTemplate>
			   <asp:Label ID="lblbrand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brand").ToString()%>' Visible="true"></asp:Label>
			 <asp:TextBox ID="txtBrand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brand").ToString()%>' Visible="false"></asp:TextBox>
			   
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFBrand" runat="server"  Width="300"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>		
			  <asp:TemplateField HeaderText="管理" FooterStyle-HorizontalAlign="Center" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
			  <ItemTemplate>  
			  <asp:LinkButton ID="lnkbtnEdit" CommandName="myedit" CommandArgument="<%#Container.DataItemIndex%>" Visible=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"%> runat=server Text="编辑" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtnOK" CommandName="ok" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()+",,"+Container.DataItemIndex.ToString() %> Visible=false runat=server Text="确定" OnLoad="EditCategory_Load" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtndel" CommandName="del" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' Visible=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"%> runat=server Text="删除" OnLoad="DeleteCategory_Load" ></asp:LinkButton>
			  </ItemTemplate>
			  <FooterTemplate>			  
			   <asp:LinkButton ID="lnkbtnadd" CommandName="myadd" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' Visible=true runat=server Text="添加" OnLoad="AddCategory_Load" ></asp:LinkButton>
			  </FooterTemplate>
			  
			  </asp:TemplateField>	                    
	            </Columns>
            </asp:GridView>
    </form>
</body>
</html>
