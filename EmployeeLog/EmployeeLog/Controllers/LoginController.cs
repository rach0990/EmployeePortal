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
           

                DatabaseConnect db = new DatabaseConnect();
                string result = db.Verify(acc);

                if (result != "Error")
                {
            Session["UserName"] = acc.Name;

                return RedirectToAction("Profile","Profile");

                

                
                }
            

            return View("Login");
        }
        
            
        
        
        


        
    }
}