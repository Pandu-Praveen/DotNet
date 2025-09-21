<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee2Form.aspx.cs" Inherits="ServerSideStateManagement.Employee2Form" %>

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
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style3" ForeColor="#3333FF" Text="Employee 2 Form"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Name"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtEmp2Name" runat="server" CssClass="auto-style3"></asp:TextBox>
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
                    <asp:TextBox ID="txtEmp2Designation" runat="server" CssClass="auto-style3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label5" runat="server" CssClass="auto-style3" Text="Branch"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmp2Branch" runat="server" CssClass="auto-style3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
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
