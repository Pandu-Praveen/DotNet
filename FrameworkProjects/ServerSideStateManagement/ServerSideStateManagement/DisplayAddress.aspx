<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayAddress.aspx.cs" Inherits="ServerSideStateManagement.DisplayAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 352px;
        }
        .auto-style5 {
            font-size: x-large;
            font-weight: 700;
            text-align: left;
        }
        .auto-style6 {
            width: 352px;
            font-size: x-large;
        }
        .auto-style4 {
            height: 23px;
            width: 352px;
        }
        .auto-style7 {
            height: 23px;
            font-size: x-large;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5"><strong>
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style5" ForeColor="Blue" Text="Address Details"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"><strong>
                    <asp:Label ID="Label5" runat="server" CssClass="auto-style5" Text="User Name"></asp:Label>
                    </strong></td>
                <td class="auto-style5"><strong>
                    <asp:Label ID="lblUserName" runat="server" CssClass="auto-style5"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style3"><strong>
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style5" Text="House Number"></asp:Label>
                    </strong></td>
                <td><strong>
                    <asp:Label ID="lblHouseNumber" runat="server" CssClass="auto-style5"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style4"><strong>
                    <asp:Label ID="Label6" runat="server" CssClass="auto-style5" Text="Street Name"></asp:Label>
                    </strong></td>
                <td class="auto-style7"><strong>
                    <asp:Label ID="lblStreetName" runat="server" CssClass="auto-style5"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style6"><strong>
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style5" Text="City Name"></asp:Label>
                    </strong></td>
                <td class="auto-style5"><strong>
                    <asp:Label ID="lblCityName" runat="server" CssClass="auto-style5"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style4"><strong>
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="PIN Code"></asp:Label>
                    </strong></td>
                <td class="auto-style2"><strong>
                    <asp:Label ID="lblPinCode" runat="server" CssClass="auto-style5"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
