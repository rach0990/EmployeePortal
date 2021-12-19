using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EmployeeLog.Models;
using System.Web.UI.WebControls.WebParts;

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
        public string Verify(Account acc)
        {

            UserDetails userDetails;

            using (var context = new LoginDataBaseContext())
            {
                userDetails = context.UserDetails
                             .Where(user => user.UserName == acc.UserName)
                             .Where(user => user.Password == acc.Password)
                             .FirstOrDefault();
            }

            if (userDetails != null)
                return acc.UserName;
            
            return "Error";
        }

        //Employer/employee path
       public bool IsEmployer(Account acc)
        {
            
            UserDetails userDetails;

            using (var context = new LoginDataBaseContext())
            {
                userDetails = context.UserDetails
                       .Where(user => user.UserName == acc.UserName)
                       .Where(user => user.Password == acc.Password)
                       .FirstOrDefault();
            }

            if (userDetails.IsEmployer == true)
                return true;

            return false;
        }

            
        

        public string CreateUser(Account acc)
        {
            try
            {
               
         
                using (var context = new LoginDataBaseContext())
                {
                 
                    context.Add(acc);
                  
                    context.SaveChanges();
                    
                }
          
                return acc.FirstName;

                // return View("~/Views/Account/Create.cshtml");    //success view!!   redirect to view in another folder??
            }

            catch (Exception exception)
            {
                Console.WriteLine("THERE HAS BEEN AN ERROR!  " + exception.Message);
                Console.WriteLine(" SQL statement :   " + com.CommandText);
                connection.Close();
                return "Error";  

            }
        }
    }
}