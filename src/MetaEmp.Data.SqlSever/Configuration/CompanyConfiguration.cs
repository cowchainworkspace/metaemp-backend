using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaEmp.Data.SqlSever.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name).HasMaxLength(64);
        builder.Property(c => c.Description).HasMaxLength(1024);

        builder.HasOne(c => c.Owner)
            .WithMany(c => c.Companies)
            .HasForeignKey(c => c.OwnerId);

        builder.HasOne(c => c.Logo)
            .WithOne()
            .HasForeignKey<Company>(c => c.LogoId);

        builder.ToTable("Companies");
    }
}