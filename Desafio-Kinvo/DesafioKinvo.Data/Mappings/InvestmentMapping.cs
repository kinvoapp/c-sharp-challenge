using DesafioKinvo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Data.Mappings
{
    public class InvestmentMapping : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("Investments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(10)")
                .HasMaxLength(10);
            
            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("DECIMAL(5, 2)");

            builder.Property(x => x.Rate)
                .IsRequired()
                .HasColumnType("DECIMAL(5, 2)");

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnType("DECIMAL(10, 2)");

            builder.HasIndex(x => x.Name);
        }
    }
}
