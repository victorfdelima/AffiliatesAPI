using AfiliadosAPI.Models;
using AfiliadosAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AfiliadosAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Seller> Sellers { get; set; }
        
        public DbSet<Afiliate> Afiliates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Seller)
                .WithMany(s => s.Sales)
                .HasForeignKey(t => t.SellerId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Afiliate)
                .WithMany(a => a.ReceivedCommissions)
                .HasForeignKey(t => t.AfiliateId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
