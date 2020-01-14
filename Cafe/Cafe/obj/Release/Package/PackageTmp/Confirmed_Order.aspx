<%@ Page Title="Confirmed Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmed_Order.aspx.cs" Inherits="Cafe.Confirmed_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <p><asp:Button ID="btnCheckOut" runat="server" Text="Check Out" OnClick="btnCheckOut_Click"/></p>
    <table style="width:100%;background-color:#e0ebeb; margin:0 auto">
        <tr>
            <td style="width:25%"><center><b><asp:Label ID="lblFoodName" runat="server" Text="Food Name"></asp:Label></b></center></td>
            <td style="width:25%"><center><b><asp:Label ID="lblItemType" runat="server" Text="Item Type"></asp:Label></b></center></td>
            <td style="width:25%"><center><b><asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label></b></center></td>
            <td style="width:25%"><center><b><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></b></center></td>
        </tr>
    </table>
    <asp:DataList ID="ConfirmedOrderList" runat="server" Width="100%">
        <ItemTemplate>
            <table style="width:100%; margin:0 auto">
                <tr>
                    <td style="width:25%"><center><asp:Label ID="lblFoodName2" runat="server" Text='<%# Eval("food_name") %>'></asp:Label></center></td>
                    <td style="width:25%"><center><asp:Label ID="lblItemType2" runat="server" Text='<%# Eval("item_type") %>'></asp:Label></center></td>
                    <td style="width:25%"><center><asp:Label ID="lblQuantity2" runat="server" Text='<%# Eval("quantity") %>'></asp:Label></center></td>
                    <td style="width:25%"><center><asp:Label ID="lblPrice2" runat="server" Text='<%# Eval("price") %>'></asp:Label></center></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
