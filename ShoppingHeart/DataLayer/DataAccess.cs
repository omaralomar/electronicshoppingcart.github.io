﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace ShoppingHeart.DataLayer
{
    public class DataAccess
    { //this class can used for sending data in or getting from database
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString();

            }
        }
        public static SqlParameter AddParameter(string parameterName , object value , SqlDbType DbType , int size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.Value = value.ToString();
            param.SqlDbType = DbType;
            param.Size = size;
            param.Direction = ParameterDirection.Input;
            return param;
        }
        public static DataTable ExecuteDbByProcedure(string ProcedureName , SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = ProcedureName;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            try
            {
                adapter.Fill(dTable);
            }
            catch (Exception)
            {
               
            }
            finally
            {
                //disposing objects
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();

            }
            return dTable;            
        }
    }
}