<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Random.aspx.cs" Inherits="_01_Random.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox type="text" runat="server" id="tbLowerBound" placeholder="lower" />
        <asp:TextBox type="text" runat="server" id="tbUpperBound" placeholder="upper" />
        <asp:button runat="server" 
            id="btnGenerate" 
            OnClick="btnGenerate_ServerClick" Text="Generate"/>
    </div>
    </form>
    <p runat="server" id="result"></p>
</body>
</html>
