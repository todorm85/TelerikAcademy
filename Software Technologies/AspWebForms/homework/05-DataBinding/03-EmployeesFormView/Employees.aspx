<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_03_EmployeesFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView ID="fvEmployees" runat="server" ItemType="_02_Employees.Employee"
            AllowPaging="true" OnPageIndexChanging="fvEmployees_PageIndexChanging">
            <ItemTemplate>
                <a href="Employees.aspx?id=<%# Item.EmployeeID %>">
                    <%#: Item.FirstName %>
                </a>
            </ItemTemplate>
            <EditItemTemplate>
                <p><%#: Item.FirstName %></p>
                <p><%#: Item.LastName %></p>
                <p><%#: Item.Notes %></p>
            </EditItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
