<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CertApply.ascx.cs" Inherits="Cert_CertApply" %>
<%--<link href="../public/bootstrap3.3.5/css/bootstrap.css" rel="stylesheet" />--%>
<link href="../public/font-awesome-4.4.0/css/font-awesome.css" rel="stylesheet" />
<script src="../public/jquery1.11.3/jquery1.11.3.min.js"></script>
<script src="../public/bootstrap3.3.5/js/bootstrap.js"></script>

<div >
    <table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                        <tr>
                        <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb6.gif" width="13" height="32" /></td>
                              <td width="150" background="../images/lb7.gif" class="text-bla-b-14"><asp:Label runat="server" ID="Label1">初次申请</asp:Label></td>
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
                <tr> 
                  <td><table width="725" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="26"><img src="../img/intro_body_2.gif" width="26" height="33"></td>
                        <td width="12" background="../img/intro_body_3.gif"><img src="../img/ico3.gif" width="3" height="11"></td>
                        <td background="../img/intro_body_3.gif" class="bt-hui"><asp:Label runat="server" ID="lblSortName">申请</asp:Label></td>
                        <td width="22"><img src="../img/intro_body_4.gif" width="22" height="33"></td>
                      </tr>
                    </table></td>
                </tr>
        </table>

    <asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
</div>

<div style="display:none">
    <div id="applyNo">
        <asp:Literal runat="server" ID="litApplyNo"></asp:Literal>
    </div>
</div>