using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingHeart
{
    public partial class TrackYourOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                string TransactionNo = Request.QueryString["Id"];
                ucCustomerOrder1.TransactionNoText = TransactionNo;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Session["ShoppingHeartAdmin"])))
            {
                ucCustomerOrder1.IsAuthorizedToAddStatus = true;

            }
            else
            {
                ucCustomerOrder1.IsAuthorizedToAddStatus = false;

            }

        }
    }
}