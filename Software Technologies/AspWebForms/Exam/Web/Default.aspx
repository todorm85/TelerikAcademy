<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YouTubePlaylists._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Welcome to YouTubePlaylists</h1>

    <asp:ListView runat="server" ID="ListViewPlaylists" ItemType="YouTubePlaylists.Models.Playlist"
        SelectMethod="ListViewPlaylists_GetData">

        <LayoutTemplate>
            <div class="row">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">Title</th>
                            <th class="text-center">Category</th>
                            <th class="text-center">Author</th>
                            <th class="text-center">Ratings</th>
                        </tr>
                    </thead>
                    <tbody class="text-center">
                        <div runat="server" id="itemPlaceHolder"></div>
                    </tbody>
                </table>
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink NavigateUrl='<%# "~/Playlists/Playlist.aspx?id=" + Item.Id %>' runat="server" Text="<%#: Item.Title %>" />
                </td>
                <td><%#: Item.Category.Name %> </td>
                <td><%#: Item.Creator.UserName %> </td>
                <td><%#: Item.Ratings.Any() ? Item.Ratings.Average(x => x.Value) : 0 %> </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

</asp:Content>
