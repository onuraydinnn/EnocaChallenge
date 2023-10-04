using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EfCodeFirstMapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            this.HasKey(t => t.CompanyId);

            this.Property(t => t.CompanyId).IsRequired();

            this.Property(t => t.CompanyName).IsRequired().HasMaxLength(40);

            this.Property(t => t.ApprovalStatus).IsRequired();

            this.Property(t => t.OrderPermissionStartTime).IsRequired();

            this.Property(t => t.OrderPermissionEndTime).IsRequired();


            this.ToTable("Companies");

            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.ApprovalStatus).HasColumnName("ApprovalStatus");
            this.Property(t => t.OrderPermissionStartTime).HasColumnName("OrderPermissionStartTime");
            this.Property(t => t.OrderPermissionEndTime).HasColumnName("OrderPermissionEndTime");


        }
    }
}
