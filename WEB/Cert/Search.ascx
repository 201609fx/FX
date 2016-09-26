<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Cert_Search" %>
	<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                        <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="Label1">企业申请资料查询</asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  证书办理</td>
                              <td width="13"><img src="../images/lb8.gif" width="13" height="32" /></td>
                            </tr>
                          </table></td>
                      </tr>                
                <tr> 
                  <td height="6"></td>
                </tr>
                <tr> 
                  <td><img src="../img/intro_body_1.gif" width="725" height="9"></td>
                </tr>
                <%--<tr> 
                  <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="26"><img src="../img/intro_body_2.gif" width="26" height="33"></td>
                        <td width="12" background="../img/intro_body_3.gif"><img src="../img/ico3.gif" width="3" height="11"></td>
                        <td background="../img/intro_body_3.gif" class="bt-hui"><asp:Label runat="server" ID="lblSortName">企业信息查询</asp:Label></td>
                        <td width="22"><img src="../img/intro_body_4.gif" width="22" height="33"></td>
                      </tr>
                    </table></td>
                </tr>--%>
                <tr> 
                  <td height="200" valign="top" background="../img/intro_body_51.gif"> 
                    <table width="704" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td><table width="680" height="200" border="0" align="center" cellpadding="0" cellspacing="0" class="text-wz">
                           <tr><td align="center" valign="middle">
                            <table width="500" border="0" align="center" cellpadding="0" cellspacing="0" class="text-wz">
                            <tr><td align="right">记录号：</td><td><asp:TextBox runat="server" ID="txtNO"></asp:TextBox></td></tr>
                               <tr><td align="center" colspan="2" height="20"></td></tr>
                             <tr><td align="right">公司名称：</td><td><asp:TextBox runat="server" ID="txtCompany"></asp:TextBox></td></tr>
                                  <tr><td align="center" colspan="2" height="30"></td></tr>
                               <tr><td align="center" colspan="2">
                                   <asp:Button ID="btnOk" runat="server" Text="查询" OnClick="btnOk_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
                            </table>
                           </td></tr>
                          </table></td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <%--<tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>--%>
                    </table></td>
                </tr>
                <tr> 
                  <td style="height: 10px"><img src="../img/intro_body_6.gif" width="725" height="10"/></td>
                </tr>
              </table>