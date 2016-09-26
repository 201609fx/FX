<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WorkAroundTop.ascx.cs" Inherits="Control_WorkAroundTop" %>

<link href="../styles/style.css" rel="stylesheet" type="text/css">

<script language="javascript">

window.onload=function(){
var s=window.location.href;
setAll();
if(s.indexOf('FirstAuditing')>0)
{
        tabFirstAuditing.style.display="block";
        if(s.indexOf('FirstAuditing.aspx?tid=1')>0)
        setA(a11);
        else
        if(s.indexOf('FirstAuditing.aspx?tid=2')>0)
        setA(a12);
}
else if(s.indexOf('FirstCheck.aspx')>0)
{
tabFirstCheck.style.display="block";
setA(a21);

}
else if(s.indexOf('syndic.aspx')>0||s.indexOf('syndic_checkPlate.aspx')>0)
{
tabsyndic.style.display="block";
  if(s.indexOf('syndic.aspx')>0)
        setA(a31);
        else
        if(s.indexOf('syndic_checkPlate.aspx')>0)
        setA(a32);
}
else if(s.indexOf('Result.aspx')>0)
{
tabResult.style.display="block";
setA(a41);
}
else if(s.indexOf('PromotionDeal.aspx')>0)
{
tabPromotionDeal.style.display="block";
setA(a51);
}
else if(s.indexOf('lastApprove.aspx')>0)
{
tabapprove.style.display="block";
setA(a61);
}
else if(s.indexOf('CompanyAdd')>0)
{
tblCompany.style.display="block";
        if(s.indexOf('CompanyList.aspx')>0)
        setA(a01);
        else
        if(s.indexOf('CompanyLogList.aspx')>0)
        setA(a02);

}

}

function setAll()
{
tabFirstAuditing.style.display="none";
tabFirstCheck.style.display="none";
tabsyndic.style.display="none";
tabResult.style.display="none";
tabPromotionDeal.style.display="none";
tabapprove.style.display="none";
tabSearch.style.display="none";
tblCompany.style.display="none";
}
function setA(a)
{
  a.className='link-04';
}
function setUrl(a)
{
  parent.window.document.getElementById("mainFrame").src=a;
}
</script>

<table cellpadding="0" border="0" cellspacing="0" id="tblCompany">
<tr>
<td align="center"><a id="a01" href="javascript:setUrl('CompanyAdd/CompanyList.aspx')" class="link-03" >正在申办企业列表</a>
<a id="a02" href="javascript:setUrl('CompanyAdd/CompanyLogList.aspx')"  class="link-03" >已发证企业列表</a>
</td>
</tr>
</table>
<table cellpadding="0" width="100%" border="0" cellspacing="0" id="tabFirstAuditing">
<tr>
<td align="center" ><a id="a11" href="javascript:setUrl('workaround/FirstAuditing.aspx?tid=1')" class="link-03" >网上申请初审列表</a>
<a id="a12" href="javascript:setUrl('workaround/FirstAuditing.aspx?tid=2')"  class="link-03" >网上晋级申请初审列表</a>
</td>
</tr>
</table>
<table cellpadding="0" width="100%" border="0" cellspacing="0" id="tabFirstCheck">
<tr>
<td align="center" ><a id="a21" href="javascript:setUrl('workaround/FirstCheck.aspx')" class="link-03" >书面资料审核列表</a>
</td>
</tr>
</table>
<table cellpadding="0" border="0" cellspacing="0" id="tabsyndic">
<tr>
<td align="center">
<a id="a31" href="javascript:setUrl('workaround/syndic.aspx')" class="link-03" >待评审列表</a>
<a id="a32" href="javascript:setUrl('workaround/syndic_checkPlate.aspx')" class="link-03" >评审表模版列表</a>
</td>
</tr>
</table>
<table cellpadding="0" border="0" cellspacing="0" id="tabResult">
<tr>
<td align="center">
<a id="a41" href="javascript:setUrl('workaround/result.aspx')" class="link-03" >评审结论列表</a>
</td>
</tr>
</table>
<table cellpadding="0" border="0" cellspacing="0" id="tabPromotionDeal">
<tr>
<td align="center"><a id="a51" href="javascript:setUrl('workaround/PromotionDeal.aspx')" class="link-03" >处理通知列表</a>
</td>
</tr>
</table>
<table cellpadding="0" border="0" cellspacing="0" id="tabapprove">
<tr>
<td align="center">
<a id="a61" href="javascript:setUrl('workaround/lastApprove.aspx')" class="link-03" >报批申请列表</a>
</td>
</tr>
</table>
<table cellpadding="0" border="0" cellspacing="0" id="tabSearch">
<tr>
<td align="center"></td>
</tr>
</table>