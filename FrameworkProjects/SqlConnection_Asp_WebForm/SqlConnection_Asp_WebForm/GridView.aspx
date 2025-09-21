<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="SqlConnection_Asp_WebForm.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 504px;
        }
        .auto-style3 {
            width: 504px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 504px;
            font-weight: bold;
        }
        .auto-style6 {
            font-weight: bold;
            font-size: x-large;
        }
        .auto-style7 {
            width: 504px;
            font-weight: bold;
            font-size: x-large;
        }
        .auto-style8 {
            font-size: x-large;
            font-weight: 700;
        }
        .auto-style9 {
            width: 504px;
            font-weight: bold;
            font-size: x-large;
            height: 30px;
        }
        .auto-style10 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style8" ForeColor="#3366FF" Text="Automatically Loading Data into GridView"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style8" ForeColor="#3366FF" Text="Programmatically Loading Data into GridView"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnShow" runat="server" CssClass="auto-style6" OnClick="btnShow_Click" Text="Show Data" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="accNo" DataSourceID="SqlDataSource1" PageSize="5" Width="416px">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="accNo" HeaderText="accNo" ReadOnly="True" SortExpression="accNo" />
                            <asp:BoundField DataField="customerName" HeaderText="customerName" SortExpression="customerName" />
                            <asp:BoundField DataField="accPin" HeaderText="accPin" SortExpression="accPin" />
                            <asp:BoundField DataField="accBalance" HeaderText="accBalance" SortExpression="accBalance" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myencoraConnectionString %>" DeleteCommand="DELETE FROM [customers] WHERE [accNo] = @accNo" InsertCommand="INSERT INTO [customers] ([accNo], [customerName], [accPin], [accBalance]) VALUES (@accNo, @customerName, @accPin, @accBalance)" SelectCommand="SELECT * FROM [customers]" UpdateCommand="UPDATE [customers] SET [customerName] = @customerName, [accPin] = @accPin, [accBalance] = @accBalance WHERE [accNo] = @accNo">
                        <DeleteParameters>
                            <asp:Parameter Name="accNo" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="accNo" Type="Int32" />
                            <asp:Parameter Name="customerName" Type="String" />
                            <asp:Parameter Name="accPin" Type="Int32" />
                            <asp:Parameter Name="accBalance" Type="Decimal" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="customerName" Type="String" />
                            <asp:Parameter Name="accPin" Type="Int32" />
                            <asp:Parameter Name="accBalance" Type="Decimal" />
                            <asp:Parameter Name="accNo" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="182px" Width="469px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
