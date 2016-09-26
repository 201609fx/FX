<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Stat_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">

   <table width="100%" height="738" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#F2F2F2">
  <tr> 
    <td valign="top"><table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td>&nbsp;</td>
        </tr>
        <tr> 
          <td class="left-bt">&nbsp;<img src="../img/body_ico_bt.gif" width="6" height="6">&nbsp;机构简介</td>
        </tr>
		<tr> 
          <td height="8"></td>
        </tr>
        <tr> 
          <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td width="16"><img src="../img/list_top_1.gif" width="16" height="32"></td>
                <td background="../img/list_top_2.gif" class="body-bt">&nbsp;</td>
                <td width="16"><img src="../img/list_top_3.gif" width="16" height="32"><asp:Label ID="lblID" runat="server" Visible="false"></asp:Label></td>
              </tr>
              <tr> 
                <td align="center" bgcolor="#ECEAE3"></td>
                <td bgcolor="#ECEAE3">
                
              <table width="100%" border="0" cellspacing="2" cellpadding="0" ID="Table2">
    <tr height="30">
        <td width="100" align="center" bgcolor="#DEDEDE" class="carte-menu-bt">科目</td>
        <td align="center" bgcolor="#DEDEDE" class="carte-menu-bt">统计结果</td>
    </tr>  
    <tr bgcolor="#DAECF2" height="25">
        <td class="main-text" align="right">申请企业总数</td>
        <td class="main-text" align="left">&nbsp;&nbsp;<asp:Label ID="lblSQ" runat="server" ForeColor="red"></asp:Label>&nbsp;&nbsp;</td>
    </tr>
    <tr bgcolor="#DAF0C0" height="25">
        <td class="main-text" align="right">已获证书总数</td>
        <td class="main-text" align="left">&nbsp;&nbsp;<asp:Label ID="lblYH" runat="server" ForeColor="red"></asp:Label>&nbsp;&nbsp;</td>
    </tr>
    <tr bgcolor="#FFF3C9" height="25">
        <td class="main-text" align="right">有效证书总数</td>
        <td class="main-text" align="left">&nbsp;&nbsp;<asp:Label ID="lblYX" runat="server" ForeColor="red"></asp:Label>&nbsp;&nbsp;</td>       
    </tr>
    <tr bgcolor="#E9F4F6" height="25">
        <td class="main-text" align="right">过期证书总数</td>
        <td class="main-text" align="left">&nbsp;&nbsp;<asp:Label ID="lblGQ" runat="server" ForeColor="red"></asp:Label>&nbsp;&nbsp;</td>
    </tr>
        <tr bgcolor="#E9F4F6" height="25">
        <td class="main-text" align="right">吊销证书总数</td>
        <td class="main-text" align="left">&nbsp;&nbsp;<asp:Label ID="lblDX" runat="server" ForeColor="red"></asp:Label>&nbsp;&nbsp;</td>
    </tr>
    <tr bgcolor="#EFEFEF" height="25">
        <td class="text-gray" colspan="2"></td>
    </tr>
    <tr>
        <td height="1" bgcolor="#989898" colspan="7"></td>
    </tr>
</table>  
					
										</td>
                <td bgcolor="#ECEAE3">&nbsp;</td>
                
              </tr>
              
										
              <tr> 
                <td height="2"></td>
                <td height="2"></td>
                <td height="2"></td>
              </tr>             
              <tr bgcolor="#E7E2D6"> 
                <td height="1"></td>
                <td></td>
                <td></td>
              </tr>
              <tr> 
                <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr class="main-text">
                      <td align="center"></td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>
