using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using EmployeeLog.Models;
using EmployeeLog.Data;

namespace EmployeeLog.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
     

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        [HttpGet]
        public ActionResult CreateAcc()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult CreateUser(Account acc)
        {
            PasswordValidator reqLength = new PasswordValidator();

            if (reqLength.IsValid(acc.Password))
            {
                if (acc.Name != null)
                {
                    DatabaseConnect regDb = new DatabaseConnect();
                    string result = regDb.CreateUser(acc);

                    if (result != "Error")
                    {

                        return View("~/Views/Account/Create.cshtml");
                    }

                }
            }
            return View("CreateAcc");

           
            
        }

    }
}