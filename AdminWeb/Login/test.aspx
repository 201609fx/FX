<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Login_test" %>

<html>
<head>
<title>深圳市质量技术监督局电子政务综合信息平台</title>
<link href="../css/leftfont.css" rel="stylesheet" type="text/css"/>
<LINK href="../css/style.css" type='text/css' rel='stylesheet'/>
<style type="text/css">
<!--
body {
	margin-top: 0px;
	margin-bottom: 0px;
	background-color: #f0f0f0;
	margin-left: 0px;
	background-image: url(../img/login/4new2.gif);
}
.style1 {
	font-size: 12px;
	color: #4C4C4C;
}
.style2 {
	font-size: 16px;
	color: #000000;
}
.style3 {
	font-size: 14px;
	color: #000000;
}

-->
</style>


<script language="javascript">


function setfocus()
{
    document.getElementById("gh1").focus();
}

function reloadtdMenu(){
 obj=document.getElementById("cabtn");
	 if(obj){
       obj.style.backgroundImage="url('../img/Login/login-01.jpg')";
	 }
 obj=document.getElementById("ptbtn");
	 if(obj){
       obj.style.backgroundImage="url('../img/Login/login-02.jpg')";
	 }
}


function dealEnter()
{
   if (event.keyCode==13)
   {
       event.keyCode=9;
   }
   return;
}
function deen()
{
   if (event.keyCode==13)
   {
       u_log();
   }
   return;
}
function deenca()
{
   if (event.keyCode==13)
   {
       checkin();
   }
   return;
}
function u_log(){
if(document.forms[0].gh1.value==""){
	alert("请输入用户名！");
	document.forms[0].gh1.focus();
	return false;
}
if(document.forms[0].passwd.value==""){
	alert("请输入密码！");
	document.forms[0].passwd.focus();
	return false;
}

//  alert("系统测试中，请稍后使用！");
document.forms[0].ENCR.value=window.document.getElementById("passwd").value;
document.forms[0].gh.value=window.document.getElementById("gh1").value;
document.forms[0].doAction.value="admin";
document.forms[0].submit();
}

function calogin(){
	document.all("caflag1").style.display="";
	document.all("caflag2").style.display="";

	document.all("caflag5").style.display="";
	document.all("caflag7").style.display="";
	document.all("ptflag8").style.display="";

	document.all("ptflag1").style.display="none";
	document.all("ptflag2").style.display="none";
	
	document.all("ptflag6").style.display="none";
	document.all("ptflag7").style.display="none";

	document.all("messageText").style.display="none";
	
	document.getElementById("cabtn").style.backgroundImage ="url('../img/login/login-01f.jpg')";
	document.getElementById("ptbtn").style.backgroundImage ="url('../img/login/login-02.jpg')";

	getCert();
}

function ptlogin(){
	document.all("caflag1").style.display="none";
	document.all("caflag2").style.display="none";
	
	document.all("caflag5").style.display="none";
	document.all("caflag7").style.display="none";
	

	document.all("ptflag1").style.display="";
	document.all("ptflag2").style.display="";
	
	document.all("ptflag6").style.display="";
	document.all("ptflag7").style.display="";
	document.all("ptflag8").style.display="";

	document.all("messageText").style.display="";

	document.getElementById("cabtn").style.backgroundImage ="url('../img/login/login-01.jpg')";
	document.getElementById("ptbtn").style.backgroundImage ="url('../img/login/login-02f.jpg')";

	document.forms[0].gh.focus();
}

</script>

<body onLoad="javascript:document.theform.passwd.value='';reloadtdMenu();">
<form name="loginActionForm" method="post" action="../FLogin.aspx" id="theform">
<input type="hidden" name="gh" value="">
<input type="hidden" name="ENCR" value="">
<input type="hidden" name="doAction" value="">
<input type="hidden" name="signature" value="">
<input type="hidden" name="iscert" value="">
<input type="hidden" name="ghca" value="">

<TABLE height=620 cellSpacing=0 cellPadding=0 width=990 border=0>
  <TBODY>
  <TR>
    <TD vAlign=top align=left width=1009 height=592><table width="100%" height="231" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="231">&nbsp;</td>
      </tr>
    </table>
      <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>

          <td width="633" valigh="top" align="right" height="230">
		  <table border="1"  width="480" cellpadding="0" cellspacing="0" bgcolor="">
			<tr align="center"><td>
				<table>
					<tr><td class="style2"><b>登录说明：</b></td></tr>
					<tr><td class="style3">&nbsp;&nbsp;&nbsp;&nbsp;一：首先请选择登录方式：数字证书或普通方式。</td></tr>
					<tr><td class="style3">&nbsp;&nbsp;&nbsp;&nbsp;二：普通方式采用用户名、密码、验证码进行登录；数字证书登录采用数字证书及密码进行登录。相比较而言，数字证书方式登录更安全可靠，建议采用数字证书方式进行登录系统使用。</td></tr>
					<tr><td class="style3">&nbsp;&nbsp;&nbsp;&nbsp;三：使用数字证书，需事先在操作系统中安装您个人的数字证书，一般是*.pfx的文件，安装之后即可使用证书进行登录。<a target="new" href="pfx.doc"><u>如何安装数字证书？</u></a></td></tr>
					<tr><td class="style3">&nbsp;&nbsp;&nbsp;&nbsp;四：三个月之内您可以选择普通方式或数字证书方式登录，之后将只提供数字证书方式登录，所以我们强烈建议您通过管理员获取并使用数字证书进行登录。</td></tr>					
				</table>
			</td></tr>
			</table>
		  </td>

          <td align="center" width="357">
			  <table width="208" height="46" border="0" cellpadding="0" cellspacing="0" >
				<tr>              
				  <td align="center" width="208" height="46" id="cabtn" onclick="calogin();">				  		
				  </td>
				</tr>
				<tr><td>
					<br>
				</td></tr>
				<tr>              
				  <td align="center"  width="208" height="46" id="ptbtn" onclick="ptlogin();" >									  
				  </td>
				</tr>

			  </table>

            <table width="75%" border="0" cellpadding="0" cellspacing="1" >
			<tr>
              <td height="108" >
			  <TABLE cellSpacing=0 cellPadding=0 width="100%" border="0">                
                  <TR>				  
                    <TD width="35%" height="25" >
						<span id="ptflag1" style="DISPLAY:none"><DIV align=center>用 户 名：</DIV></span>
						<span id="caflag1" style="DISPLAY:none"><DIV align=center>姓　 &nbsp;名：</DIV></span>
					</TD>
                    <TD width="49%">
						<span id="ptflag2" style="DISPLAY:none">
						<input type="text" name="gh1" id="gh1" size="10" value="" onkeydown="dealEnter();" class="inputtext">
						</span>
						<span id="caflag2" style="DISPLAY:none"><input type="text" name="xm" size="10" value="" readonly="readonly" class="inputtext"></span>
						<div id="messageText"><div>
					</TD>
             				
                  </TR>
                  <TR>
                    <TD height="25" >
					<span id="ptflag8" style="DISPLAY:none"><DIV align=center>密　 &nbsp;码：</DIV></span>				
					</TD>
                    <TD>
					<span id="ptflag7" style="DISPLAY:none">
					<input type="password" id="passwd" name="passwd" size="10" value="" onkeydown="dealEnter();" class="inputtext"></span>
						<span id="caflag7" style="DISPLAY:none"><input type="password" name="passwdca" size="10" value="" onkeydown="deenca();" class="inputtext"></span>
					</TD>
              
                  </TR>
                  <TR>
                    <TD colspan="2" align=center>
					<span id="ptflag6" style="DISPLAY:none"><DIV align=center><input type="button" name="button1" class="button2" value="登 录" onclick="u_log()"/></DIV></span>
					<span id="caflag5" style="DISPLAY:none"><DIV align=center><input type="button" name="button3" class="button2" value="登 录" onclick="checkin()"/></DIV></span>
					</TD>          
                  </TR>	
              </TABLE></td>
            </tr>
          </table>
            </td>
        </tr>


		
      </table></TD></TR></TBODY></TABLE>


</form>
</body>
</html>

<script language="javascript">
var signed = false;
function getCert()
{
    InfoSecNetSign1.NSSetPlainText(1920694890);
    document.all("signature").value=InfoSecNetSign1.NSAttachedSign("");
    errNum = InfoSecNetSign1.errorNum;
    if(errNum == -10005)
    {
       // window.close();
	   alert("请选择一个有效的证书!");
        return;
    }
    if(errNum!=0)
    {
        alert("出现错误,错误代码是"+InfoSecNetSign1.errorNum+"\n"+InfoSecNetSign1.errMsg);
        signed = false;
       // window.close();
        return;
    }
//alert(InfoSecNetSign1.NSGetSignerCertInfo(3));
//alert(InfoSecNetSign1.NSGetSignerCertInfo(4));
    dn = InfoSecNetSign1.NSGetSignerCertInfo(1);
	dn2=dn;
    dn = dn.toUpperCase();
//	alert(dn); 
    if(dn.match("O=SZZJJ") == null)
    {
        alert("您使用的证书非深圳质监局所发！");
    }
    else
    {
       // theform.gh.value = dn2.substring(13, 17);
	   //alert(dn2.length);
	   nn=dn2.split(",");
//	   alert(nn[2].substring(4,nn[2].length));
//	   alert(nn[1].substring(4,nn[1].length));

	   theform.ghca.value = nn[3].substring(4,nn[3].length);
	   theform.xm.value = nn[2].substring(4,nn[2].length);
    }
    signed = true;

  //  checkin() ;
//  document.forms[0].iscert.value="1";
  theform.passwdca.focus();
}
function checkin(){
	//netcert
	if(document.forms[0].passwdca.value==""){
	alert("请输入密码！");
	document.forms[0].passwdca.focus();
	return false;
	}else{
//		alert("系统测试中，请稍后使用！");
	document.forms[0].doAction.value="netcert";
	document.forms[0].submit();
	}
}
</script>
