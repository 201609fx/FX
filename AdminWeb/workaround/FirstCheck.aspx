﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstCheck.aspx.cs" Inherits="workaround_FirstCheck" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>
<%@ Register Src="~/Control/WorkAroundTop.ascx" TagPrefix="cc1" TagName="WorkAroundTop" %>


<html  >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
     <script language="javascript" >
               function OpenCheck(id1,id2)
                {
	                var features = 'width=600,height=400,scrollbars=no,left=250,top=250,resizable=yes';
	                var winName = '初审记录';
	                var Url = 'FirstCheck_Pop.aspx?mid=' + id1+'&tid='+id2;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }
                function OpenPrint(id1,id2)
                {
	                var features = 'width=640,height=700,scrollbars=yes,left=250,top=50,resizable=yes';
	                var winName = '初审记录打印';
	                var Url = 'FirstCheckPrint.aspx?mid='+id1+'&tid='+id2;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }
                
                function OpenDetail(id1,id2)
                {
	                var features = 'width=640,height=400,scrollbars=yes,left=50,top=50,resizable=yes';
	                var winName = '报批申请表明细';
	                var Url = 'FirstCheckDetail.aspx?mid='+id1+'&tid='+id2;
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">书面资料审核</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"><cc1:WorkAroundTop ID="WorkAroundTop1" runat="server" /></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
         <tr><td colspan="3" > 
       <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
       <tr>
       <td align="right" valign="bottom">
             申请时间范围:
       <asp:TextBox runat="server" ID="tbxDataStart" Width="80"></asp:TextBox>~
           <asp:TextBox runat="server" ID="tbxDataEnd" Width="80"></asp:TextBox>
            公司名称:
       <asp:TextBox runat="server" ID="txtKey" Width="150"></asp:TextBox>
       <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />&nbsp;&nbsp;</td>
       </tr>
       </table>
         </td></tr>
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
		            <asp:TemplateField HeaderText="企业名称" ItemStyle-Width="50%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>	
			             <a class="link-02" href="javascript:OpenDetail('<%#((System.Data.DataRowView)Container.DataItem)["ID"] %>','<%#((System.Data.DataRowView)Container.DataItem)["type"] %>')">	                
		                 	                
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
		            <asp:TemplateField HeaderText="状态" ItemStyle-Width="12%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#getState(((System.Data.DataRowView)Container.DataItem)["state"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="审核" ItemStyle-Width="4%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>		
			            <a class="link-02" style="cursor:hand"  id="UnPass" onclick="OpenCheck('<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>','<%# ((System.Data.DataRowView)Container.DataItem)["Type"] %>')">审核</a>					          
			               </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="管理" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate> <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="lnkbtnEdit" CommandName="pass" Text="合格" OnLoad="LinkCategory_Load" ></asp:LinkButton>
				              <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton1" CommandName="unpass" Text="不合格" OnLoad="LinkCategory_Load1" ></asp:LinkButton>
				       </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="打印" ItemStyle-Width="4%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>			            			              
			            <a class="link-02" style="cursor:hand"  id="A1" onclick="OpenPrint('<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>','<%# ((System.Data.DataRowView)Container.DataItem)["Type"] %>')">打印</a>	
			            
			               </ItemTemplate>
		            </asp:TemplateField>
		            
		            <asp:TemplateField HeaderText="完成" ItemStyle-Width="4%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>
			            			              
			                    <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton2" CommandName="set" Text="完成" OnLoad="LinkCategory_Load2" ></asp:LinkButton>	
			            
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
                      <td align="right"><cc2:aspnetpager id="AspNetPager1" AlwaysShow="true" PageSize="20" FirstPageText="首页" PrevPageText="上一页"  NextPageText="下一页" LastPageText="尾页" runat="server" OnPageChanged="AspNetPager1_OnPageChanged"></cc2:aspnetpager></td>
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
