<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Application.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Login.css" />
</head>
<body>
    <form runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
        <br />
        <asp:Label ID="NoAccountTB" runat="server" Font-Bold="True" Text="Dont have an account?"></asp:Label>
        <br />
        <asp:Button ID="RegButton" runat="server" OnClick="RegButton_Click" Text="Register" />
    </form>
</body>
</html>
