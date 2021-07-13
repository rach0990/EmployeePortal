using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeLog.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLog.Models
{
    public class ModelAccountContext : DbContext
    {
        public DbSet<UserDetails> UserDetail { get; set; }

       // protected override void OnConfiguring(DbContextOptionsBuilder options) =>
           // options.UseSqlite(@"Data Source=LIANNE-PC;database=LoginDataBase;integrated security=SSPI;");


        public class UserDetails
        {
            [Key]
            public int UserId { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string Password { get; set; }
            public bool IsEmployer { get; set; }

        }
    }

    
   

}