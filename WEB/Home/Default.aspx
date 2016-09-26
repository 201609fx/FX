<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Home_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<script type="text/javascript">
    function aa() {
        alert("因春节期间，2月1日至17日之间不开放申报提交申请，请择日提交！");
    }
</script>
<table width="966" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="559" valign="top"><table width="548" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><table width="548" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb2.gif" width="13" height="30" /></td>
                              <td background="../images/lb3.gif" class="text-gre-b-14">企业公示</td>
                              <td width="45" background="../images/lb3.gif"><a class="link-gre-12" href="../CompanyShow/default.aspx">更多 >></a></td>
                              <td width="13"><img src="../images/lb4.gif" width="13" height="30" /></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td background="../images/lb1.gif"><table width="515" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top:15px; margin-bottom:15px;" class="text-hui-12">
                            <asp:Repeater runat="server" ID="rptView">
                            <ItemTemplate>
                            <tr>
                              <td height="18"><a class="link-gre-12" href="../CompanyShow/default.aspx?m=../Cert/CertView&id=<%#((System.Data.DataRowView)Container.DataItem)["MainSCID"]%>" target="_blank"><%#((System.Data.DataRowView)Container.DataItem)["Company"]%></a></td>
                            </tr>
                            <tr>
                              <td><span class="text-blu-12"><%#((System.Data.DataRowView)Container.DataItem)["CertNO"]%></span> <span class="text-red-12"><%#getLevel(((System.Data.DataRowView)Container.DataItem)["CertNO"].ToString())%></span> <%#((System.Data.DataRowView)Container.DataItem)["address"]%></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                            </tr>
                            </ItemTemplate>
                          </asp:Repeater>                          
                          </table></td>
                      </tr>
                      <tr>
                        <td bgcolor="#B9D5AF" height="1"></td>
                      </tr>
                      <tr>
                        <td height="3"></td>
                      </tr>
                      <tr>
                        <td><table width="548" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td height="90" valign="top" background="../images/se-bg.jpg"><table width="405" border="0" cellspacing="0" cellpadding="0" style="margin-left:20px;">
                                  <tr>
                                    <td height="30">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                    <td width="80"><img src="../images/se1.gif" width="76" height="18" /></td>
                                    <td><input name="txtKey" id="txtKey" type="text" class="inp1"/></td>
                                    <td width="83"><img src="../images/se2.gif" width="83" height="25" border="0" onclick="javascript:getsearch()"/></td>
                                    <script language="javascript">
                                        function getsearch() {
                                            var s = document.getElementById("txtKey").value;
                                            if (s == "") {
                                                alert('请输入企业名称或企业名称关键字查询!');
                                                return false;
                                            }
                                            location.href = '../Cert/default.aspx?m=default&key=' + escape(s);
                                            return true;
                                        }
                                    </script>                                  
                                  </tr>
                                  <tr>
                                    <td>&nbsp;</td>
                                    <td height="25" colspan="2" class="text-hui-12">查询提示：请输入企业名称或企业名称关键字查询。</td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table></td>
                  <td width="407" valign="top"><table width="407" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><table width="407" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="13"><img src="../images/lb2.gif" width="13" height="30" /></td>
                              <td background="../images/lb3.gif" class="text-gre-b-14">公告栏</td>
                              <td width="45" background="../images/lb3.gif"><a class="link-gre-12" href="../Notes/Default.aspx?pid=3">更多 &gt;&gt;</a></td>
                              <td width="13"><img src="../images/lb4.gif" width="13" height="30" /></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td background="../images/lb5.gif"><table width="380" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top:9px; margin-bottom:9px;">
                          <asp:Repeater runat="server" ID="rptNote">
                          <ItemTemplate>                            
                          <tr>
                              <td height="23"><a class="link-gre-12" href="../Notes/Default.aspx?m=../PopWindow/ShowNews&pid=3&id=<%#((System.Data.DataRowView)Container.DataItem)["ID"] %>" title='<%#((System.Data.DataRowView)Container.DataItem)["Title"] %>'><%#getLeft(((System.Data.DataRowView)Container.DataItem)["Title"].ToString(),20,true)%></a></td>
                            </tr>
                          </ItemTemplate>
                        </asp:Repeater>                           
                        </table></td>
                      </tr>
                      <tr>
                        <td bgcolor="#B9D5AF" height="1"></td>
                      </tr>
                    </table>
                    <table width="407" border="0" cellspacing="0" cellpadding="0" style="margin-top:6px;">
                      <tr>
                        <td bgcolor="#B9D5AF" height="1"></td>
                      </tr>
                      <tr>
                        <td background="../images/lb5.gif"><table width="385" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-bottom:10px;">
                            <tr>
                              <td height="30" colspan="3" class="text-gre-b-14">新办证书</td>
                            </tr>
                            <tr>
                              <td width="122"><a href="#" ><img src="../images/li1.jpg" width="122" height="94" border="0" /></a></td>
                              <td align="center"><a href="../Cert/default.aspx?m=SearchTemp"><img src="../images/li2.jpg" width="122" height="94" border="0" /></a></td>
                              <td width="122"><a href="../Cert/default.aspx?m=Search"><img src="../images/li3.jpg" width="122" height="94" border="0" /></a></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td bgcolor="#B9D5AF" height="1"></td>
                      </tr>
                    </table>
                    <table width="407" border="0" cellspacing="0" cellpadding="0" style="margin-top:6px;">
                      <tr>
                        <td bgcolor="#B9D5AF" height="1"></td>
                      </tr>
                      <tr>
                        <td background="../images/lb5.gif"><table width="385" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-bottom:10px;">
                            <tr>
                              <td height="30" colspan="3" class="text-gre-b-14">晋级证书</td>
                            </tr>
                            <tr>
                              <td width="122"><a href="#"><img src="../images/li4.jpg" width="122" height="94" border="0" /></a></td>
                              <td align="center"><a href="../Cert/default.aspx?m=SearchTemp"><img src="../images/li5.jpg" width="122" height="94" border="0" /></a></td>
                              <td width="122"><a href="../Cert/default.aspx?m=Search"><img src="../images/li6.jpg" width="122" height="94" border="0" /></a></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td bgcolor="#B9D5AF" height="1"></td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
         </asp:Content>

