using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EfCodeFirstMapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.HasKey(t => t.ProductId);

            this.Property(t => t.ProductId);

            this.Property(t => t.ProductName).IsRequired().HasMaxLength(40);

            this.Property(t => t.Stock).IsRequired();

            this.Property(t => t.Price).IsRequired();

            this.ToTable("Products");

            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Stock).HasColumnName("Stock");
            this.Property(t => t.Price).HasColumnName("Price");




        }
    }
}
