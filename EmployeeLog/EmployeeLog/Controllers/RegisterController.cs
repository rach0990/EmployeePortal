using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using EmployeeLog.Models;
using EmployeeLog.Data;
using System.Data;

namespace EmployeeLog.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
     

       


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
                if (acc.UserName != null)
                {
                    DatabaseConnect regDb = new DatabaseConnect();
                    string result = regDb.CreateUser(acc);


                    if (result != "Error") 
                    {
                        if(acc.IsEmployer == true)
                        {
                            //employer box ticked go to employers profile
                            return RedirectToAction("EmployerProfile", "Profile");
                        }

                        return RedirectToAction("Profile", "Profile");
                    }

                   
                }

            }
            ViewData["Error"] = "Password must be at least 8 characters long";
            return View("CreateAcc");
                      
            
        }

    }
}