<%@ Page Language="C#" Theme="Pop" StylesheetTheme="Pop" AutoEventWireup="true" CodeFile="ApplyPrint.aspx.cs" Inherits="Cert_ApplyPrint" Title="Untitled Page" %>
<html>
<head id="Head1" runat="server">
    <title>申请书打印</title>
        <style media=print>  
/*
* @breif: 用本样式在打印时隐藏非打印项目
*/
.Noprint
{
 display:none;
}
/*
* @breif: 控制分页
*/
.PageNext
{
 page-break-after: always;
}
</style> 
        <script language="javascript">
var HKEY_root,HKEY_Path,HKEY_Key; 
HKEY_Root="HKEY_CURRENT_USER"; 
HKEY_Path="\\Software\\microsoft\\Internet Explorer\\PageSetup\\"; 
//设置网页打印的页眉页脚为空 
function PageSetup_Null() 
{ 
  document.all.factory.printing.portrait = true;

 try 
 { 
  var Wsh=new ActiveXObject("WScript.shell"); 
  HKEY_Key="header"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,""); 
  HKEY_Key="footer"; 
  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,""); 
 } 
 catch(e)
 {
  alert(e.message);
 } 
} 
        </script>
</head>
<body>
    <form id="form1" runat="server">
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">     

       <tr><td colspan="3" align="center" class="Print-bt3"><br/>
       <asp:Label runat="server" Visible="false" id="lblID"></asp:Label>
       </td></tr>
       <tr><td colspan="3" align="right">
       <span class="Noprint">
 <a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(6,6)" style="cursor:hand">〖打 印〗</a>&nbsp;<a style="cursor:hand" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(7,1)">〖预 览〗</a>&nbsp;<a onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" style="cursor:hand">〖打印设置〗</a></span>
 </td></tr>
       </table>       
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">  
        <tr> 
          <td colspan="3" align="center" valign="top">
      
<TABLE  width="100%" border="0"  cellpadding="0" cellspacing="0" class="Print-text2"> 

         <tr><td valign="top">
         <TABLE  width="100%" border="0" cellpadding="0" cellspacing="0" class="Print-text2"> 
             <tr><td colspan="3" align="right"  class="print-mainbt">编号:<asp:Label runat="server" ID="lblNO"></asp:Label></td></tr>
            <tr height="300"><td colspan="3" valign="middle" align="center" class="Print-btmain"><br/><br/>维修企业技术等级证书<br/><br/><br/><asp:Label runat="server" ID="lblApplyName"></asp:Label></td></tr>
              <tr height="400">
                 <td></td>
                 <td align="left">&nbsp;</td>
                 <td></td>
             </tr> 
             <tr>
                 <td width="20%">&nbsp;</td>
                 <td align="left" class="Print-Main1">企业名称（盖章）：</td>
                 <td></td>
             </tr> 
                <tr height="30">
                 <td></td>
                 <td align="left">&nbsp;</td>
                 <td></td>
             </tr> 
             <tr>
                 <td></td>
                 <td align="left" class="Print-Main1">申请日期：</td>
                 <td></td>
             </tr>
                <tr height="30">
                 <td></td>
                 <td align="left">&nbsp;</td>
                 <td></td>
             </tr> 
             <tr>
                 <td></td>
                 <td align="left" class="Print-Main1">交表日期：</td>
                 <td></td>
             </tr>
        </TABLE>
       </td>
        </tr>
        <tr height="30" class="PageNext"><td> &nbsp;</td></tr>
        <tr><td valign="top">
         <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 
  
          <tr height="40">
          <td   align="center" colspan="2">企业名称(全称)</td>
          <td colspan="6"><asp:Label runat="server" ID="txtCompany" Width="100%"></asp:Label></td>
          </tr>
          
          <tr height="40">
          <td  align="center">经营地址</td>
          <td colspan="5"><asp:Label runat="server" ID="txtAddress" Width="100%"></asp:Label></td>
          <td  align="center">邮编</td>
          <td><asp:Label runat="server" ID="txtCode" Width="100%"></asp:Label></td>
          </tr>
          <tr height="40">
          <td width="12%"  align="center">联系人</td>
          <td width="10%"><asp:Label runat="server" ID="txtContact" Width="100%"></asp:Label></td>
          <td  width="12%" align="center">固定电话</td>
          <td width="15%"><asp:Label runat="server" ID="txtPhone" Width="100%"></asp:Label></td>
          <td  width="12%" align="center">移动电话</td>
          <td width="12%"><asp:Label runat="server" ID="txtMobile" Width="100%"></asp:Label></td>
          <td  width="15%" align="center">传真</td>
          <td width="10%"><asp:Label runat="server" ID="txtFax" Width="100%"></asp:Label></td>
          </tr>
          
          <tr height="40">
          <td  align="center">法人代表</td>
          <td colspan="2"><asp:Label runat="server" ID="txtFrdb" Width="100%"></asp:Label></td>
          <td  align="center">联系电话</td>
          <td colspan="2"><asp:Label runat="server" ID="txtFtel" Width="100%"></asp:Label></td>
          <td  align="center">营业面积</td>
          <td><asp:Label runat="server" ID="txtArea" Width="100%"></asp:Label></td>       
          </tr>
          
         <tr height="40">
          <td  align="center">企业总人数</td>
          <td colspan="2"><asp:Label runat="server" ID="txtAnum" Width="100%"></asp:Label></td>
          <td  align="center">维修人员人数</td>
          <td colspan="2"><asp:Label runat="server" ID="txtMnum" Width="100%"></asp:Label></td>
          <td  align="center">安装人员人数</td>
          <td><asp:Label runat="server" ID="txtBnum" Width="100%"></asp:Label></td>       
          </tr>          
         
          <tr height="40">
          <td  colspan="2" height="100" align="center">维修业务范围<br/>(有特约维修业务的请注明)</td>
          <td colspan="6"><asp:Label runat="server" ID="txtOperation" Height="90" Width="100%" TextMode="MultiLine"></asp:Label></td>               
          </tr>
          
          <asp:Panel runat="server" ID="pnlOperation">
              <tr><td align="left" colspan="2">特约维修业务</td>
              <td colspan="6"  align="center" valign="top">
              <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tab1">
              <tr>
              <td align="center" valign="top"> 
                <asp:GridView ID="gvList"  runat="server"  AutoGenerateColumns="false" BorderWidth="1" CssClass="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" BackColor="Black" cellspacing="0" cellpadding="0" Width="100%"  ShowHeader="true">
	          <HeaderStyle  BackColor="#FFFFFF" HorizontalAlign="center" Font-Bold="false"  Height="40"  CssClass="Print-text2" />
	            <RowStyle BackColor="#FFFFFF" Height="40" CssClass="Print-text2" HorizontalAlign="Center" />
	            <Columns>	    
	            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="50" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#DataBinder.Eval(Container.DataItem, "ID").ToString()=="0"?"":(Container.DataItemIndex+1).ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
	            <asp:TemplateField HeaderText="类别" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">        
		      
			  <ItemTemplate>
			   <asp:Label ID="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SortName").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			
			  </asp:TemplateField>	
			      <asp:TemplateField HeaderText="内容" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150">
			  <ItemTemplate>
			   <asp:Label ID="lblContent" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Content").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			 
			  </asp:TemplateField>	    
			    <asp:TemplateField HeaderText="品牌" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80">
			  <ItemTemplate>
			   <asp:Label ID="lblbrand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brand").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>			 
			  </asp:TemplateField>	                   
	            </Columns>
            </asp:GridView>
              </td>
              </tr>
              </table>
           
			 </td>
          </tr>
          </asp:Panel>
          </TABLE>
          </td></tr>
          <tr height="20"><td> &nbsp;</td></tr>
      
         <asp:Panel ID="pnlSummary" runat="server" Visible="true">
        <tr>
          	 	 <td>
			 <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 

           <tr height="500" id="trSummary">
          <td   width="15%" align="center">企业总结</td>
          <td width="85%" ><asp:Label runat="server" ID="txtSummary" ></asp:Label></td>
        </tr>
        </TABLE>
        </td>
        </tr>
        
          <tr height="20" class="PageNext"><td> &nbsp;</td></tr>
          </asp:Panel>
         <tr><td>
         <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 
  
          <tr>
          <td  width="15%" align="center">管理人员/专业技术人员状况</td>
          <td colspan="85%" align="center" align="top" style="border-collapse:collapse;">
           <asp:GridView ID="gvMemployee" runat="server" AutoGenerateColumns="false" BorderWidth="1" CssClass="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" BackColor="Black" cellspacing="0" cellpadding="0" Width="100%"  ShowHeader="true">
	          <HeaderStyle  BackColor="#FFFFFF" HorizontalAlign="center" Font-Bold="false"  Height="40"  CssClass="Print-text2" />
	            <RowStyle BackColor="#FFFFFF" Height="40" CssClass="Print-text2" HorizontalAlign="Center" />
			 
			  <Columns>	
			
			 <asp:TemplateField  HeaderText="姓名" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100">
			 <ItemTemplate>
			 <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' Width="90"></asp:Label>
			</ItemTemplate>
			</asp:TemplateField> 			 
			  <asp:TemplateField HeaderText="学历" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			  <asp:Label ID="lblEducational" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "educational")%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>	
			  <asp:TemplateField HeaderText="岗位" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblEposition" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Eposition").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>		
			  <asp:TemplateField HeaderText="持有证书名称" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblcertName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "certName").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>		
			  <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblremark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "remark").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>	
			 </Columns>			 
			 </asp:GridView>
		</td>
		</tr>
		</TABLE>		
     </td></tr>	
		
          <tr height="20"><td> &nbsp;</td></tr>	 
	 <tr><td>
			 <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 

			 <tr>
			  
          <td  width="15%" align="center">安装/维修人员状况</td>
          <td width="85%" align="center" valign="top">
           <asp:GridView ID="gvWemployee" runat="server" AutoGenerateColumns="false" BorderWidth="1" CssClass="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" BackColor="White" cellspacing="0" cellpadding="0" Width="100%"  ShowHeader="true">
	          <HeaderStyle HorizontalAlign="center"  Height="40"  CssClass="Print-text2" />
	            <RowStyle BackColor="#FFFFFF" Height="40" CssClass="Print-text2" HorizontalAlign="Center" />
			  <Columns>	
			
			 <asp:TemplateField  HeaderText="姓名" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100">
			 <ItemTemplate>
			 <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' Width="90"></asp:Label>
			</ItemTemplate>
			</asp:TemplateField> 			 
			  <asp:TemplateField HeaderText="学历" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			  <asp:Label ID="lblEducational" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "educational")%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>	
			  <asp:TemplateField HeaderText="岗位" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblEposition" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Eposition").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>		
			  <asp:TemplateField HeaderText="持有证书名称" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblcertName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "certName").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>		
			  <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
			  <ItemTemplate>
			   <asp:Label ID="lblremark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "remark").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>		
			 </Columns>			 
			 </asp:GridView>
			 </td></tr>	
			 </table>
			 </td></tr>
			 
          <tr height="20" class="PageNext"><td> &nbsp;</td></tr>
			 	 <tr><td>
			 <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 

			  <tr>
			  
          <td  width="15%" align="center">维修安装作业设备</td>
          <td  width="85%" valign="top"  > 
          <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 
          <tr><td width="20%"></td>         
           <td rowspan="2" align="center">
            <asp:GridView ID="gvEList" runat="server" AutoGenerateColumns="false" BorderWidth="1" CssClass="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" BackColor="White" cellspacing="0" cellpadding="0" Width="100%"  ShowHeader="true">
	          <HeaderStyle HorizontalAlign="center"  Height="40"  CssClass="Print-text2" />
	            <RowStyle BackColor="#FFFFFF" Height="40" CssClass="Print-text2" HorizontalAlign="Center" />
	            <Columns>	
	            <asp:TemplateField HeaderText="(名称)型号" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="270">
			  <ItemTemplate>
			   <asp:Label ID="lbldes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "des").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>	
			      <asp:TemplateField HeaderText="数量" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			   <asp:Label ID="lblNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Num").ToString()%>' Visible="true"></asp:Label>
			 </ItemTemplate>
			  </asp:TemplateField>	
			          
		           	          
	            </Columns>
            </asp:GridView></td></tr>
          <tr>
          <td  align="center">交通工具</td>
          <td></td>
          </tr>
          <tr>
          <td  align="center">其它仪器设备</td>
          <td  align="center" valign="top">
          <asp:GridView ID="gvElist2"
         runat="server" AutoGenerateColumns="false" BorderWidth="1" CssClass="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" BackColor="White" cellspacing="0" cellpadding="0" Width="100%"  ShowHeader="false">
	          <HeaderStyle HorizontalAlign="center"  Height="40"  CssClass="Print-text2"  />
	            <RowStyle BackColor="#FFFFFF" Height="40" CssClass="Print-text2" HorizontalAlign="Center" />
	            <Columns>	
	            <asp:TemplateField HeaderText="(名称)型号" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="270">
			  <ItemTemplate>
			   <asp:Label ID="lbldes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "des").ToString()%>' Visible="true"></asp:Label>
			</ItemTemplate>
			  </asp:TemplateField>	
			      <asp:TemplateField HeaderText="数量" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			   <asp:Label ID="lblNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Num").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>		                   
	            </Columns>
            </asp:GridView></td>
          </tr>
          </TABLE>
          </td>
          </tr>
          </TABLE>
          	 </td></tr>
          	 
          <tr height="20"><td> &nbsp;</td></tr>
      
        <tr>
          	 	 <td>
			 <TABLE  width="100%" border="1" style="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" cellpadding="0" cellspacing="0" class="Print-text2"> 

          <tr>
          <td  width="15%" align="center">送审资料</td>
          <td width="85%" valign="top" ><asp:GridView ID="gvCSFile"          runat="server" AutoGenerateColumns="false" BorderWidth="1" CssClass="background-color:White;border-width:1px;border-style:Solid;border-color:Black;border-collapse:collapse;" BackColor="White" cellspacing="0" cellpadding="0" Width="100%"  ShowHeader="true">
	          <HeaderStyle HorizontalAlign="center"  Height="40"  CssClass="Print-text2" />
	            <RowStyle BackColor="#FFFFFF" Height="40" CssClass="Print-text2" HorizontalAlign="Center" />
	            <Columns>		           
		            <asp:TemplateField HeaderText="序号">
			            <ItemStyle Width="10%" HorizontalAlign="center" />
			            <ItemTemplate>
				            <%#DataBinder.Eval(Container.DataItem, "ID").ToString()=="0"?"":(Container.DataItemIndex+1).ToString()%>
			            </ItemTemplate>
		            </asp:TemplateField>
		             
		      <asp:TemplateField HeaderText="目录" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="300">
			  <ItemTemplate>
			   <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>' Visible="true"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>	
			      <asp:TemplateField HeaderText="份数" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60">
			  <ItemTemplate>
			   <asp:Label ID="lblNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Num").ToString()%>' Visible="true"></asp:Label>
			  <asp:Label ID="txtNum" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Num")%>' Visible="false" Width="97%"></asp:Label>
			  </ItemTemplate>
			  </asp:TemplateField>	     
	            </Columns>
            </asp:GridView></td>
          </tr>
          </TABLE>
          </td>
          </tr>
</TABLE>   
 </td>
            </tr>
                <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="http://www.meadroid.com/scriptx/smsx.cab#Version=5,60,0,360" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
  </OBJECT>
                          <object  id="WebBrowser"  width="0"  height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
 <PARAM NAME="Offline" VALUE="0">
</object>
                    <tr bgcolor="white"> 
                <td height="6"></td>
                <td height="6"></td>
                <td height="6"></td>
              </tr>
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>       
         </table>
         </form>

</body>
</html>


