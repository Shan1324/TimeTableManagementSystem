<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Admin_AdminHome" EnableEventValidation="false"%>

<%@ Register src="~/Admin/StudentSelectedCourseDetails_Admin.ascx" tagname="SelectedCourseControl" tagprefix="SelectedCoursePrefix" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            width: 106px;
        }
        .auto-style14 {
            width: 1631px;
        }
        .auto-style15 {
            width: 80px;
            height: 42px;
        }
        .auto-style16 {
            width: 80px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>
                <table class="auto-style1">
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style14">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="btnSignOut" runat="server" OnClick="btnSignOut_Click" Text="Sign Out" Width="94px" />
                                    </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style16">
                            <table class="auto-style1" style="width: 18%">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                            <asp:ListItem>--- Approve For ---</asp:ListItem>
                                            <asp:ListItem>Student</asp:ListItem>
                                            <asp:ListItem>Teacher</asp:ListItem>
                                            <asp:ListItem>--- Other Operations ---</asp:ListItem>
                                            <asp:ListItem Value="Gen_Pref_tbl">Generate preference table</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp; &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style15">
                            <table class="auto-style1" style="width: 97%; margin-left: 0px">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlDepartment" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlSemester" runat="server" Visible="False">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                        </asp:DropDownList>
                                    &nbsp;
                                       
                   
                                        <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="List Down" Visible="False" />
                                       
                   
                                    &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style10">
                            <asp:ListView ID="lstUserList" runat="server" >
                                  <LayoutTemplate>
                                    <table runat="server" id="table1" >
                                      <tr runat="server" id="itemPlaceholder" ></tr>
                                    </table>
                                  </LayoutTemplate>
                                  <ItemTemplate>
                                    <tr id="Tr1" runat="server">
                                      <td id="Td1" runat="server">
                                        <%-- Data-bound content. --%>
                                        <asp:LinkButton ID="lblSelectedUser" runat="server" 
                                          Text='<%#Eval("ID")%>' OnClick="lblSelectedUser_Click" />
                                      </td>
                                    </tr>
                                  </ItemTemplate>
                            </asp:ListView>
                        &nbsp;</td>
                        <td>
                            <asp:Panel ID="pnlDetails" runat="server" Visible="False">
                                <br />
                                <asp:Label ID="Label1" Text="ID : " runat="server"></asp:Label>
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                                <asp:GridView ID="grdSelectedUserDet" runat="server">
                                </asp:GridView>
                                &nbsp;&nbsp;
                            </asp:Panel>
                            <asp:Panel ID="pnlApprove" runat="server" Visible="False">
                            
                            <br />
                            <asp:DropDownList ID="ddlRequestService" runat="server">
                                <asp:ListItem>Approve</asp:ListItem>
                                <asp:ListItem>Reject</asp:ListItem>
                            </asp:DropDownList>
&nbsp;
                            <br />
                            Message for the user:<br />
                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            <asp:Button ID="btnApply" runat="server" Text="Apply" Width="121px" OnClick="btnApply_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

