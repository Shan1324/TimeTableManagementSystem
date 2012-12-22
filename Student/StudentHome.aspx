<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="StudentHome.aspx.cs" Inherits="Student_StdentHome" %>
<%@ Register Src="~/Student/StudentSelectedCourseDetails.ascx" TagName="SelectedCourseControl" TagPrefix="SelectedCoursePrefix" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style7 {
        width: 42px;
    }
    .auto-style9 {
        width: 42px;
        height: 42px;
    }
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            width: 100%;
        }
        .auto-style12 {
            width: 240px;
        }
        .auto-style13 {
            width: 99px;
        }
        .auto-style14 {
            width: 69px;
        }
        .auto-style15 {
            width: 131px;
        }
        .auto-style16 {
            width: 147px;
        }
        .auto-style17 {
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;&nbsp;
                <table class="auto-style11">
                    <tr>
                        <td class="auto-style13">Course Title&nbsp; </td>
                        <td class="auto-style12">
                            <asp:DropDownList ID="ddlCourseTitle" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style14">Tutor&nbsp;&nbsp; </td>
                        <td class="auto-style15">
                            <asp:DropDownList ID="ddlTutor" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <table class="auto-style11">
                                <tr>
                                    <td class="auto-style16">Com Code</td>
                                    <td>
                                        <asp:TextBox ID="txtComCode" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style16">Course Code</td>
                                    <td>
                                        <asp:TextBox ID="txtCouresNo" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13">Day&nbsp; </td>
                        <td class="auto-style12">
                            <asp:DropDownList ID="ddlDay" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style14">Hour&nbsp; </td>
                        <td class="auto-style15">
                            <asp:DropDownList ID="ddlHour" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <table class="auto-style11">
                                <tr>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="127px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table class="auto-style1" id="TimeTableSchedule" style="overflow: visible; padding: 50px; margin: 5px" border="1">
                    <tr style="text-align:center">
                        <td>&nbsp;</td>
                        <td>1</td>
                        <td>2</td>
                        <td>3</td>
                        <td>4</td>
                        <td>5</td>
                        <td>6</td>
                        <td>7</td>
                        <td>8</td>
                        <td>9</td>
                    </tr>
                    <tr>
                        <td>Sun</td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun1" runat="server"/></td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun2" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun3" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun4" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun5" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun6" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun7" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun8" runat="server"/>
                        </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Sun9" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Mon</td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon1" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon2" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon3" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon4" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon5" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon6" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon7" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon8" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Mon9" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Tue</td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue1" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue2" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue3" runat="server"/></td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue4" runat="server"/>
                            </td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue5" runat="server"/>
                            </td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue6" runat="server"/>
                            </td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue7" runat="server"/>
                            </td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue8" runat="server"/>
                            </td>
                        <td class="auto-style10">
                            <SelectedCoursePrefix:SelectedCourseControl id="Tue9" runat="server"/>
                            </td>
                    </tr>
                    <tr>
                        <td>Wed</td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed1" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed2" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed3" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed4" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed5" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed6" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed7" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed8" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Wed9" runat="server"/>
                            </td>
                    </tr>
                    <tr>
                        <td>Thu</td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu1" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu2" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu3" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu4" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu5" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu6" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu7" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu8" runat="server"/>
                            </td>
                        <td>
                            <SelectedCoursePrefix:SelectedCourseControl id="Thu9" runat="server"/>
                            </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

