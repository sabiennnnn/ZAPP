using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZAPP.Models;

namespace ZAPP.Data
{
    public class ZAPPContext : IdentityDbContext
    {
        public ZAPPContext(DbContextOptions<ZAPPContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Visit>().ToTable("Visit");
            modelBuilder.Entity<Models.Task>().ToTable("Task");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Customer>().ToTable("Customer");

        }
    }
}
