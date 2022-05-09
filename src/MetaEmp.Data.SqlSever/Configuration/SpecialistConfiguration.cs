﻿using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaEmp.Data.SqlSever.Configuration;

public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
{
    public void Configure(EntityTypeBuilder<Specialist> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.User)
            .WithOne(u => u.SpecialistProfile)
            .HasForeignKey<Specialist>(s => s.UserId);

        builder.HasMany(s => s.Educations)
            .WithOne(e => e.Specialist)
            .HasForeignKey(e => e.SpecialistId);
        
        builder.HasMany(s => s.Experiences)
            .WithOne(e => e.Specialist)
            .HasForeignKey(e => e.SpecialistId);
    }
}