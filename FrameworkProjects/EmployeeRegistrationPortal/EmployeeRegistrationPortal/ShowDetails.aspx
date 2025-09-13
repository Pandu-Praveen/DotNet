<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="EmployeeRegistrationPortal.ShowDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            width: 195px;
            height: 24px;
        }
        .auto-style8 {
            height: 23px;
            width: 168px;
        }
        .auto-style10 {
            width: 411px;
            font-weight: bold;
            text-align: center;
        }
        .auto-style13 {
            width: 411px;
            font-weight: bold;
            text-align: center;
            height: 43px;
        }
        .auto-style15 {
            width: 411px;
            font-weight: bold;
            text-align: center;
            height: 31px;
        }
        .auto-style16 {
            width: 272px;
            text-align: right;
            height: 24px;
        }
        .auto-style17 {
            height: 23px;
            width: 272px;
            text-align: right;
        }
        .auto-style18 {
            width: 272px;
            font-weight: bold;
            text-align: right;
        }
        .auto-style19 {
            width: 272px;
            font-weight: bold;
            text-align: right;
            height: 43px;
        }
        .auto-style20 {
            width: 272px;
            font-weight: bold;
            text-align: right;
            height: 31px;
        }
        .auto-style21 {
            width: 302px;
            height: 2px;
        }
        .auto-style22 {
            width: 304px;
            font-weight: bold;
            text-align: center;
        }
        .auto-style23 {
            width: 304px;
            height: 24px;
        }
        .auto-style24 {
            height: 23px;
            width: 304px;
            text-align: center;
        }
        .auto-style25 {
            width: 304px;
            font-weight: bold;
            text-align: center;
            height: 43px;
        }
        .auto-style26 {
            width: 304px;
            font-weight: bold;
            text-align: center;
            height: 31px;
        }
        .auto-style27 {
            width: 272px;
            font-weight: bold;
            text-align: right;
            height: 24px;
        }
        .auto-style28 {
            width: 304px;
            font-weight: bold;
            text-align: center;
            height: 24px;
        }
        .auto-style29 {
            width: 411px;
            font-weight: bold;
            text-align: center;
            height: 24px;
        }
        .auto-style30 {
            width: 253px;
            font-weight: bold;
            text-align: center;
        }
        .auto-style31 {
            width: 253px;
            height: 24px;
        }
        .auto-style32 {
            width: 253px;
            font-weight: bold;
            text-align: center;
            height: 24px;
        }
        .auto-style33 {
            height: 23px;
            width: 253px;
        }
        .auto-style34 {
            width: 253px;
            font-weight: bold;
            text-align: center;
            height: 43px;
        }
        .auto-style35 {
            width: 253px;
            font-weight: bold;
            text-align: center;
            height: 31px;
        }
        .auto-style36 {
            width: 272px;
            font-weight: bold;
            text-align: right;
            height: 44px;
        }
        .auto-style37 {
            width: 304px;
            font-weight: bold;
            text-align: center;
            height: 44px;
        }
        .auto-style38 {
            width: 253px;
            font-weight: bold;
            text-align: center;
            height: 44px;
        }
        .auto-style39 {
            width: 411px;
            font-weight: bold;
            text-align: center;
            height: 44px;
        }
    </style>
</head>
<body style="font-size: large">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style21"></td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style36">
                    <asp:Label ID="Label12" runat="server" Text="Employee Details" ForeColor="#3333FF" style="text-align: center"></asp:Label>
                </td>
                <td class="auto-style37">
                    <br />
                </td>
                <td class="auto-style38">
                    <asp:Label ID="Label13" runat="server" Text="User Details" ForeColor="#3333FF"></asp:Label>
                </td>
                <td class="auto-style39">
                </td>
            </tr>
            <tr>
                <td class="auto-style27">
                    &nbsp;</td>
                <td class="auto-style28">
                    &nbsp;</td>
                <td class="auto-style32">
                    &nbsp;</td>
                <td class="auto-style29">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style27">
                    <asp:Label ID="Label11" runat="server" Text="Employee ID"></asp:Label>
                </td>
                <td class="auto-style28">
                    <asp:Label ID="dspEmpId" runat="server"></asp:Label>
                </td>
                <td class="auto-style32">
                    <asp:Label ID="Label2" runat="server" Text="User ID"></asp:Label>
                </td>
                <td class="auto-style29">
                    <asp:Label ID="dspUserId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style23"></td>
                <td class="auto-style31"></td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="dspEmpName" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">
                    <asp:Label ID="Label14" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="dspUserName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
                <td class="auto-style28"></td>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style29"></td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label4" runat="server" Text="Department"></asp:Label>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="dspEmpDept" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">
                    <asp:Label ID="Label15" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="dspUserPassword" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
                <td class="auto-style28"></td>
                <td class="auto-style32"></td>
                <td class="auto-style29"></td>
            </tr>
            <tr>
                <td class="auto-style17">
                    <asp:Label ID="Label5" runat="server" Text="Age" style="font-weight: 700"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:Label ID="dspEmpAge" runat="server" style="font-weight: 700"></asp:Label>
                </td>
                <td class="auto-style33">
                </td>
                <td class="auto-style8">
                </td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="dspEmpAddress" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                </td>
                <td class="auto-style25">
                    <asp:Label ID="dspEmpCity" runat="server"></asp:Label>
                </td>
                <td class="auto-style34">
                    &nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label8" runat="server" Text="PIN Code"></asp:Label>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="dspEmpPin" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style26">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label9" runat="server" Text="Mobile Number"></asp:Label>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="dspEmpMobileNumber" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label10" runat="server" Text="Email ID"></asp:Label>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="dspEmpEmailId" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
