<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertNOSearch.aspx.cs" Inherits="CertNO_CertNOSearch" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
<%@ Register Src="~/Control/WorkAroundTop.ascx" TagPrefix="cc1" TagName="WorkAroundTop" %>


<html  >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
             <script language="javascript" >
               function OpenPrint(id1,id2)
                {
	                var features = 'width=1000,height=700,scrollbars=yes,left=10,top=50,resizable=yes';
	                var winName = '评审表答案打印';
	                var Url = 'syndic_AnswerView.aspx?aid='+id2+'&mid='+id1;
	                var win = window.open(Url, winName, features);
	                win.focus();
                } 
                 function OpenDetailView(id1,id2)
                {
	                var features = 'width=900,height=800,scrollbars=yes,left=10,top=10,resizable=yes';
	                var winName = '明细查看';
	                var Url = '../workaround/FirstAuditingDetailMainSC.aspx?mid='+id1+'&tid='+id2;
	                var win = window.open(Url, winName, features);
	                win.focus();
                
                }
               function OpenView(id)
                {
	                var features = 'width=1000,height=400,scrollbars=yes,left=10,top=250,resizable=yes';
	                var winName = '投诉历史记录';
	                var Url = '../workaround/Complain_History.aspx?id='+escape(id);
	                var win = window.open(Url, winName, features);
	                win.focus();
                }   
                 function OpenDetail(id)
                {
	                var features = 'width=900,height=300,scrollbars=yes,left=10,top=200,resizable=yes';
	                var winName = '历史记录查看';
	                var Url = '../CertNO/CertHistory.aspx?id='+id;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }  
                function SetTabDisplay()
                {
                
                   if(tabMySearch.style.display=="none")
                   {
                      tabMySearch.style.display="block";
                   }
                   else
                   {
                      tabMySearch.style.display="none";
                   }
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
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">高级查询</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"><cc1:WorkAroundTop ID="WorkAroundTop1" runat="server" /></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3" class="text-b" style="cursor:hand" onclick="SetTabDisplay()" align="left">
           <table border="0" width="100%" align="center" cellpadding="0" cellspacing="0" class="main-text1">
           <tr>
           <td align="left" class="main-text">
        &nbsp;&nbsp;隐藏/展开搜索条件</td></tr>
           </table> </td></tr>
               
       <tr>
       <td colspan="3">
          <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text" id="tabMySearch">
            <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">企业名称：</td>
                <td bgColor="#f5f5f1"  align="left" colspan="3"><asp:TextBox runat="server" ID="txtCompany" Width="98%"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">申请编号：</td>
                <td bgColor="#f5f5f1" width="50%" align="left"><asp:TextBox runat="server" ID="txtMainSCNO" Width="95%"></asp:TextBox></td>
                  <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">记录编号：</td>
                <td bgColor="#f5f5f1" width="30%" align="left"><asp:TextBox runat="server" ID="txtNoteNum" Width="95%"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">原证书：</td>
                <td bgColor="#f5f5f1" width="50%" align="left"><asp:TextBox runat="server" ID="txtOldCertNO" Width="95%"></asp:TextBox></td>
                  <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">新获证书：</td>
                <td bgColor="#f5f5f1" width="30%" align="left"><asp:TextBox runat="server" ID="txtCertNO" Width="95%"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">证书等级：</td>
                <td bgColor="#f5f5f1" width="40%" align="left"><asp:DropDownList runat="server" ID="ddlCertLevel">
                <asp:ListItem Text="请选择等级" Value="0"></asp:ListItem>
                <asp:ListItem Text="一级" Value="A"></asp:ListItem>
                <asp:ListItem Text="二级" Value="B"></asp:ListItem>
                <asp:ListItem Text="三级" Value="C"></asp:ListItem>
                </asp:DropDownList></td>
                  <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">辖区：</td>
                <td bgColor="#f5f5f1" width="50%" align="left"><asp:DropDownList runat="server" ID="ddlAreaID" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">维修范围：</td>
                <td bgColor="#f5f5f1" width="30%" align="left" colspan="3">
                <asp:DropDownList runat="server" ID="ddlOperation" ></asp:DropDownList>
                </td>
                
            </tr>
             <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">申请类型：</td>
                <td bgColor="#f5f5f1" width="50%" align="left"> <asp:DropDownList runat="server" ID="ddlType" Font-Size="12px" Width="95%">
                <asp:ListItem Text='选择一个类型' Value=''></asp:ListItem>
                  <asp:ListItem Text='初次申请' Value='1'></asp:ListItem>
                    <asp:ListItem Text='晋级申请' Value='2'></asp:ListItem>
                </asp:DropDownList></td>
                  <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">申请状态：</td>
                <td bgColor="#f5f5f1" width="30%" align="left">
                <asp:DropDownList runat="server" ID="ddlState" Font-Size="12px" Width="95%">
                  <asp:ListItem Text='网上申请' Value='0'></asp:ListItem>
                    <asp:ListItem Text='书面资料审核' Value='1'></asp:ListItem>
                    <asp:ListItem Text='书面资料审核未通过' Value='11'></asp:ListItem>
                    <asp:ListItem Text='书面资料审核通过' Value='12'></asp:ListItem>
                    <asp:ListItem Text='现场评审' Value='2'></asp:ListItem>
                    <asp:ListItem Text='评审结论' Value='3'></asp:ListItem>
                    <asp:ListItem Text='处理通知' Value='4'></asp:ListItem>
                    <asp:ListItem Text='待审批' Value='5'></asp:ListItem>
                    <asp:ListItem Text='待领证' Value='6'></asp:ListItem>
                    <asp:ListItem Text='申请未通过' Value='7'></asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
               <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">申请日期：</td>
                <td bgColor="#f5f5f1" align="left" >从
            <cc1:DatePicker ID="dpFtime" runat="server" IsRequest="false" />至
            <cc1:DatePicker ID="dpTotime" runat="server" IsRequest="false"/></td>
              <%--<td class="leftTitle" bgColor="#f9f9f0"  align="right">特约维修品牌：</td>
                <td bgColor="#f5f5f1" align="left">
                <asp:DropDownList runat="server" ID="ddlBrand"></asp:DropDownList>
                </td>--%>
            </tr>
              
               <tr bgcolor="#f9f9f0"> 
                <td colspan="4" align="center" >
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />&nbsp; </td>               
              </tr>  
               <tr bgcolor="#E7E2D6" height="1px">  
             <td colspan="4" height="1"></td>          
              </tr>
             <tr height="6"><td colspan="4" height="6"></td></tr>
            
            </TABLE>
       </td>
       </tr>
 
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
			              <a class="link-02" href="javascript:OpenDetailView('<%#((System.Data.DataRowView)Container.DataItem)["MainSCID"]%>','<%#((System.Data.DataRowView)Container.DataItem)["type"]%>')">	               
		                 		                
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
		            <asp:TemplateField HeaderText="证书状态" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["MainSCTempID"].ToString()==""?"已发放":"待领证"%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            
		            <asp:TemplateField HeaderText="证书编号" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["CertNO"].ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <%--<asp:TemplateField HeaderText="投诉记录" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
			            <a class="link-02"  style="cursor:hand;" onclick="javascript:OpenView('<%#((System.Data.DataRowView)Container.DataItem)["Company"].ToString()%>')" title="点击查看投诉历史记录">
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["CNum"].ToString()%>
				            </a>
			            </ItemTemplate>
		            </asp:TemplateField>--%>
		            <asp:TemplateField HeaderText="申请次数" ItemStyle-Width="6%">
		                <ItemStyle HorizontalAlign="Center" />
			            <ItemTemplate>
			             <a class="link-02" href="javascript:OpenDetail('<%#((System.Data.DataRowView)Container.DataItem)["CertNO"]%>')" title="点击查看历史">  
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["MainNum"].ToString()%>
				              </a>
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

<%--       <asp:Panel runat="server" ID="pnlSee" Visible="false">
              <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text" id="tabSee" >
            <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">企业名称：</td>
                <td bgColor="#f5f5f1"  align="left" colspan="3"><asp:Label runat="server" ID="txtCompany1"></asp:Label>
                <asp:Label ID="lblMainSCID" Visible="false" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">申请编号：</td>
                <td bgColor="#f5f5f1" width="40%" align="left"><asp:Label runat="server" ID="txtMainSCNO1" ></asp:Label></td>
                  <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">证书编号：</td>
                <td bgColor="#f5f5f1" width="40%" align="left"><asp:Label runat="server" ID="lblCertNO"></asp:Label>
                </td>
            </tr>
             <tr>
                  <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="right">申请状态：</td>
                <td bgColor="#f5f5f1" width="40%" align="left">
                <asp:DropDownList runat="server" ID="ddlState1" Font-Size="12px" Width="95%">
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
                </td>
                 <td class="leftTitle" bgColor="#f9f9f0" width="10%" align="left" colspan="2"> </td>
            </tr>          
              
               <tr bgcolor="#f9f9f0"> 
                <td colspan="4" align="center" >                    
        <asp:Button ID="btnSee" runat="server" Text="查 看" OnClick="btnSee_Click" />&nbsp; </td>               
              </tr>  
               <tr bgcolor="#E7E2D6" height="1px">  
             <td colspan="4" height="1"></td>          
              </tr>
             <tr height="6"><td colspan="4" height="6"></td></tr>
            
            </TABLE>
            </asp:Panel>--%>