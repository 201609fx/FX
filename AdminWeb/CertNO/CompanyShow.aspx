<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyShow.aspx.cs" Inherits="CertNO_CompanyShow" %>


 <html>
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
    <script language="javascript">
    window.onload=function(){
    var s=location.href; 
    if(s.indexOf('tid=1')>0)
    {
        trSummary.style.display="none";  
    }
    }
    </script>
</head>
<body>
    <form id="form2" runat="server">
   <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt" colspan="3">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;<asp:Label runat="server" ID="lblSortName">初审</asp:Label></td>
        </tr>
		<tr> 
          <td height="8" colspan="3"></td>
        </tr>
        <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt"  width="100%" align="center"><asp:Label id="lblTitle" runat="server">申请表审核</asp:Label></td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"></td>
       </tr>
       <tr><td colspan="3"  height="10"></td></tr>
        <tr> 
          <td colspan="3">
          
          <table  width="100%" border="0" align="center" cellpadding="1" cellspacing="3" BackColor="#9D9DA1" class="main-text">
          <tr>
          <td  bgcolor="#f9f9f0" >企业名称(全称)</td>
          <td colspan="7" bgColor="#f5f5f1"><asp:Label runat="server" ID="lblCompany" Width="100%"></asp:Label></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0">经营地址</td>
          <td colspan="5" bgColor="#f5f5f1"><asp:Label runat="server" ID="lblAddress" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0">邮编</td>
          <td bgColor="#f5f5f1"><asp:Label runat="server" ID="lblCode" Width="100%"></asp:Label></td>
          </tr>
          
          <tr>
          <td width="11%" bgcolor="#f9f9f0">联系人</td>
          <td width="10%" bgColor="#f5f5f1"><asp:Label runat="server" ID="lblContact" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0" width="10%">固定电话</td>
          <td bgColor="#f5f5f1" width="10%"><asp:Label runat="server" ID="lblPhone" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0" width="10%">移动电话</td>
          <td bgColor="#f5f5f1" width="20%"><asp:Label runat="server" ID="lblMobile" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0" width="9%">传真</td>
          <td bgColor="#f5f5f1" width="20%"><asp:Label runat="server" ID="lblFax" Width="100%"></asp:Label></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0">法人代表</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:Label runat="server" ID="lblFrdb" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0">联系电话</td>
          <td bgColor="#f5f5f1"colspan="2"><asp:Label runat="server" ID="lblFtel" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0">营业面积</td>
          <td bgColor="#f5f5f1"><asp:Label runat="server" ID="lblArea" Width="100%"></asp:Label></td>       
          </tr>
          
         <tr>
          <td bgcolor="#f9f9f0">企业总人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:Label runat="server" ID="lblAnum" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0">维修人员人数</td>
          <td bgColor="#f5f5f1" colspan="2"><asp:Label runat="server" ID="lblMnum" Width="100%"></asp:Label></td>
          <td bgcolor="#f9f9f0">安装人员人数</td>
          <td bgColor="#f5f5f1"><asp:Label runat="server" ID="lblBnum" Width="100%"></asp:Label></td>       
          </tr>
          
              <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100" align="center">维修业务范围<br>(有特约维修业务的请注明)</td>
          <td bgcolor="#f5f5f1" colspan="6">          
          
          <asp:GridView ID="gvOperationMain"
          runat="server" AutoGenerateColumns="false" BorderWidth="0"   BackColor="#9D9DA1" cellspacing="1" ShowHeader="true" cellpadding="0" Width="100%"  style="font-size:12px;">

	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>	    
	            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="50" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#DataBinder.Eval(Container.DataItem, "ID").ToString()=="0"?"":(Container.DataItemIndex+1).ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
	            <asp:TemplateField HeaderText="范围" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="450">        
		      
			  <ItemTemplate>
			   <asp:Label ID="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductName").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>			                    
	            </Columns>
            </asp:GridView> </td>               
          </tr>
          <asp:Panel runat="server" ID="pnlOperation" Visible="false">
          <tr><td bgcolor="#f9f9f0" colspan="2" align="left">特约维修业务</td>
              <td colspan="6"  bgcolor="#f5f5f1" align="center" valign="top">
               <asp:GridView ID="gvOperation"
          runat="server" AutoGenerateColumns="false" BorderWidth="0"   BackColor="#9D9DA1" cellspacing="1" ShowHeader="true" cellpadding="0" Width="100%"  style="font-size:12px;">

	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            
	            <Columns>	    
	            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="50" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#DataBinder.Eval(Container.DataItem, "ID").ToString()=="0"?"":(Container.DataItemIndex+1).ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
	            <asp:TemplateField HeaderText="范围" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350">        
		      
			  <ItemTemplate>
			   <asp:Label ID="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SortName").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>	    
			   <asp:TemplateField HeaderText="品牌" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150">
			  <ItemTemplate>
			   <asp:Label ID="lblbrand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BrandName").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>		                    
	            </Columns>
            </asp:GridView>
           
			 </td>
          </tr>
          </asp:Panel>
          
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100">管理人员/专业技术人员状况</td>
          <td bgcolor="#f5f5f1" colspan="6"><asp:GridView ID="gvMemployee" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="5%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%# Container.DataItemIndex+1%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <asp:BoundField ItemStyle-Width="15%" HeaderText="姓名" DataField="Name" />	 
		             <asp:BoundField ItemStyle-Width="15%" HeaderText="学历" DataField="educational" />	
		              <asp:BoundField ItemStyle-Width="15%" HeaderText="岗位" DataField="Eposition" />	 
		               <asp:BoundField ItemStyle-Width="25%" HeaderText="持有证书名称" DataField="certName" />	 
		                <asp:BoundField ItemStyle-Width="25%" HeaderText="备注" DataField="remark" />           
	            </Columns>
            </asp:GridView></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100">安装/维修人员状况</td>
          <td bgcolor="#f5f5f1" colspan="6"><asp:GridView ID="gvWemployee" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="5%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%# Container.DataItemIndex+1%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <asp:BoundField ItemStyle-Width="15%" HeaderText="姓名" DataField="Name" />	 
		             <asp:BoundField ItemStyle-Width="15%" HeaderText="学历" DataField="educational" />	
		              <asp:BoundField ItemStyle-Width="15%" HeaderText="岗位" DataField="Eposition" />	 
		               <asp:BoundField ItemStyle-Width="25%" HeaderText="持有证书名称" DataField="certName" />	 
		                <asp:BoundField ItemStyle-Width="25%" HeaderText="备注" DataField="remark" />           
	            </Columns>
            </asp:GridView></td>
          </tr>
          
          <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100">维修安装作业设备</td>
          <td colspan="6">
          <table border="0" cellspacing="1" cellpadding="3" BackColor="#9D9DA1" class="main-text" height="100%" width="100%">
          <tr><td width="20%"></td>         
           <td rowspan="2"> <asp:GridView ID="gvEList" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="(名称)型号">
			            <ItemStyle Width="80%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#((System.Data.DataRowView)Container.DataItem)["des"]%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="数量" ItemStyle-Width="20%">
			            <ItemStyle HorizontalAlign="left" />
			            <ItemTemplate>
		                    <%#((System.Data.DataRowView)Container.DataItem)["Num"]%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>		          
	            </Columns>
            </asp:GridView></td></tr>
          <tr>
          <td bgcolor="#f9f9f0">交通工具</td>
          <td></td>
          </tr>
          <tr>
          <td bgcolor="#f9f9f0">其它仪器设备</td>
          <td><asp:GridView ID="gvElist2" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false" ShowHeader="false" >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="(名称)型号">
			            <ItemStyle Width="80%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#((System.Data.DataRowView)Container.DataItem)["des"]%>
			            </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText="数量" ItemStyle-Width="20%">
			            <ItemStyle HorizontalAlign="center" />
			            <ItemTemplate>
		                    <%#((System.Data.DataRowView)Container.DataItem)["Num"]%>
		                    </a>
			            </ItemTemplate>
		            </asp:TemplateField>		          
	            </Columns>
            </asp:GridView></td>
          </tr>
          </table>
          </td>          
          </tr>  
                  
         <tr height="300" id="trSummary">
          <td  bgcolor="#f9f9f0">企业总结</td>
          <td colspan="7" bgColor="#f5f5f1"><asp:Label runat="server" ID="lblSummary" Width="100%" Height="100%"></asp:Label></td>
        </tr>
        
         <tr>
          <td bgcolor="#f9f9f0" colspan="2" height="100">送审资料</td>
          <td bgcolor="#f5f5f1" colspan="6"><asp:GridView ID="gvCSFile" runat="server" Width="100%" BorderWidth="0" cellpadding="0" cellspacing="1"
	            BackColor="#9D9DA1" style="font-size:12px;" AutoGenerateColumns="false"  >
	            <HeaderStyle BackColor="#E0DFE3" HorizontalAlign="center" Font-Size="12px" Height="23" Font-Bold="true" />
	            <RowStyle BackColor="#f5f5f1" Height="23" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="10%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%# Container.DataItemIndex+1%>
			            </ItemTemplate>
		            </asp:TemplateField>
		              <asp:BoundField ItemStyle-Width="70%" HeaderText="目录" DataField="Name" />	 
		             <asp:BoundField ItemStyle-Width="20%" HeaderText="份数" DataField="Num" DataFormatString="{0}份" />          
	            </Columns>
            </asp:GridView></td>
          </tr>
          
           <tr  >
 <script language="javascript" >
               function OpenUnPass(id1,id2)
                {
	                var features = 'width=600,height=300,scrollbars=no,left=250,top=250,resizable=yes';
	                var winName = '不通过';
	                var Url = 'FirstAuditing_PopWindow.aspx?mid=' + escape(id1)+'&tid='+id2;
	                var win = window.open(Url, winName, features);
	                win.focus();
                }
</script>
          &nbsp;&nbsp;</td>
        </tr>
          </table>
          
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
