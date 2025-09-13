<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="EmployeeRegistrationPortal.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function CheckPasswordStrength(password) {
            var strengthLabel = document.getElementById('<%= lblPasswordStrength.ClientID %>');
            var strength = "Weak";

            if (password.length === 0) {
                strengthLabel.innerText = "";
                return;
            }

            
            var mediumRegex = new RegExp("^(?=.*[A-Za-z])(?=.*\\d).{6,}$"); 
            var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*]).{8,}$"); 

            if (strongRegex.test(password)) {
                strength = "Strong";
                strengthLabel.style.color = "green";
            }
            else if (mediumRegex.test(password)) {
                strength = "Medium";
                strengthLabel.style.color = "orange";
            }
            else {
                strength = "Weak";
                strengthLabel.style.color = "red";
            }
            strengthLabel.innerText = "Strength: " + strength;
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 411px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style11 {
            width: 411px;
            height: 29px;
        }
        .auto-style12 {
            height: 29px;
        }
        .auto-style10 {
            width: 411px;
            font-weight: bold;
            text-align: center;
        }
        .auto-style7 {
            font-size: x-large;
        }
        .auto-style5 {
            width: 411px;
            height: 24px;
            text-align: center;
        }
        .auto-style6 {
            height: 24px;
        }
        .auto-style8 {
            width: 411px;
            height: 70px;
            font-weight: bold;
            text-align: center;
        }
        .auto-style9 {
            height: 70px;
        }
        .auto-style16 {
            height: 31px;
        }
        .auto-style2 {
            width: 411px;
        }
        .auto-style17 {
            width: 411px;
            height: 31px;
        }
        .auto-style18 {
            width: 411px;
            font-weight: bold;
            text-align: center;
            height: 43px;
        }
        .auto-style19 {
            height: 43px;
        }
    </style>
</head>
<body style="font-size: x-large">
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" ForeColor="Blue" style="font-weight: 700" Text="User Details"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label2" runat="server" Text="User ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserId" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserId" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="auto-style7" onkeyup="CheckPasswordStrength(this.value)"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
    ErrorMessage="Password does not meet criteria" ControlToValidate="txtPassword" 
    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
<br />
<asp:Label ID="lblPasswordStrength" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
<br />

                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Confirm Password must be same as Password" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="#CC0000"></asp:CompareValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" style="font-size: x-large" Text="Submit" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="All fields are required" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
