<%@ Page Language="C#" Theme="Pop" StylesheetTheme="Pop"  AutoEventWireup="true" CodeFile="Elist2.aspx.cs" Inherits="Cert_Elist2" %>


<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
<script language="javascript">
window.onload=function(){
   window.parent.document.getElementById("FrameEList2").style.height = document.body.scrollHeight;
} 
</script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:GridView ID="gvElist2"
          runat="server" AutoGenerateColumns="false" BorderWidth="0"  BackColor="#979797" cellspacing="1" ShowHeader="false" cellpadding="0" Width="100%" OnRowCommand="gvEList2_RowCommand" ShowFooter="true" >

	         <HeaderStyle HorizontalAlign="center"  Height="23"  CssClass="bt-huihead" />
	            <RowStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center" />
	            <FooterStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center"  />
	            <Columns>	
	            <asp:TemplateField HeaderText="名称" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="170">
			  <ItemTemplate>
			   <asp:Label ID="lbldes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "des").ToString()%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtdes" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "des")%>' Visible="false"  Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFdes" runat="server" Width="97%"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>	
			       <asp:TemplateField HeaderText="型号" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblModel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Model").ToString()%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtModel" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Model")%>' Visible="false" Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFModel" runat="server" Width="97%"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>
			      <asp:TemplateField HeaderText="数量" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			   <asp:Label ID="lblNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Num").ToString()=="0"?"":DataBinder.Eval(Container.DataItem, "Num").ToString()%>' Visible="true"></asp:Label>
			  <asp:TextBox ID="txtNum" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Num")%>' Visible="false" Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			  <asp:TextBox ID="txtFNum" runat="server"  Width="97%"></asp:TextBox>
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
