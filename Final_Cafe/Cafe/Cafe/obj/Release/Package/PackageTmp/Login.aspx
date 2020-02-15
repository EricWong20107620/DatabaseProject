<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cafe.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table border="1" style="width:90px;background-color:#e0ebeb; margin:0 auto">
        <tr>
            <td><center><b><asp:Label ID="lblLoginID" runat="server" Text="LoginID" Width="90px"></asp:Label></b></center></td>
            <td><center><asp:TextBox ID="txtLoginID" runat="server" Width="90px"></asp:TextBox></center></td>
        </tr>
        <tr>
            <td><center><b><asp:Label ID="lblPassword" runat="server" Text="Password" Width="90px"></asp:Label></b></center></td>
            <td><center><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="90px"></asp:TextBox></center></td>
        </tr>
        <tr>
            <td><center><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" Width="90px"/></center></td>
            <td><center><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="90px"/></center></td>
        </tr>
    </table>
</asp:Content>
