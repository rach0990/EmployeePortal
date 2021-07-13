using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLog.Models
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public bool IsEmployer { get; set; }
    }
}