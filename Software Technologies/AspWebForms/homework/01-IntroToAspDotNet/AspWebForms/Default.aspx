<%@ Page Title="Calculator Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET MVC Calculator</h1>
        <p class="lead">This is numbers sumator in WebForms.</p>
    </div>

    <fieldset>
        <legend>Calculator</legend>

        <div class="form-group">
            <label for="firstNumber" class="col-lg-2 control-label">FirstNumber</label>
            <div class="col-lg-10">
                <input type="text" class="form-control" ID="firstNumber" name="FirstNumber" placeholder="First Number" runat="server">
            </div>
        </div>

        <div class="form-group">
            <label for="secondNumber" class="col-lg-2 control-label">SecondNumber</label>
            <div class="col-lg-10">
                <input type="text" class="form-control" ID="secondNumber" name="SecondNumber" placeholder="Second Number" runat="server">
            </div>
        </div>

        <div class="form-group">
            <p class="col-lg-2 control-label">Result:</p>
            <div class="col-lg-10">
                <input type="text" class="form-control" ID="result" disabled="" runat="server">
            </div>
        </div>

        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <asp:button class="btn btn-primary" runat="server" ID="btnCalculate" Text="Calculate" OnClick="btnCalculate_Click"/>
            </div>
        </div>

    </fieldset>

</asp:Content>
