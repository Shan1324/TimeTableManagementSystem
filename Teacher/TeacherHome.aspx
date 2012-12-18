<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="TeacherHome.aspx.cs" Inherits="Teacher_TeacherHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            width: 14%;
        }
        .auto-style8 {
            width: 22%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlSearchItem" runat="server" Width="150px">
                    <asp:ListItem Value="ComCod">COM COD</asp:ListItem>
                    <asp:ListItem Value="CourseNo">COURSE NO</asp:ListItem>
                    <asp:ListItem Value="CourseTitle">COURSE TITLE</asp:ListItem>
                    <asp:ListItem Value="Department">DEPARTMENT</asp:ListItem>
                    <asp:ListItem Value="Semester">SEMESTER</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
                <br />
            </td>
            <td rowspan="5">
                <asp:GridView ID="grdCourses" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdCourses_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItemSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ComCod" HeaderText="COM COD" />
                        <asp:BoundField DataField="CourseNo" HeaderText="COURSE NO" />
                        <asp:BoundField DataField="CourseTitle" HeaderText="COURSE TITLE" />
                        <asp:TemplateField HeaderText="SECTION">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlSection" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <br />
                <asp:Button ID="btnAddCourses" runat="server" Text="Add selected to profile" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                Department [Optional]</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlDepartments" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                Semester [Optional]</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlSem" runat="server">
                    <asp:ListItem>All Semesters</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnListDown" runat="server" Text="List Down" OnClick="btnListDown_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

