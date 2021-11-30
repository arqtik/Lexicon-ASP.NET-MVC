using System;
using Microsoft.EntityFrameworkCore;

namespace DevASPMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Person> People { get; set; }
    }
}
