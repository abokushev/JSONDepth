<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSONDepthPage.aspx.cs" Inherits="JSONDepth.JSONDepthCalculatingWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<asp:TextBox ID="JSONInput" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="CalculateJsonMaxDepthButton" Text="Button" />
        </div>        
    </form>
    <p>
        <asp:Label ID="JSONOutput" runat="server"></asp:Label>
    </p>
</body>
</html>
