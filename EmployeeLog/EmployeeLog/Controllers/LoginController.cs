using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeLog.Controllers;
using EmployeeLog.Models;
using System.Data.SqlClient;
using EmployeeLog.Data;

namespace EmployeeLog.Controllers
{
    public class LoginController : Controller
    {
      
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Verify(Account acc)
        {
           //  PasswordValidator errorPass = new PasswordValidator();
            DatabaseConnect db = new DatabaseConnect();

                string result = db.Verify(acc);

            if (result != "Error")
            {
                //go to database
                bool IsEmployer = db.IsEmployer(acc);
                Session["UserName"] = acc.UserName;

                if (IsEmployer == true)
                {
                   
                    return RedirectToAction("EmployerProfile", "Profile");
                    
                }

                //else carry on as before
    
                return RedirectToAction("Profile", "Profile");

            }
         


                ViewData["Invalid"] = "Invalid username or password";
                return View("Login");
                
        }
        
        


        
    }
}