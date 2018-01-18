<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04_EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
            border-collapse:collapse;
        }
        table th,
        table td {
            border: 1px solid black;
            padding: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="_02_Employees.Employee">
            <HeaderTemplate>
                <table>
                    <thead>
                        <th>Index</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%# Item.EmployeeID %></td>
                            <td><%#: Item.FirstName %></td>
                            <td><%#: Item.LastName %></td>
                        </tr>
                    </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
