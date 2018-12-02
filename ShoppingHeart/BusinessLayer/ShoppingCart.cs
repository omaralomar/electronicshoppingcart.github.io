using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using ShoppingHeart.DataLayer;



namespace ShoppingHeart.BusinessLayer
{
    public class ShoppingCart
    {

        public string CategoryName;
        public int CategoryID;
        public int ProductID;
        public int CustomerID;

        public string ProductName;
        public string ProductImage;
        public string ProductPrice;
        public string ProductDescription;

        public string CustomerName;
        public string CustomerEmailID;
        public string CustomerPhoneNo;
        public string CustomerAddress;
        public string ProductList;
        public string PaymentMethod;

        public string OrderStatus;
        public string OrderNo;

        public int TotalProducts;
        public int TotalPrice;
        public int StockType;
        public int Flag;

        public void AddNewCategory() //for adding categories data to the categories table 
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_AddNewCategory", parameters); 

        }
        public void AddNewProduct()//for adding products data to the categories table 
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameters[1] = DataLayer.DataAccess.AddParameter("@ProductPrice", ProductPrice, System.Data.SqlDbType.Int, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@ProductImage", ProductImage, System.Data.SqlDbType.VarChar, 500);
            parameters[3] = DataLayer.DataAccess.AddParameter("@ProductDescription", ProductDescription, System.Data.SqlDbType.VarChar, 1000);
            parameters[4] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            parameters[5] = DataLayer.DataAccess.AddParameter("@ProductQuantity", TotalProducts, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_AddNewProduct", parameters);
        }
        public DataTable GetAllProducts() // for getting data from database 
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_GetAllProducts", parameters);
            return dt;
        }
        public DataTable GetAllCategories()// for getting data from database 
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_GetAllGategories", parameters);
            return dt;

        }
        internal DataTable SaveCustomerDetails() //we store all customer details for tracking the shipment and knowing our customer saved 
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@CustomerPhoneNo", CustomerPhoneNo, System.Data.SqlDbType.VarChar, 10);
            parameters[3] = DataLayer.DataAccess.AddParameter("@CustomerAddress", CustomerAddress, System.Data.SqlDbType.VarChar, 500);
            parameters[4] = DataLayer.DataAccess.AddParameter("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            parameters[5] = DataLayer.DataAccess.AddParameter("@TotalPrice", TotalPrice, System.Data.SqlDbType.Int, 100);
            parameters[6] = DataLayer.DataAccess.AddParameter("@PaymentMethod", PaymentMethod, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_SaveCustomerDetails", parameters);

            return dt;
        }
        internal DataTable GetOrdersList() 
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@Flag", Flag, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_GetOrdersList", parameters);
            return dt;
        }
        internal DataTable GetTransactionDetails() //getting all transaction numbers  
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@TransactionNo", Flag, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_GetTransactionDetails", parameters);
            return dt;
        }
        internal DataTable GetSetOrderStatus() // delivery status
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccess.AddParameter("@TransactionNo", Convert.ToInt32(OrderNo), System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParameter("@OrderStatus", OrderStatus, System.Data.SqlDbType.VarChar, 300);
            parameters[2] = DataLayer.DataAccess.AddParameter("@Flag", Flag, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_OrderStatus", parameters);
            return dt;
        }
        internal void SaveCustomerProducts() // this to collect all products data of each customer 
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParameter("@ProductID", ProductID, System.Data.SqlDbType.Int, 20);
            parameters[2] = DataLayer.DataAccess.AddParameter("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 10);
      

            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_SaveCustomerProducts", parameters);
        }
        internal DataTable GetAvailableStock() //will show the available number of same products in the warehouse 
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParameter("@StockType", StockType, System.Data.SqlDbType.Int, 10);
            parameters[1] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_GetAvailableStock", parameters);
            return dt;
        }
        internal DataTable GetIncomeReport()// another feature in the admin page will show some numbers as a result what is sold and how much!
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@ReportType", Flag, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExecuteDbByProcedure("SP_GetIncomeReport", parameters);
            return dt;
        }

    }
}   