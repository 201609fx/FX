<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="FirstTimeApply.ascx.cs" Inherits="Cert_FirstTimeApply" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>


             <script language="javascript" >
               function OpenPrint(id)
                {
	                var features = 'width=900,height=700,scrollbars=yes,left=50,top=50,resizable=yes';
	                var winName = '审批表打印';
	                var Url = 'testPrint.aspx?id=' + id;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }
            
               window.onload=function ()
               {
                  var chk=window.document.getElementById("<%=cbOp.ClientID %>"); 
                  if(chk.checked)
                  {              
                     tab1.style.display="block";    
                  } 
                  else
                  {   
                     tab1.style.display="none";            
                  }            
               }
               function cbop()
               {
                 var chk=window.document.getElementById("<%=cbOp.ClientID %>"); 
                  if(chk.checked)
                  {              
                     tab1.style.display="block";    
                  } 
                  else
                  {   
                     tab1.style.display="none";            
                  } 
               }
</script>
<style>
.text-star-12 {
	font-family:"宋体";
	font-size: 12px;
	color: #ff0000;
}
</style>
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
                <tr> 
                  <td height="410" valign="top" background="../img/intro_body_5.gif"> 
                    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td>&nbsp;<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label></td>
                      </tr>
                      <tr> 
                        <td>
                        <table width="680" border="0" align="center" cellpadding="1" cellspacing="1"  class="text-b">
                        
                <asp:Panel runat="server" ID="pnlSuggest">        
          <tr>
          <td bgcolor="#f9f9f0" align="center">修改意见</td>
          <td colspan="7" bgColor="#f5f5f1"><asp:Label runat="server" ID="lblSuggest" ></asp:Label></td>
          </tr>
          </asp:Panel>               
           <asp:Panel runat="server" ID="pnlCert">        
          <tr>
          <td bgcolor="#f9f9f0" align="center"  width="13%"><span class="text-star-12">*</span>原证书号</td>
          <td colspan="3" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtOldCertNO" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center"></td>
          <td colspan="3" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtNewCertNO" Width="100%" Visible="false"></asp:TextBox></td>
          </tr>
          </asp:Panel>
                 <tr>
          <td  bgcolor="#f9f9f0" align="center" width="13%"><span class="text-star-12">*</span>企业名称(全称)</td>
          <td colspan="7" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCompany" Width="100%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>经营地址</td>
          <td colspan="5" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtAddress" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">邮编</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCode" Width="100%"></asp:TextBox></td>
          </tr>
          <tr>
          <td width="10%" bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>联系人</td>
          <td width="10%" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtContact" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%" align="center"><span class="text-star-12">*</span>固定电话</td>
          <td bgColor="#f5f5f1" width="12%"><asp:TextBox runat="server" ID="txtPhone" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%" align="center"><span class="text-star-12">*</span>移动电话</td>
          <td bgColor="#f5f5f1" width="18%"><asp:TextBox runat="server" ID="txtMobile" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="12%" align="center"><span class="text-star-12">*</span>传真</td>
          <td bgColor="#f5f5f1" width="18%"><asp:TextBox runat="server" ID="txtFax" Width="100%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>所属区域</td>
          <td bgColor="#f5f5f1">
          <asp:DropDownList runat="server" ID="ddlAreaID" DataTextField="Name" DataValueField="ID"></asp:DropDownList></td>  
          <td bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>法人代表</td>
          <td bgColor="#f5f5f1" ><asp:TextBox runat="server" ID="txtFrdb" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center"><span class="text-star-12">*</span>联系电话</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtFtel" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">营业面积</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtArea" Width="100%"></asp:TextBox></td>       
          </tr>
          
         <tr>
          <td bgcolor="#f9f9f0" align="center">企业总人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtAnum" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">维修人员人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtMnum" Width="100%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">安装人员人数</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtBnum" Width="100%"></asp:TextBox></td>       
          </tr>          
         
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100" align="center"><span class="text-star-12">*</span>维修业务范围<br>(有特约维修业务的请注明)</td>
          <td bgcolor="#f5f5f1" colspan="6">          
          <iframe id="FrameOperation" name="FrameOperation" height="100" src="<%=strOperation %>" width="100%" frameborder="0" scrolling="no"></iframe>
          </td>               
          </tr>
          <tr><td bgcolor="#f9f9f0" colspan="2" align="left">
              <asp:CheckBox ID="cbOp" runat="server" Text="有特约维修业务" Checked="true" /></td>
              <td colspan="6"  bgcolor="#f5f5f1" align="center" valign="top">
              <table cellpadding="0" cellspacing="0" border="0"  width="99%" id="tab1">
              <tr>
              <td align="center" valign="top" bgcolor="#f5f5f1">
               <iframe id="FrameOp" name="FrameOp" src="<%=strOp %>" width="100%" frameborder="0" scrolling="no"></iframe>
	        	</td>
              </tr>
              </table>
           
			 </td>
          </tr>
          
         <asp:Panel ID="pnlSummary" runat="server">
           <tr height="300" id="trSummary">
          <td  bgcolor="#f9f9f0" colspan="2" align="center"><span class="text-star-12">*</span>企业总结</td>
          <td colspan="6" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtSummary" TextMode="MultiLine" Width="97%" Height="250"></asp:TextBox></td>
        </tr>
        </asp:Panel>
          <tr height="150">
       
          <td bgcolor="#f9f9f0" align="center">管理人员/专业技术人员状况</td>
          <td colspan="7" bgcolor="#f5f5f1" align="center"  valign="top">
          <iframe id="Iframe1" name="FrameMemployee" src="<%=strMemployee %>" width="100%" frameborder="0" scrolling="no"></iframe>
		
			 </td></tr>	
          
			 <tr height="150">
			  
          <td bgcolor="#f9f9f0" align="center">安装/维修人员状况</td>
          <td colspan="7" bgcolor="#f5f5f1" align="center">
          <iframe id="FrameWemployee" name="FrameWemployee" src="<%=strWemployee %>" width="100%" frameborder="0" scrolling="no"></iframe>
           
			 </td></tr>	
			  <tr height="150">
			  
          <td bgcolor="#f9f9f0" colspan="2" align="center">维修安装作业设备</td>
          <td colspan="6" > 
          <table border="0" cellspacing="1" cellpadding="3" BackColor="#9D9DA1" class="main-text" height="100%" width="100%">
          <tr><td width="20%"></td>         
           <td rowspan="2" bgcolor="#f5f5f1" align="center">
          <iframe id="FrameEList" name="FrameEList" src="<%=strEList %>" width="100%" frameborder="0" scrolling="no"></iframe>
          </td></tr>
          <tr>
          <td bgcolor="#f9f9f0" align="center">交通工具</td>
          <td></td>
          </tr>
          <tr>
          <td bgcolor="#f9f9f0" align="center">其它仪器设备</td>
          <td  bgcolor="#f5f5f1" align="center">
          
          <iframe id="FrameEList2" name="FrameEList2" src="<%=strEList2 %>" width="100%" frameborder="0" scrolling="no"></iframe>
          </td>
          </tr>
          </table>
          	 </td></tr>
          <tr height="250">
          <td bgcolor="#f9f9f0" colspan="2" align="center">送审资料</td>
          <td bgcolor="#f5f5f1" colspan="6">
          
          <iframe id="FrameCSFil" name="FrameCSFil" src="<%=strCSFil %>" width="100%" frameborder="0" scrolling="no"></iframe>
         </td>
          </tr>
                          </table>
                           </td>
                      </tr>
                      <tr>
                      <td align="center"><asp:Label runat="server" Text="需要添加的数据请确保添加成功，*号项为必填项，请填写完整再进行提交！" CssClass="text-star-12"></asp:Label></td>
                      </tr>
                      <tr> 
                        <td>&nbsp;</td>
                      </tr>
                      <tr> 
                        <td align="center">
                         <asp:Button ID="btnSum" runat="server" Text="提 交" OnClick="btnSum_Click" />
                         <asp:Button ID="btnOK" runat="server"  Text="保 存" OnClick="btnOK_Click" />
                         <input type="button" value="打 印" onclick="OpenPrint('<%=lblID.Text %>')" />
                            <asp:Button ID="btnBack" Visible="false" runat="server" Text="返 回" OnClick="btnBack_Click" /></td>
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
