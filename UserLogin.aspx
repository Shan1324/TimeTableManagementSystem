<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style6 {
            width: 249px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="auto-style1">
        <tr>
            <td style="width:25%">&nbsp;</td>
            <td style="width:50%">
                <table class="auto-style1">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table class="auto-style1">
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="auto-style1">
                                            <tr>
                                                <td class="auto-style6">User ID</td>
                                                <td>
                                                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6">Password</td>
                                                <td>
                                                    <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" Width="50%" OnClick="btnLogin_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLoginStatus" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:25%">&nbsp;</td>
        </tr>
    </table>
</asp:Content>


