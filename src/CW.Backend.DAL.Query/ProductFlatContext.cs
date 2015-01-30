using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query
{
    public class ProductFlatContext : DbContext
    {
        public DbSet<ProductDetails> Products { get; set; }

        public ProductFlatContext() : base("ProductFlat") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ProductDetails>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<ProductDetails>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
        }
    }
}
