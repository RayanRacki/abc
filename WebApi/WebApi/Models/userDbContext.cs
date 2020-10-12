using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class userDbContext : DbContext
    {
        public userDbContext(DbContextOptions<userDbContext> options):base(options)
        {

        }

        public DbSet<addressModel> Address { get; set; }
        public DbSet<userModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userModel>()
                .HasIndex(u => u.email)
                .IsUnique();
        }
    }
}
