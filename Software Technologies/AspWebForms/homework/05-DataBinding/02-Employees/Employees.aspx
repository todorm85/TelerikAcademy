<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02_Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server"
            ID="employeesGrid"
            AutoGenerateColumns="false"
            AllowPaging="true"
            OnPageIndexChanging="employeesGrid_PageIndexChanging"
            PageSize="5"
            PagerSettings-Mode="NextPrevious">
            <Columns>
                <asp:HyperLinkField DataTextField="FirstName"
                    HeaderText="First name"
                    DataNavigateUrlFields="EmployeeID" 
                    DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
