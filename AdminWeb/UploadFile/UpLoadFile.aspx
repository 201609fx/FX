<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoadFile.aspx.cs" Inherits="FileUpLoad_UpLoadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../styles/style_enter1.css" rel="stylesheet" type="text/css">
</head>
<body>

  		<script language="javascript">
  		window.onload=function(){
  var ptd = window.parent.document.getElementById("Myiframe");
   ptd.style.height = document.body.scrollHeight;
}
   function iframeAutoFit()
   {
      try
      {
         if(window!=parent)
         {
          var a = parent.document.getElementsByTagName("Myiframe");
            for(var i=0; i<a.length; i++) //author:meizz
            {
               if(a[i].contentWindow==window)
               {
                   var h = document.body.scrollHeight;
                   if(document.all) {h += 4;}
                   if(window.opera) {h += 1;}
                   a[i].style.height = h;
               }
            }
         }
      }
      catch (ex)
      {
         alert("脚本无法跨域操作！");
      }
   }
   if(document.attachEvent)  window.attachEvent("onload",  iframeAutoFit);  
   else  window.addEventListener('load',  iframeAutoFit,  false);  
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0" bgcolor=#F2F2F2 >
				<%--<TR >
					<TD class="main-text" align="center" colSpan="2" height="26">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="11">&nbsp;</TD>
								<TD class="bt-hui" height="25">上传文件</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>--%>
				<TR>
					<TD class="main-text" >文件名称:</TD>
					<TD class="main-text">
						<asp:textbox id="txtFileName" runat="server" cssclass="input-200" Width=93%>文件</asp:textbox>
						<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtFileName" ErrorMessage="*"></asp:RequiredFieldValidator><asp:Label id="lblFileName" Runat="server" ForeColor="Red" Visible="False">请输入附件名称</asp:Label></TD>
				</TR>
				<TR>
					<TD class="main-text">文件上传:</TD>
					<TD class="main-text"><INPUT Class="input-enter1" id="myFile" type="file" name="myFile" runat="server">
						<asp:Button id="btn_upload" Runat="server" CssClass="button-blue" Text="Upload..." OnClick="btn_upload_Click"></asp:Button>
					</TD>
				</TR>
				</table>
				
				<asp:Panel ID="panelShowFiles" Runat="server">
				<table cellSpacing="0" cellPadding="0" width="100%" border="1" bgcolor=#F2F2F2 rules=rows>
				<tr >
				<td>
				<table cellSpacing="1" cellPadding="0" width="100%" border="0" bgcolor=#F2F2F2  >			
					<asp:repeater id="rptList" Runat="server" OnItemCommand="rptList_ItemCommand">
						<HeaderTemplate>
							<tr>
								<td align="center"  class="main-text">序号</td>
								<Td align="center"  class="main-text">文件名</Td>
								<td align="center" width="50" class="main-text">操作</td>
							</tr>
						</HeaderTemplate>
						<ItemTemplate>
						<tr height=1 bgcolor="#989898">
						<td colspan="3"></td>
						</tr>
							<tr>
								<td align="center"  class="main-text"><%# Container.ItemIndex+1 %></td>
								<td align="left" class="left-bt">&nbsp;&nbsp;&nbsp;&nbsp;<a target=_blank href='<%#  System.Configuration.ConfigurationManager.AppSettings["FileDownLoadUrl"]+"/"+DataBinder.Eval(Container.DataItem, "TableName").ToString()+"/"+DataBinder.Eval(Container.DataItem, "SortName").ToString()+"/"+DataBinder.Eval(Container.DataItem, "FileUrl").ToString()  %>' class="link-03"><%#((System.Data.DataRowView)Container.DataItem)["Name"]%></a></td>
								<td align="center"  class="left-bt">&nbsp;<ASP:LINKBUTTON id="Linkbutton3" CssClass="link-03" runat="server" text="删除" commandname="delete" commandargument='<%# DataBinder.Eval(Container.DataItem, "FileID") %>' onload="DeleteCategory_Load">
									</ASP:LINKBUTTON>
								</td>
							</tr>
						</ItemTemplate>						
					</asp:repeater>
					</table>
					</td>
				 </tr>
				 </TABLE>
				</asp:Panel>
		
		</form>
</body>
</html>
