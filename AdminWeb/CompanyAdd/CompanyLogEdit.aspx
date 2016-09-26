<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyLogEdit.aspx.cs" Inherits="CompanyAdd_CompanyLogEdit" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
    
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
</head>
<body>
    <form id="form1" runat="server">
 



    <table width="97%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top" align="left">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0" class="main-text">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName" CssClass="main-text">已发证书企业</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="97%" align="center"></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
          <tr><td colspan="3"  height="10"></td></tr>
          <tr><td colspan="3" align="left">
<table width="97%" border="0" align="right" cellpadding="0" cellspacing="0" class="main-text">

                <tr> 
                  <td height="410" valign="top" background="../img/intro_body_5.gif"> 
                    <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td>&nbsp;<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label></td>
                      </tr>
                      <tr> 
                        <td align="left">
                        <table width="97%" border="0" align="center" cellpadding="1" cellspacing="1" class="main-text">
                        
                   
           <asp:Panel runat="server" ID="pnlCert">        
          <tr>
          <td bgcolor="#f9f9f0" align="center">原证书号</td>
          <td colspan="3" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtOldCertNO" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center"></td>
          <td colspan="3" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtNewCertNO" Width="97%" Visible="false"></asp:TextBox></td>
          </tr>
          </asp:Panel>
          <tr>
          <td  bgcolor="#f9f9f0" align="center">企业名称(全称)</td>
          <td colspan="5" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCompany" Width="99%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">证书号</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCertNO" Width="97%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" align="center">经营地址</td>
          <td colspan="5" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtAddress" Width="99%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">邮编</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtCode" Width="97%"></asp:TextBox></td>
          </tr>
          <tr>
          <td width="10%" bgcolor="#f9f9f0" align="center">联系人</td>
          <td width="10%" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtContact" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%" align="center">固定电话</td>
          <td bgColor="#f5f5f1" width="12%"><asp:TextBox runat="server" ID="txtPhone" Width="100"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="10%" align="center">移动电话</td>
          <td bgColor="#f5f5f1" width="18%"><asp:TextBox runat="server" ID="txtMobile" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" width="12%" align="center">传真</td>
          <td bgColor="#f5f5f1" width="18%"><asp:TextBox runat="server" ID="txtFax" Width="97%"></asp:TextBox></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" align="center">所属区域</td>
          <td bgColor="#f5f5f1">
          <asp:DropDownList runat="server" ID="ddlAreaID" DataTextField="Name" DataValueField="ID"></asp:DropDownList></td>  
          <td bgcolor="#f9f9f0" align="center">法人代表</td>
          <td bgColor="#f5f5f1" ><asp:TextBox runat="server" ID="txtFrdb" Width="100"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">联系电话</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtFtel" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">营业面积</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtArea" Width="97%"></asp:TextBox></td>       
          </tr>
          
         <tr>
          <td bgcolor="#f9f9f0" align="center">企业总人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtAnum" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">维修人员人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:TextBox runat="server" ID="txtMnum" Width="97%"></asp:TextBox></td>
          <td bgcolor="#f9f9f0" align="center">安装人员人数</td>
          <td bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtBnum" Width="96%"></asp:TextBox></td>       
          </tr> 
                   
  
     <tr>
      <td class="leftTitle" bgColor="#f9f9f0" align="right">
            有效期限:</td>
        <td bgColor="#f5f5f1" align="left" colspan="5">
         <cc2:DatePicker ID="dpStartTime" runat="server" IsRequest="false" />至<cc2:DatePicker runat="server" ID="dpEndTime" IsRequest="false"/>
        </td>
           <td class="leftTitle" bgColor="#f9f9f0" align="right">
            领证人:</td>
        <td bgColor="#f5f5f1" align="left" >
        <asp:TextBox runat="server" ID="txtLZR"  Width="150"></asp:TextBox>              
        </td>
    </tr> 
    
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100" align="center">维修业务范围<br/>(有特约维修业务的请注明)</td>
          <td bgcolor="#f5f5f1" colspan="6">          
          <iframe id="FrameOperation" name="FrameOperation" height="100" src="<%=strOperation %>" width="97%" frameborder="0" scrolling="no"></iframe>
          </td>               
          </tr>
          <tr><td bgcolor="#f9f9f0" colspan="2" align="left">
              <asp:CheckBox ID="cbOp" runat="server" Text="有特约维修业务" Checked="true" /></td>
              <td colspan="6"  bgcolor="#f5f5f1" align="left" valign="top">
              <table cellpadding="0" cellspacing="0" border="0"  width="99%" id="tab1">
              <tr>
              <td align="left" valign="top" bgcolor="#f5f5f1">
               <iframe id="FrameOp" name="FrameOp" src="<%=strOp %>" width="99%" frameborder="0" scrolling="no"></iframe>
	        	</td>
              </tr>
              </table>
           
			 </td>
          </tr>
          
         <asp:Panel ID="pnlSummary" runat="server">
           <tr height="300" id="trSummary">
          <td  bgcolor="#f9f9f0" colspan="2" align="center">企业总结</td>
          <td colspan="6" bgColor="#f5f5f1"><asp:TextBox runat="server" ID="txtSummary" TextMode="MultiLine" Width="97%" Height="250"></asp:TextBox></td>
        </tr>
        </asp:Panel>
          <tr height="150">
       
          <td bgcolor="#f9f9f0" align="center">管理人员/专业技术人员状况</td>
          <td colspan="7" bgcolor="#f5f5f1" align="center"  valign="top">
          <iframe id="Iframe1" name="FrameMemployee" src="<%=strMemployee %>" width="97%" frameborder="0" scrolling="no"></iframe>
		
			 </td></tr>	
          
			 <tr height="150">
			  
          <td bgcolor="#f9f9f0" align="center">安装/维修人员状况</td>
          <td colspan="7" bgcolor="#f5f5f1" align="center">
          <iframe id="FrameWemployee" name="FrameWemployee" src="<%=strWemployee %>" width="97%" frameborder="0" scrolling="no"></iframe>
           
			 </td></tr>	
			  <tr height="150">
			  
          <td bgcolor="#f9f9f0" colspan="2" align="center">维修安装作业设备</td>
          <td colspan="6" > 
          <table border="0" cellspacing="1" cellpadding="3" BackColor="#9D9DA1" class="main-text" height="97%" width="97%">
          <tr><td width="20%"></td>         
           <td rowspan="2" bgcolor="#f5f5f1" align="center">
          <iframe id="FrameEList" name="FrameEList" src="<%=strEList %>" width="97%" frameborder="0" scrolling="no"></iframe>
          </td></tr>
          <tr>
          <td bgcolor="#f9f9f0" align="center">交通工具</td>
          <td></td>
          </tr>
          <tr>
          <td bgcolor="#f9f9f0" align="center">其它仪器设备</td>
          <td  bgcolor="#f5f5f1" align="center">
          
          <iframe id="FrameEList2" name="FrameEList2" src="<%=strEList2 %>" width="97%" frameborder="0" scrolling="no"></iframe>
          </td>
          </tr>
          </table>
          	 </td></tr>
          <tr height="250">
          <td bgcolor="#f9f9f0" colspan="2" align="center">送审资料</td>
          <td bgcolor="#f5f5f1" colspan="6">
          
          <iframe id="FrameCSFil" name="FrameCSFil" src="<%=strCSFil %>" width="97%" frameborder="0" scrolling="no"></iframe>
         </td>
          </tr>
                          </table>
                           </td>
                      </tr>
                      <tr> 
                        <td align="center">
                         <asp:Button ID="btnOK" runat="server"  Text="保 存" OnClick="btnOK_Click" /></td>
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
                      </td></tr>
                       </table>    
   
    </td>
  </tr>
</table>

    </form>
</body>
</html>
