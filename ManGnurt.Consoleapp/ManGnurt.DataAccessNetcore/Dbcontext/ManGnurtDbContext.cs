using System;
using System.Collections.Generic;
using System.Text;
using ManGnurt.DataAccessNetcore.DataObject;
using Microsoft.EntityFrameworkCore;

namespace ManGnurt.DataAccessNetcore.Dbcontext
{
    // Ensure the correct base class is referenced.
    // If the intended base class is 'DbContext' from Entity Framework, use the correct casing and namespace.
    // For example: using Microsoft.EntityFrameworkCore;

    public class ManGnurtDbContext : DbContext
    {
        public ManGnurtDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed.
        }
        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<Account> account { get; set; }
        public virtual DbSet<Category> category { get; set; }

    }
}
