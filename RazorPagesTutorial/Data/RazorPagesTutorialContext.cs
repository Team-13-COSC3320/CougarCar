using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Data
{
    public class RazorPagesTutorialContext : DbContext
    {
        public RazorPagesTutorialContext (DbContextOptions<RazorPagesTutorialContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTutorial.Models.Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("PRODUCTS");
        }
    }
}
