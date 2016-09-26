<%@ Page Language="C#" AutoEventWireup="true" CodeFile="syndic_problemList.aspx.cs" Inherits="workaround_syndic_problemList" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc2" %>
<%@ Register Src="~/Control/WorkAroundTop.ascx" TagPrefix="cc1" TagName="WorkAroundTop" %>

<html >
<head runat="server">
    <title>无标题页</title>
    <script language="javascript">
    function setFrame(id1)
    {
      window.document.getElementById("FrameProblem").style.display="block";
      window.document.getElementById("FrameProblem").src="syndic_problemAdd.aspx?sid="+id1;
    }
    function setEFrame(id1,id2)
    {
      window.document.getElementById("FrameProblem").style.display="block";
      window.document.getElementById("FrameProblem").src="syndic_problemAdd.aspx?sid="+id1+"&id="+id2;
    }
    </script>
   <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="13"></td>
    </tr>

	<tr>
      <td><table width="690" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td colspan="3"><table width="690" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_1.gif" width="14" height="29"></td>
                  <td background="../img/tc_3.gif" class="body-bt"><asp:Label runat="server" ID="lblSortName">题目列表</asp:Label></td>
                  <td width="14"><img src="../img/tc_2.gif" width="14" height="29"></td>
                </tr>
              </table></td>
          </tr>          
 <tr>
      <td height="13" align="right" colspan="3" width="100%">
      <input type="button" class="button" value="新 增" onclick="setFrame('<%=Request.QueryString["ID"] %>')" />
    <iframe id="FrameProblem" scrolling="no" frameborder="0" width="100%" style="display:none"></iframe>  
      </td>
    </tr>
    
          <tr>
            <td bgColor="#f5f5f1" colspan="3">
            
              <asp:GridView ID="gvList" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand" >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="50" HorizontalAlign="center" />
			            <ItemTemplate>
				            <asp:Label ID="Rowkey" runat="server" Text='<%#Container.DataItemIndex+AspNetPager1.StartRecordIndex%>'>
				            </asp:Label>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="题目(名称)" ItemStyle-Width="180">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
			                <a href="FirstAuditingCheck.aspx?mid=<%#((System.Data.DataRowView)Container.DataItem)["ID"]%>&tid=<%# Request.QueryString["tid"] %>" Class="link-02">
		                    <%#((System.Data.DataRowView)Container.DataItem)["ProblemContent"]%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>		           
		            <asp:TemplateField HeaderText="总分" ItemStyle-Width="60">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#((System.Data.DataRowView)Container.DataItem)["Totle"].ToString()%>分
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="类型" ItemStyle-Width="100">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            &nbsp;<%#gettype(((System.Data.DataRowView)Container.DataItem)["ProblemTypeID"].ToString())%>
			            </ItemTemplate>
		            </asp:TemplateField>
		                       <asp:TemplateField HeaderText="创建时间" ItemStyle-Width="80">
		                <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["CreateTime"].ToString()).ToShortDateString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		                <asp:TemplateField HeaderText="排序" ItemStyle-Width="100">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
				            <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="up" Runat="server" text="上移" ID="Linkbutton4"></asp:LinkButton>&nbsp;
                           <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'  CssClass="link-02" CommandName="down" Runat="server" text="下移" ID="Linkbutton5"></asp:LinkButton>&nbsp;
                           <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CssClass="link-02" CommandName="top" Runat="server" text="置顶" ID="Linkbutton6"></asp:LinkButton>            
                         </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="操作" ItemStyle-Width="120">
		                <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
			            
			            <a class="link-02" style="cursor:hand"  id="A1" href="syndic_optionEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ID")%>&pid=<%#Request.QueryString["id"] %>">编辑选项</a>
				              <a class="link-02" style="cursor:hand"  id="UnPass" onclick="setEFrame('<%#Request.QueryString["id"] %>','<%#((System.Data.DataRowView)Container.DataItem)["ID"]%>')">编辑</a>
				         <asp:LinkButton runat="server" CssClass="link-02"  CommandArgument='<%# ((System.Data.DataRowView)Container.DataItem)["ID"]%>' ID="LinkButton1" CommandName="del" Text="删除" OnLoad="LinkCategory_Load" ></asp:LinkButton>
			            </ItemTemplate>
		            </asp:TemplateField>
	            </Columns>
            </asp:GridView>
            
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
                <td colspan="3" align="center"><table width="690" border="0" cellspacing="0" cellpadding="0">
                    <tr class="main-text">
                      <td width="200" height="25"><asp:Label ID="lblNum" runat="server">共100条，分6页显示。</asp:Label></td>
                      <td align="right"><cc2:aspnetpager id="AspNetPager1" AlwaysShow="true" PageSize="20" FirstPageText="首页" PrevPageText="上一页"  NextPageText="下一页" LastPageText="尾页" runat="server"></cc2:aspnetpager></td>
                    </tr>
                  </table></td>
              </tr>       
          <tr>
          <td align="center" colspan="3" bgcolor="#F0EEE9">&nbsp;&nbsp;<object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object><input type="button" onclick="window.close()" value="关闭" /></td>
          </tr>
          <tr>
            <td colspan="3"><table width="690" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="14"><img src="../img/tc_4.gif" width="14" height="10"></td>
                  <td width="662" background="../img/tc_6.gif"></td>
                  <td width="14"><img src="../img/tc_5.gif" width="14" height="10"></td>
                </tr>
              </table></td>
          </tr>
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
  </table>
    </form>
</body>
</html>
