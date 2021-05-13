using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}