<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee1Form.aspx.cs" Inherits="ServerSideStateManagement.Employee1Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 426px;
        }
        .auto-style3 {
            font-size: x-large;
            font-weight: 700;
            text-align: left;
        }
        .auto-style4 {
            width: 426px;
            font-size: x-large;
        }
        .auto-style5 {
            width: 426px;
            height: 37px;
        }
        .auto-style6 {
            height: 37px;
        }
        .auto-style7 {
            width: 426px;
            font-size: x-large;
            height: 31px;
        }
        .auto-style8 {
            font-size: x-large;
            font-weight: 700;
            text-align: left;
            height: 31px;
        }
        .auto-style9 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style3" ForeColor="#3333FF" Text="Employee 1 Form"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Employee Name"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtEmp1Name" runat="server" CssClass="auto-style3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style3" Text="Designation"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmp1Designation" runat="server" CssClass="auto-style3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label5" runat="server" CssClass="auto-style3" Text="Branch"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmp1Branch" runat="server" CssClass="auto-style3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style9">
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style3" OnClick="btnSubmit_Click" Text="Submit" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
 
</body>
</html>
