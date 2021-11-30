using System;
using Microsoft.EntityFrameworkCore;

namespace DevASPMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person
            {
                ID = -1,
                FirstName = "Johannes",
                LastName = "Hugosson",
                Gender = Gender.Male,
                Address = "Gustav gatan 21C 54412 Gävle",
                Email = "johhug@domain.com"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                ID = -2,
                FirstName = "Ingrid",
                LastName = "Andersson",
                Gender = Gender.Female,
                Address = "Tidnings gatan 3F 65351 Borås",
                Email = "ingand@domain.com"
            });

        }
    }
}
