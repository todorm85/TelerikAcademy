<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playlist.aspx.cs" Inherits="YouTubePlaylists.Web.Playlists.Playlist" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button Text="CREATE" runat="server" ID="btnCreate"
        CssClass="btn btn-success btn-lg"
        OnClick="btnCreate_Click" />

    <asp:FormView runat="server" ID="FormViewPlaylist" ItemType="YouTubePlaylists.Models.Playlist" SelectMethod="FormViewPlaylist_GetItem"
        RenderOuterTable="false" InsertMethod="FormViewPlaylist_InsertItem" DeleteMethod="FormViewPlaylist_DeleteItem" 
        UpdateMethod="FormViewPlaylist_UpdateItem" DataKeyNames="Id">

        <ItemTemplate>
            <div class="col-md-6 col-md-offset-3">

                <h2><%#: Item.Title %> <small><%#: Item.Category.Name %></small></h2>
                <p>Description: <%#: Item.Description %></p>

                <span class="text-uppercase">Playlist videos: </span>
                <br />
                <asp:Repeater runat="server" ID="Repeater1"
                    DataSource="<%# Item.Videos.ToList() %>"
                    ItemType="YouTubePlaylists.Models.Video">
                    <ItemTemplate>
                        <asp:HyperLink NavigateUrl="<%# Item.Url %>" runat="server" Text="<%#: Item.Url %>" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <p>
                    <span>Author: <%#: Item.Creator.FirstName %> <%#: Item.Creator.LastName %></span>
                    <span class="pull-right"><%#: Item.CreationDate %></span>
                </p>

                <div class="col-md-12 well-sm">
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-default" />
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
                </div>

            </div>

        </ItemTemplate>

        <InsertItemTemplate>
            <div class="col-md-6 col-md-offset-3">

                <h3>Title: 
                   
                    <asp:TextBox runat="server" ID="TextBoxInsertTitle" Width="300" Text="<%#: BindItem.Title %>"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Title is required!" ValidationGroup="InsertPlaylist"
                        ControlToValidate="TextBoxInsertTitle" ForeColor="Red" runat="server" />
                </h3>

                <p>
                    Category: 
                   
                    <asp:DropDownList runat="server" ID="DropDownListCategories" ItemType="YouTubePlaylists.Models.Category" DataTextField="Name"
                        SelectedValue="<%#: BindItem.CategoryId %>" DataValueField="Id" SelectMethod="DropDownListCategories_GetData">
                    </asp:DropDownList>
                </p>

                <p>
                    Description: 
                   
                    <asp:TextBox runat="server" ID="TextBoxInsertContent" Width="300" TextMode="MultiLine" Text="<%#: BindItem.Description %>"
                        Rows="6"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Content is Required!" ValidationGroup="InsertPlaylist"
                        ControlToValidate="TextBoxInsertContent" ForeColor="Red" runat="server" />
                </p>

                <p>VideoUrls(SEPARATE WITH SPACE): </p>
                <p>
                    <asp:TextBox runat="server" ID="tbVideoUrls" Width="300" TextMode="MultiLine" Text=""
                        Rows="6"></asp:TextBox>
                </p>

                <div>
                    <asp:LinkButton runat="server" ID="ButtonInsertArticle" CssClass="btn btn-success" CommandName="Insert" Text="Insert"
                        CausesValidation="true" ValidationGroup="InsertPlaylist" />
                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                </div>
            </div>
        </InsertItemTemplate>

        <EditItemTemplate>
            <div class="col-md-6 col-md-offset-3">

                <h3>Title: 
                   
                    <asp:TextBox runat="server" ID="TextBoxInsertTitle" Width="300" Text="<%#: BindItem.Title %>"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Title is required!" ValidationGroup="InsertPlaylist"
                        ControlToValidate="TextBoxInsertTitle" ForeColor="Red" runat="server" />
                </h3>

                <p>
                    Category: 
                   
                    <asp:DropDownList runat="server" ID="DropDownListCategories" ItemType="YouTubePlaylists.Models.Category" DataTextField="Name"
                        SelectedValue="<%#: BindItem.CategoryId %>" DataValueField="Id" SelectMethod="DropDownListCategories_GetData">
                    </asp:DropDownList>
                </p>

                <p>
                    Description: 
                   
                    <asp:TextBox runat="server" ID="TextBoxInsertContent" Width="300" TextMode="MultiLine" Text="<%#: BindItem.Description %>"
                        Rows="6"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Content is Required!" ValidationGroup="InsertPlaylist"
                        ControlToValidate="TextBoxInsertContent" ForeColor="Red" runat="server" />
                </p>

                <p>
                    <div id="events" class="form-group col-md-12">
                        <span class="text-primary">Videos: </span>
                        <asp:ListBox runat="server" ID="ListBoxEditVideos"
                            DataSource="<%# Item.Videos %>"
                            ItemType="YouTubePlaylists.Models.Video"
                            DataTextField="Url"
                            DataValueField="Id"
                            SelectionMode="Multiple"></asp:ListBox>
                        <asp:Button ID="RemoveEvent" runat="server"
                            OnClick="RemoveVideo_Click"
                            Text="Remove video" />
                    </div>
                </p>

                <div>
                    <asp:LinkButton runat="server" ID="ButtonInsertArticle" CssClass="btn btn-success" CommandName="Update" Text="Update"
                        CausesValidation="true" ValidationGroup="InsertPlaylist" />
                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                </div>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
