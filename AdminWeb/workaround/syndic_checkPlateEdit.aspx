<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_checkPlateEdit.aspx.cs" Inherits="workaround_syndic_checkPlateEdit" %>

<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>
<%@ Register Src="~/Control/WorkAroundTop.ascx" TagPrefix="cc1" TagName="WorkAroundTop" %>


<html  >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
     <script language="javascript" >
     function OpenAddProblemSort(id1,id2,id3)
     {
                    var features = 'width=600,height=300,scrollbars=no,left=250,top=350,resizable=yes';
	                var winName = '添加类型';
	                var Url = 'syndic_checkPlateAddSort.aspx?tid=' + id1+'&aid='+id2+'&pid='+id3;
	                var win = window.open(Url, winName, features);
	                win.focus();
     }
          function OpenEditProblemSort(id1,id2)
     {
                    var features = 'width=600,height=300,scrollbars=no,left=250,top=350,resizable=yes';
	                var winName = '编辑类型';
	                var Url = 'syndic_checkPlateAddSort.aspx?tid=' + id1+'&id='+id2;
	                var win = window.open(Url, winName, features);
	                win.focus();
     }
               function OpenEditProblem(id1)
     {
                    var features = 'width=700,height=500,scrollbars=no,left=250,top=100,resizable=yes';
	                var winName = '编辑类型';
	                var Url = 'syndic_problemList.aspx?id=' + id1;
	                var win = window.open(Url, winName, features);
	                win.focus();
     }
                function SetAddFrame(id)
                {
                trAdd.style.display="block";
                window.document.getElementById("FrameAdd").src="syndic_AddTopProblem.aspx?aid="+id+"&tid=1&pid=0";
                }
                function setDisPlay(a)
                {
                    var s=a.id;
                    s=s.replace("tr1", "tr2");
                    if( window.document.getElementById(s).style.display=='none')
                    {
                        window.document.getElementById(s).style.display="block";
                        window.document.getElementById('<%=txtShowID.ClientID %>').value+=s+',';
                                                          
                                 
                    }
                     else
                     {
                        window.document.getElementById(s).style.display='none';
                        window.document.getElementById('<%=txtShowID.ClientID %>').value=window.document.getElementById('<%=txtShowID.ClientID %>').value.replace(s+',','');
                 
                     }
                }
               window.onload=function(){             
                    var s=   window.document.getElementById('<%=txtShowID.ClientID %>').value; 
                    var ss;
                    if(s=='')
                    {}
                   else
                   {                   
                   var a=s.split(",");
                   for(var i=0;i<a.length;i++)
                   {
                     ss=a[i].replace(",", "");                     
                     if(ss!='')
                     window.document.getElementById(ss).style.display='block';
                   }
                   
                   }     
                }
</script>
</head>
<body>
    <form id="form1" runat="server">
   <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr style="display:none"> 
          <td colspan="3" >&nbsp;<asp:TextBox runat="server" ID="txtShowID" ></asp:TextBox><asp:Label runat="server" ID="lblID" Visible="false"></asp:Label></td>
            
        </tr>
          <tr> 
          <td colspan="3">&nbsp;</td>
            
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">评审</asp:Label></td>
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
        <td class="leftTitle" bgColor="#f9f9f0" width="20%"></td>
        <td bgColor="#f5f5f1" width="80%" align="left"></td>
    </tr>
      
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0">
            简介</td>
        <td bgColor="#f5f5f1" align="left">
            <asp:TextBox ID="txtDes" runat=server Width="90%" Height="100" TextMode=multiLine></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftTitle" bgColor="#f9f9f0">
            状态</td>
        <td bgColor="#f5f5f1" align="left">
            <asp:RadioButtonList ID="rblState" runat="server" RepeatColumns="3" CssClass="main-text">
            <asp:ListItem Text="激活" Value="1" ></asp:ListItem>
             <asp:ListItem Text="编辑" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="作废" Value="2" ></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>  
    <tr>
        <td bgColor="#f5f5f1" colspan="2" align=center>
            <asp:Button ID="btnSubmit" Text="保 存" CssClass="button" runat="server" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返 回" Class="button" id="btnBack" onclick="location.href='syndic_checkPlate.aspx'" />
        </td>
    </tr>
    <tr height="6"></tr>
     <tr bgcolor="#E7E2D6"> 
                <td height="1" colspan="2" ></td>               
              </tr>
     <tr><td align="right" colspan="2" >&nbsp;&nbsp;&nbsp;&nbsp; <input type="button" value="新增大题" class="button" id="btn" onclick="SetAddFrame('<%=Request.QueryString["id"] %>')" /> </td></tr>
     <tr id="trAdd" style="display:none"><td align="right" colspan="2" ><iframe height="100" id="FrameAdd" frameborder="0" scrolling="no" width="100%"></iframe></td></tr>
              
</TABLE>             
<asp:Repeater ID="rptProblemSort" runat="server" OnItemCommand="rptProblemSort_ItemCommand" OnItemDataBound="rptProblemSort_ItemDataBound">
<HeaderTemplate>
<table cellpadding='3' cellspacing='1'  border="0" class="main-text">
<tr  bgcolor="#E0DFE3">
<td class="body-bt" align="center" width="30px">序号</td>
<td class="body-bt" align="center" width="200px">题目</td>
<td class="body-bt" align="center" width="50px">总分</td>
<td class="body-bt" align="center" width="200px">备注</td>
<td class="body-bt" align="center" width="80px">操作人</td>
<td class="body-bt" align="center" width="90px">排序</td>
<td class="body-bt" align="center" width="30px">选择</td>
<td class="body-bt" align="center" width="30px">删除</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr  bgcolor="#f5f5f1">
<td class="main-text">
  <%#Container.ItemIndex+1%>.</td>
  <td class="main-text" onclick="<%#DataBinder.Eval(Container.DataItem, "hasChild").ToString()=="0"?"":"setDisPlay(this)" %>" id="tr1<%# DataBinder.Eval(Container.DataItem, "ID") %>" style="<%#DataBinder.Eval(Container.DataItem, "hasChild").ToString()=="0"?"":"cursor:hand;" %>">
 <%# DataBinder.Eval(Container.DataItem, "Name")%></td>
  <td class="main-text">
  <%# DataBinder.Eval(Container.DataItem, "Totle") %></td>
  <td class="main-text">
<%# DataBinder.Eval(Container.DataItem, "Remark") %></td>
  <td class="main-text">
<%# DataBinder.Eval(Container.DataItem, "userName") %></td>
  <td class="main-text">  
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="up" Runat="server" text="上移" ID="Linkbutton4"></asp:LinkButton>&nbsp;
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="down" Runat="server" text="下移" ID="Linkbutton5"></asp:LinkButton>&nbsp;
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CssClass="link-02" CommandName="top" Runat="server" text="置顶" ID="Linkbutton6"></asp:LinkButton>            
 </td>
  <td class="main-text">
   <a href="javascript:OpenEditProblemSort('0','<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">编辑</a>
    </td>
 <td>  <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="del" Runat="server" text="删除" OnLoad="LinkCategory_Load"  ID="Linkbutton2"></asp:LinkButton>
</td>				      
</tr>
<tr>
<td align="right" colspan="8"> &nbsp;&nbsp;&nbsp;<a href="javascript:OpenAddProblemSort('1','<%#Request.QueryString["id"] %>','<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">新增下级题目类型</a></td>
</td>
</tr>
<tr id="tr2<%# DataBinder.Eval(Container.DataItem, "ID") %>" style="display:none">
<td colspan="8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Repeater ID="rptSProblemSort" runat="server" OnItemCommand="rptProblemSort_ItemCommand" OnItemDataBound="rptSProblemSort_ItemDataBound">
<HeaderTemplate>
<table cellpadding='3' cellspacing='1'  border="0" bgcolor="#f5f5f1" class="main-text">
<tr bgcolor="#E7E2D6" height="1"><td colspan="8"></td></tr>
<tr  bgcolor="#E0DFE3">
<td class="body-bt" align="center" width="30px">序号</td>
<td class="body-bt" align="center" width="200px">题目</td>
<td class="body-bt" align="center" width="50px">总分</td>
<td class="body-bt" align="center" width="200px">备注</td>
<td class="body-bt" align="center" width="80px">操作人</td>
<td class="body-bt" align="center" width="90px">排序</td>
<td class="body-bt" align="center" width="30px">选择</td>
<td class="body-bt" align="center" width="30px">删除</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr  bgcolor="#f5f5f1">
<td class="main-text">
  (<%#Container.ItemIndex+1%>)</td>
    <td class="main-text" onclick="<%#DataBinder.Eval(Container.DataItem, "hasChild").ToString()=="0"?"":"setDisPlay(this)" %>" id="tr1<%# DataBinder.Eval(Container.DataItem, "ID") %>" style="<%#DataBinder.Eval(Container.DataItem, "hasChild").ToString()=="0"?"":"cursor:hand;" %>"> <%# DataBinder.Eval(Container.DataItem, "Name")%></td>
  <td class="main-text">
  <%# DataBinder.Eval(Container.DataItem, "Totle") %></td>
  <td class="main-text">
<%# DataBinder.Eval(Container.DataItem, "Remark") %></td>
  <td class="main-text">
<%# DataBinder.Eval(Container.DataItem, "userName") %></td>
  <td class="main-text">
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'   CssClass="link-02" CommandName="up" Runat="server" text="上移" ID="Linkbutton4"></asp:LinkButton>&nbsp;
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="down" Runat="server" text="下移" ID="Linkbutton5"></asp:LinkButton>&nbsp;
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="top" Runat="server" text="置顶" ID="Linkbutton6"></asp:LinkButton>            
 </td>
  <td class="main-text">
 <a href="javascript:OpenEditProblemSort('0','<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">编辑</a>
 </td>
 <td>  <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="del" Runat="server" text="删除"  OnLoad="LinkCategory_Load" ID="Linkbutton2"></asp:LinkButton>
</td>				      
</tr>
<tr>
<td align="right" colspan="8"><a href="javascript:OpenEditProblem('<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">所属题目</a>&nbsp;&nbsp;&nbsp; <a href="javascript:OpenAddProblemSort('1','<%#Request.QueryString["id"] %>','<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">新增下级题目类型</a></td>
</td>
</tr><tr id="tr2<%# DataBinder.Eval(Container.DataItem, "ID") %>" style="display:none">
<td colspan="8">
<asp:TextBox runat="server" ID="txtID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:TextBox>
<asp:Repeater ID="rptTProblemSort" runat="server" OnItemCommand="rptProblemSort_ItemCommand" >
<HeaderTemplate>
<table cellpadding='3' cellspacing='1'  border="0" bgcolor="#f5f5f1" class="main-text">
<tr  height="10"><td colspan="8"></td></tr>
<tr bgcolor="#E7E2D6" height="1"><td colspan="8"></td></tr>
<tr  bgcolor="#E0DFE3">
<td class="body-bt" align="center" width="30px">序号</td>
<td class="body-bt" align="center" width="200px">题目</td>
<td class="body-bt" align="center" width="50px">总分</td>
<td class="body-bt" align="center" width="200px">备注</td>
<td class="body-bt" align="center" width="80px">操作人</td>
<td class="body-bt" align="center" width="90px">排序</td>
<td class="body-bt" align="center" width="30px">选择</td>
<td class="body-bt" align="center" width="30px">删除</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr  bgcolor="#f5f5f1">
<td class="main-text">
  [<%#Container.ItemIndex+1%>]</td>
  <td class="main-text">
 <%# DataBinder.Eval(Container.DataItem, "Name")%></td>
  <td class="main-text">
  <%# DataBinder.Eval(Container.DataItem, "Totle") %></td>
  <td class="main-text">
<%# DataBinder.Eval(Container.DataItem, "Remark") %></td>
  <td class="main-text">
<%# DataBinder.Eval(Container.DataItem, "userName") %></td>
  <td class="main-text">
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="up" Runat="server" text="上移" ID="Linkbutton4"></asp:LinkButton>&nbsp;
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="down" Runat="server" text="下移" ID="Linkbutton5"></asp:LinkButton>&nbsp;
   <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="top" Runat="server" text="置顶" ID="Linkbutton6"></asp:LinkButton>            
 </td>
  <td class="main-text">
  <a href="javascript:OpenEditProblemSort('0','<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">编辑</a> </td>
 <td>  <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="del" Runat="server"  OnLoad="LinkCategory_Load" text="删除" ID="Linkbutton2"></asp:LinkButton>
</td>				      
</tr>
<tr>
<td align="right" colspan="8"><a href="javascript:OpenEditProblem('<%# DataBinder.Eval(Container.DataItem, "ID") %>')" class="link-02">所属题目</a>&nbsp;&nbsp;&nbsp; </td>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
<tr bgcolor="#E7E2D6" height="1"><td colspan="8"></td></tr>
<tr  height="10"><td colspan="8"></td></tr>
</table>
</FooterTemplate>
 </asp:Repeater>
 
  </td>
</tr>

</ItemTemplate>
<FooterTemplate>

<tr bgcolor="#E7E2D6" height="1"><td colspan="8"></td></tr>
<tr  height="10"><td colspan="8"></td></tr>
</table>
</FooterTemplate>
 </asp:Repeater>
 
 
 </td>
</tr>
</ItemTemplate>
<FooterTemplate>

</table>
</FooterTemplate>
 </asp:Repeater>
      
      
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
