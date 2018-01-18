<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="YouTubePlaylists.Web.Account.Profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <asp:FormView runat="server" ID="FormViewUserDetails"
                ItemType="YouTubePlaylists.Models.User"
                DataKeyNames="Id"
                SelectMethod="GetData"
                UpdateMethod="UpdateItem"
                RenderOuterTable="false">

                <ItemTemplate>
                    <div class="panel panel-primary">

                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> detias</h3>
                        </div>

                        <div class="panel-body">

                            <div class="col-md-6 col-md-offset-3" id="avatar-container">
                                <img src="<%# Item.ImageUrl %>"
                                    class="img-thumbnail img-responsive" />
                            </div>

                            <div class="col-md-12 well-sm">
                                <p><span class="text-uppercase">Email:</span> <%#: Item.Email %></p>
                            </div>

                            <div class="col-md-12 well-sm">
                                <p><span class="text-uppercase">FirstName:</span> <%#: Item.FirstName %></p>
                            </div>

                            <div class="col-md-12 well-sm">
                                <p><span class="text-uppercase">LastName:</span> <%#: Item.LastName %></p>
                            </div>

                            <div class="col-md-12 well-sm">
                                <p>
                                    <span class="text-uppercase">Facebook:</span>
                                    <asp:HyperLink NavigateUrl='<%# Item.FacebookUrl %>' runat="server" Text="<%#: Item.FacebookUrl %>" />
                                </p>
                            </div>

                            <div class="col-md-12 well-sm">
                                <p>
                                    <span class="text-uppercase">Youtube:</span>
                                    <asp:HyperLink NavigateUrl='<%# Item.YouTubeUrl %>' runat="server" Text="<%#: Item.YouTubeUrl %>" />
                                </p>
                            </div>

                            <div class="col-md-12 well-sm">
                                <span class="text-uppercase">User roles: </span>
                                <asp:Repeater runat="server" ID="RepeaterRoles"
                                    DataSource="<%# Item.AppRoles.ToList() %>"
                                    ItemType="YouTubePlaylists.Models.AppRole">
                                    <ItemTemplate>
                                        <span class="label label-default"><%#:Item.Name %></span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <div class="col-md-12 well-sm">
                                <span class="text-uppercase">User playlists: </span>
                                <asp:Repeater runat="server" ID="Repeater1"
                                    DataSource="<%# Item.Playlists.ToList() %>"
                                    ItemType="YouTubePlaylists.Models.Playlist">
                                    <ItemTemplate>
                                        <asp:HyperLink NavigateUrl='<%# "~/Playlists/Playlist.aspx?id=" + Item.Id %>' runat="server" Text="<%#: Item.Title %>" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <div class="col-md-12 well-sm">
                                <asp:Button ID="ButtonEdit" runat="server"
                                    CommandName="Edit"
                                    Text="Edit"
                                    CssClass="btn btn-default" />
                                <%--<asp:Button ID="ButtonDelete" runat="server"
                                    CommandName="Delete"
                                    Text="Delete"
                                    CssClass="btn btn-danger" />--%>
                            </div>

                        </div>
                    </div>
                </ItemTemplate>

                <EditItemTemplate>
                    <div class="panel panel-primary">

                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> edit details</h3>
                        </div>

                        <div class="panel-body">

                            <div class="form-group col-md-12">
                                <span class="text-primary">FirstName</span>
                                <asp:TextBox runat="server" ID="FirstName" Text="<%#: BindItem.FirstName %>" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                    CssClass="text-danger" ErrorMessage="The FirstName field is required." />
                            </div>

                            <div class="form-group col-md-12">
                                <span class="text-primary">LastName</span>
                                <asp:TextBox runat="server" ID="LastName" Text="<%#: BindItem.LastName %>" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                                    CssClass="text-danger" ErrorMessage="The LastName field is required." />
                            </div>

                            <div class="form-group col-md-12">
                                <span class="text-primary">ImageUrl</span>
                                <asp:TextBox runat="server" ID="TextBox2" Text="<%#: BindItem.ImageUrl %>" />
                            </div>

                            <div class="form-group col-md-12">
                                <span class="text-primary">FacebookUrl</span>
                                <asp:TextBox runat="server" ID="TextBox3" Text="<%#: BindItem.FacebookUrl %>" />
                            </div>

                            <div class="form-group col-md-12">
                                <span class="text-primary">YouTubeUrl</span>
                                <asp:TextBox runat="server" ID="TextBox4" Text="<%#: BindItem.YouTubeUrl %>" />
                            </div>

                            <div class="col-md-12">
                                <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                            </div>
                        </div>

                    </div>
                </EditItemTemplate>

            </asp:FormView>
        </div>
    </div>
</asp:Content>
