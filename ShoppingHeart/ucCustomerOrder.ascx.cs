using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BusinessLayer;
using System.Data;

namespace ShoppingHeart
{
    public partial class ucCustomerOrder : System.Web.UI.UserControl
    {
        public bool CanIUpdateStatus;
        
        public string TransactionNoText
        {
            get { return txtTransactionNo.Text; }
            set { txtTransactionNo.Text = value; }
        }
        public bool IsAuthorizedToAddStatus
        {
            set { CanIUpdateStatus = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(txtTransactionNo.Text != string.Empty)
                {
                    ShowOrderDetails(rblOrderDetails.SelectedValue, Convert.ToInt32(txtTransactionNo.Text));
                }
                else
                {
                    rblOrderDetails.Visible = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;

                }
            }
        }
        protected void rblOrderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtTransactionNo.Text != string.Empty)
            {
                ShowOrderDetails(rblOrderDetails.SelectedValue, Convert.ToInt32(txtTransactionNo.Text.Trim()));
            }
        }
        private void ShowOrderDetails(string PanelId, int OrderNo)
        {
            rblOrderDetails.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;

            if (IsOrderNoValid(OrderNo))
            {
                rblOrderDetails.Visible = true;
                if(PanelId == "1")
                {
                    ShoppingCart k = new ShoppingCart
                    {
                        Flag = OrderNo
                    };
                    DataTable dtCustomerDetails = k.GetOrdersList();

                    if(dtCustomerDetails.Rows.Count > 0)
                    {
                        Panel1.Visible = true;
                        lblCustomerName.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerName"]);
                        lblCustomerPhoneNo.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerPhoneNo"]);
                        lblCustomerEmailId.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerEmailId"]);
                        lblTotalPrice.Text = Convert.ToString(dtCustomerDetails.Rows[0]["TotalPrice"]);
                        lblTotalProducts.Text = Convert.ToString(dtCustomerDetails.Rows[0]["TotalProducts"]);
                        txtCutomerAddress.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerAddress"]);
                        lblPaymentMethod.Text = Convert.ToString(dtCustomerDetails.Rows[0]["PaymentMethod"]);

                    }
                }
                if (PanelId == "2")
                {
                    Panel2.Visible = true;

                    ShoppingCart k = new ShoppingCart()
                    {
                        Flag = OrderNo
                    };
                    dlProducts.DataSource = k.GetTransactionDetails();
                    dlProducts.DataBind();

                }
                if (PanelId == "3")
                {
                    Panel3.Visible = true;
                    txtStatus.Visible = CanIUpdateStatus;
                    btnAdd.Visible = CanIUpdateStatus;
                    GetSetOrderStatus(0);
                }

            }
            else
            {
                Panel4.Visible = true;
            }
        }
        private bool IsOrderNoValid(int OrderNo)
        {
            ShoppingCart k = new ShoppingCart
            {
                Flag = OrderNo

            };
            DataTable dtCustomerDetails = k.GetOrdersList();

            if(dtCustomerDetails.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            if(txtTransactionNo.Text != string.Empty)
            {
                rblOrderDetails.Visible = true;
                ShowOrderDetails(rblOrderDetails.SelectedValue, Convert.ToInt32(txtTransactionNo.Text));
            }
            else
            {
                rblOrderDetails.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            GetSetOrderStatus(1);
        }
        private void GetSetOrderStatus(int Flag)
        {
            ShoppingCart k = new ShoppingCart
            {
                OrderStatus = txtStatus.Text,
                OrderNo = txtTransactionNo.Text,
                Flag = Flag

            };
            DataTable dt = k.GetSetOrderStatus();

            gvOrderStatus.DataSource = dt;
            gvOrderStatus.DataBind();
            txtStatus.Text = string.Empty;

        }
    }
}