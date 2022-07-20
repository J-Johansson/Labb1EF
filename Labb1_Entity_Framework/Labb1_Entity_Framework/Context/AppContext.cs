using Labb1_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb1_Entity_Framework.Context
{
    class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-35CC471\SQLEXPRESS;Initial Catalog=LeaveApp;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   EmployeeId = 1,
                   FirstName = "Jonathan",
                   LastName = "Johansson"
               });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   EmployeeId = 2,
                   FirstName = "Emmy",
                   LastName = "Johansson"
               });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   EmployeeId = 3,
                   FirstName = "Daniel",
                   LastName = "West"
               });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   EmployeeId = 4,
                   FirstName = "Lisa",
                   LastName = "Gerzen"
               });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   EmployeeId = 5,
                   FirstName = "Bob",
                   LastName = "Johansson"
               });
            modelBuilder.Entity<LeaveApplication>()
                .HasData(new LeaveApplication
                {
                    LeaveId = 1,
                    Reason = "Sick",
                    StartDate = DateTime.Parse("2022-04-05"),
                    EndDate = DateTime.Parse("2022-04-07"),
                    ForeignEmployeeId = 1
                });
            modelBuilder.Entity<LeaveApplication>()
                .HasData(new LeaveApplication
                {
                    LeaveId = 2,
                    Reason = "Vacation",
                    StartDate = DateTime.Parse("2022-04-08"),
                    EndDate = DateTime.Parse("2022-04-15"),
                    ForeignEmployeeId = 1
                });
            modelBuilder.Entity<LeaveApplication>()
                .HasData(new LeaveApplication
                {
                    LeaveId = 3,
                    Reason = "Sick children",
                    StartDate = DateTime.Parse("2022-05-15"),
                    EndDate = DateTime.Parse("2022-05-22"),
                    ForeignEmployeeId = 4
                });
            modelBuilder.Entity<LeaveApplication>()
                .HasData(new LeaveApplication
                {
                    LeaveId = 4,
                    Reason = "Vacation",
                    StartDate = DateTime.Parse("2022-06-06"),
                    EndDate = DateTime.Parse("2022-08-06"),
                    ForeignEmployeeId = 3
                });
            modelBuilder.Entity<LeaveApplication>()
                .HasData(new LeaveApplication
                {
                    LeaveId = 5,
                    Reason = "Home sick with kids",
                    StartDate = DateTime.Parse("2022-06-11"),
                    EndDate = DateTime.Parse("2022-06-14"),
                    ForeignEmployeeId = 2
                });
            modelBuilder.Entity<LeaveApplication>()
                .HasData(new LeaveApplication
                {
                    LeaveId = 6,
                    Reason = "Ski vacation",
                    StartDate = DateTime.Parse("2022-11-05"),
                    EndDate = DateTime.Parse("2022-12-07"),
                    ForeignEmployeeId = 1
                });
        }
    }
}
