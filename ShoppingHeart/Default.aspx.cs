using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

namespace ShoppingHeart
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //when is the first time opening the home page..
        {
            if (!IsPostBack) //if the page is rendered for the first time or not 
            {
                lblCategoryName.Text = "Popular Products At Electronic Shopping Cart";
                GetCategory();
                GetProducts(0);//Get All Products


            }
            lblAvailableStockAlert.Text = string.Empty;

        }
        private void GetCategory() //making an instace of shoppingcart class and bind some data to the interface 
        {
            ShoppingCart k = new ShoppingCart();
            dlCategories.DataSource = null;
            dlCategories.DataSource = k.GetAllCategories();
            dlCategories.DataBind();

        }
        private void GetProducts(int CategoryID) //instace of shoppingcart class and binding products data using categoryID 
        {
            ShoppingCart k = new ShoppingCart()
            {
                CategoryID = CategoryID
            };
            dlProducts.DataSource = null;
            dlProducts.DataSource = k.GetAllProducts();
            dlProducts.DataBind();
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString(); //convert productID to INT
            string ProductQuantity = "1"; //by default product quantity is 1 for each click

            DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;

            if(Session["MyCart"] != null) //when the cart have some products 
            {
                DataTable dt = (DataTable)Session["MyCart"];
                var checkProduct = dt.AsEnumerable().Where(r => r.Field<string>("ProductID") == ProductID); //add products by productID
                if(checkProduct.Count() == 0)
                {
                    string query = "select * from Products where ProductID = " + ProductID + "";
                    DataTable dtProducts = GetData(query);

                    DataRow dr = dt.NewRow(); //load all details of a product from the table database
                    dr["ProductID"] = ProductID;
                    dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                    dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                    dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                    dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                    dr["ProductQuantity"] = ProductQuantity;
                    dr["AvailableStock"] = lblAvailableStock.Text;

                    dt.Rows.Add(dr);

                    Session["MyCart"] = dt;
                    btnShoppingHeart.Text = dt.Rows.Count.ToString();

                }

            }
            else //when the cart is empty
            {
                string query = "select * from Products where ProductID = " + ProductID + "";
                DataTable dtProducts = GetData(query);

                DataTable dt = new DataTable();

                dt.Columns.Add("ProductID", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Price", typeof(string));
                dt.Columns.Add("ImageUrl", typeof(string));
                dt.Columns.Add("ProductQuantity", typeof(string));
                dt.Columns.Add("AvailableStock", typeof(string));

                DataRow dr = dt.NewRow();
                dr["ProductID"] = ProductID;
                dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                dr["ProductQuantity"] = ProductQuantity;
                dr["AvailableStock"] = lblAvailableStock.Text;

                dt.Rows.Add(dr);

                Session["MyCart"] = dt;
                btnShoppingHeart.Text = dt.Rows.Count.ToString();
            }
            HighlightCartProducts();
        } //add to cart button to add this product to my cart 
        private void HighlightCartProducts() //this will highlight and make some changes on the product after select or click on it 
        {
            if (Session["MyCart"] != null)
            {
                DataTable dtProductsAddedToCart = (DataTable)Session["MyCart"];
                if(dtProductsAddedToCart.Rows.Count > 0)
                {
                    foreach(DataListItem item in dlProducts.Items)
                    {
                        HiddenField hfProductID = item.FindControl("hfProductID") as HiddenField;
                        if (dtProductsAddedToCart.AsEnumerable().Any(row => hfProductID.Value == row.Field<String>("ProductID")))
                        {

                            Button btnAddToCart = item.FindControl("btnAddToCart") as Button;
                            btnAddToCart.BackColor = System.Drawing.Color.CornflowerBlue;
                            btnAddToCart.Text = "Added To Cart";

                            Image imgGreenStar = item.FindControl("imgStar") as Image;
                            imgGreenStar.Visible = true;

                            
                        }
                    }
                }
                
            }
        }
        protected void lbtnCategory_Click(object sender, EventArgs e) //filtering the products by its categories and controling the panels
        {
            pnlMyCart.Visible = false;
            pnlProducts.Visible = true;
            int CategoryID = Convert.ToInt16((((LinkButton)sender).CommandArgument));
            GetProducts(CategoryID); //calling the products from database by its categoryID clicked 
            HighlightCartProducts();

        }
        protected void lblLogo_Click(object sender, EventArgs e) //to go back to homepage and set everthing to default mode when click on the name of website 
        {
            lblCategoryName.Text = "Popular Products At Electronic Shopping Cart";
            lblProducts.Text = "Products";
            pnlCategories.Visible =true;
            pnlCheckOut.Visible = false;
            pnlEmptyCart.Visible =false ;
            pnlMyCart.Visible =false;
            pnlOrderPlacedSuccessfully.Visible =false;
            pnlProducts.Visible =true;

            GetProducts(0);
            HighlightCartProducts();

        }
        protected void btnShoppingHeart_Click(object sender, EventArgs e) //clicking on number to checkout for products to mycart 
        {
            GetMyCart();
            lblCategoryName.Text = "Products In Your Shopping Cart";
            lblProducts.Text = "Customer Details";

            //pnlCheckOut.Visible = true;
            //pnlMyCart.Visible = true;
            //pnlCategories.Visible = false;
            //pnlProducts.Visible = false;


        }
        public DataTable GetData(string query) //this method for getting data and making connection with database and sending aQuery and recive a data 
        {
            DataTable dt = new DataTable();
            string Conn = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection con = new SqlConnection(Conn);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query , con);
            da.Fill(dt);

            con.Close();
            return dt;


        }
        protected void btnRemoveFromCart_Click(object sender, EventArgs e) //remove product from my cart 
        {
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];

                DataRow drr = dt.Select("ProductID=" + ProductID + " ").FirstOrDefault();

                if(drr != null)
                {
                    dt.Rows.Remove(drr);
                    Session["MyCart"] = dt;
                }
                GetMyCart();
            }
        }
        protected void btnPlaceOrder_Click(object sender, EventArgs e) //will take all the cutomer info and regiter his/her products by his info and storing it to the database
        {
            string productids = string.Empty;
            DataTable dt;
            if (Session["MyCart"] != null)
            {
                dt = (DataTable)Session["MyCart"];

                ShoppingCart k = new ShoppingCart()
                {
                    CustomerName = txtCustomerName.Text,
                    CustomerEmailID = txtCustomerEmailID.Text,
                    CustomerAddress = txtCustomerAddress.Text,
                    CustomerPhoneNo = txtCustomerPhoneNo.Text,
                    TotalProducts = Convert.ToInt32(txtTotalProducts.Text),
                    TotalPrice = Convert.ToInt32(txtTotalPrice.Text),
                    ProductList = productids,
                    PaymentMethod = rblPaymentMethod.SelectedItem.Text
               
                };
                DataTable dtResult = k.SaveCustomerDetails();

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    ShoppingCart SaveProducts = new ShoppingCart()
                    {
                        CustomerID = Convert.ToInt32(dtResult.Rows[0][0]),

                        ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]),

                        TotalProducts = Convert.ToInt32(dt.Rows[i]["ProductQuantity"])

                    };
                     SaveProducts.SaveCustomerProducts();
                }


                Session.Clear();
                GetMyCart();

                lblTransactionNo.Text = "Your Transaction No : " + dtResult.Rows[0][0];

                pnlCategories.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = false;
                pnlMyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = true;
                pnlProducts.Visible = false;

                

                txtCustomerName.Text = string.Empty;
                txtCustomerEmailID.Text = string.Empty;
                txtCustomerAddress.Text = string.Empty;
                txtCustomerPhoneNo.Text = string.Empty;
                txtTotalProducts.Text = "0";
                txtTotalPrice.Text = "0";

            }
        }
        private void GetMyCart() //getting  data of my cart method and setting some visiblity for the interface 
        {
            DataTable dtProducts;
            if(Session["MyCart"] != null)
            {
                dtProducts = (DataTable)Session["MyCart"];

            }
            else
            {
                dtProducts = new DataTable();
            }
            if(dtProducts.Rows.Count > 0)
            {
                txtTotalProducts.Text = dtProducts.Rows.Count.ToString();
                btnShoppingHeart.Text = dtProducts.Rows.Count.ToString();
                dlCartsProducts.DataSource = dtProducts;
                dlCartsProducts.DataBind();
                  UpdateTotalBill();

                pnlCategories.Visible = false;
                pnlCheckOut.Visible = true;
                pnlEmptyCart.Visible = false;
                pnlMyCart.Visible = true;
                pnlOrderPlacedSuccessfully.Visible = false;
                pnlProducts.Visible = false;
                
            }
            else
            {
                pnlCategories.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = true;
                pnlMyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;
                pnlProducts.Visible = false;

                txtTotalProducts.Text = "0";
                txtTotalPrice.Text = "0";
                btnShoppingHeart.Text = "0";
                dlCartsProducts.DataSource = null;
                dlCartsProducts.DataBind();
            }

        }
        private void UpdateTotalBill() //some calculation to show the total amount of what cost of these product for ex
        {
            long TotalPrice = 0;
            long TotalProducts = 0;
            foreach(DataListItem item in dlCartsProducts.Items)
            {
                Label PriceLable = item.FindControl("lblPrice") as Label;
                TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox;
                long ProductPrice = Convert.ToInt64(PriceLable.Text) * Convert.ToInt64(ProductQuantity.Text);
                TotalPrice = TotalPrice + ProductPrice;
                TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);

            }
            txtTotalPrice.Text = Convert.ToString(TotalPrice);
            txtTotalProducts.Text = Convert.ToString(TotalProducts);
        
        }
        protected void txtProductQuantity_TextChanged(object sender, EventArgs e) //updating on the number of product quantity as its available in the warehouse 
        {
            TextBox txtQuantity = (sender as TextBox);

            DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;
            HiddenField ProductID = currentItem.FindControl("hfProductID") as HiddenField;

            if (txtQuantity.Text == string.Empty || txtQuantity.Text == "0"|| txtQuantity.Text == "1")
            {
                txtQuantity.Text = "1";
            }
            else
            {
                if(Session["MyCart"] != null)
                {
                    if(Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(lblAvailableStock))
                    {
                        DataTable dt = (DataTable)Session["MyCart"];

                        DataRow[] rows = dt.Select("ProductID='" + ProductID.Value + "'");
                        int index = dt.Rows.IndexOf(rows[0]);

                        dt.Rows[index]["ProductQuantity"] = txtQuantity.Text;

                        Session["MyCart"] = dt;

                    }
                    else
                    {
                        lblAvailableStockAlert.Text = "Alert Product Buyout Should Not Be More than Available Stock!!";
                        txtQuantity.Text = "1";

                    }
                }

            }
            UpdateTotalBill();


        }
        private string PopulateOrderEmailBody(string customerName , string transactionNo) //this for sending email to customer feature we will work on it later 
         {
            string body = string.Empty;
            using(StreamReader reader = new StreamReader(Server.MapPath("~/OrderTamplate.html")))
            {
                body = reader.ReadToEnd();

            }
            body = body.Replace("{CustomerName}",customerName);
            body = body.Replace("{OrderNo}", transactionNo);
            body = body.Replace("{TransactionURL}", "http://www.ShoppingHeart.com/TrackYourOrder.aspx?Id=" + transactionNo);

            return body; 
         }
        private void SendOrderPlacedAlert(string CustomerName ,string CustomerEmailID ,string TransactionNo)
        {
            string body = this.PopulateOrderEmailBody(CustomerName, TransactionNo);

            EmailEngine.SendEmail(CustomerEmailID, "Electronic Shopping Cart -- Your Order Details ", body);

        }
    }
}