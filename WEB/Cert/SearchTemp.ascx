<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchTemp.ascx.cs" Inherits="Cert_SearchTemp" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
            <table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                 <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="Label1">申请进度查询</asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  证书办理</td>
                              <td width="13"><img src="../images/lb8.gif" width="13" height="32" /></td>
                            </tr>
                          </table></td>
                      </tr>
                <tr> 
                  <td height="6"></td>
                </tr>
                <tr> 
                  <td><img src="../img/intro_body_1.gif" width="725" height="9"/></td>
                </tr>
                <%--<tr> 
                  <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="26"><img src="../img/intro_body_2.gif" width="26" height="33"></td>
                        <td width="12" background="../img/intro_body_3.gif"><img src="../img/ico3.gif" width="3" height="11"></td>
                        <td background="../img/intro_body_3.gif" class="bt-hui"><asp:Label runat="server" ID="lblSortName">申请进度查询</asp:Label></td>
                        <td width="22"><img src="../img/intro_body_4.gif" width="22" height="33"></td>
                      </tr>
                    </table></td>
                </tr>--%>
                <tr height="5"><td  background="../img/intro_body_5.gif"> &nbsp;</td></tr>
                <tr style="display:none;">
                <td class="text-b"  onclick="SetTabDisplay()"> &nbsp;&nbsp;隐藏/展开搜索条件 </td></tr>
                <script language="javascript">
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
                <tr> 
                  <td align="center" valign="top" background="../img/intro_body_5.gif">  
          <TABLE width="500" cellSpacing="1" cellPadding="3" border="0" class="text-wz" id="TABLE1">
            
                  <tr>
                  <td width="30%" align="right">记录编号：</td>
                <td width="70%" align="left"><asp:TextBox runat="server" ID="txtNoteNum" Width="250"></asp:TextBox>
                </td>
             </tr> 
               <tr > 
               <td>&nbsp;</td>
                <td  align="center" >
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  </td>               
              </tr>
             </TABLE> 
            <TABLE width="698" cellSpacing="1" cellPadding="3" border="0" class="text-wz" id="tabMySearch">
              <tr style="display:none;">
                <td class="text-wz"  width="10%" align="right">企业名称：</td>
                <td  align="left" colspan="3"><asp:TextBox runat="server" ID="txtCompany" Width="98%"></asp:TextBox></td>
              </tr>
               <tr style="display:none;">
                <td class="text-wz"  width="10%" align="right">申请编号：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtMainSCNO" Width="95%"></asp:TextBox></td>
             </tr>
          
              <tr style="display:none;">
                <td class="text-wz"   width="10%" align="right">原证书：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtOldCertNO" Width="95%"></asp:TextBox></td>
                  <td class="text-wz"  width="10%" align="right">新获证书：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtCertNO" Width="95%"></asp:TextBox>
                </td>
            </tr>
             <tr style="display:none;">
                <td class="text-wz"  width="10%" align="right">申请类型：</td>
                <td width="40%" align="left"> <asp:DropDownList runat="server" ID="ddlType" Font-Size="12px" Width="95%">
                <asp:ListItem Text='选择一个类型' Value=''></asp:ListItem>
                  <asp:ListItem Text='初次申请' Value='1'></asp:ListItem>
                    <asp:ListItem Text='晋级申请' Value='2'></asp:ListItem>
                </asp:DropDownList></td>
                  <td class="text-wz"  width="10%" align="right">申请进度：</td>
                <td width="40%" align="left">
                <asp:DropDownList runat="server" ID="ddlState" Font-Size="12px" Width="95%">
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
            </tr>
               <tr style="display:none;">
                <td class="text-wz"  width="10%" align="right">申请日期：</td>
                <td align="left" colspan="3">从
            <cc1:DatePicker ID="dpFtime" runat="server" IsRequest="false" />至
            <cc1:DatePicker ID="dpTotime" runat="server" IsRequest="false"/></td>
            </tr>
            <tr style="display:none;">
                <td class="text-wz"  width="10%" align="right">发证日期：</td>
                <td align="left" colspan="3">从
            <cc1:DatePicker ID="dpCFtime" runat="server" IsRequest="false" />至
            <cc1:DatePicker ID="dpCTotime" runat="server" IsRequest="false"/></td>
            </tr>
               
               <tr bgcolor="#E7E2D6" height="1px">  
             <td colspan="4" height="1"></td>          
              </tr>
             <tr height="6"><td colspan="4" height="6"></td></tr>
            
            </TABLE>
                    </td>
                </tr>
                
                
                <asp:Panel ID="search" runat="server" Visible="false">
        <tr> 
          <td background="../img/intro_body_5.gif" align="center">
         <asp:GridView ID="gvList" runat="server" Width="95%" BorderWidth="0" cellspacing="1" cellpadding="0"
	            BackColor="#999999" style="font-size:12px;" AutoGenerateColumns="false" >
	            <HeaderStyle HorizontalAlign="center"  Height="23"  CssClass="bt-huihead" />
	            <RowStyle BackColor="#FFFFFF" Height="23" CssClass="text-b" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="5%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <asp:Label ID="Rowkey" runat="server" Text='<%#Container.DataItemIndex+AspNetPager1.StartRecordIndex%>'>
				            </asp:Label>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="企业名称" ItemStyle-Width="40%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>	
			            <a class="link-03" href="default.aspx?m=CertTempView&id=<%#((System.Data.DataRowView)Container.DataItem)["ID"] %>">		                
		                    <%#((System.Data.DataRowView)Container.DataItem)["Company"]%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>		           
		            <asp:TemplateField HeaderText="申请书编号" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#getMainNO(((System.Data.DataRowView)Container.DataItem)["ID"].ToString(), ((System.Data.DataRowView)Container.DataItem)["Type"].ToString())%>&nbsp;&nbsp;
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="证书状态" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#getIstate(((System.Data.DataRowView)Container.DataItem)["state"].ToString(), ((System.Data.DataRowView)Container.DataItem)["InsertFlag"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="受理日期" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#getTime(((System.Data.DataRowView)Container.DataItem)["CheckTime"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
	            </Columns>
            </asp:GridView>
            </td>
            </tr> 
            <tr>
            <td background="../img/intro_body_5.gif" align="center">
            <table width="100%" cellspacing="0" border="0" cellpadding="0" class="text-wz" background="../img/intro_body_5.gif"> 
              <tr> 
                   <td>&nbsp;&nbsp;</td>
                             <td width="60%" align="left">
                             <cc1:aspnetpager id="AspNetPager1" AlwaysShow="true" NumericButtonType="Text" PagingButtonType="Image"  PageSize="20" ImagePath="../img/"  runat="server" 
                                  OnPageChanging="AspNetPager1_OnPageChanging"></cc1:aspnetpager></td>
                            <td width="40%" height="25"  align="right"><asp:Label ID="lblNum" runat="server">共100条，分6页显示。</asp:Label></td>
                            </tr> 
                            
             </table></td>
            </tr>
            </asp:Panel>
                <tr> 
                  <td><img src="../img/intro_body_6.gif" width="725" height="10"></td>
                </tr>
              </table>