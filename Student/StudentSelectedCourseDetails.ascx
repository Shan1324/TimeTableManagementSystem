<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentSelectedCourseDetails.ascx.cs" Inherits="Student_StudentSelectedCourseDetails" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style7 {
        width: 42px;
    }
    .auto-style9 {
        width: 42px;
        height: 42px;
    }
        .auto-style10 {
        width: 596px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td colspan="2">
                            <table class="auto-style1" style="width: 100%">
                                <tr>
                                    <td class="auto-style7">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style9">
                                        <asp:Label ID="Label1" runat="server" Text="Com Code"></asp:Label>
                                        <asp:TextBox ID="txtSelectedComCod" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Text="Course Code"></asp:Label>
                                        <asp:TextBox ID="txtSelectedCourseNo" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                                        <asp:TextBox ID="txtSelectedTitle" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label4" runat="server" Text="Tutor"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtSelectedTutor" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">
                                        <asp:Label ID="Label5" runat="server" Font-Italic="True" Text="No Course Added For This Session"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
    </tr>
    <tr>
        <td class="auto-style10">&nbsp;</td>
        <td>
            <asp:Button ID="btnRemoveSelectedCourse" runat="server" Text="Remove" />
        </td>
    </tr>
</table>

