using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Butcher> Butchers { get; set; }
        public DbSet<ButcherStore> ButcherStores { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ButcherStore>()
                .HasOne<Butcher>(ButcherStore => ButcherStore.Butcher)
                .WithMany(Butcher => Butcher.ButcherStores)
                .HasForeignKey(ButcherStore => ButcherStore.ButcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Butcher>(Butcher => Butcher.HasIndex(b => b.Username).IsUnique());
        }
    }
}
