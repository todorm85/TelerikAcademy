<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="YouTubePlaylists.Web.Categories.Categories" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="YouTubePlaylists.Models.Category" DataKeyNames="Id" SelectMethod="ListViewCategories_GetData"
        InsertMethod="ListViewCategories_InsertItem" UpdateMethod="ListViewCategories_UpdateItem"
        InsertItemPosition="LastItem" OnSorting="ListViewCategories_Sorting">

        <LayoutTemplate>
            <div class="row">
            </div>
            <div class="row">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">Action</th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-default" Text="Sort by Id"
                                    CommandArgument="Id" CommandName="Sort" />
                            </th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-default" Text="Sort by Name"
                                    CommandArgument="Name" CommandName="Sort" />
                            </th>
                            <th class="text-center">
                                <asp:LinkButton runat="server" ID="ButtonSortByCount" CssClass="btn btn-default" Text="Sort by PlaylistCount"
                                    CommandArgument="Playlists.Count" CommandName="Sort" />
                            </th>
                        </tr>
                    </thead>
                    <tbody class="text-center">
                        <div runat="server" id="itemPlaceHolder"></div>
                    </tbody>
                </table>
            </div>

            <div class="row">
                <asp:DataPager runat="server" ID="DataPagerBooks" PagedControlID="ListViewCategories" PageSize="5">
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
                    <asp:LinkButton runat="server" ID="ButtonEditBook" CssClass="btn btn-info btn-xs" Text="Edit" CommandName="Edit" />
                </td>
                <td><%#: Item.Id %> </td>
                <td><%#: Item.Name %> </td>
                <td><%#: Item.Playlists.Count() %> </td>
            </tr>
        </ItemTemplate>

        <EditItemTemplate>
            <td>
                <asp:LinkButton runat="server" ID="ButtonEditBook" CssClass="btn btn-success btn-xs" Text="Save"
                    CommandName="Update" CausesValidation="true" ValidationGroup="EditBook" />
                <asp:LinkButton runat="server" ID="ButtonCancelEditBook" CssClass="btn btn-danger btn-xs" Text="Cancel"
                    CommandName="Cancel" CausesValidation="false" />
            </td>
            <td><%#: Item.Id %></td>
            <td>
                <asp:TextBox ID="tbEditTitle" runat="server" Text="<%#: BindItem.Name %>" />
                <asp:RequiredFieldValidator ErrorMessage="Title is required!" ValidationGroup="EditBook" ControlToValidate="tbEditTitle"
                    ForeColor="Red" runat="server" />
            </td>
            <td><%#: Item.Playlists.Count() %></td>
        </EditItemTemplate>

        <InsertItemTemplate>
            <td>
                <asp:LinkButton runat="server" ID="ButtonInsertBook" CssClass="btn btn-success" CommandName="Insert" Text="Insert" CausesValidation="true"
                    ValidationGroup="InsertBook" />
            </td>
            <td>Auto</td>
            <td>
                <asp:TextBox ID="TextBoxInsertTitle" runat="server" Text="<%#: BindItem.Name %>" />
                <asp:RequiredFieldValidator ErrorMessage="Title is required!" ValidationGroup="InsertBook" ControlToValidate="TextBoxInsertTitle"
                    ForeColor="Red" runat="server" />
            </td>
            <td>Auto</td>
        </InsertItemTemplate>

    </asp:ListView>

</asp:Content>
