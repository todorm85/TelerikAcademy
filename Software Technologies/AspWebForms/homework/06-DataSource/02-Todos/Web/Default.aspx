<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Todos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Todos</h3>
    <asp:Button ID="AddNewButton" runat="server"
        Text="Add new"
        OnClick="AddNewButton_Click"
        CssClass="btn btn-default" />
    <div class="row">
        <div class="col-md-6">

            <asp:ListView runat="server" ID="ListViewTodos"
                DataKeyNames="Id"
                SelectMethod="ListViewTodos_GetData"
                ItemType="Countries.Data.Models.Todo"
                DeleteMethod="FormViewTodoDetails_DeleteItem">

                <LayoutTemplate>
                    <ul class="list-group">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="list-group-item" runat="server" id="li1">
                        <a href="#" runat="server"
                            name="<%# Item.Id %>"
                            onserverclick="ListViewTodos_ServerClick">
                            <%#: Item.Title %></a>
                        <asp:Button ID="ButtonDelete" runat="server"
                                CommandName="Delete"
                                Text="Delete"
                                CssClass="btn btn-default" />
                    </li>
                </ItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="ListViewTodosPager" runat="server"
                PagedControlID="ListViewTodos" PageSize="5"
                QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>

        </div>

        <div class="col-md-6">

            <asp:FormView runat="server" ID="FormViewTodoDetails"
                ItemType="Countries.Data.Models.Todo"
                DataKeyNames="Id"
                SelectMethod="FormViewTodos_GetData"
                UpdateMethod="FormViewTodoDetails_UpdateItem"
                InsertMethod="FormViewTodoDetails_InsertItem"
                DeleteMethod="FormViewTodoDetails_DeleteItem"
                RenderOuterTable="false">
                <EmptyDataTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            Nothing selected
                        </div>
                    </div>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.Title %></h3>
                        </div>
                        <div class="panel-body">
                            <p><%#: Item.Body %></p>
                            <p><%#: Item.Category.Name %></p>
                            <asp:Button ID="ButtonEdit" runat="server"
                                CommandName="Edit"
                                Text="Edit"
                                CssClass="btn btn-default" />
                            <asp:Button ID="ButtonDelete" runat="server"
                                CommandName="Delete"
                                Text="Delete"
                                CssClass="btn btn-default" />
                        </div>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.Title %></h3>
                        </div>
                        <div class="panel-body">
                            Title:
                            <asp:TextBox runat="server" ID="editTitle"
                                Text="<%#: BindItem.Title %>" />
                            <br />
                            Body:
                            <asp:TextBox runat="server" ID="editBody"
                                Text="<%#: BindItem.Body %>" />
                            <br />
                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </div>
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Add new Todo</h3>
                        </div>
                        <div class="panel-body">
                            Title:
                            <asp:TextBox runat="server" ID="insertTitle"
                                Text="<%#: BindItem.Title %>" />
                            <br />
                            Body:
                            <asp:TextBox runat="server" ID="insertBody"
                                Text="<%#: BindItem.Body %>" />
                            <br />
                            Category:
                            <asp:DropDownList runat="server" ID="DropDownListCategoriesList"
                                ItemType="Countries.Data.Models.Category"
                                SelectMethod="GetGategories"
                                DataTextField="Name"
                                DataValueField="Id">
                            </asp:DropDownList>
                            <br />
                            <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="ButtonInsertCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </div>
                    </div>
                </InsertItemTemplate>
            </asp:FormView>

        </div>
    </div>

</asp:Content>
