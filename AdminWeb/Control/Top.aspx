<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Control_Top" %>


<html>
<head runat="server">
    <title>无标题页</title>
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
        <script language="JavaScript" type="text/JavaScript">
<!--



function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
function SetFrames(a,b)
{

   this.parent.window.document.getElementById("leftFrame").src=a;  
   this.parent.window.document.getElementById("mainFrame").src=b;
//  if(a.indexOf('workaround')>-1)
//  {  
//      this.parent.window.document.getElementById("fsMain").rows="*"; 
//      this.parent.window.document.getElementById("fsMain").cols="138.*"; 
//      this.parent.window.document.getElementById("leftFrame").scrolling="auto";
//      
//  }
//  else
//  {
//      this.parent.window.document.getElementById("fsMain").rows="*"; 
//      this.parent.window.document.getElementById("fsMain").cols="119.*";
//      this.parent.window.document.getElementById("leftFrame").scrolling="no";
//  }
}
//-->
</script>
</head>
<body>
    <form id="form1" runat="server">

<table width="1020" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="954" background="../img/0002.gif"><table width="1020" height="94" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td align="right" valign="bottom" class="loTop"><table width="820" height="44" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="110" valign="bottom" background="../img/0004.gif"> <table width="96%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                     <td align="right"><a class="link-01" href="javascript:SetFrames('leftframe/Home.aspx','Home/default.aspx')">首页</a></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr> 
                      <td height="8"></td>
                      <td></td>
                    </tr>
                  </table></td>
                <td valign="bottom" background="../img/0003.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/Introduction.aspx','Introduction/default.aspx')">机构简介</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/help.aspx','Law/NewsEdit.aspx?id=6')">办证指南</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/Contact.aspx','Contact/default.aspx')">联系我们</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01"  href="javascript:SetFrames('leftframe/Law.aspx','Law/default.aspx?pid=2')">政策法规</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/Note.aspx','Law/default.aspx?pid=3')">公告栏</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/workaround.aspx','workaround/FirstAuditing.aspx?tid=1')">工作区</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/CertNO.aspx','CertNO/default.aspx')">证书管理</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/Complain.aspx','workaround/Complain.aspx')">投诉受理</a></td>
                      <td>&nbsp;</td>
                      <td><a class="link-01" href="javascript:SetFrames('leftframe/UserSysAdmin.aspx','UserSysAdmin/UserList.aspx')" >系统管理</a></td>
                    </tr>
                    <tr> 
                      <td height="8"></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td></td>
                    </tr>
                  </table></td>
                <td width="110" valign="bottom" background="../img/0005.gif"> <table width="76%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                      <td align="right"><asp:LinkButton CssClass="link-01" ID="lnkbtnLogout" runat="server" OnClick="lnkbtnLogout_Click">退出登陆</asp:LinkButton><br /></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr> 
                      <td height="8"></td>
                      <td></td>
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
