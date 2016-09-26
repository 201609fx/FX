
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="default.ascx.cs" Inherits="Cert_default" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="lblSortName">证书查询</asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  企业公示</td>
                              <td width="13"><img src="../images/lb8.gif" width="13" height="32" /></td>
                            </tr>
                          </table></td>
                      </tr>
<tr><td class="text-b" style="cursor:hand" onclick="SetTabDisplay()"> &nbsp;&nbsp;隐藏/展开搜索条件 </td></tr>                      <tr>
                        <td align="center">
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
                <table width="680" cellSpacing="1" cellPadding="3" width="100%" border="0" class="text-wz" id="tabMySearch" style="display:none;">
              <tr>
                <td class="text-wz"  width="10%" align="right">企业名称：</td>
                <td  align="left" colspan="3"><asp:TextBox runat="server" ID="txtCompany" Width="98%"></asp:TextBox></td>
              </tr>
               <tr>
                <td class="text-wz"  width="10%" align="right">申请编号：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtMainSCNO" Width="95%"></asp:TextBox></td>
                  <td class="text-wz"  width="10%" align="right">记录编号：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtNoteNum" Width="95%"></asp:TextBox>
                </td>
             </tr>
              <tr>
                <td class="text-wz"  width="10%" align="right">原证书：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtOldCertNO" Width="95%"></asp:TextBox></td>
                  <td class="text-wz"  width="10%" align="right">新获证书：</td>
                <td width="40%" align="left"><asp:TextBox runat="server" ID="txtCertNO" Width="95%"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="text-wz"  width="10%" align="right">申请类型：</td>
                <td width="40%" align="left"> <asp:DropDownList runat="server" ID="ddlType" Font-Size="12px" Width="95%">
                <asp:ListItem Text='选择一个类型' Value=''></asp:ListItem>
                  <asp:ListItem Text='初次申请' Value='1'></asp:ListItem>
                    <asp:ListItem Text='晋级申请' Value='2'></asp:ListItem>
                </asp:DropDownList></td>
                  <td class="text-wz"  width="10%" align="right">证书状态：</td>
                <td width="40%" align="left">
                <asp:DropDownList runat="server" ID="ddlState" Font-Size="12px" Width="95%">
                <asp:ListItem Text='选择一个状态' Value='0'></asp:ListItem>
                    <asp:ListItem Text='待领' Value='1'></asp:ListItem>
                    <asp:ListItem Text='已发放' Value='2'></asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
               <tr>
                <td class="text-wz"  width="10%" align="right">申请日期：</td>
                <td align="left" colspan="3">从
            <cc1:DatePicker ID="dpFtime" runat="server" IsRequest="false" />至
            <cc1:DatePicker ID="dpTotime" runat="server" IsRequest="false"/></td>
            </tr>
            <tr>
                <td class="text-wz"  width="10%" align="right">发证日期：</td>
                <td align="left" colspan="3">从
            <cc1:DatePicker ID="dpCFtime" runat="server" IsRequest="false" />至
            <cc1:DatePicker ID="dpCTotime" runat="server" IsRequest="false"/></td>
            </tr>
               <tr > 
                <td colspan="4" align="center" >
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />&nbsp; </td>               
              </tr>  
               <tr bgcolor="#E7E2D6" height="1px">  
             <td colspan="4" height="1"></td>          
              </tr>
             <tr height="6"><td colspan="4" height="6"></td></tr>
            
            </table>            
            </td>
                      </tr>
                      <tr>
                        <td><table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                            <%--<tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>--%>
                            <tr>
                              <td height="8"></td>
                            </tr>
                            <tr>
                            <td>
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
			            <a class="link-03" href="default.aspx?m=../Cert/CertView&id=<%#((System.Data.DataRowView)Container.DataItem)["MainSCID"] %>">		                
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
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["MainSCTempID"].ToString()==""?"已发放":"待领证"%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="证书编号" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["CertNO"]%>
			            </ItemTemplate>
		            </asp:TemplateField>
	            </Columns>
            </asp:GridView>  </td>                           </tr>
                            <tr>
                              <td height="8"></td>
                            </tr>
                            <%--<tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>--%>
                            <tr>
                              <td height="35"><table width="680" border="0" cellspacing="0" cellpadding="0" class="text-hui-12">
                                  <tr>
                                    <td><%--<a class="link-blu-12" href="#">上一页</a> <a class="link-blu-12" href="#">1</a> <a class="link-blu-12" href="#">2</a> <a class="link-blu-12" href="#">3</a> <a class="link-blu-12" href="#">下一页</a>--%>
                                <cc1:aspnetpager id="AspNetPager1" AlwaysShow="true" NumericButtonType="Text" PagingButtonType="Image"  PageSize="20" ImagePath="../img/" class="link-blu-12" runat="server" 
                                  OnPageChanged="AspNetPager1_OnPageChanging"></cc1:aspnetpager>                                    </td>
                                    <td width="300" align="right"><asp:Label ID="lblNum" runat="server">共100条，分5页显示。</asp:Label></td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                      </tr>
</table>