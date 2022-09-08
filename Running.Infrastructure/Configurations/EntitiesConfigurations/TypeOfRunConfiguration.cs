using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Running.Domain.Entities;

namespace Running.Infrastructure.Configurations.EntitiesConfigurations;

public class TypeOfRunConfiguration : IEntityTypeConfiguration<TypeOfRun>
{
    public void Configure(EntityTypeBuilder<TypeOfRun> builder)
    {
        builder.HasMany(t => t.Runs)
            .WithOne(r => r.TypeOfRun)
            .HasForeignKey(r => r.TypeOfRunId);
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}

