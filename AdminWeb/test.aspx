<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
  <form id="theform" action="login1.aspx" method="post">
   
  <input type="text" name="encr" id="encr" style="display:none" />
  <input type="text" name="txtUserID"  id="txtUserID" style="display:none;" />
    </form>
    <a onclick='javascript:openHome(theform)'> dsasdas</a>
    <script language="javascript">
    function openHome(obj){
   obj.action="login1.aspx";
   obj.txtUserID.value='dasdsadsa';  
   obj.encr.value = 'testtest';
   obj.submit();
 }
    </script>
</body>
</html>
