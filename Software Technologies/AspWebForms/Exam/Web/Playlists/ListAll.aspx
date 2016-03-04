<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAll.aspx.cs"
    Inherits="YouTubePlaylists.Web.Playlists.ListAll" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="form-group col-md-3">
            <input type="text" class="form-control" placeholder="Search" runat="server" id="InputTextSearch" />
        </div>
        <asp:LinkButton CssClass="btn btn-default" runat="server" ID="ButtonSearch" OnClick="ButtonSearch_Click">Search</asp:LinkButton>
    </div>

    <asp:ListView runat="server" ID="ListViewPlaylists" ItemType="YouTubePlaylists.Models.Playlist" DataKeyNames="Id"
        SelectMethod="ListViewPlaylists_GetData" OnSorting="ListViewPlaylists_Sorting">

        <LayoutTemplate>

            <div class="row">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">Action</th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-default" Text="Sort by Title"
                                    CommandArgument="Title" CommandName="Sort" />
                            </th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-default" Text="Sort by Category"
                                    CommandArgument="Category.Name" CommandName="Sort" />
                            </th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton3" CssClass="btn btn-default" Text="Sort by creator"
                                    CommandArgument="Creator.FirstName" CommandName="Sort" />
                            </th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton4" CssClass="btn btn-default" Text="Sort by videos count"
                                    CommandArgument="Videos.Count" CommandName="Sort" />
                            </th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton5" CssClass="btn btn-default" Text="Sort by Date"
                                    CommandArgument="CreationDate" CommandName="Sort" />
                            </th>
                        </tr>
                    </thead>
                    <tbody class="text-center">
                        <div runat="server" id="itemPlaceHolder"></div>
                    </tbody>
                </table>
            </div>

            <div class="row">
                <asp:DataPager runat="server" ID="DataPagerBooks" PagedControlID="ListViewPlaylists" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ShowNextPageButton="false" ShowPreviousPageButton="true" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowNextPageButton="true" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink NavigateUrl='<%# "~/Playlists/Playlist.aspx?id=" + Item.Id %>' runat="server" Text="Details" CssClass="btn btn-default" />
                </td>
                <td>
                    <asp:HyperLink NavigateUrl='<%# "~/Playlists/Playlist.aspx?id=" + Item.Id %>' runat="server" Text="<%#: Item.Title %>" CssClass="btn btn-default" />
                </td>
                <td>                    
                    <asp:HyperLink NavigateUrl='<%# "~/Playlists/ListAll.aspx?category=" + Item.Category.Name %>' runat="server" 
                        Text="<%#: Item.Category.Name %>" CssClass="btn btn-default" />
                </td>
                <td><%#: Item.Creator.FirstName %> <%#: Item.Creator.LastName %></td>
                <td><%#: Item.Videos.Count() %> </td>
                <td><%#: Item.CreationDate %> </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

</asp:Content>
