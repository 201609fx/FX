<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="Cert_LeftMenu" %>
<%@ Register TagPrefix="uu1" Src="~/Controls/Link.ascx" TagName="Link" %>
<table width="233" border="0" cellspacing="0" cellpadding="0">
<tr>
                  <td width="233" valign="top"><table width="233" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td bgcolor="#ECF6E7" class="n-bg1"><table width="220" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                              <td height="40" class="text-gre-b-14" style="padding-left:10px; padding-top:5px;">证书办理</td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA"><a class="link-n-left-list" href="?m=FirstTimeApply&staus=1">初次申请</a></td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA"><a class="link-n-left-list" href="?m=FirstTimeApply&type=2&staus=1">晋级申请</a></td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA"><a class="link-n-left-list" href="?m=SearchTemp">申请进度查询</a></td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA"><a class="link-n-left-list" href="?m=Search">企业申请资料查询</a></td>
                            </tr>
                            <tr>
                              <td height="1" bgcolor="#C9E1BD"></td>
                            </tr>
                            <tr>
                              <td height="25" bgcolor="#EFF8EA"><a class="link-n-left-list" href="?m=default">证书查询</a></td>
                            </tr>
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
  </td>
 </tr>
 <uu1:Link ID="link" runat="server"></uu1:Link>
</table>