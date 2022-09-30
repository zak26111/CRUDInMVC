using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDInMVC.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext():base("DbConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}