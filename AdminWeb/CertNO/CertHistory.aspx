<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertHistory.aspx.cs" Inherits="CertNO_CertHistory" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
<html>
<head runat="server">
    <title>历史信息</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
        
          <script language="javascript" >
               function OpenView(id)
                {
	                var features = 'width=1000,height=400,scrollbars=yes,left=10,top=250,resizable=yes';
	                var winName = '投诉历史记录';
	                var Url = '../workaround/Complain_History.aspx?id='+escape(id);
	                var win = window.open(Url, winName, features);
	                win.focus();
                }   
                
                
                 function OpenDetail(id1,id2)
                {
	                var features = 'width=900,height=800,scrollbars=yes,left=10,top=10,resizable=yes';
	                var winName = '明细查看';
	                var Url = '../workaround/FirstAuditingDetailMainSC.aspx?mid='+id1+'&tid='+id2;
	                var win = window.open(Url, winName, features);
	                win.focus();
                
                }             
               
</script>
</head>
<body>
    <form id="form1" runat="server">
           <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">      
          <tr> 
          <td colspan="3">&nbsp;</td>
            
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">历史信息</asp:Label></td>
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
		            <asp:TemplateField HeaderText="企业名称" ItemStyle-Width="20%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>	
			              <a class="link-02" href="javascript:OpenDetail('<%#((System.Data.DataRowView)Container.DataItem)["MainSCID"]%>','<%#((System.Data.DataRowView)Container.DataItem)["type"]%>')">	               
		                 		                
		                    <%#((System.Data.DataRowView)Container.DataItem)["Company"]%>
		                    </a>	
			            </ItemTemplate>
		            </asp:TemplateField>		           
		            <asp:TemplateField HeaderText="申请书编号" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#getMainNO(((System.Data.DataRowView)Container.DataItem)["ID"].ToString(), ((System.Data.DataRowView)Container.DataItem)["Type"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="证书编号" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["CertNO"].ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>		            
		            <asp:TemplateField HeaderText="投诉记录" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
			            <a class="link-02"  style="cursor:hand;" onclick="javascript:OpenView('<%#((System.Data.DataRowView)Container.DataItem)["Company"].ToString()%>')" title="点击查看投诉历史记录">
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["CNum"].ToString()%>
				            </a>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="申请次数" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["MainNum"].ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="获证时间" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            &nbsp;<%#getTime(((System.Data.DataRowView)Container.DataItem)["CreateTime"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="操作" ItemStyle-Width="15%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate> 
			            <asp:DropDownList runat="server" ID="ddlState">			            
                <asp:ListItem Text='选择一个状态' Value=''></asp:ListItem>
                  <asp:ListItem Text='申请' Value='0'></asp:ListItem>
                    <asp:ListItem Text='初审' Value='1'></asp:ListItem>
                    <asp:ListItem Text='初审未通过' Value='11'></asp:ListItem>
                    <asp:ListItem Text='初审通过' Value='12'></asp:ListItem>
                    <asp:ListItem Text='评审' Value='2'></asp:ListItem>
                    <asp:ListItem Text='结论' Value='3'></asp:ListItem>
                    <asp:ListItem Text='通知' Value='4'></asp:ListItem>
                    <asp:ListItem Text='待审批' Value='5'></asp:ListItem>
                    <asp:ListItem Text='待领证' Value='6'></asp:ListItem>
			            </asp:DropDownList>
			             <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["MainSCID"].ToString()+",,"+(Container.DataItemIndex).ToString()%>' ID="LinkButton2" CommandName="see" Text="查看" ></asp:LinkButton>
			         	
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
                      <td align="right"><cc1:aspnetpager id="AspNetPager1" AlwaysShow="true" PageSize="20" FirstPageText="首页" PrevPageText="上一页"  NextPageText="下一页" LastPageText="尾页" runat="server" OnPageChanged="AspNetPager1_OnPageChanged"></cc1:aspnetpager></td>
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
