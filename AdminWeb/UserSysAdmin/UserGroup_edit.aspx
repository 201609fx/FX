<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroup_edit.aspx.cs" Inherits="UserSysAdmin_UserGroup_edit" %>

<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
        
  <script language="javascript">
    function selectAll(sender) 
    {
        var container = sender.parentNode;        
        while (container.tagName.toUpperCase() == "SPAN"||container.tagName.toUpperCase() == "TD"||container.tagName.toUpperCase() == "TR") { // 服务器控件设置呈现为 table 布局（默认设置），否则使用流布局
            container = container.parentNode; // 层次： <table><tr><td><input />
        }        
        
        var sel = document.all["<%=txtRights.ClientID%>"];        
	         sel.value ="";
        var chkList = container.getElementsByTagName("input");
        var senderState = sender.checked;
        if(senderState)   
        {
            var str ; 
            for(var i=0; i<chkList.length;i++) {
            if(chkList[i].id.toUpperCase().indexOf('CHK')>-1)
             {       
                chkList[i].checked = senderState;         
	                  str= ","+chkList[i].value + ",";
	                 sel.value += str;
	          }
            }    
        }
        else
        {
            for(var i=0; i<chkList.length;i++) {
                if(chkList[i].id.toUpperCase().indexOf('CHK')>-1)
                 {       
                    chkList[i].checked = senderState; 
	             }
	        }
        }
        
   }
     function selectChange(sender) 
    {
        var container = sender.parentNode;        
        while (container.tagName.toUpperCase() == "SPAN"||container.tagName.toUpperCase() == "TD"||container.tagName.toUpperCase() == "TR") { // 服务器控件设置呈现为 table 布局（默认设置），否则使用流布局
            container = container.parentNode; // 层次： <table><tr><td><input />
        }        
        
        var sel = document.all["<%=txtRights.ClientID%>"];
        sel.value="";
        var chkList = container.getElementsByTagName("input");
        for(var i=0; i<chkList.length;i++) {
        if(chkList[i].id.toUpperCase().indexOf('CHK')>-1)
            {
               chkList[i].checked = !chkList[i].checked;
               if(chkList[i].checked)
                {
		          sel.value += ","+ chkList[i].value+",";
	            }
	           else
	            {
		            sel.value = sel.value.replace(","+ chkList[i].value+",","");
	             }
            }
        }             
    }
    
 function SelectOne(obj)
{
	var sel = document.all["<%=txtRights.ClientID%>"];
	var str = ","+obj.value + ",";
	if(obj.checked)
	{
		sel.value += str;
	}
	else
	{
		sel.value = sel.value.replace(str,"");
	}
	return true;
}

function setTxt()
{
	var str = ","+obj.value + ",";
		sel.value += str;
}
    function InitSelect()
    {
      var chkList = document.documentElement.getElementsByTagName("input");
      var txtright= document.getElementById('<%=txtRights.ClientID %>');
       for(var i=0; i<chkList.length;i++) {
              if(chkList[i].id.toUpperCase().indexOf('CHK')>-1)
                   {
                     if( txtright.value.indexOf(','+chkList[i].value+',')>-1)
                     {
                         chkList[i].checked=true;
                     }
                     else
                     {
                        chkList[i].checked=false;
                     }
                   }
        }   
    }
    window.attachEvent("onload", InitSelect);
 </script>
 
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
        <tr style="display:none;"><td>    <asp:TextBox runat="server" ID="txtRights" Visible="true"></asp:TextBox></td></tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">用户组编辑</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
        <tr> 
          <td colspan="3">
      
      
      <TABLE cellSpacing="1" cellPadding="3" width="100%" border="0" class="main-text"> 
      
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0" align="left" width="12%">
            用户组名称</td>
        <td bgColor="#f5f5f1" align="left" width="35%">
        <asp:TextBox runat="server" ID="txtName" Width="90%"></asp:TextBox></td>                
    </tr>
   <tr>
   <td class="leftTitle" bgColor="#f9f9f0" align="left" width="12%" rowspan="2">
            选择权限</td>
        <td  bgColor="#f5f5f1" align="left" colspan="5">
         <asp:DataList ID="DLRights" runat="server" RepeatColumns="4" CssClass="main-text">
         <HeaderTemplate>
          <input type="checkbox" onclick="selectAll(this)"/>全选 &nbsp;&nbsp;&nbsp;<input type="checkbox" onclick="selectChange(this)"/>反选&nbsp;&nbsp;&nbsp;
         </HeaderTemplate>
         <ItemTemplate>
         <input onclick="return SelectOne(this)" type="checkbox" id="chk<%#((System.Data.DataRowView)Container.DataItem)["RightID"]%>" value='<%#((System.Data.DataRowView)Container.DataItem)["RightID"]%>' />
         [<%#((System.Data.DataRowView)Container.DataItem)["RightID"].ToString()%>]<%#((System.Data.DataRowView)Container.DataItem)["Description"].ToString()%>
         </ItemTemplate>
         </asp:DataList>
          </td>
    </tr>
    <script type="text/javascript" language="javascript">

    </script>
    <tr>
        <td bgColor="#f5f5f1" colspan="6" align="center">
        <asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
            <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" Class="button" id="btnBack" onclick="location.href='UserGroupList.aspx'" />&nbsp;&nbsp;
        </td>
    </tr>
    <tr ><td colspan="6" height="6"></td></tr>
     <tr bgcolor="#E7E2D6"> 
                <td height="1" colspan="6" ></td>               
              </tr>                
</TABLE>            
      
      
            </td>
            </tr>           
              <tr> 
                <td height="6"></td>
                <td height="6"></td>
                <td height="6"></td>
              </tr>
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>
              <tr> 
                <td colspan="3"></td>
              </tr>
            </table>    
   
    </td>
  </tr>
</table>
    </form>
</body>
</html>
