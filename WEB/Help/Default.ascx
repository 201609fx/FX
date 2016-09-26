<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="Help_Default" %>
<table width="787" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr> 
                  <td height="6"></td>
                </tr>
                <tr> 
                  <td><img src="../img/intro_body_1.gif" width="787" height="9"></td>
                </tr>
                <tr> 
                  <td><table width="787" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="26"><img src="../img/intro_body_2.gif" width="26" height="33"></td>
                        <td width="12" background="../img/intro_body_3.gif"><img src="../img/ico3.gif" width="3" height="11"></td>
                        <td background="../img/intro_body_3.gif" class="bt-hui"><asp:Label runat="server" ID="lblSortName">办事流程</asp:Label></td>
                        <td width="22"><img src="../img/intro_body_4.gif" width="22" height="33"></td>
                      </tr>
                    </table></td>
                </tr>
                <tr> 
                  <td height="410" valign="top" background="../img/intro_body_5.gif"> 
                    <table width="766" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td><table width="740" border="0" align="center" cellpadding="0" cellspacing="0" class="text-wz">                       
                            <tr> 
                              <td>
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
										<td align="left" ><img src="../img/tztg_ico.gif" width="3" height="5">&nbsp;<a class="link-03" href='<%# System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+DataBinder.Eval(Container.DataItem, "TableName")+"\\"+DataBinder.Eval(Container.DataItem, "SortName")+"\\"+DataBinder.Eval(Container.DataItem, "FileUrl")  %>' target=_blank><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
									</tr>
								</ItemTemplate>
								<AlternatingItemTemplate>
									<tr>
										<td align="left"><img src="../img/tztg_ico.gif" width="3" height="5">&nbsp;<a class="link-03" href='<%#System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+DataBinder.Eval(Container.DataItem, "TableName").ToString()+"\\"+DataBinder.Eval(Container.DataItem, "SortName")+"\\"+DataBinder.Eval(Container.DataItem, "FileUrl") %>' target=_blank><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
									</tr>
								</AlternatingItemTemplate>
							</asp:repeater>
                            </asp:Panel>
                          </table></td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                    </table></td>
                </tr>
                <tr> 
                  <td><img src="../img/intro_body_6.gif" width="787" height="10"></td>
                </tr>
              </table>