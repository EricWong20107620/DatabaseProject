<%@ Page Title="Snacks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Snacks.aspx.cs" Inherits="Cafe.Snacks" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table border="1" style="width:90px;background-color:#e0ebeb">
        <tr>
            <th colspan="2"><center><b><asp:Label ID="lblFilter" runat="server" Text="Filter" Width="90px"></asp:Label></b></center></th>
        </tr>
        <tr>
            <td><center><b><asp:Label ID="lblfilterCategory" runat="server" Text="Category" Width="90px"></asp:Label></b></center></td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" Width="90px" AppendDataBoundItems="true" DataTextField="category" DataValueField="category">
                    <asp:ListItem Text="ALL" Value="%" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><center><asp:Button ID="btnShowAll" runat="server" Text="Show All" OnClick="btnShowAll_Click" Width="90px"/></center></td>
            <td><center><asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" Width="90px"/></center></td>
        </tr>
    </table>

    <asp:DataList ID="SnackList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%" OnItemCommand="SnackList_ItemCommand">
        <ItemTemplate>
            <br />
                <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("snack_id") %>'/>
                <asp:HiddenField ID="hfType" runat="server" Value='<%# Eval("item_type") %>'/>
                <table border="1" style="width:460px;background-color:#e0ebeb">
                    <tr>
                        <td rowspan="4"><img src="<%# Eval("picture_path") %>" width="130" height="150"/></td>
                        <td style="width:80px"><center><b><asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label></b></center></td>
                        <td style="width:250px"><center><asp:Label ID="lblCategory2" runat="server" Text='<%# Eval("Category") %>'></asp:Label></center></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblItem" runat="server" Text="Item"></asp:Label></b></center></td>
                        <td><center><asp:Label ID="lblItem2" runat="server" Text='<%# Eval("snack_name") %>'></asp:Label></center></td>
                    </tr>
                    <tr>
                        <td><center><b><asp:Label ID="lblPrice" runat="server" Text="HKD$"></asp:Label></b></center></td>
                        <td><center><asp:Label ID="lblPrice2" runat="server" Text='<%# Eval("price") %>'></asp:Label></center></td>
                    </tr>
                    <tr>
                        <td colspan="2"><center><b><asp:LinkButton ID="btnAdd" runat="server">Add</asp:LinkButton></b></center></td>
                    </tr>
                </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
