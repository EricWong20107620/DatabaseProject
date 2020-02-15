<%@ Page Title="Manage Drinks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_Drinks.aspx.cs" Inherits="Cafe.Manage_Drinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table style="width:100%">
        <tr>
            <td style="width:50%">
                <asp:Panel ID="pHeader" runat="server" ScrollBars="Vertical" Width="95%">
                <table style="width:100%;background-color:#e0ebeb">
                    <tr>
                        <td style="width:50%"><center><b><asp:Label ID="lblFoodName" runat="server" Text="Drink Name"></asp:Label></b></center></td>
                        <td style="width:30%"><center><b><asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label></b></center></td>
                        <td style="width:20%"><center><b><asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label></b></center></td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="pData" runat="server" Height="300px" ScrollBars="Vertical" Width="95%">
                    <asp:DataList ID="ManageDrinkList" runat="server" Width="100%" OnItemCommand="ManageDrinkList_ItemCommand">
                        <ItemTemplate>
                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("drink_id") %>'/>
                        <table style="width:100%">
                            <tr>
                                <td style="width:50%"><center><asp:Label ID="lblFoodName2" runat="server" Text='<%# Eval("drink_name") %>'></asp:Label></center></td>
                                <td style="width:30%"><center><asp:Label ID="lblCategory2" runat="server" Text='<%# Eval("category") %>'></asp:Label></center></td>
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
                        <td style="width:50%"><center><b><asp:Label ID="lblFoodID" runat="server" Text="Drink ID"></asp:Label></b></center></td>
                        <td style="width:50%" colspan="3"><asp:TextBox ID="txtFoodID" runat="server" Enabled="false" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblFoodName3" runat="server" Text="Drink Name"></asp:Label></b></center></td>
                        <td colspan="3"><asp:TextBox ID="txtFoodName" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblPath" runat="server" Text="Picture Path"></asp:Label></b></center></td>
                        <td colspan="3"><asp:TextBox ID="txtPath" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblCategory3" runat="server" Text="Category"></asp:Label></b></center></td>
                        <td colspan="3"><asp:TextBox ID="txtCategory" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblTemperature" runat="server" Text="Temperature"></asp:Label></b></center></td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlTemperature" runat="server" AppendDataBoundItems="true" DataTextField="temperature" DataValueField="temperature" Width="100%">
                                <asp:ListItem Text="Cold" Value="Cold" />
                                <asp:ListItem Text="Hot" Value="Hot" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></b></center></td>
                        <td colspan="3"><asp:TextBox ID="txtPrice" runat="server" Width="100%"></asp:TextBox></td>
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
