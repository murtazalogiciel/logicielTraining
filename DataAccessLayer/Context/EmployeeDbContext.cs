
using DataAccessLayer.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class EmployeeDbContext : DbContext
    {
      

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public EmployeeDbContext()
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
