using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiRoutesResponses.Models;

namespace WebApiRoutesResponses.Context
{
    public class ApiAppContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<UserRole> UserRoles {get;set;}
        public ApiAppContext(DbContextOptions<ApiAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<User> usersInitData = new List<User>();

            usersInitData.Add(new User{ Name = "User 1", LastName = "LastName 1" });
            usersInitData.Add(new User{ Name = "User 2", LastName = "LastName 2" });
            usersInitData.Add(new User{ Name = "User 3", LastName = "LastName 3" });

            builder.Entity<User>().ToTable("User").HasData(usersInitData);
            builder.Entity<User>().HasKey(p=> p.UserId);

            builder.Entity<UserRole>().ToTable("UserRole").HasKey(p=> p.UserRoleId);

            List<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(new UserRole() { Role = "Admin", UserId = usersInitData[0].UserId });
            userRoles.Add(new UserRole() { Role = "User", UserId = usersInitData[0].UserId });
            userRoles.Add(new UserRole() { Role = "Support", UserId = usersInitData[0].UserId });
            userRoles.Add(new UserRole() { Role = "Admin", UserId = usersInitData[1].UserId });

            builder.Entity<UserRole>().HasData(userRoles);

            builder.Entity<UserRole>().HasOne<User>("User");
            
        }
        
    }
}