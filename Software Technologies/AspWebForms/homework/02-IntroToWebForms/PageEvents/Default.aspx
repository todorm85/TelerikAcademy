<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PageEvents._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Assembly location</h1>
        <p class="lead" id="pLocationMessage" runat="server"></p>
    </div>

    <div class="jumbotron">
        <h1>Page events</h1>
        <p class="lead" id="pPageEvents" runat="server"></p>
    </div>

</asp:Content>
