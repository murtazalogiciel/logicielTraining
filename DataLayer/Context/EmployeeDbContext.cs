using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;

namespace DataLayer.Context
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext() 
        {
        }

        DbSet<Employee> Employees { get; set; }
    }
}
