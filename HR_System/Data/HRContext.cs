using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Models;
using HR_System.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HR_System.Data
{
    public class HRContext:IdentityDbContext<ApplicationUser> /*DbContext*/
    {
         IConfiguration config;

     

        public HRContext (IConfiguration _config)
         {
             config = _config;
         }

     

        public DbSet<Employee> employees { set; get; }
        public DbSet<Department> depts { set; get; }

        public DbSet<Country> countries { set; get; }

        public DbSet<City> cities { set; get; }

        //public DbSet<IdentityUser> User { set; get; }
        //public DbSet<IdentityRole> Role { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("conString"));
           // optionsBuilder.UseSqlServer("data source=(local);initial catalog=HrSystem;integrated security=true");
            base.OnConfiguring(optionsBuilder);

        }
    }
}

