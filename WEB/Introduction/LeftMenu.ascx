<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="Introduction_LeftMenu" %>
<%@ Register TagPrefix="uu1" Src="~/Controls/Link.ascx" TagName="Link" %>

            <table width="193" border="0" cellspacing="0" cellpadding="0">
                <tr> 
                  <td height="6"></td>
                </tr>
                <tr> 
                  <td><table width="193" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td><img src="../img/intro_1.gif" width="193" height="9"></td>
                      </tr>
                      <tr> 
                        <td><table width="193" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                              <td width="21"><img src="../img/intro_2.gif" width="21" height="33"></td>
                              <td background="../img/intro_4.gif"><img src="../img/intro_3.gif" width="66" height="33"></td>
                              <td width="15"><img src="../img/intro_5.gif" width="15" height="33"></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr> 
                        <td background="../img/intro_6.gif" height="2"></td>
                      </tr>
                      <tr> 
                        <td background="../img/intro_6.gif"><table width="182" border="0" align="center" cellpadding="0" cellspacing="2">
                            <tr> 
                              <td height="25" bgcolor="#EFEFEF">&nbsp;&nbsp;<img src="../img/ico2.gif" width="3" height="11">&nbsp;<a class="link-03" href="../Introduction/default.aspx">机构简介</a></td>
                            </tr>
                             <tr> 
                              <td height="25" bgcolor="#EFEFEF">&nbsp;&nbsp;<img src="../img/ico2.gif" width="3" height="11">&nbsp;<a class="link-03" href="../Introduction/default.aspx?m=../PopWindow/ShowNews&id=3">机构职能</a></td>
                            </tr>
                            <tr> 
                              <td height="25" bgcolor="#EFEFEF">&nbsp;&nbsp;<img src="../img/ico2.gif" width="3" height="11">&nbsp;<a class="link-03" href="../Introduction/default.aspx?m=../PopWindow/ShowNews&id=4">机构设置</a></td>
                            </tr>
                            <tr> 
                              <td height="25" bgcolor="#EFEFEF">&nbsp;&nbsp;<img src="../img/ico2.gif" width="3" height="11">&nbsp;<a class="link-03" href="../Introduction/default.aspx?m=../PopWindow/ShowNews&id=5">组织架构</a></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr> 
                        <td><img src="../img/intro_7.gif" width="193" height="8"></td>
                      </tr>
                    </table></td>
                </tr>
                <tr> 
                  <td height="6"></td>
                </tr>
              <uu1:Link ID="link" runat="server"></uu1:Link>
              </table>