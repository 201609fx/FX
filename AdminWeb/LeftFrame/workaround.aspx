﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workaround.aspx.cs" Inherits="LeftFrame_workaround" %>

<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>工作区</title>
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



<table width="119" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td height="1" bgcolor="#9D9DA1" colspan="2"></td>
    </tr>
    <tr> 
      <td colspan="2"><table width="116" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="36" align="center" background="../img/left_bt_bg.gif" class="left-bt" colspan="2">工作区</td>
          </tr>
        </table></td>
    </tr>
    
    <tr id="tr1"> 
   
      <td height="700" align="right" valign="top" > 
      <div id=demo style=overflow:hidden;height:700;width:91;background:#FFFFFF;color:#FFFFFF>
<div id=demo1>
<!-- 定义图片 -->

        <table width="63" border="0" cellspacing="0" cellpadding="0" >
          <tr height="11"> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="40"><a style="cursor:hand;"   onclick="setMainFrame('workaround/FirstAuditing.aspx?tid=1')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image1','','../img/img_ico/L-01-2.gif',1)"><img src="../img/img_ico/L-01-1.gif" name="Image1" width="63" height="49" border="0"></a></td>
          </tr>
          <tr height="1"> 
            <td>&nbsp;</td>
          </tr>
          <tr  > 
            <td height="65"><a style="cursor:hand;"   onclick="setMainFrame('workaround/FirstCheck.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image2','','../img/img_ico/L-02-2.gif',1)"><img src="../img/img_ico/L-02-1.gif" name="Image2" width="63" height="63" border="0" id="Image2"></a></td>
          </tr>
          <tr height="1"> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="40"><a style="cursor:hand;"   onclick="setMainFrame('workaround/syndic.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image3','','../img/img_ico/L-03-2.gif',1)"><img src="../img/img_ico/L-03-1.gif" name="Image3" width="63" height="49" border="0" id="Image3"></a></td>
          </tr>
          <tr height="1"> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="40"><a style="cursor:hand;"   onclick="setMainFrame('workaround/Result.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image4','','../img/img_ico/L-04-2.gif',1)"><img src="../img/img_ico/L-04-1.gif" name="Image4" width="63" height="49" border="0" id="Image4"></a></td>
          </tr>
          <tr height="1"> 
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td height="40"><a style="cursor:hand;"   onclick="setMainFrame('workaround/PromotionDeal.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image5','','../img/img_ico/1_11_2.gif',1)"><img src="../img/img_ico/1_11_1.gif" name="Image5" width="63" height="49" border="0" id="Image5"></a></td>
          </tr>
          <tr height="1">
            <td>&nbsp;</td>
          </tr>
          <tr>
          <td height="40"><a style="cursor:hand;"  onclick="setMainFrame('workaround/approve.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image6','','../img/img_ico/L-05-2.gif',1)"><img src="../img/img_ico/L-05-1.gif" name="Image6" width="63" height="49" border="0" id="Image6"></a></td>         
          </tr>
          <tr height="1">
            <td>&nbsp;</td>
          </tr>
          <tr>
          <td height="40"><a style="cursor:hand;" onclick="setMainFrame('workaround/Search.aspx')" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image7','','../img/img_ico/1_13_2.gif',1)"><img src="../img/img_ico/1_13_1.gif" name="Image7" width="63" height="49" border="0" id="Image7"></a></td>         
        
          </tr>
        </table>  
</div>
<div id=demo2>
<table width="63" border="0" cellspacing="0" cellpadding="0" >
          <tr height="400"> 
            <td>&nbsp;</td>
          </tr>
          </table>
</div>
</div>
          
      </td>
      <td align="center" width="28">
      <table  border="0" cellspacing="0" cellpadding="0">
      <tr height="200">
      <td align="left" valign="bottom">
      
      <span id="td1"><img src="../img/img_ico/work_up.gif" /></span>
       <br />
      <span id="td2"><img src="../img/img_ico/work_down.gif" /></span>
     
      </td>
      </tr>
      </table>
      </td>
 
    </tr>
   
  </table>


<script>
var speed=10
function Marquee(){
if(demo1.offsetTop-demo.scrollTop>=0)
{}
else{
demo.scrollTop--
}
}
function Marquee2(){

if(demo.scrollTop>=demo1.scrollHeight)
{}
else{
demo.scrollTop=demo.scrollTop+1
}
}
var MyMar,MyMar1;
td1.onmouseout=function() {clearInterval(MyMar)}
td1.onmouseover=function() {MyMar=setInterval(Marquee,speed)}


td2.onmouseout=function() {clearInterval(MyMar1)}
td2.onmouseover=function() {MyMar1=setInterval(Marquee2,speed)}
</script>
</body>

</html>

