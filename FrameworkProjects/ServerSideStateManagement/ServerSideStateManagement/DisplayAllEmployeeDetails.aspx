<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayAllEmployeeDetails.aspx.cs" Inherits="ServerSideStateManagement.DisplayAllEmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            width: 192px;
        }
        .auto-style3 {
            width: 439px;
            height: 23px;
            font-size: x-large;
            text-align: center;
            color: #003399;
        }
        .auto-style12 {
            width: 265px;
            font-size: x-large;
        }
        .auto-style8 {
            width: 205px;
            text-align: center;
        }
        .auto-style10 {
            font-size: x-large;
        }
        .auto-style13 {
            width: 192px;
            font-size: x-large;
        }
        .auto-style11 {
            width: 205px;
            font-size: x-large;
        }
        .auto-style2 {
            width: 265px;
        }
        .auto-style6 {
            width: 192px;
            height: 23px;
        }
        .auto-style7 {
            width: 265px;
            height: 23px;
        }
        .auto-style9 {
            width: 205px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
            font-size: x-large;
        }
        .auto-style14 {
            width: 205px;
            text-align: left;
        }
        .auto-style15 {
            width: 192px;
            height: 31px;
        }
        .auto-style16 {
            width: 265px;
            font-size: x-large;
            height: 31px;
        }
        .auto-style17 {
            width: 205px;
            text-align: center;
            height: 31px;
        }
        .auto-style18 {
            font-size: x-large;
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div style="text-align: center; font-weight: 700;">
                        <asp:Label ID="lblCompanyName" runat="server" CssClass="auto-style3" ForeColor="#0033CC"></asp:Label>
        </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style15">
                    </td>
                    <td class="auto-style16"></td>
                    <td class="auto-style17">
                    </td>
                    <td class="auto-style18"></td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style3" ForeColor="#3333FF" Text="Employee 1 Details"></asp:Label>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Label ID="Label9" runat="server" CssClass="auto-style3" ForeColor="#3333FF" Text="Employee 2 Details"></asp:Label>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label5" runat="server" CssClass="auto-style10" Text="Name: "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblEmpName1" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:Label ID="Label13" runat="server" CssClass="auto-style10" Text="Name: "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmpName2" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label6" runat="server" CssClass="auto-style10" Text="Designation:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblEmpDesignation1" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:Label ID="Label12" runat="server" CssClass="auto-style10" Text="Designation:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmpDesignation2" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label10" runat="server" CssClass="auto-style10" Text="Branch:"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblBranch1" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="Label11" runat="server" CssClass="auto-style10" Text="Branch:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="lblBranch2" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
