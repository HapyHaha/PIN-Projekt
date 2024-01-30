<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clicker.aspx.cs" Inherits="Web_Application.Clicker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clicker</title>
    <link rel="stylesheet" type="text/css" href="Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center">Clicker</h1>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebFormsLabosConnectionString %>" ProviderName="<%$ ConnectionStrings:WebFormsLabosConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Stats] ORDER BY [lvl] DESC, [points] DESC, [username]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="LogOutButton" runat="server" OnClick="LogOutButton_Click" style="text-align: center" Text="Log out" />
            <br />
            <br />
            <asp:Label ID="ScoreLabel" runat="server" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Size="Larger" style="text-align: center"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="LevelLabel" runat="server" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Size="Larger" style="text-align: center">Level:</asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="LevelNumber" runat="server" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Size="Larger" style="text-align: center"></asp:Label>
            &nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Button ID="ClickButton" runat="server" BackColor="#999999" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Size="Larger" OnClick="ClickButton_Click" Text="CLICK" type="submit"/>
        &nbsp;<br />
            <br />
            <asp:Button ID="LevelButton" runat="server" BackColor="#999999" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" OnClick="LevelButton_Click" Text="LEVEL UP" type="submit" Enabled="False" Height="32px" Width="107px"/>
            <asp:Label ID="LevelCost" runat="server" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Size="Larger" style="text-align: center"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="ListBox1" runat="server" CausesValidation="True" DataSourceID="SqlDataSource1" DataTextField="username" DataValueField="username" Height="221px" SelectionMode="Multiple" style="text-align: center" Width="264px"></asp:ListBox>
            <br />
        </div>
    </form>
</body>
</html>
