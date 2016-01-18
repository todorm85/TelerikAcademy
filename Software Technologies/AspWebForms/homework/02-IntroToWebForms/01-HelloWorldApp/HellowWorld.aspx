<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HellowWorld.aspx.cs" Inherits="_01_HelloWorldApp.HellowWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HelloWorldApp</title>
</head>
<body>
    <form id="formHelloWorld" runat="server">
        <div>
            <asp:Label ID="lbName" runat="server" Text="Your Name" AssociatedControlID="tbName" ></asp:Label>
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSendName" runat="server" Text="Greet" OnClick="OnBtnSendNameClick"/>
        </div>
    </form>
    <p id="pMessage" runat="server"></p>
</body>
</html>
