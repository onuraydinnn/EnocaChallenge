using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EfCodeFirstMapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(t => t.OrderId);

            this.Property(t => t.ProductId).IsRequired();

            this.Property(t => t.CompanyId).IsRequired();

            this.Property(t => t.OrderPlacerName).IsRequired().HasMaxLength(40);

            this.Property(t => t.Quantity).IsRequired();

            this.Property(t => t.OrderDate).IsRequired();

            this.ToTable("Orders");

            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.OrderPlacerName).HasColumnName("OrderPlacerName");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");

            this.HasOptional(t => t.Company).WithMany(t => t.Orders).HasForeignKey(d => d.CompanyId);
            this.HasOptional(t => t.Product).WithMany(t => t.Orders).HasForeignKey(d => d.ProductId);
        }
    }
}
