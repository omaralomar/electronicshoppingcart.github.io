<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoppingHeart.Default" %>

<!DOCTYPE html  >
<html xmlns="http://www.w3.org/1999/xhtml" runat="server">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>

</head>
<body>
    <div>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <main role="main">

                        <!-- Image and text -->
                        <nav class="navbar navbar-light bg-light container">
                            <img src="Images/shopping_icon.svg" width="30" height="30" class="d-inline-block align-top" alt="">
                            <asp:LinkButton ID="lblLogo" runat="server" Text="Electronic Shopping Cart" Font-Names="Patua One" Font-Size="25pt"
                                ForeColor="#343A40" OnClick="lblLogo_Click"></asp:LinkButton>
                            <asp:Image ID="Image6" Height="67px" Width="282px" ImageUrl="~/Images/OShopping_2015.png" runat="server" />
                            <div>
                                <asp:Image ID="Image2" Height="53px" Width="70px" ImageUrl="~/Images/ssssss.png" runat="server" />
                                <asp:LinkButton ID="btnShoppingHeart" runat="server" Font-Underline="False"
                                    Font-Size="20pt" Style="font-weight: bold" ForeColor="#343A40" OnClick="btnShoppingHeart_Click">0
                                </asp:LinkButton>
                                <label style="font-size: 15pt; font-weight: bold; color: #343A40">Check Out </label>
                            </div>
                        </nav>
                        <!-- Upper NavBar -->

                        <!-- Navbar content -->
                        <div class=" navbar navbar-dark bg-dark container">

                            <div class="col-sm-9">
                                <asp:Label ID="lblCategoryName" runat="server" Font-Size="15pt" ForeColor="white"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblProducts" runat="server" Text="Products" Font-Size="15pt" ForeColor="white"></asp:Label>
                            </div>

                        </div>
                        <div class="container">
                            <!-- Content here -->
                            <div class="row">
                                <div class="col-sm-9">
                                    <!--  PNL PRODUCT -->
                                    <asp:Panel ID="pnlProducts" runat="server" ScrollBars="Auto">
                                        <asp:DataList ID="dlProducts" runat="server" RepeatColumns="3">
                                            <ItemTemplate>

                                                <div class="card" style="width: 260px; height: 310px">
                                                    <img class="card-img-top justify-content-center" style="width: 200px; height: 170px;" alt="Card image cap" src='<%# Bind("ImageUrl") %>' runat="server" id="imgProductPhoto" />
                                                    <div class="card-body justify-content-center align-content-start align-content-sm-start">
                                                        <h5 class="card-title">
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></h5>
                                                        <p class="card-text">
                                                            Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                                            *
                                        <asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>'
                                            ToolTip="Available Stock" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                            <asp:Image ID="imgStar" runat="server" Visible="false" ImageUrl="~/Images/green-star-icon.png" BorderStyle="None" Height="20px" Width="20px" />
                                                            <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                        </p>
                                                        <asp:Button class="btn btn-dark" ID="btnAddToCart" runat="server" CommandArgument='<%# Bind("ProductID") %>' OnClick="btnAddToCart_Click"
                                                            Text="Add To Cart" Width="100%" />
                                                    </div>
                                                </div>

                                            </ItemTemplate>
                                        </asp:DataList>
                                    </asp:Panel>
                                </div>
                                <div class="col-sm-3">
                                    <!-- PNL CATEGORIES -->
                                    <div class="row">
                                        <asp:Panel ID="pnlCategories" runat="server">
                                            <asp:DataList ID="dlCategories" runat="server" class="list-group">
                                                <ItemTemplate>
                                                    <asp:LinkButton class="list-group-item list-group-item-action " ID="lbtnCategory" runat="server" OnClick="lbtnCategory_Click" Text='<%# Bind("CategoryName") %>'
                                                        CommandArgument='<%# Bind("CategoryID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </asp:Panel>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="container">
                            <!-- Content here -->
                            <div class="row">
                                <div class="col-sm-9">
                                    <!-- PNL MYCART -->
                                    <asp:Panel ID="pnlMyCart" runat="server" ScrollBars="Auto" Visible="false">
                                        <asp:Label ID="lblAvailableStockAlert" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        <asp:DataList ID="dlCartsProducts" runat="server" RepeatColumns="3">
                                            <ItemTemplate> <!--this the card of each product -->

                                                <div class="card" style="width: 260px; height: 310px">
                                                    <img class="card-img-top" alt="Card image cap" src='<%# Eval("ImageUrl") %>' runat="server" id="imgProductPhoto" style="width: 200px; height: 170px;" />
                                                    <div class="card-body justify-content-center align-content-start align-content-sm-start">
                                                        <h5 class="card-title">
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></h5>
                                                        <p class="card-text">
                                                            AvailableStock<asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>'
                                                                ToolTip="Available Stock" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                            Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                            <asp:TextBox ID="txtProductQuantity" runat="server" Width="10px" Height="10px" MaxLength="1"
                                                                OnTextChanged="txtProductQuantity_TextChanged" AutoPostBack="true" Text='<%# Eval("ProductQuantity") %>'></asp:TextBox>
                                                            <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                        </p>

                                                        <asp:Button class="btn btn-dark" ID="btnRemoveFromCart" runat="server" Text="Remove From Cart" CommandArgument='<%# Eval("ProductID") %>'
                                                            Width="100%" OnClick="btnRemoveFromCart_Click" CausesValidation="false" />
                                                    </div>
                                                </div>

                                            </ItemTemplate>

                                        </asp:DataList>
                                    </asp:Panel>
                                </div>
                                <div class="col-sm-3">
                                    <!-- PNL CHECKOUT -->
                                    <!--this panel contain the customer details -->
                                    <asp:Panel ID="pnlCheckOut" runat="server" Visible="false">
                                        <form>
                                            <div class="form-group" style="text-align: left">
                                                <label>Full Name:</label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerName"
                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtCustomerName" runat="server" class="form-control"></asp:TextBox>


                                                <label>Phone Number:</label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustomerPhoneNo"
                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtCustomerPhoneNo" runat="server" class="form-control" MaxLength="10"></asp:TextBox>


                                                <label>Email address:</label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCustomerEmailID"
                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                                <asp:TextBox ID="txtCustomerEmailID" runat="server" class="form-control"></asp:TextBox>


                                                <label>Address:</label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCustomerAddress"
                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtCustomerAddress" runat="server" Rows="3" class="form-control" Height="81px" TextMode="MultiLine"></asp:TextBox>


                                                <label>Total Products:</label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTotalProducts"
                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtTotalProducts" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>


                                                <label>Total Price:</label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTotalPrice"
                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtTotalPrice" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>


                                                <label>Payment Method:</label>
                                                <div class="custom-control custom-radio">

                                                    <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                                                        <asp:ListItem Value="1" Selected="True">1.Cash On Delivery</asp:ListItem>
                                                        <asp:ListItem Value="2">2.Payment Gateway</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:Button ID="btnPlaceOrder" runat="server" class="btn btn-primary" OnClick="btnPlaceOrder_Click"
                                                        Text="Place Order" />

                                                </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCustomerEmailID"
                                                    ErrorMessage="Please Enter Valid EmailID" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </div>


                                        </form>
                                    </asp:Panel>

                                </div>
                            </div>
                        </div>
                        <div class="container">
                            <!-- PNL EMPTY CART -->
                            <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                                <div style="text-align: center;">
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/empty-shopping.png" Width="500px" />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="container">
                            <!-- PNL ORDER PLACE -->
                            <asp:Panel ID="pnlOrderPlacedSuccessfully" runat="server" Visible="false">
                                <div style="text-align: center;">
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/full-shopping.png" Width="500px" /><br />
                                    <br />
                                    <label>
                                        Order Placed Successfully ... 
                                    </label>
                                    <br />
                                    <br />
                                    Transactions Details Are Sent At EmailID Provided By You .<br />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblTransactionNo" runat="server" Style="font-weight: 700"></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <a href="TrackYourOrder.aspx" target="_blank">Track Your Transaction Details Here</a>
                                    <br />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                        </div>

                    </main>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>

        <!-- FOOTER -->
        <div class="bg-dark" style="height: 400px">
            <nav class="navbar navbar-dark bg-dark justify-content-center">
                <!-- Navbar content -->
                <ul class="nav justify-content-center">
                    <li class="nav-item ">
                        <a class="nav-link active" href="http://www.google.com" style="color: white; font-weight: bold;">Google</a>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="Default.aspx" style="color: white; font-weight: bold;">Home</a>
                    </li>
                    <li class="nav-item ">
                        <!--     <a class="nav-link" href="Admin/Login.aspx" style="color:white; font-weight:bold;">Admin Panel</a> -->
                        <a class="nav-link" href="Admin1.aspx" style="color: white; font-weight: bold;">Admin Panel</a>
                    </li>
                    <li class="nav-item r">
                        <a class="nav-link" href="TrackYourOrder.aspx" style="color: white; font-weight: bold;">Track Your Order Status</a>
                    </li>
                </ul>
            </nav>
        </div>


        <!-- Bootstrap core JavaScript
    ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
        <script src="../../assets/js/vendor/popper.min.js"></script>
        <script src="../../dist/js/bootstrap.min.js"></script>
        <script src="../../assets/js/vendor/holder.min.js"></script>
        <svg xmlns="http://www.w3.org/2000/svg" width="288" height="225" viewBox="0 0 288 225" preserveAspectRatio="none" style="display: none; visibility: hidden; position: absolute; top: -100%; left: -100%;">
            <defs>
                <style type="text/css"></style>
            </defs><text x="0" y="14" style="font-weight: bold; font-size: 14pt; font-family: Arial, Helvetica, Open Sans, sans-serif">Thumbnail</text>
        </svg>

    </div>
</body>
</html>
