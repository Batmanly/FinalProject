using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext//it's coming from EntityFramework
    {
        //Context : DB tablolari ile proje classlarini baglamak
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=true");//SQLServer Kullanacaz, onu nasil kullanacagimizi belirtmemiz lazim
        }

        public DbSet<Product> Products { get; set; } //Tablolari bagladik
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
