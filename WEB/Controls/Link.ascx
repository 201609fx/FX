<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link.ascx.cs" Inherits="Controls_Link" %>
  <tr><td>                
                  <table width="233" border="0" cellspacing="0" cellpadding="0" style="margin-top:8px;"><tr>
                        <td bgcolor="#ECF6E7" class="n-bg1"><table width="220" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                              <td height="40" class="text-gre-b-14" style="padding-left:10px; padding-top:5px;">相关链接</td>
                            </tr>
                            <asp:Repeater runat="server" ID="rptlink">
                            <ItemTemplate>                            
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA"><a class="link-n-left-list" target="_blank" href="<%#((System.Data.DataRowView)Container.DataItem)["Url"] %>"><%#((System.Data.DataRowView)Container.DataItem)["Title"]%></a></td>
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="10"></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td bgcolor="#E3F2DC" height="8"></td>
                      </tr>
                    </table>
                    <table width="233" border="0" cellspacing="0" cellpadding="0" style="margin-top:8px;">
                      <tr>
                        <td bgcolor="#ECF6E7" class="n-bg1"><table width="220" border="0" align="center" cellpadding="0" cellspacing="0" class="text-hui-12">
                            <tr>
                              <td height="40" class="text-gre-b-14" style="padding-left:10px; padding-top:5px;">联系我们</td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA" style="padding-left:10px;">联系电话：0755 83283815</td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA" style="padding-left:10px;">传真号码：0755 83288295</td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="10"></td>
                            </tr>
                          </table></td>
                      </tr>
                      </table>
</td></tr>
