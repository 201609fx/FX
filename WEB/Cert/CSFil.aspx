<%@ Page Language="C#"  Theme="Pop" StylesheetTheme="Pop"  AutoEventWireup="true" CodeFile="CSFil.aspx.cs" Inherits="Cert_CSFil" %>
<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
<script language="javascript">
window.onload=function(){
   window.parent.document.getElementById("FrameCSFil").style.height = document.body.scrollHeight;
} 
</script>
</head>
<body>
    <form id="form1" runat="server"> <asp:GridView ID="gvCSFile" runat="server" Width="100%" BorderWidth="0" cellpadding="0"  BackColor="#979797" cellspacing="1"
	             style="font-size:12px;" AutoGenerateColumns="false"  OnRowCommand="gvCSFile_RowCommand" >
	         <HeaderStyle HorizontalAlign="center"  Height="23"  CssClass="bt-huihead" />
	            <RowStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center" />
	            <FooterStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" HorizontalAlign="Center"  />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="10%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#DataBinder.Eval(Container.DataItem, "ID").ToString()=="0"?"":(Container.DataItemIndex+1).ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		             
		      <asp:TemplateField HeaderText="目录" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="300">
			  <ItemTemplate>
			   <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>	
			      <asp:TemplateField HeaderText="份数" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			  <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>' Visible="false"></asp:Label>
			   <asp:Label ID="lblNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Num").ToString()%>' Visible="false"></asp:Label>
			  <asp:TextBox ID="txtNum" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Num")%>' Visible="true" Width="97%"></asp:TextBox>
			  </ItemTemplate>
			  </asp:TemplateField>			
			  <asp:TemplateField HeaderText="管理" FooterStyle-HorizontalAlign="Center" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
			  <ItemTemplate>  
			  <asp:LinkButton ID="lnkbtnEdit" CommandName="myedit" CommandArgument="<%#Container.DataItemIndex%>"  Visible="false" runat="server" Text="编辑" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtnOK" CommandName="ok" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID").ToString()+",,"+Container.DataItemIndex.ToString() %>' Visible='<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"&&(Container.DataItemIndex+1).ToString()=="1"%>'  runat="server" Text="确定"  ></asp:LinkButton>
			  </ItemTemplate>
			  
			  </asp:TemplateField>	      
	            </Columns>
            </asp:GridView>
    </form>
</body>
</html>
