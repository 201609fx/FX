<%@ Control Language="C#" AutoEventWireup="true" CodeFile="default.ascx.cs" Inherits="Complain_default" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
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
                        <td background="../img/intro_body_3.gif" class="bt-hui"><asp:Label runat="server" ID="lblSortName">我要投诉</asp:Label></td>
                        <td width="22"><img src="../img/intro_body_4.gif" width="22" height="33"></td>
                      </tr>
                    </table></td>
                </tr>
                <tr> 
                  <td height="410" valign="top" background="../img/intro_body_5.gif"> 
                    <table width="766" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td>&nbsp;<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label></td>
                      </tr>
                      <tr> 
                        <td>
                        <table width="740" border="0" align="center" cellpadding="1" cellspacing="1"  class="text-b">
                                        
                      <tr>                   
                     <td class="leftTitle"  align="center" width="10%">
                        投诉单位(人)</td>
                    <td  align="left" colspan="5">
                    <asp:TextBox runat="server" ID="txtComplainer" CssClass="main-text" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                  <td class="leftTitle"  align="center" width="10%">
                        地址</td>
                    <td  align="right" width="30%"><asp:TextBox runat="server"  ID="txtCaddresstou" CssClass="main-text" Width="220"></asp:TextBox>    
                    </td>
                    <td class="leftTitle"  align="center" width="15%">
                        电话</td>
                    <td  align="left" width="15%">
                     <asp:TextBox runat="server" ID="txtCtel" CssClass="main-text" Width="100%"></asp:TextBox>                   
                    </td>  
                      <td class="leftTitle"  align="center" width="10%">
                        投诉方式</td>
                    <td  align="left" width="20%">
                    <asp:DropDownList runat="server" ID="ddlCType" Enabled="false" Width="100%">
                    <asp:ListItem Text="选择投诉方式" Value="0"></asp:ListItem>        
                    <asp:ListItem  Text="电话" Value="1"></asp:ListItem>
                    <asp:ListItem Selected='True'  Text="网上" Value="2"></asp:ListItem>
                    </asp:DropDownList>           
                    </td>        
                </tr> 
                    <tr>
                  <td class="leftTitle"  align="center" >
                        被投诉单位(人)</td>
                    <td  align="right" width="30%">
                           <asp:TextBox runat="server" ID="txtBComplainer" CssClass="main-text" Width="220"></asp:TextBox>    
                    </td>
                    <td class="leftTitle"  align="center">
                        电话</td>
                    <td  align="left">
                     <asp:TextBox runat="server" ID="txtBCTel" CssClass="main-text" Width="100%"></asp:TextBox>                   
                    </td>  
                      <td class="leftTitle"  align="center" >
                        联系人</td>
                    <td  align="left">
                     <asp:TextBox runat="server" ID="txtBContact" CssClass="main-text" Width="100%"></asp:TextBox>                  
                    </td>        
                </tr> 
                  <tr>
                  <td class="leftTitle"  align="center">
                        地址</td>
                    <td  align="right" colspan="5">
                           <asp:TextBox runat="server" ID="txtBAddress" CssClass="main-text" Width="100%" ></asp:TextBox>    
                    </td>          
                </tr> 
                   <tr>
                  <td class="leftTitle"  align="center">案件名称</td>
                    <td  align="right" colspan="5">
                           <asp:TextBox runat="server" ID="txtName" CssClass="main-text" Width="100%" ></asp:TextBox>    
                    </td>          
                </tr> 
                     <tr>
                  <td class="leftTitle"  align="center">内容</td>
                    <td  align="right" colspan="5" height="350">
                           <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Height="350" Width="100%" CssClass="main-text"></asp:TextBox>    
                    </td>          
                </tr>   
              
                    <tr height="6"></tr>
                     <tr bgcolor="#E7E2D6"> 
                                <td height="1" colspan="6" ></td>               
                              </tr>         
   
                          </table>
                           </td>
                      </tr>
                      <tr> 
                        <td align="center"> <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="清 空" Class="button" id="btnd" onclick="location.href='Default.aspx'" />&nbsp;&nbsp;</td>
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
