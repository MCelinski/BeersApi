using BeersApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BeersApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().HasKey(am => new
            {
                am.Id,
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brewery> Breweries { get; set; }
    }
}
