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
        SqlConnection connection = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void ConnectionString()
        {
            connection.ConnectionString = "Data Source=LIANNE-PC;database=LoginDataBase;integrated security=SSPI;";
        }

        //log in account
        public string Verify(Account acc)//void replaced actionresult
        {
            ConnectionString();
            connection.Open();
            com.Connection = connection;
            com.CommandText = "select * from dbo.UserDetails where UserName='" + acc.Name + "' and Password='" + acc.Password + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {                
                connection.Close();
                return acc.Name;

            }
            else
                connection.Close();

            return "Error";
        }

        public bool IsEmployer(Account acc)
        {
            ConnectionString();
            connection.Open();
            com.Connection = connection;
            com.CommandText = "select IsEmployer from dbo.UserDetails where UserName='" + acc.Name + "' and Password='" + acc.Password + "'";
          
            using (var reader = com.ExecuteReader())
            {

                if (reader.Read())
                {

                    acc.IsEmployer = reader.GetBoolean(0);
                    connection.Close();


                    return acc.IsEmployer;

                }
                else
                    connection.Close();

                return false;
            }
        }

            
        

        public string CreateUser(Account acc)
        {
            try
            {
                ConnectionString();
                connection.Open();
                com.Connection = connection;
                com.CommandText = "INSERT INTO UserDetails([UserName], [Password], [FirstName], [Surname], [IsEmployer]) VALUES ('" + acc.Name + "', '" + acc.Password + "','" + acc.FirstName + "', '" + acc.Surname + "' , '"+acc.IsEmployer+ "' )";

                dr = com.ExecuteReader();

                connection.Close();
                return acc.FirstName;

                // return View("~/Views/Account/Create.cshtml");    //success view!!   redirect to view in another folder??
            }
            catch (Exception exception)
            {
                Console.WriteLine("THERE HAS BEEN AN ERROR!  " + exception.Message);
                Console.WriteLine(" SQL statement :   " + com.CommandText);
                connection.Close();
                return "Error";  //Error view  :(

            }
        }
    }
}