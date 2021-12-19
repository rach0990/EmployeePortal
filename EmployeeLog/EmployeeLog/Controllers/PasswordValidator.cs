using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeLog.Controllers
{
    public class PasswordValidator
    {
        private int RequiredLength { get; set; }
        private bool RequiredNonLetterOrDigit { get; set; }
        private bool RequiredUpperCase { get; set; }
        private bool RequiredLowercase { get; set; }
       

        public PasswordValidator()
        {
            RequiredLength = 8;


        }



        public bool IsValid(string password)
        {
            if (password.Length < 8)

                return false;

            else
                return true;           

        }
        public bool IsUpperCase(string password)
        {
            
          // LINQ helper returns true is uppercase is present
            return password.Any(c => char.IsUpper(c)); 

        }

      
    }


}