using EmployeeLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeLog.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        [HttpGet]
        public ActionResult Profile()
        {
           /* if(Session["UserName"] == null) //not logged in
            {
                return RedirectToAction("Login","Login");
            }*/

            return View();
        }

        [HttpGet]
        public ActionResult EmployerProfile()
        {
            return View();

        }


        [HttpPost]
        public ActionResult ProfileView(Account acc)
        {
            ViewData["FirstName"] = acc.FirstName;

            return View();
        }
       
    }
}