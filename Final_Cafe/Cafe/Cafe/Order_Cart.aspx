<%@ Page Title="Order Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order_Cart.aspx.cs" Inherits="Cafe.Order_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <p><asp:Button ID="btnConfirm" runat="server" Text="Confirm Order" OnClick="btnConfirm_Click"/></p>
    <table style="width:100%;background-color:#e0ebeb; margin:0 auto">
        <tr>
            <td style="width:25%"><center><b><asp:Label ID="lblFoodName" runat="server" Text="Food Name"></asp:Label></b></center></td>
            <td style="width:25%"><center><b><asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label></b></center></td>
            <td style="width:25%"><center><b><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></b></center></td>
            <td style="width:25%"><center><b><asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label></b></center></td>
        </tr>
    </table>
    <asp:DataList ID="OrderCartList" runat="server" Width="100%" OnItemCommand="OrderCartList_ItemCommand">
        <ItemTemplate>
            <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("food_id") %>'/>
            <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("item_type") %>'/>
            <table style="width:100%; margin:0 auto">
                <tr>
                    <td style="width:25%"><center><asp:Label ID="lblFoodName2" runat="server" Text='<%# Eval("food_name") %>'></asp:Label></center></td>
                    <td style="width:25%"><center><asp:Label ID="lblQuantity2" runat="server" Text='<%# Eval("quantity") %>'></asp:Label></center></td>
                    <td style="width:25%"><center><asp:Label ID="lblPrice2" runat="server" Text='<%# Eval("price") %>'></asp:Label></center></td>
                    <td style="width:25%"><center><asp:LinkButton ID="btnRemove" runat="server">Remove</asp:LinkButton></center></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
