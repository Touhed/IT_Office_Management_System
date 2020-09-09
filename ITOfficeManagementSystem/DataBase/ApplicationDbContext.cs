using System;
using System.Collections.Generic;
using System.Text;
using ITOfficeManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITOfficeManagementSystem.ViewModels;

namespace ITOfficeManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<AssignTask> AssignTask { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Event> Event { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        Address = "Null",
            //        EmployeeId = 1,
            //        Contact = 0,

            //    }
            //    );
            //modelBuilder.Entity<Client>().HasData(
            //   new Client
            //   {
            //       Name = "Null",
            //       CustomerId = 1,
            //       Contact = 0,
            //   }
            //   );

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole
               {
                   UserType = "Admin",
                   UserRoleId = 1
               }
               );
            modelBuilder.Entity<Users>().HasData(
              new Users
              {
                  UserId = 1,
                  UserType = "Admin",
                  UserName = "Touhed",
                  Email = "admin@gmail.com",
                  Password = "admin",
                  ConfirmPassword = "admin",
                  UserRoleId = 1
              }
              );
        }
    }
}
