<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertNO.aspx.cs" Inherits="LeftFrame_CertNO" %>
<html >
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript">
<!--
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
function setMainFrame(a)
{
parent.window.document.getElementById("mainFrame").src=a;
}
//-->
</script>
</head>

<body>
    <form id="form1" runat="server">
<table width="119" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td height="1" bgcolor="#9D9DA1"></td>
    </tr>
    <tr> 
      <td><table width="116" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="36" align="center" background="../img/left_bt_bg.gif" class="left-bt">证书管理</td>
          </tr>
        </table></td>
    </tr>
    <tr> 
<%--    bgcolor="#F2F2F2"--%>
      <td  align="center" valign="top" > 
        <table width="63" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="49"><a href="#" onclick="setMainFrame('CertNO/default.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image1','','../img/img_ico/7_1_2.gif',1)"><img src="../img/img_ico/7_1_1.gif" name="Image1" width="63" height="49" border="0"></a></td>
          </tr>
          <tr> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="49"><a href="#" onclick="setMainFrame('CertNO/CertNOList.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image2','','../img/img_ico/7_2_2.gif',1)"><img src="../img/img_ico/7_2_1.gif" name="Image2" width="63" height="49" border="0"></a></td>
          </tr>
          <tr> 
            <td>&nbsp;</td>
          </tr>
          <tr height="49"> 
            <td height="49"><a href="#" onclick="setMainFrame('CertNO/CertNOSearch.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image3','','../img/img_ico/L-18-2.gif',1)"><img src="../img/img_ico/L-18-1.gif" name="Image3" width="63" height="49" border="0"></a></td>
          </tr>
          <tr> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="49">&nbsp;</td>
          </tr>
          <tr> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="49">&nbsp;</td>
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
          <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
        </table>
      </td>
    </tr>
    <tr> 
      <td>&nbsp;</td>
    </tr>
  </table>
    </form>
</body>
</html>

