﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Notes_Default" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>


<html  >
<head id="Head1" runat="server">
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
          <td>&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">公告</asp:Label></td>
        </tr>
		<tr> 
          <td height="8"></td>
        </tr>
        <tr> 
          <td>
         <asp:GridView ID="gvList" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand" >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#FFFFFF" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="5%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <asp:Label ID="Rowkey" runat="server" Text='<%#Container.DataItemIndex+AspNetPager1.StartRecordIndex%>'>
				            </asp:Label>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="标题" ItemStyle-Width="50%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
			                <a class="link-02" href="ShowNews.aspx?id=<%#((System.Data.DataRowView)Container.DataItem)["ID"]%>&pid=3" target="_blank">
		                    <%#((System.Data.DataRowView)Container.DataItem)["Title"]%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="点击次数" ItemStyle-Width="7%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
			                <%#((System.Data.DataRowView)Container.DataItem)["CLICKTIMES"]%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="发布时间" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["IssueDate"].ToString()).ToShortDateString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="发布人" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["USERNAME"]%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="操作" ItemStyle-Width="12%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				           <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="lnkbtnEdit" CommandName="edit1" Text="编辑" >编辑</asp:LinkButton>
				           <asp:LinkButton runat="server" CssClass="link-02" CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="lnkbtnDel" CommandName="del1" Text="删除"></asp:LinkButton>
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
    </form>
</body>
</html>
