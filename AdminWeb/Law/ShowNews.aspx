<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowNews.aspx.cs" Inherits="Law_ShowNews" %>

<html >
<head runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    
      <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">政策法规</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"><asp:Label ID="lblID" Visible="false" runat="server"></asp:Label></td>
        </tr>
          <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%">&nbsp;</td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
        <tr> 
          <td colspan="3">
    <table width="740" border="0" align="center" cellpadding="0" cellspacing="0" class="text-wz">
                             <asp:Panel ID="pnlNew" runat="server" >
                            
									<tr><td height="20" align="center"><asp:Label cssclass="bt-hui3" id="labTitle" runat="server"></asp:Label></td></tr>
							
							<tr>
								<td height="20" align="center" class="bt-hui">
									发布时间：<asp:Label id="labIssueDate" runat="server"></asp:Label>&nbsp;&nbsp; 浏览次数：<asp:Label id="labClickTimes" runat="server"></asp:Label>&nbsp;&nbsp; 
									来源：<asp:Label id="labRefer" runat="server"></asp:Label></td>
							</tr>
							
                             </asp:Panel>
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
										<td align="left" ><img src="../img/tztg_ico.gif" width="3" height="5">&nbsp;<a class="link-03" href='<%# System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+"\\"+DataBinder.Eval(Container.DataItem, "TableName")+"\\"+DataBinder.Eval(Container.DataItem, "SortName")+"\\"+DataBinder.Eval(Container.DataItem, "FileUrl")  %>' target=_blank><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
									</tr>
								</ItemTemplate>
								<AlternatingItemTemplate>
									<tr>
										<td align="left"><img src="../img/tztg_ico.gif" width="3" height="5">&nbsp;<a class="link-03" href='<%#System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+"\\"+DataBinder.Eval(Container.DataItem, "TableName").ToString()+"\\"+DataBinder.Eval(Container.DataItem, "SortName")+"\\"+DataBinder.Eval(Container.DataItem, "FileUrl") %>' target=_blank><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
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
                    </table>
	</td>
	</tr>
        
	</table>
	</td>
	</tr>
	</table>
	
    </form>
</body>
</html>
