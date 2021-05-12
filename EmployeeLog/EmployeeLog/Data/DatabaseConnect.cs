using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EmployeeLog.Models;

namespace EmployeeLog.Data
{
    public class DatabaseConnect
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void ConnectionString()
        {
            con.ConnectionString = "Data Source=LIANNE-PC;database=LoginDataBase;integrated security=SSPI;";
        }

        //log in account
        public string Verify(Account acc)//void replaced actionresult
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from dbo.UserDetails where UserName='" + acc.Name + "' and Password='" + acc.Password + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return acc.Name;

            }
            else
                con.Close();

            return "Error";
        }

        public string CreateUser(Account acc)
        {
            try
            {
                ConnectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO UserDetails([UserName], [Password], [FirstName], [Surname]) VALUES ('" + acc.Name + "', '" + acc.Password + "','" + acc.FirstName + "', '" + acc.Surname + "' )";

                dr = com.ExecuteReader();

                con.Close();
                return acc.FirstName;

                // return View("~/Views/Account/Create.cshtml");    //success view!!   redirect to view in another folder??
            }
            catch (Exception exception)
            {
                con.Close();
                return "Error";  //Error view  :(

            }
        }
    }
}