﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="topred.aspx.cs" Inherits="Control_topred" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <link href="../styles/style.css" rel="stylesheet" type="text/css">
<head runat="server">
    <title>无标题页</title>
<style type="text/css">
<!--
body {
	margin-top: 0px;
	margin-bottom: 0px;
	margin-left: 0px;
	margin-right: 0px;
}
-->
</style>
<script language="JavaScript" type="text/JavaScript">
crntMenu=null;
crntImg=null;
var curMenu=2;

function reloadtdMenu(){
	for(var i=2;i<=16;i++){
	 var td="tdMenu"+i;
	 var igd="bo"+i;
	 obj=document.getElementById(td);
	 if(obj){
       obj.style.backgroundImage="url('images-topred/"+igd+".jpg')";
	 }
	}
}


function onMenuClick(iMenu,imgObj){
	if(curMenu!=iMenu){
		var td = "tdMenu"+curMenu; 
		var imgold="bo"+curMenu;
		document.getElementById(td).style.backgroundImage ="url('images-topred/"+imgold+".jpg')";
		
		var imgcur="bof"+iMenu;
        document.getElementById("tdMenu"+iMenu).style.backgroundImage = "url('images-topred/"+imgcur+".jpg')";
		
		curMenu=iMenu;
		return true;
	}else{
		return false;
	}
}

function onMover(obj,id){	
	var imgcur="bof"+id;
    obj.style.backgroundImage = "url('images-topred/"+imgcur+".jpg')";
}
function onMout(obj,id){	
	var imgcur="bo"+id;
	if(curMenu!=id){
		obj.style.backgroundImage = "url('images-topred/"+imgcur+".jpg')";
	}
}

/*
function onMenuClick(iMenu,imgObj){

	if(crntImg != imgObj){
		if(crntImg != null){
		//	crntImg.src = "images-topred/bo" + crntMenu + ".jpg";
		}
	//	imgObj.src = "images-topred/bof" + iMenu + ".jpg";
		crntImg = imgObj;
		crntMenu = iMenu;
		return true;
	}else{
		return false;
	}
}
*/

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
  var i,j=0,x,a=MM_swapImage.arguments; 
  document.MM_sr=new Array; 
  for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){
	  document.MM_sr[j++]=x; 
	  if(!x.oSrc) 
		  x.oSrc=x.src; 
	  x.src=a[i+2];
	}
}
//-->


</script>

</head>
<body onLoad="MM_preloadImages('images-topred/m-indexo.jpg','images-topred/m8o.jpg','images-topred/m3o.jpg','images-topred/m4o.jpg','images-topred/m2o.jpg','images-topred/m5o.jpg','images-topred/m6o.jpg','images-topred/m9o.jpg','images-topred/m11o.jpg','images-topred/m10o.jpg','images-topred/bof3.jpg','images-topred/bof4.jpg','images-topred/bof5.jpg','images-topred/bof6.jpg','images-topred/bof7.jpg','images-topred/bof8.jpg','images-topred/bof9.jpg','images-topred/bof10.jpg','images-topred/bof12.jpg','images-topred/bof13.jpg','images-topred/bof14.jpg','images-topred/bof15.jpg','images-topred/bof16.jpg');reloadtdMenu();">
    <form id="theform" action="../login.aspx" method="post">
<input id="gh" name="gh" type="text" style="display:none" />
<input id="encr"  name="encr" type="text" style="display:none" />
<input id="txtUserID"  name="txtUserID" type="text" style="display:none;" />
    </form>
    
<table width="1024" height="93"  border="0" cellpadding="0" cellspacing="0" bgcolor="#525552">
  <tr>
    <td height="81" align="left" valign="top" background="images-topred/index_01.jpg">
	<table width="85" border="0" align="right" cellpadding="0" cellspacing="0">
      <tr>
        <td width="20" height="26"></td>
        <td width="65" align="left"></td>
      </tr>
    </table>
	</td>
  </tr>

</table>

<script language="javascript">
var cpzlhost="http://203.175.142.103";
//电子地图
function openGis(obj){
   theform.target="midFrame";
   theform.action="http://203.175.142.94/SSO/gis/main.jsp";
   theform.submit();
}

//维修监管
function openSZMA(){
   theform.target="midFrame";
   theform.action="../login.aspx";
//   theform.gh.value='<%=AdminUser.GH%>';
theform.gh.value='double';
   theform.encr.value ='<%=AdminUser.ENCR%>';
   theform.submit();
}
//BBS
function openBBS(obj){
   theform.target="midFrame";
   theform.action=cpzlhost+"/Quality/Login.aspx?type=bbs";
   theform.txtUserID.value='<%=AdminUser.GH%>';
   theform.encr.value ='<%=AdminUser.ENCR%>';
   theform.submit();
}

//食品安全
function openSpaq(obj){
	theform.target="midFrame";
   theform.action=cpzlhost+"/Quality/Login.aspx?busi=1";
   theform.txtUserID.value='<%=AdminUser.GH%>';
   theform.encr.value = '<%=AdminUser.ENCR%>';
   theform.submit();
 }
function openCpzljg(obj){
	  theform.target="midFrame";
	  theform.action=cpzlhost+"/Quality/Login.aspx?busi=3";
	  theform.txtUserID.value='<%=AdminUser.GH%>';
	  theform.encr.value = '<%=AdminUser.ENCR%>';
	  theform.submit();
 }

 function openJiliang(obj){ 
   theform.target="midFrame";
   theform.action="/jiliang/loginAction.do?doAction=ssoLogin";
   theform.gh.value='<%=AdminUser.GH%>';
   theform.encr.value = '<%=AdminUser.ENCR%>';
   theform.submit();  
 }

 function openXzzf(obj){
 if( 1==1){
	  theform.target="midFrame";
      theform.action="/xzzf/loginAction.do?doAction=ssoLogin";
	  theform.gh.value='<%=AdminUser.GH%>';
	  theform.encr.value ='<%=AdminUser.ENCR%>';
	  theform.submit();
  }else{
   alert("对不起，你没有这个系统的权限！！");
  }
 }

function openTzsb(obj){
 if( 1==1){
   theform.target="midFrame";
   theform.action="/loginAction.do?doAction=ssoLogin";
   theform.gh.value='<%=AdminUser.GH%>';
   theform.encr.value = '<%=AdminUser.ENCR%>';
   theform.submit();
  }else{
   alert("对不起，你没有这个系统的权限！！");
  }
 }


function openOA(obj){
   theform.target="midFrame";
   theform.action="http://203.175.145.115/xdoctest/first.asp";
 //  alert(obj.action);
   theform.hcusername.value='<%=loginModel2.getGh()%>';
  theform.encr.value = obj.encrtmp.value;
//   obj.hcusername.value='shiag';
  // obj.password.value='zhangw';
   theform.submit();  
 }

function openStandard(obj){
   theform.target="midFrame";
   theform.action="http://localhost:8088/ds/ssologin";
   theform.gh.value='<%=loginModel2.getGh()%>';
   theform.encr.value = '<%=AdminUser.ENCR%>';
   theform.submit();  
 } 
 
 function openManager(obj){
 // var url="http://203.175.142.94/loginAction.do?doAction=systemset&gh=<%=loginModel2.getGh()%>";
  // openURL(url);
   theform.target="midFrame";
   theform.action="http://203.175.142.103/SSO/loginAction.do?doAction=systemset";
   theform.gh.value='<%=loginModel2.getGh()%>';
   theform.encr.value = '<%=AdminUser.ENCR%>';
   theform.submit();  
 }

 function openQuery(obj){
//   var url="http://203.175.142.94/loginAction.do?doAction=sysquery&gh=<%=loginModel2.getGh()%>";
//   openURL(url);
   theform.target="midFrame";
   theform.action="/SSO/loginAction.do?doAction=sysquery";
   theform.gh.value='<%=loginModel2.getGh()%>';  
   theform.encr.value = '<%=AdminUser.ENCR%>';
//   alert(theform.encr.value);
   theform.submit();
 }

 function openTjfx(obj){
   theform.target="midFrame";
   theform.action="/SSO/loginAction.do?doAction=tjfx";
   theform.gh.value='<%=loginModel2.getGh()%>';  
   theform.encr.value ='<%=AdminUser.ENCR%>';
   theform.submit();
 }

function openHome(obj){
	theform.target="midFrame";
   theform.action="/SSO/loginAction.do?doAction=openHome&logintime=<%=logintime%>";
   theform.gh.value='<%=loginModel2.getGh()%>';  
   theform.encr.value = '<%=AdminUser.ENCR%>';
   theform.submit();
 }



//退出系统
function exitsys(){
	if(confirm("确认要退出吗？")){
//		window.parent.opener='login';
//	   window.parent.close();
//	
		top.location.href="/SSO/Service_login.jsp";
	}
}



function openPortalnet(){
	my_newwindow("http://www.szbqts.gov.cn");
}

function openURL(paramName)
{
   location.href=paramName;
	
}

function openNew(paramName)
{
	my_newwindow(paramName);
}

function my_newwindow(myurl)
{
    var childWin;

    childWin=window.open(myurl,"full", "location=no,toolbar=no,status=no,resizable=no,scrollbars=no,menubar=no,directories=no");
//    childWin.parentWin = this;
	obj.target='full';
	childWin.moveTo(-3,-3);  
    childWin.resizeTo(screen.availWidth+6, screen.availHeight+6);
}


</script>

<SPAN id=radiofflag1 style="DISPLAY:none"><textarea id="encrtmp"></textarea></SPAN>
</body>
</html>
