using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ITToolTest.Models;

namespace ITToolTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ITToolTest.Models.Courses> Courses { get; set; }
        public DbSet<ITToolTest.Models.CoursesData> CoursesData { get; set; }
        public DbSet<ITToolTest.Models.User> User { get; set; }
        public DbSet<ITToolTest.Models.UserCourse> UserCourse { get; set; }
        
    }
}
