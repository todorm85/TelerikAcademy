<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_05_EmployeesListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .employee {
            display: inline-block;
            background-color: burlywood;
            min-width: 150px;
            min-height: 150px;
            text-align: center;
            padding: 5px;
            vertical-align: central;
            line-height: 150px;
        }
        .employee-list {
            display: inline-block;
            border: 3px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListView runat="server" ItemType="_02_Employees.Employee"
            GroupItemCount="3" DataKeyNames="EmployeeID" ID="employeesList">
            <LayoutTemplate>
                <h3>Employees</h3>
                <div class="employee-list">
                    <asp:PlaceHolder runat="server" ID="groupPlaceholder"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <span>|</span>
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div class="employee">
                    <%#: Item.FirstName + " " + Item.LastName %>
                </div>
            </ItemTemplate>

            <GroupTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </GroupTemplate>

            <GroupSeparatorTemplate>
                <hr />
                <hr />
            </GroupSeparatorTemplate>
        </asp:ListView>
    </form>
</body>
</html>
