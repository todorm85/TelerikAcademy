<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="_02_Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Inputs:
            <br />
            <asp:TextBox runat="server" ID="tbInput" />
            <asp:Button Text="Send" runat="server" OnClick="OnBtnSend_Click" />
        </div>
        <br />
        <br />
        <div>
            Results:
            <br />
            Textbox:<asp:TextBox runat="server" ID="tbResult" Enabled="false"/>
            <br />
            Label:<asp:Label Text="" runat="server" ID="lbResult" />
        </div>
    </form>
</body>
</html>
