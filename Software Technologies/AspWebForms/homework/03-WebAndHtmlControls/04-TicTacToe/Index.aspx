<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_04_TicTacToe.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TicTacToe</title>
    <style>
        .btnGameField {
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" id="container">
            
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <br />
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <br />
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>
            <asp:Button runat="server" OnCommand="GameField_Command" CssClass="btnGameField" Text=" "/>

        </div>
        <button runat="server" id="reset" onserverclick="reset_ServerClick">Reset</button>
    </form>
</body>
</html>
