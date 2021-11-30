using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevASPMVC.Models;

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
            modelBuilder.Entity<Country>().HasKey(c => c.ID);
            modelBuilder.Entity<Country>()
                .HasMany(co => co.Cities)
                .WithOne(city => city.Country)
                .HasForeignKey(city => city.CountryID);

            modelBuilder.Entity<City>().HasKey(city => city.ID);
            modelBuilder.Entity<City>()
                .HasMany(c => c.People)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityID);


            List<Country> countries = new List<Country>
            {
                new Country {ID = -1, Name = "Sweden"}
            };

            List<City> cities = new List<City>
            {
                new City {
                    ID = -1,
                    Name = "Stockholm",
                    CountryID = -1
                },
                new City {
                    ID = -2,
                    Name = "Göteborg",
                    CountryID = -1
                }
            };

            List<Person> people = new List<Person>
            {
                new Person {
                    ID = -1,
                    FirstName = "Johannes",
                    LastName = "Hugosson",
                    Gender = Gender.Male,
                    CityID = -1,
                    Email = "johhug@domain.com"
                },
                new Person {
                    ID = -2,
                    FirstName = "Ingrid",
                    LastName = "Andersson",
                    Gender = Gender.Female,
                    CityID = -2,
                    Email = "ingand@domain.com"
                },
            };

            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<Person>().HasData(people);
        }

        public DbSet<DevASPMVC.Models.City> City { get; set; }
    }
}
