<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test_Default" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <FTB:FreeTextBox id="ftbContent"  runat="server" Width="90%" AutoConfigure="EnableAll" HelperFilesPath="../Control/FreeTexoBox/ftb/HelperScripts/"  ButtonPath="../Images/ftb/office2003/" ></FTB:FreeTextBox>
    </div>
    </form>
</body>
</html>
