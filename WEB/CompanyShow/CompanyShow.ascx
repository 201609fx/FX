<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompanyShow.ascx.cs" Inherits="CompanyShow_CompanyShow" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="lblSortName">获证企业公示</asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  企业公示</td>
                              <td width="13"><img src="../images/lb8.gif" width="13" height="32" /></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td align="center">
                
                <table width="680" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                <td class="text-wz"  width="10%" align="right" height="25px" valign="bottom">企业名称：</td>
                <td  align="left" width="20%"><asp:TextBox runat="server" ID="txtCompany" Width="95%"></asp:TextBox></td>
                 <td class="text-wz"  width="10%" align="right" valign="bottom">证书等级：</td>
                 <td class="text-wz"  align="left" colspan="2">&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlLevel" Width="120">
                 <asp:ListItem Text="不选择" Value="0"></asp:ListItem>
                 <asp:ListItem Text="一级" Value="A"></asp:ListItem>
                 <asp:ListItem Text="二级" Value="B"></asp:ListItem>
                 <asp:ListItem Text="三级" Value="C"></asp:ListItem>
                 </asp:DropDownList></td>
              </tr>
              <tr>
                  <td class="text-wz"  width="10%" align="right" valign="bottom" height="25px">证书号：</td>
                <td width="20%" align="left"><asp:TextBox runat="server" ID="txtCertNO" Width="95%"></asp:TextBox></td>
                <td class="text-wz"  width="10%" align="right" valign="bottom">发证日期：</td>
                <td class="text-wz"  align="left">从<cc1:DatePicker ID="dpCFtime" runat="server" IsRequest="false" />&nbsp; &nbsp; &nbsp; 至</td><td>
            <cc1:DatePicker ID="dpCTotime" runat="server" IsRequest="false" /></td>
            </tr>
                  <tr > 
                <td colspan="5" align="center" >
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />&nbsp; </td>               
              </tr>  
               <tr bgcolor="#E7E2D6" height="1px">  
             <td colspan="5" height="1"></td>          
              </tr>
             <tr height="6"><td colspan="5" style="height: 6px"></td></tr>
            
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
		            <asp:TemplateField HeaderText="企业名称" ItemStyle-Width="50%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>	
			            <a class="link-03" href="default.aspx?m=../Cert/CertView&id=<%#((System.Data.DataRowView)Container.DataItem)["MainSCID"] %>">		                
		                    <%#((System.Data.DataRowView)Container.DataItem)["Company"]%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>		           
		            <asp:TemplateField HeaderText="证书编号" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#((System.Data.DataRowView)Container.DataItem)["CertNO"].ToString()%>&nbsp;&nbsp;
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="证书状态" ItemStyle-Width="10%">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				              &nbsp;<%#((System.Data.DataRowView)Container.DataItem)["MainSCTempID"].ToString()==""?"已发放":"待领证"%>
				         </ItemTemplate>
		            </asp:TemplateField>
	            </Columns>
            </asp:GridView> </td>                           </tr>
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