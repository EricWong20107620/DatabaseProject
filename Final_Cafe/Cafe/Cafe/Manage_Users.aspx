<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_Users.aspx.cs" Inherits="Cafe.Manage_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table style="width:100%">
        <tr>
            <td style="width:50%">
                <asp:Panel ID="pHeader" runat="server" ScrollBars="Vertical" Width="95%">
                <table style="width:100%;background-color:#e0ebeb">
                    <tr>
                        <td style="width:50%"><center><b><asp:Label ID="lblLoginID" runat="server" Text="Login ID"></asp:Label></b></center></td>
                        <td style="width:30%"><center><b><asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label></b></center></td>
                        <td style="width:20%"><center><b><asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label></b></center></td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="pData" runat="server" Height="300px" ScrollBars="Vertical" Width="95%">
                    <asp:DataList ID="ManageUserList" runat="server" Width="100%" OnItemCommand="ManageUserList_ItemCommand">
                        <ItemTemplate>
                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("login_id") %>'/>
                        <table style="width:100%">
                            <tr>
                                <td style="width:50%"><center><asp:Label ID="lblLoginID2" runat="server" Text='<%# Eval("login_id") %>'></asp:Label></center></td>
                                <td style="width:30%"><center><asp:Label ID="lblRole2" runat="server" Text='<%# Eval("user_role") %>'></asp:Label></center></td>
                                <td style="width:20%"><center><asp:LinkButton ID="btnViewDetail" runat="server">View Detail</asp:LinkButton></center></td>
                            </tr>
                        </table>
                        </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
            </td>
            <td style="width:50%">
                <table border="1" style="width:100%;background-color:#e0ebeb">
                    <tr>
                        <td colspan="4"><center><b><asp:Label ID="lblDetail" runat="server" Text="Detail"></asp:Label></b></center></td>
                    </tr>
                    <tr>
                        <td style="width:50%"><center><b><asp:Label ID="lblLoginID3" runat="server" Text="Login ID"></asp:Label></b></center></td>
                        <td style="width:50%" colspan="3"><asp:TextBox ID="txtLoginID" runat="server" Enabled="false" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label></b></center></td>
                        <td colspan="3"><asp:TextBox ID="txtPassword" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblRole3" runat="server" Text="User Role"></asp:Label></b></center></td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlRole" runat="server" AppendDataBoundItems="true" DataTextField="role" DataValueField="role" Width="100%">
                                <asp:ListItem Text="Customer" Value="C" />
                                <asp:ListItem Text="Staff" Value="S" /> 
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblStatus" runat="server" Text="Item Status"></asp:Label></b></center></td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="true" DataTextField="category" DataValueField="category" Width="100%">
                                <asp:ListItem Text="Enable" Value="1" />
                                <asp:ListItem Text="Disable" Value="0" /> 
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblAction2" runat="server" Text="Action"></asp:Label></b></center></td>
                        <td><asp:Button ID="btnAdd" runat="server" Text="Add New One" Width="100%" OnClick="btnAdd_Click"/></td>
                        <td><asp:Button ID="btnInsert" runat="server" Text="Insert" Width="100%" Visible="false" OnClick="btnInsert_Click"/></td>
                        <td><center><asp:Button ID="btnUpdate" runat="server" Text="Update" Width="100%" OnClick="btnUpdate_Click" /></center></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
