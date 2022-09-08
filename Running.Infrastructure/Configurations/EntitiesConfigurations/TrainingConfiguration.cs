using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Running.Domain.Entities;

namespace Running.Infrastructure.Configurations.EntitiesConfigurations;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.HasMany(t => t.Runs)
             .WithOne(r => r.Training)
             .HasForeignKey(r => r.TrainingId);
        builder.Property(t => t.TrainingDate)
            .IsRequired();
        builder.Property(t => t.CreateDate)
            .IsRequired();
    }
}

