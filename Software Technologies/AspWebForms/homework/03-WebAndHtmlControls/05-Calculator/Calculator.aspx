<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_05_Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .calc-container {
            display: inline-block;
            border: 3px solid black;
        }
        .calc-control {
            margin: 2px;
            padding: 5px;
            border: 1px solid black;
            text-align: center;
        }
        .calc-main button {
            margin: 2px;
            width: 30px;
        }
        .calc-result input {
            border: 1px solid black;
            min-width: 50px;
            text-align: right;
            padding: 3px;
        }
        .calc-calculate {
            text-align: center;
        }
        .calc-calculate button {
            min-width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="calc-container">
            <div class="calc-control calc-result">
                <input type="text" name="result" value="" runat="server" id="result" disabled="disabled"/>
            </div>
            <div class="calc-control calc-main">
                <button runat="server" onserverclick="Digit_ServerClick">1</button>
                <button runat="server" onserverclick="Digit_ServerClick">2</button>
                <button runat="server" onserverclick="Digit_ServerClick">3</button>
                <button runat="server" onserverclick="Operation_ServerClick">+</button>
                <br />
                <button runat="server" onserverclick="Digit_ServerClick">4</button>
                <button runat="server" onserverclick="Digit_ServerClick">5</button>
                <button runat="server" onserverclick="Digit_ServerClick">6</button>
                <button runat="server" onserverclick="Operation_ServerClick">-</button>
                <br />
                <button runat="server" onserverclick="Digit_ServerClick">7</button>
                <button runat="server" onserverclick="Digit_ServerClick">8</button>
                <button runat="server" onserverclick="Digit_ServerClick">9</button>
                <button runat="server" onserverclick="Operation_ServerClick">x</button>
                <br />
                <button runat="server" onserverclick="Clear_ServerClick">CE</button>
                <button runat="server" onserverclick="Digit_ServerClick">0</button>
                <button runat="server" onserverclick="Operation_ServerClick">/</button>
                <button runat="server" onserverclick="Sqrt_ServerClick">&#8730;</button>
                <br />
            </div>
            <div class="calc-control calc-calculate">
                <button runat="server" onserverclick="Operation_ServerClick">=</button>
            </div>
        </div>
        <input type="hidden" value="" runat="server" id="lastOperation"/>
        <input type="hidden" value="" runat="server" id="currentResult"/>
    </form>
</body>
</html>
