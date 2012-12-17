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
                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                    <asp:ListItem>COM COD</asp:ListItem>
                    <asp:ListItem>COURSE NO</asp:ListItem>
                    <asp:ListItem>COURSE TITLE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
            </td>
            <td rowspan="3">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="bind(&quot;ComCod&quot;)" HeaderText="COM COD" />
                        <asp:BoundField DataField="bind(&quot;CourseNo&quot;)" HeaderText="COURSE NO" />
                        <asp:BoundField DataField="bind(&quot;CourseTitle&quot;)" HeaderText="COURSE TITLE" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnCourseView" runat="server" Text="View" />
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
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnListDown" runat="server" Text="List Down" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

