<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomValidator.aspx.cs" Inherits="ASPValidationControls.CustomValidator" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<script>

        function checkNumber(source,args) {

            if (args.Value % 2 == 0)

                args.IsValid = true;

            else

                args.IsValid = false;

        }
 
    </script>
 
    <style type="text/css">

        .auto-style1 {

            width: 100%;

        }

        .auto-style2 {

            text-align: center;

            color: #0000CC;

        }

        .auto-style3 {

            font-size: xx-large;

        }
</style>
</head>
<body style="font-size: xx-large">
<form id="form1" runat="server">
<div class="auto-style2">
<strong>Custom Validator Demo</strong></div>
<table class="auto-style1">
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>Enter a number</td>
<td>
<asp:TextBox ID="txtNumber" runat="server" CssClass="auto-style3" Height="42px"></asp:TextBox>
</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="checkNumber" ControlToValidate="txtNumber" ErrorMessage="Invalid number" ForeColor="Red"></asp:CustomValidator>
</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
<asp:Button ID="btnSubmit" runat="server" CssClass="auto-style3" Text="Submit" OnClick="btnSubmit_Click" />
</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
<asp:Label ID="lblMessage" runat="server" Text="---"></asp:Label>
</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
</table>
</form>
</body>
</html>

 