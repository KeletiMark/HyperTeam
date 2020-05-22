using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.EF
{
    public class ShopContext : DbContext  
    {
        public ShopContext() : base("ShopDB") 
        {
        }

        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Memory> Memories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Memory>().HasKey(m => m.Id);
            modelBuilder.Entity<Processor>().HasKey(p => p.Id);
            modelBuilder.Entity<Memory>().HasKey(m => m.Id);
        }
    }
}
