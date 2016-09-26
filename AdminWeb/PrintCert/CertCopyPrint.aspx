<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertCopyPrint.aspx.cs" Inherits="PrintCert_CertCopyPrint" %>

<%@ Register Assembly="DevExpress.XtraReports3, Version=1.12.1.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxwc" %>
<html>
<head runat="server">
    <title>无标题页</title>
       <script language="javascript">
var HKEY_root,HKEY_Path,HKEY_Key; 
HKEY_Root="HKEY_CURRENT_USER"; 
HKEY_Path="\\Software\\microsoft\\Internet Explorer\\PageSetup\\"; 
//设置网页打印的页眉页脚为空 
function PageSetup_Null() 
{ 
 try 
 {
  document.all.factory.printing.portrait = false;
   document.all.factory.printing.leftMargin =0;
   document.all.factory.printing.topMargin = 0;
   document.all.factory.printing.rightMargin = 0;
   document.all.factory.printing.bottomMargin = 0;
//  document.all.factory.printing.paperSize ="A4"; 
  }
  catch(e)
  {
  alert(e.message);}
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
        <div>
            <table cellpadding="0" border="0" cellspacing="1" width="100%" style="display:none;">
                <tr>
                    <td>
                        <dxwc:ReportToolbar ID="ReportToolbar2" runat="server" ReportViewer="<%# CertReport2 %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <dxwc:ReportViewer ID="CertReport2" runat="server" BorderStyle="Inset" Width="412px"
                            ReportName="CertCopyReport" />
                    </td>
                </tr>
            </table>
            <table cellpadding="0" border="0" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <dxwc:ReportViewer ID="CertReport1" runat="server" ReportName="CertCopyReport" BorderStyle="Inset"
                            Width="412px" />
                    </td>
                </tr>
                <tr align="center">
                    <td>     <OBJECT id="factory" viewastext name="factory" style="DISPLAY:none;WIDTH:1px;HEIGHT:1px" codebase="../scriptx/smsx.cab#Version=6,3,436,14" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814">   
  </OBJECT>
                            <object  id="WebBrowser"  width="0"  height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
 <PARAM NAME="Offline" VALUE="0">
</object>
                   <input type="button" onclick="PageSetup_Null();TBarService.handleButton('ReportToolbar2','ReportToolbar2_PrintReport')" value="选择打印机打印" />
                       <%-- <asp:Button ID="Button1" runat="server" Text="打印" OnClick="Button1_Click"  />--%>
                         <input type="button" onclick="javascript:PageSetup_Null();document.all.WebBrowser.ExecWB(8,1)" value="打印设置" />   

                        </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
