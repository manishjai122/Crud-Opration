<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crud_opration.aspx.cs" Inherits="practice.crud_opration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--        <div>
            <asp:Label ID="lblempid" runat="server" Text="Empid:"></asp:Label>
            <asp:TextBox ID="txtempid" runat="server"></asp:TextBox>
        </div>--%>
        <div>
            <asp:Label ID="lblname" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbllname" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbldepart" runat="server" Text="Department:"></asp:Label>
            <asp:DropDownList ID="dropdep" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="depname" DataValueField="depname">
                <asp:ListItem Selected="True">Select Department</asp:ListItem>
                <asp:ListItem>Hr</asp:ListItem>
                <asp:ListItem>Devoloper</asp:ListItem>
                <asp:ListItem>Project manger</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:employeeConnectionString %>" SelectCommand="SELECT * FROM [dptname]"></asp:SqlDataSource>
        </div>
        <div>
            <asp:Label ID="lbljoindt" runat="server" Text="Joining Date:"></asp:Label>
            <asp:TextBox ID="txtjoindt" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="lblgen" runat="server" Text="Gander:"></asp:Label>
            <asp:RadioButtonList ID="chkgender" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnadd" runat="server" Text="Insert" OnClick="btnadd_Click" />
            &nbsp;
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" OnClientClick="return conform (&quot;Are You Sure To Deleted ?&quot;)" />
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="empid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
