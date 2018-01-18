<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="_03_Students.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="First name" runat="server" />
            <asp:TextBox runat="server" ID="tbFirstName" />
            <br />
            <br />
            <asp:Label Text="Last name" runat="server" />
            <asp:TextBox runat="server" ID="tbLastName" />
            <br />
            <br />
            <asp:Label Text="Faculty number" runat="server" />
            <asp:TextBox runat="server" ID="tbFacultyNumber" />
            <br />
            <br />
            <asp:Label Text="University" runat="server" />
            <asp:DropDownList runat="server" ID="dlistlUniversity">
                <asp:ListItem Text="UACEG" Value="0" />
                <asp:ListItem Text="SU" Value="1" />
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label Text="Specialty" runat="server" />
            <asp:DropDownList runat="server" ID="dlistSpecialty">
                <asp:ListItem Text="Applied science" Value="0" />
                <asp:ListItem Text="Theoretical science" Value="1" />
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label Text="Courses:" runat="server" />
            <select id="selectCourses" runat="server" multiple="true">
                <option value="0">Alchemy</option>
                <option value="1">Witchcraft</option>
            </select>
            <asp:Button Text="Submit" runat="server" OnClick="OnSubmit_Click" />
        </div>

        <div runat="server" id="output"></div>

    </form>
</body>
</html>
