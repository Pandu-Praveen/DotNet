<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistrationForm.aspx.cs" Inherits="SqlConnection_Asp_WebForm.StudentRegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        *{
            background-color: beige;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 439px;
            font-weight: bold;
        }
        .auto-style3 {
            width: 439px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            font-size: xx-large;
            font-weight: 700;
            text-align: center;
        }
        .auto-style6 {
            width: 439px;
            font-size: x-large;
            font-weight: bold;
        }
        .auto-style7 {
            font-size: x-large;
            font-weight: bold;
        }
        .auto-style8 {
            width: 439px;
            height: 23px;
            font-weight: bold;
        }
        .auto-style9 {
            width: 439px;
            font-size: x-large;
            font-weight: bold;
            height: 30px;
        }
        .auto-style10 {
            font-size: x-large;
            font-weight: bold;
            height: 30px;
        }
        #TextArea1 {
            height: 58px;
            width: 222px;
        }
        .auto-style11 {
            width: 439px;
            font-weight: bold;
            height: 44px;
        }
        .auto-style12 {
            height: 44px;
        }
        .auto-style13 {
            width: 439px;
            font-weight: bold;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style5" ForeColor="#0099CC" Text="Student Registration Form"></asp:Label>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style5" Text="Name"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtStudentName" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <b>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStudentName" CssClass="auto-style5" ErrorMessage="Name is Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </b></td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="Address"></asp:Label>
                </td>
                <td class="auto-style4">
                    <textarea id="txtStudentAddress" runat="server" cols="20" name="S1" rows="2"></textarea><b><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStudentAddress" CssClass="auto-style5" ErrorMessage="Address is Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </b>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style5" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style7">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label5" runat="server" CssClass="auto-style5" Text="Pin Code"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtStudentPinCode" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <b>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStudentPinCode" CssClass="auto-style5" ErrorMessage="Pin Code is Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStudentPinCode" ValidationExpression="\d{6}" ErrorMessage="Please enter the valid Pin code" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </b>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" CssClass="auto-style5" Text="Mobile Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStudentMobileNumber" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <b>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStudentMobileNumber" CssClass="auto-style5" ErrorMessage="Mobile Number is Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStudentMobileNumber" ValidationExpression="^[6-9][0-9]{9}$" ErrorMessage="Please enter the valid Mobile Number" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </b>
                </td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" CssClass="auto-style5" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStudentEmail" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <b>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStudentEmail" CssClass="auto-style5" ErrorMessage="Email is Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtStudentEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please enter the valid Email" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </b>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style7" OnClick="btnSubmit_Click" Text="Submit" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" Height="42px"   CausesValidation="false"   OnClick="btnClear_Click" style="font-weight: 700; font-size: x-large" Text="Clear" Width="115px" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" style="font-size: x-large; font-weight: 700" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
