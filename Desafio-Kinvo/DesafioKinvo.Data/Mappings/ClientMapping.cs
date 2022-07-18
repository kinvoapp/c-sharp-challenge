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
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.Investments)
                .WithOne(i => i.Client)
                .HasForeignKey(x => x.ClientId);
        }
    }
}
