<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Address1.aspx.cs" Inherits="ServerSideStateManagement.Address1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 412px;
        }
        .auto-style4 {
            height: 23px;
            width: 412px;
        }
        .auto-style5 {
            font-size: x-large;
            font-weight: 700;
            text-align: left;
        }
        .auto-style6 {
            width: 412px;
            font-size: x-large;
        }
        .auto-style7 {
            height: 23px;
            font-size: x-large;
        }
        .auto-style8 {
            width: 412px;
            height: 62px;
        }
        .auto-style9 {
            height: 62px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5"><strong>
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style5" ForeColor="Blue" Text="Address Demo"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style6"><strong></strong></td>
                <td class="auto-style5"><strong></strong></td>
            </tr>
            <tr>
                <td class="auto-style3"><strong>
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style5" Text="User Name"></asp:Label>
                    </strong></td>
                <td><strong>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="auto-style5"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style7"><strong></strong></td>
            </tr>
            <tr>
                <td class="auto-style8"><strong>
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style5" Text="House Number"></asp:Label>
                    </strong></td>
                <td class="auto-style9"><strong>
                    <textarea id="txtHouseNumber" runat="server" class="auto-style5" cols="20" name="S1" rows="2"></textarea></strong></td>
            </tr>
            <tr>
                <td class="auto-style6"><strong></strong></td>
                <td class="auto-style5"><strong></strong></td>
            </tr>
            <tr>
                <td class="auto-style4"><strong>
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="Street Name"></asp:Label>
                    </strong></td>
                <td class="auto-style2"><strong>
                    <asp:TextBox ID="txtStreetName" runat="server" CssClass="auto-style5"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style6"><strong></strong></td>
                <td class="auto-style5"><strong></strong></td>
            </tr>
            <tr>
                <td class="auto-style6"><strong></strong></td>
                <td><strong>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style5" OnClick="btnSubmit_Click" Text="Submit" />
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style6"><strong></strong></td>
                <td class="auto-style5"><strong></strong></td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
