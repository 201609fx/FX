<%@ Page Language="C#" Theme="Pop" StylesheetTheme="Pop" AutoEventWireup="true" CodeFile="Operation.aspx.cs" Inherits="Cert_Operation" %>

<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
<script language="javascript">
window.onload=function(){
   window.parent.document.getElementById("FrameOperation").style.height = document.body.scrollHeight;
} 
function checkDrop(a,stra,strb)
{
var c=a.id.replace(stra,strb)
var b=window.document.getElementById(c);
 if(a.value=='abc')
 {   
   b.style.display='inline';
 }
 else
 {
    b.style.display='none'; 
 }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:GridView ID="gvList"
          runat="server" AutoGenerateColumns="false" BorderWidth="0"  BackColor="#979797" cellspacing="1" ShowHeader="true" cellpadding="0" Width="100%" OnRowCommand="gvEList2_RowCommand" ShowFooter="true" OnRowDataBound="gvList_RowDataBound" >

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
	            <asp:TemplateField HeaderText="维修业务" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350">        
		      
			  <ItemTemplate>
			   <asp:Label ID="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductName").ToString()%>' Visible="true"></asp:Label>
			 <asp:DropDownList ID="ddlSortID" runat="server"  Visible="false" Width="150" onchange="javascript:checkDrop(this,'ddlSortID','txtSortName')"></asp:DropDownList>
			 <asp:TextBox ID="txtSortName" runat="server" Width="150" style="display:none"></asp:TextBox>
			  </ItemTemplate>
			  <FooterTemplate>
			 <asp:DropDownList ID="ddlFSortID" runat="server"  Width="150" onchange="javascript:checkDrop(this,'ddlFSortID','txtFSortName')"></asp:DropDownList>
			 <asp:TextBox ID="txtFSortName" runat="server" Width="150" style="display:none"></asp:TextBox>
			  </FooterTemplate>
			  </asp:TemplateField>				    
			  <asp:TemplateField HeaderText="" FooterStyle-HorizontalAlign="Center" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center">
			  <ItemTemplate>  
			  <asp:LinkButton ID="lnkbtnEdit" CommandName="myedit" CommandArgument="<%#Container.DataItemIndex%>" Visible=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"%> runat=server Text="编辑" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtnOK" CommandName="ok" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()+",,"+Container.DataItemIndex.ToString() %> Visible=false runat=server Text="确定" OnLoad="EditCategory_Load" ></asp:LinkButton>
			   <asp:LinkButton ID="lnkbtndel" CommandName="del" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' Visible=<%#DataBinder.Eval(Container.DataItem, "ID").ToString()!="0"%> runat=server Text="删除" OnLoad="DeleteCategory_Load" ></asp:LinkButton>
			  </ItemTemplate>
			  <FooterTemplate>			  
			   <asp:LinkButton ID="lnkbtnadd" CommandName="myadd" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' Visible=true runat=server Text="确定" OnLoad="AddCategory_Load" ></asp:LinkButton>
			  </FooterTemplate>
			  
			  </asp:TemplateField>	                    
	            </Columns>
            </asp:GridView>
    </form>
</body>
</html>
