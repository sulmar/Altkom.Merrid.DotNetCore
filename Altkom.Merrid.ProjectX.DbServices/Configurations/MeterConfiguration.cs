using Altkom.Merrid.ProjectX.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.Merrid.ProjectX.DbServices.Configurations
{
    // PM> Install-Package Microsoft.EntityFrameworkCore.Relational
    public class MeterConfiguration : IEntityTypeConfiguration<Meter>
    {
        public void Configure(EntityTypeBuilder<Meter> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Nazwa")
                .HasMaxLength(50);
        }
    }
}
