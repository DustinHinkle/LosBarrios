using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Los_Barrios_Project
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        //public DbSet<User> Users {get; set;}

        //public DbSet<Question> Questions {get; set;}

        //public DbSet<Answer> Answers {get; set;}

    }
}