// JScript 文件
var HKEY_root,HKEY_Path,HKEY_Key; 
HKEY_Root="HKEY_CURRENT_USER"; 
HKEY_Path="\\Software\\microsoft\\Internet Explorer\\PageSetup\\"; 
//设置网页打印的页眉页脚为空 

function PageSetup_Null() 
{ 
try
{
  document.all.factory.printing.portrait = true;
}
catch(e)
{
  alert(e.message);
}
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