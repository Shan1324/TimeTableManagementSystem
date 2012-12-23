<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="TeacherHome.aspx.cs" Inherits="Teacher_TeacherHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            width: 14%;
        }
        .auto-style8 {
            width: 22%;
        }
        .auto-style9 {
            width: 370px;
        }
        .auto-style10 {
            width: 106px;
        }
        .auto-style11 {
        }
        .auto-style12 {
            width: 114px;
            height: 23px;
        }
        .auto-style13 {
            height: 23px;
        }
        .auto-style14 {
            width: 109px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td class="auto-style10" >
                &nbsp;</td>
            <td class="auto-style9" >
                &nbsp;</td>
            <td >
                <asp:Button ID="btnSignOut" runat="server" OnClick="btnSignOut_Click" Text="Sign Out" Width="94px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlSearchItem" runat="server" Width="150px">
                    <asp:ListItem Value="ComCod">COM COD</asp:ListItem>
                    <asp:ListItem Value="CourseNo">COURSE NO</asp:ListItem>
                    <asp:ListItem Value="CourseTitle">COURSE TITLE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
                <br />
            </td>
            <td colspan="3" >
                List of courses not added to profile<br />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                Department [Optional]</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlDepartments" runat="server">
                </asp:DropDownList>
            </td>
            <td rowspan="3" colspan="3" >
                <asp:GridView ID="grdCourses" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnSelectedIndexChanged="grdCourses_SelectedIndexChanged" OnPageIndexChanging="grdCourses_PageIndexChanging" PageSize="2">
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
                <asp:Button ID="btnAddCourses" runat="server" OnClick="btnAddCourses_Click" Text="Add selected to profile" Width="240px" />
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
            <td class="auto-style7">
                <asp:Button ID="btnListDown" runat="server" Text="List Down" OnClick="btnListDown_Click" />
            </td>
            <td class="auto-style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td colspan="3" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="3" >
                List of courses added to profile</td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="auto-style1">
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style12">Approval Status</td>
                                    <td class="auto-style13">
                                        <asp:Label ID="lblApprovalStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style11" colspan="2">
                                        <asp:TextBox ID="txtMessageBox" runat="server" Enabled="False" ReadOnly="True" Rows="5" TextMode="MultiLine" Width="224px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSendForApproval" runat="server" OnClick="btnSendForApproval_Click" Text="Send for approval" Width="118px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td colspan="3" >
                <asp:GridView ID="grdTeachingCourses" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="grdTeachingCourses_PageIndexChanging" PageSize="2">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItemSelectRemove" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ComCod" HeaderText="COM COD" />
                        <asp:BoundField DataField="CourseNo" HeaderText="COURSE NO" />
                        <asp:BoundField DataField="CourseTitle" HeaderText="COURSE TITLE" />
                        <asp:BoundField DataField="Section" HeaderText="SECTION" />
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
                <asp:Button ID="btnRemoveCourse" runat="server" OnClick="btnRemoveCourse_Click" Text="Remove selected from profile" />
            </td>
        </tr>
    </table>
</asp:Content>

