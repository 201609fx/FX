<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowNews.ascx.cs" Inherits="PopWindow_ShowNews" %>
 
<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="lblSortName"></asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  <asp:Label runat="server" ID="Label1"></asp:Label></td>
                              <td width="13"><img src="../images/lb8.gif" width="13" height="32" /></td>
                            </tr>
                          </table></td>
                      </tr>
                      <%-- <tr>
                       <td><table width="380" border="0" align="center" cellpadding="0" cellspacing="0" class="text-hui-12">
                            <tr>
                              <td width="80" height="80"></td>
                            </tr>
                          </table></td>
                      </tr>--%>
                      <tr>
                        <td><table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                            <%--<tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>--%>
                            <tr>
                              <td height="8"></td>
                            </tr>
                            <asp:Panel ID="pnlNew" runat="server" >
                            
									<tr><td height="20" align="center"><asp:Label cssclass="bt-hui1" id="labTitle" runat="server"></asp:Label></td></tr>
							
							<tr>
								<td height="20" align="center" class="bt-hui">
									发布时间：<asp:Label id="labIssueDate" runat="server"></asp:Label>&nbsp;&nbsp; 浏览次数：<asp:Label id="labClickTimes" runat="server"></asp:Label>&nbsp;&nbsp; 
									来源：<asp:Label id="labRefer" runat="server"></asp:Label></td>
							</tr>
							<tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>
                            <tr>
                              <td >&nbsp;</td>
                            </tr>
                             </asp:Panel>                            <tr>
                              <td height="25">
                              <asp:Literal runat="server" ID="lblContent">
                              
                              </asp:Literal>
                              </td>
                            </tr>
                            <asp:Panel ID="pnlFile" runat="server">
                            <tr height="50"><td>&nbsp;</td> </tr>
                            <tr>
							<td align="left" >相关附件下载：</td>
							</tr>
                            <asp:repeater id="rptListDots" Runat="server">
								<ItemTemplate>
									<tr>
										<td align="left" ><img src="../img/tztg_ico.gif" width="3" height="5">&nbsp;<a class="link-03" href='<%# System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+DataBinder.Eval(Container.DataItem, "TableName")+"\\"+DataBinder.Eval(Container.DataItem, "SortName")+"\\"+DataBinder.Eval(Container.DataItem, "FileUrl")  %>' target="_blank"><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
									</tr>
								</ItemTemplate>
								<AlternatingItemTemplate>
									<tr>
										<td align="left"><img src="../img/tztg_ico.gif" width="3" height="5">&nbsp;<a class="link-03" href='<%# System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+DataBinder.Eval(Container.DataItem, "TableName").ToString()+"\\"+DataBinder.Eval(Container.DataItem, "SortName")+"\\"+DataBinder.Eval(Container.DataItem, "FileUrl") %>' target="_blank"><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
									</tr>
								</AlternatingItemTemplate>
							</asp:repeater>
                            </asp:Panel>                            
                            <tr>
                              <td height="8"></td>
                            </tr>
                            <%--<tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>--%>
                            <tr>
                              <td height="35"><table width="680" border="0" cellspacing="0" cellpadding="0" class="text-hui-12">
                                  <tr>
                                    <td></td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                      </tr>
</table>
