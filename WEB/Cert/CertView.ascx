<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CertView.ascx.cs" Inherits="Cert_CertView" %>
<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="Label1">证书明细</asp:Label></td>
                              <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  企业公示</td>
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
                <tr> 
                  <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="26"><img src="../img/intro_body_2.gif" width="26" height="33"></td>
                        <td width="12" background="../img/intro_body_3.gif"><img src="../img/ico3.gif" width="3" height="11"></td>
                        <td background="../img/intro_body_3.gif" class="bt-hui"><asp:Label runat="server" ID="lblSortName">证书明细</asp:Label></td>
                        <td width="22"><img src="../img/intro_body_4.gif" width="22" height="33"></td>
                      </tr>
                    </table></td>
                </tr>
                <tr> 
                  <td height="410" valign="top" background="../img/intro_body_5.gif"> 
                    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0" >
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td><table width="680" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#999999" class="text-b">
                            <tr height="25"> 
                            <td align="right" bgcolor="White" >企业名称:</td>
                              <td align="left"  bgcolor="White" colspan="3">
                              <asp:Literal runat="server" ID="lblCompany">                              
                              </asp:Literal>
                               </td>
                            </tr>
                             <tr  height="25"> 
                            <td align="right"  bgcolor="White">企业地址:</td>
                              <td align="left"  bgcolor="White"  colspan="3">
                              <asp:Literal runat="server" ID="lblAddress">                              
                              </asp:Literal>
                               </td>
                            </tr>
                             <tr  height="50"> 
                            <td align="right"  bgcolor="White">维修范围:</td>
                              <td align="left"  bgcolor="White"  colspan="3">
                              <asp:Literal runat="server" ID="lblOperation">                              
                              </asp:Literal>
                               </td>
                            </tr>
                             <tr  height="25" > 
                            <td width="10%" align="right"  bgcolor="White">证书编号:</td>
                              <td align="left"  bgcolor="White" colspan="3" >
                              
                              <asp:Literal runat="server" ID="lblCertNO">                              
                              </asp:Literal>
                               </td>
                            </tr>
                             <tr  height="25"> 
                            <td align="right" width="10%"   bgcolor="White">技术等级:</td>
                              <td align="left" width="40%"   bgcolor="White">
                              <asp:Literal runat="server" ID="ltLevel">                              
                              </asp:Literal>
                               </td>
                               <td align="right"  width="10%"  bgcolor="White">证书状态:</td>
                               <td align="left" width="40%"  bgcolor="White">
                              <asp:Literal runat="server" ID="lblState">                              
                              </asp:Literal></td>
                            </tr>
                             <tr  height="25"> 
                            <td align="right"  bgcolor="White">发放日期:</td>
                              <td align="left"  bgcolor="White">
                              <asp:Literal runat="server" ID="lblStartTime">                              
                              </asp:Literal>
                               </td>
                               <td align="right"  bgcolor="White">截止日期:</td>
                               <td align="left"  bgcolor="White">
                              <asp:Literal runat="server" ID="lblEndTime">                              
                              </asp:Literal></td>
                            </tr>
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
                  <td><img src="../img/intro_body_6.gif" width="725" height="10"></td>
                </tr>
              </table>