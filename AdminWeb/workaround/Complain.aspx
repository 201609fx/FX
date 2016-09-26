<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complain.aspx.cs" Inherits="workaround_Complain" %>


<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>
<%@ Register Src="~/Control/WorkAroundTop.ascx" TagPrefix="cc1" TagName="WorkAroundTop" %>
 <script language="javascript" >
               function OpenPrint(id)
                {
	                var features = 'width=900,height=700,scrollbars=yes,left=50,top=50,resizable=yes';
	                var winName = '审批表打印';
	                var Url = 'Complain_Print.aspx?id=' + id;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }
</script>
<html>
<head runat="server">
    <title>无标题页</title>    
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">投诉列表</asp:Label></td>
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
       <tr><td colspan="3" align="right" valign="bottom" class="main-text"> 关键字:
       <asp:TextBox runat="server" ID="txtKey" Width="150"></asp:TextBox>
       <asp:DropDownList runat="server" ID="ddlState" Width="100">
       <asp:ListItem Value="0" Text="选择状态"></asp:ListItem>
       <asp:ListItem Value="1" Text="待确定"></asp:ListItem>
       <asp:ListItem Value="2" Text="立案"></asp:ListItem>
       <asp:ListItem Value="3" Text="结案"></asp:ListItem>
       </asp:DropDownList>
       <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />&nbsp;&nbsp;
           <asp:Button ID="btnAdd" runat="server" Text="添 加" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;</td></tr>
    
       
        <tr> 
          <td colspan="3">
         <asp:GridView ID="gvList" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand" >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="5%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <asp:Label ID="Rowkey" runat="server" Text='<%#Container.DataItemIndex+AspNetPager1.StartRecordIndex%>'>
				            </asp:Label>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="投诉人" ItemStyle-Width="23%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>			                
		                    <%#((System.Data.DataRowView)Container.DataItem)["Complainer"].ToString()%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>		           
		            <asp:TemplateField HeaderText="被投诉人" ItemStyle-Width="30%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#((System.Data.DataRowView)Container.DataItem)["BComplainer"].ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		               <asp:TemplateField HeaderText="投诉时间" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#getTime(((System.Data.DataRowView)Container.DataItem)["CTime"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		                  <asp:TemplateField HeaderText="状态" ItemStyle-Width="6%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#getCState(((System.Data.DataRowView)Container.DataItem)["InsertFlag"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		
		             <asp:TemplateField HeaderText="编辑" ItemStyle-Width="5%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>				      
			            <a class="link-02"  href="<%#((System.Data.DataRowView)Container.DataItem)["InsertFlag"].ToString()=="1"?"Complain_EditFirst.aspx":"Complain_Edit.aspx" %>?id=<%#((System.Data.DataRowView)Container.DataItem)["ID"]%>" >编辑</a>	
			            </ItemTemplate>
		            </asp:TemplateField>
		                         <asp:TemplateField HeaderText="管理" ItemStyle-Width="12%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>				      			            
				        <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton4" CommandName="unpass" Text="退回" OnLoad="LinkCategory_Load4"  ></asp:LinkButton>
				        <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton1" CommandName="passF" Text="立案" OnLoad="LinkCategory_Load1"  ></asp:LinkButton>
				         <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton2" CommandName="passS" Text="结案" OnLoad="LinkCategory_Load3" ></asp:LinkButton>		           

			            </ItemTemplate>
		            </asp:TemplateField>
		            
		             <asp:TemplateField HeaderText="打印" ItemStyle-Width="5%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>				      
			           			             <a class="link-02"  href="javascript:OpenPrint('<%#((System.Data.DataRowView)Container.DataItem)["ID"]%>')" >打印</a>
			           	</ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="删除" ItemStyle-Width="5%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>				      
			            <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton3" CommandName="del" Text="删除" OnLoad="LinkCategory_Load2"  ></asp:LinkButton>	
			            </ItemTemplate>
		            </asp:TemplateField>
	            </Columns>
            </asp:GridView>
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
                <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="main-text">
                      <td width="200" height="25"><asp:Label ID="lblNum" runat="server">共100条，分6页显示。</asp:Label></td>
                      <td align="right"><cc2:aspnetpager id="AspNetPager1" AlwaysShow="true" PageSize="20" FirstPageText="首页" PrevPageText="上一页"  NextPageText="下一页" LastPageText="尾页" runat="server" OnPageChanged="AspNetPager1_OnPageChanging"></cc2:aspnetpager></td>
                    </tr>
                  </table></td>
              </tr>
            </table>    
   
    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
