<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_01_CarsSearch.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Producer:
        <asp:DropDownList runat="server" ID="ltProducers" AutoPostBack="true">
        </asp:DropDownList>
        Model:
        <asp:DropDownList runat="server" ID="ltModels" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        
        Engine type:
        <asp:RadioButtonList runat="server" ID="ltEngines" RepeatDirection="Horizontal" AutoPostBack="true">
        </asp:RadioButtonList>
        <br />

        Gear box:
        <asp:RadioButtonList runat="server" ID="ltGearBoxes" RepeatDirection="Horizontal" AutoPostBack="true">
        </asp:RadioButtonList>
        <br />
        <br />
        <br />

        <asp:Literal runat="server" ID="postbackQuery"></asp:Literal>
    </form>
</body>
</html>
