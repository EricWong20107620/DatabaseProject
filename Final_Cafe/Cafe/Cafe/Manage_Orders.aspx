<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_Orders.aspx.cs" Inherits="Cafe.Manage_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table style="width:100%">
        <tr>
            <td style="width:50%">
                <asp:Panel ID="pHeader" runat="server" ScrollBars="Vertical" Width="95%">
                <table style="width:100%;background-color:#e0ebeb">
                    <tr>
                        <td style="width:20%"><center><b><asp:Label ID="lblLoginID" runat="server" Text="Login ID"></asp:Label></b></center></td>
                        <td style="width:20%"><center><b><asp:Label ID="lblOrdStatus" runat="server" Text="Order Status"></asp:Label></b></center></td>
						<td style="width:40%"><center><b><asp:Label ID="lblConfirmTime" runat="server" Text="Confirm Time"></asp:Label></b></center></td>
                        <td style="width:20%"><center><b><asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label></b></center></td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="pData" runat="server" Height="300px" ScrollBars="Vertical" Width="95%">
                    <asp:DataList ID="OrderMasterList" runat="server" Width="100%" OnItemCommand="OrderMasterList_ItemCommand">
                        <ItemTemplate>
                        <asp:HiddenField ID="hfOrderID" runat="server" Value='<%# Eval("order_id") %>'/>
                        <table style="width:100%">
                            <tr>
                                <td style="width:20%"><center><asp:Label ID="lblLoginID2" runat="server" Text='<%# Eval("login_id") %>'></asp:Label></center></td>
                                <td style="width:20%"><center><asp:Label ID="lblOrdStatus2" runat="server" Text='<%# Eval("ord_status") %>'></asp:Label></center></td>
                                <td style="width:40%"><center><asp:Label ID="lblConfirmTime2" runat="server" Text='<%# Eval("confirm_time") %>'></asp:Label></center></td>
                                <td style="width:20%"><center><asp:LinkButton ID="btnViewDetail" runat="server">View Detail</asp:LinkButton></center></td>
                            </tr>
                        </table>
                        </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
            </td>
            <td style="width:50%">
                <table style="width:100%;background-color:#e0ebeb">
                    <tr>
                        <td style="width:25%"><center><b><asp:Label ID="lblFoodName" runat="server" Text="Food Name"></asp:Label></b></center></td>
                        <td style="width:25%"><center><b><asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label></b></center></td>
                        <td style="width:25%"><center><b><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></b></center></td>
                        <td style="width:25%"><center><b><asp:Label ID="lblAction2" runat="server" Text="Action"></asp:Label></b></center></td>
                    </tr>
                </table>
                <asp:DataList ID="OrderDetailList" runat="server" Width="100%" OnItemCommand="OrderDetailList_ItemCommand">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfFoodID" runat="server" Value='<%# Eval("food_id") %>'/>
                        <asp:HiddenField ID="hfOrderID2" runat="server" Value='<%# Eval("order_id") %>'/>
                        <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("item_type") %>'/>
                        <asp:HiddenField ID="hfStatus" runat="server" Value='<%# Eval("ord_status") %>'/>
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
            </td>
        </tr>
    </table>
</asp:Content>