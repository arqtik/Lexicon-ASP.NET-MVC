using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevASPMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;

namespace DevASPMVC.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.LanguageID, pl.PersonID });
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.Languages)
                .HasForeignKey(pl => pl.PersonID);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(l => l.People)
                .HasForeignKey(pl => pl.LanguageID);


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

            List<Language> languages = new List<Language>
            {
                new Language()
                {
                    ID = -1,
                    Name = "Swedish"
                },
                new Language()
                {
                    ID = -2,
                    Name = "English"
                },
                new Language()
                {
                    ID = -3,
                    Name = "Russian"
                },
                new Language()
                {
                    ID = -4,
                    Name = "Spanish"
                }
            };

            List<PersonLanguage> personLanguages = new List<PersonLanguage>
            {
                new PersonLanguage()
                {
                    PersonID = -1,
                    LanguageID = -1
                },
                new PersonLanguage()
                {
                    PersonID = -1,
                    LanguageID = -3
                },
                new PersonLanguage()
                {
                    PersonID = -2,
                    LanguageID = -1
                }
            };

            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<Person>().HasData(people);
            modelBuilder.Entity<Language>().HasData(languages);
            modelBuilder.Entity<PersonLanguage>().HasData(personLanguages);

            string adminRoleId = Guid.NewGuid().ToString();
            string adminUserId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            }, new IdentityRole {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            });

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminUserId,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PasswordHash = passwordHasher.HashPassword(null, "password"),
                FirstName = "Admin",
                LastName = "Adminsson",
                BirthDate = DateTime.Today
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        }
    }
}
