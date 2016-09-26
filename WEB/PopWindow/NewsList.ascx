<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList.ascx.cs" Inherits="PopWindow_NewsList" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>
<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="lblSortName">政策法规</asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  公告栏</td>
                              <td width="13"><img src="../images/lb8.gif" width="13" height="32" /></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td><table width="380" border="0" align="center" cellpadding="0" cellspacing="0" class="text-hui-12">
                            <tr>
                              <td width="80" height="80">关键字检索：</td>
                              <td width="240"><input type="text" name="textfield" id="key" class="inp1" /></td>
                              <td align="center"><a class="link-red-12" href="#" onclick="javascript:Search()">点击检索</a></td>
                                    <script language="javascript">
                                    function Search()
                                    {
                                       var s=document.getElementById("key").value;
                                       location.href='Default.aspx?pid=3&search=true&key='+escape(s);
                                       return true;
                                    }
                                    </script>                                    
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td><table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>
                            <tr>
                              <td height="8"></td>
                            </tr>
                            <asp:Repeater runat="server" ID="rptList">
                            <ItemTemplate>                            
                            <tr>
                              <td height="25"><a class="link-bla-12" href="Default.aspx?m=../PopWindow/ShowNews&pid=<%#((System.Data.DataRowView)Container.DataItem)["SortID"] %>&id=<%#((System.Data.DataRowView)Container.DataItem)["ID"] %>"><%#((System.Data.DataRowView)Container.DataItem)["Title"] %></a></td>
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>                            
                            <tr>
                              <td height="8"></td>
                            </tr>
                            <tr>
                              <td bgcolor="#CCCCCC" height="1"></td>
                            </tr>
                            <tr>
                              <td height="35"><table width="680" border="0" cellspacing="0" cellpadding="0" class="text-hui-12">
                                  <tr>
                                    <td><%--<a class="link-blu-12" href="#">上一页</a> <a class="link-blu-12" href="#">1</a> <a class="link-blu-12" href="#">2</a> <a class="link-blu-12" href="#">3</a> <a class="link-blu-12" href="#">下一页</a>--%>
                                <cc2:aspnetpager id="AspNetPager1" AlwaysShow="true" NumericButtonType="Text" PagingButtonType="Image"  PageSize="20" ImagePath="../img/" class="link-blu-12" runat="server" 
                                  OnPageChanged="AspNetPager1_OnPageChanging"></cc2:aspnetpager>                                    </td>
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
          