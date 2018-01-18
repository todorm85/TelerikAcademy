<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Random.aspx.cs" Inherits="_01_Random.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" runat="server" id="tbLowerBound" placeholder="lower" />
        <input type="text" runat="server" id="tbUpperBound" placeholder="upper" />
        <button runat="server" 
            id="btnGenerate" 
            onserverclick="btnGenerate_ServerClick">Generate</button>
    </div>
    </form>
    <p runat="server" id="result"></p>
</body>
</html>
