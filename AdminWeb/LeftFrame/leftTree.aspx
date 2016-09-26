<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftTree.aspx.cs" Inherits="LeftFrame_leftTree" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <script language="javascript">
  
    </script>
    
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body style="overflow-x:hidden;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0"  cellspacing="0" width="140" id="tbl1" align="left">
    <tr height="10"><td>&nbsp;</td></tr>
    <tr>
    <td valign="top" align="left">
     <asp:TreeView ID="tv"  CssClass="Tree-text"    runat="server" Width="140"  PopulateNodesFromClient="true" ShowLines="true" BorderStyle="None" BorderWidth="1"  SelectedNodeStyle-BackColor="white" Font-Size="10px" BackColor="White" ForeColor="black"></asp:TreeView>
  
  <script language='javascript'>
  function setcolorInit()
  {
    var a=tbl1.getElementsByTagName("A");
    for(var i=0;i<a.length;i++)
    {
       if(a[i].tagName=='A')
        a[i].style.color="#000000";
    }
  }
  function setcolor(obj)
  {
     setcolorInit();
     obj.style.color="#996633";
  }
  
    function showPage(obj,url,sid)
    {
       setcolor(obj);
      var f2=window.parent.frames.item["mainFrame"];
      var f1=window.parent.document.getElementById("mainFrame");
      if(url.indexOf('?')>-1)
      {
             url=url+'&sid='+sid;
      }
      else
      {
             url=url+'?&sid='+sid;       
      }
      window.parent.document.all.mainFrame.src=url;
      window.parent.document.all.mainFrame.location.reload();
      return false;
    }
    function changeImg(obj)
    {
      var s=obj.src;
      if(s.indexOf('1')>-1)
      {
         obj.src=s.replace('1','2');
      }
      else
      {
          obj.src=s.replace('2','1');
      }
    }
  </script>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftTree.aspx.cs" Inherits="LeftFrame_leftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
        <script language="javascript">
    function showPage(url,sid)
    {
      var f2=window.parent.frames.item["mainFrame"];
      var f1=window.parent.document.getElementById("mainFrame");
      if(url.indexOf('?')>-1)
      {
             url=url+'&sid='+sid;
      }
      else
      {
             url=url+'?&sid='+sid;       
      }
      window.parent.document.all.mainFrame.src=url;
      window.parent.document.all.mainFrame.location.reload();
      return false;
    }
    function logout()
    {
      top.location.href='../Login2.aspx'
    }
    function changeImg(obj)
    {
      var s=obj.src;
      if(s.indexOf('1')>-1)
      {
         obj.src=s.replace('1','2');
      }
      else
      {
          obj.src=s.replace('2','1');
      }
    }
    </script>
    
        <link href="../styles/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="140" bgcolor="white" >
    <tr height="10"><td>&nbsp;</td></tr>
    <tr>
    <td valign="top" align="left">
     <asp:TreeView ID="tv"  CssClass="Tree-text"    runat="server" Width="140"  PopulateNodesFromClient="true" ShowLines="true" BorderStyle="None" BorderWidth="1"  SelectedNodeStyle-BackColor="white" Font-Size="10px" BackColor="White" ForeColor="black"></asp:TreeView>
  
    </td>
    </tr>
    </table>
    </form>
</body>
</html>