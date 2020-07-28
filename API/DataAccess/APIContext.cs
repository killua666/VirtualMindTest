
using Microsoft.EntityFrameworkCore;
using TestVM.Models;

namespace TestVM.DataAccess
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Purchase> Purchase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => new { e.IdPurchase });

                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.Property(e => e.Amount).IsUnicode(false);

                entity.Property(e => e.AmountTo).IsUnicode(false);

                entity.Property(e => e.Unit).IsUnicode(false);

                entity.Property(e => e.CurrencyRate).IsUnicode(false);

                entity.Property(e => e.PurchaseDate).IsUnicode(false);
            });

        }
    }
}

