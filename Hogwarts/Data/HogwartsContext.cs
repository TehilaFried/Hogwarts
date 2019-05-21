using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hogwarts.Models;

namespace Hogwarts.Models
{
    public class HogwartsContext : DbContext
    {
        public HogwartsContext(DbContextOptions<HogwartsContext> options)
            : base(options)
        {
        }

        public DbSet<Hogwarts.Models.Customer> Customer { get; set; }

        public DbSet<Hogwarts.Models.Atractions> Atractions { get; set; }

        public DbSet<Hogwarts.Models.CustomerAtraction> CustomerAtractions { get; set; }




        public DbSet<Hogwarts.Models.Comments> Comments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAtraction>()
                .HasKey(t => new { t.CustomerId, t.AtractionId });

            modelBuilder.Entity<CustomerAtraction>()
                .HasOne(pt => pt.Customer)
                .WithMany(p => p.CustomerAtractions)
                .HasForeignKey(pt => pt.CustomerId);

            modelBuilder.Entity<CustomerAtraction>()
                .HasOne(pt => pt.Atractions)
                .WithMany(t => t.CustomerAtractions)
                .HasForeignKey(pt => pt.AtractionId);

        }
        
        public DbSet<Hogwarts.Models.Locations> Locations { get; set; }
        
        public DbSet<Hogwarts.Models.Orders> Orders { get; set; }
        
        public DbSet<Hogwarts.Models.SignUpApplication> SignUpApplication { get; set; }
        
        public DbSet<Hogwarts.Models.Statuses> Statuses { get; set; }


    }
}
