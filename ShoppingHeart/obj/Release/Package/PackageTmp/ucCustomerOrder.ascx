<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerOrder.ascx.cs" Inherits="ShoppingHeart.ucCustomerOrder" %>
<style type="text/css">
    .styleOrderDetails {
        width: 800px;
        border: 1px ridge red;
        align-items: center;
        align-content: center;
    }
</style>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <div style="vertical-align: middle; text-align: center">
            <asp:Label ID="lblTransactionNo" runat="server" Style="font-weight: 700" Text="TransactionsNo"></asp:Label>
            <asp:TextBox ID="txtTransactionNo" runat="server" Width="90px"></asp:TextBox>
            <asp:Button ID="btnGo" runat="server" Text="Go" Style="font-weight: 700" Width="122px" OnClick="btnGo_Click" />
            &nbsp;
        </div>
        <table align="center" cellspacing="1" style="width: 100%; background-color: #ffffff;">
            <tr>
                <td align="center">
                    <hr />
                    <asp:RadioButtonList ID="rblOrderDetails" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                        OnSelectedIndexChanged="rblOrderDetails_SelectedIndexChanged">

                        <asp:ListItem Selected="True" Value="1">CustomerDetails</asp:ListItem>
                        <asp:ListItem Value="2">ProductDetails</asp:ListItem>
                        <asp:ListItem Value="3">DeliveryStatus</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="Panel1" runat="server">
                        <table class="styleOrderDetails">
                            <tr>
                                <td align="center" style="text-align: center" colspan="2">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/customerdetails.png" Height="150px" />
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;">Name :
                                </td>
                                <td align="left" style="width: 50%;">
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;">EmailId :</td>
                                <td align="left" style="width: 50%;">
                                    <asp:Label ID="lblCustomerEmailId" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;">PhoneNo :</td>
                                <td align="left" style="width: 50%;">
                                    <asp:Label ID="lblCustomerPhoneNo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;">TotalProducts :</td>
                                <td align="left" style="width: 50%;">
                                    <asp:Label ID="lblTotalProducts" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;">TotalPrice :</td>
                                <td align="left" style="width: 50%;">
                                    <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;" valign="top">Address :</td>
                                <td align="left" style="width: 50%;">
                                    <asp:TextBox ID="txtCutomerAddress" runat="server" Height="73px" ReadOnly="true"
                                        TextMode="MultiLine" Width="386px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%; padding-right: 30px;" valign="top">Payment Methods :</td>
                                <td align="left" style="width: 50%;">
                                    <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 50%;">&nbsp;</td>
                                <td align="left" style="width: 50%;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 50%;">&nbsp;</td>
                                <td align="left" style="width: 50%;">&nbsp;</td>
                            </tr>

                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table class="styleOrderDetails">
                            <tr>
                                <td align="center" style="text-align: center" class="auto-style1">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/CUSSSSS.png" Height="150px" />
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:DataList ID="dlProducts" runat="server" RepeatColumns="3" Width="500px" Font-Bold="False"
                                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Visible="True">
                                        <ItemTemplate>
                                            <div align="center">
                                                <table cellspacing="1" class="style4" style="border: 1px ridge #9900FF">
                                                    <tr>
                                                        <td style="border-bottom-style: ridge; border-width: 1px; border-color: #000000" colspan="2">
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' Style="font-weight: 700"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <img alt="" src='<%# Eval("ImageUrl") %>' runat="server" id="imgProductPhoto" style="border: ridge 1px black; width: 173px; height: 160px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Quantity:<asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("ProductQuantity") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server">
                        <table class="styleOrderDetails">
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/orange-delivery-512.png" Height="150px" />
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gvOrderStatus" runat="server"
                                        BorderColor="#cccccc" BackColor="White" BorderStyle="Ridge" BorderWidth="1px"
                                        CellPadding="4" ForeColor="black" GridLines="Horizontal"
                                        Width="100%">

                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:TextBox ID="txtStatus" runat="server" Width="300px"></asp:TextBox>
                                    &nbsp; 
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" Style="font-weight: 700"
                                        Width="100px" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server">
                        <table class="styleOrderDetails">
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/unhappy.png" Height="245px" Width="315px" />
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>

