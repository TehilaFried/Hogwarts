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
        public HogwartsContext (DbContextOptions<HogwartsContext> options)
            : base(options)
        {
        }

        public DbSet<Hogwarts.Models.Customer> Customer { get; set; }

        public DbSet<Hogwarts.Models.Atractions> Atractions { get; set; }

        

        public DbSet<Hogwarts.Models.Comments> Comments { get; set; }
    }
}
