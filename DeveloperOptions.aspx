<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="DeveloperOptions.aspx.cs" Inherits="DeveloperOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            width: 96px;
        }
    .auto-style8 {
    }
    .auto-style9 {
        width: 62px;
    }
    .auto-style10 {
        width: 72px;
    }
    .auto-style11 {
        width: 68px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlOperation" runat="server"  Width="152px">
                    <asp:ListItem>--- Select Option ---</asp:ListItem>
                    <asp:ListItem Value="Select * from">View</asp:ListItem>
                    <asp:ListItem Value="Insert into ">Insert</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style11">Value1</td>
            <td class="auto-style9">Value2</td>
            <td class="auto-style10">Value3</td>
            <td>Value4</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlTableName" runat="server" Width="152px">
                    <asp:ListItem>--- Select table ---</asp:ListItem>
                    <asp:ListItem Value="tblCourses">Courses</asp:ListItem>
                    <asp:ListItem Value="tblDepartment">Departments</asp:ListItem>
                    <asp:ListItem Value="tblUsers">Users</asp:ListItem>
                    <asp:ListItem Value="tblApprovalStatus">Approval Status</asp:ListItem>
                    <asp:ListItem Value="tblCourseTeacherMap">Course - Teacher Map</asp:ListItem>
                    <asp:ListItem Value="tblStudentCourseMap">Student -Course Map</asp:ListItem>
                    <asp:ListItem Value="tblStudentSemMap">Student - Sem Map</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style11">
                <asp:TextBox ID="txtVal1" runat="server" Width="63px"></asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="txtVal2" runat="server" Width="63px"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="txtVal3" runat="server" Width="63px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtVal4" runat="server" Width="63px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="btnPerform" runat="server" Text="Perform Operation" Width="152px" OnClick="btnPerform_Click" />
            </td>
            <td class="auto-style8" colspan="4">
                <asp:GridView ID="grdDetails" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

