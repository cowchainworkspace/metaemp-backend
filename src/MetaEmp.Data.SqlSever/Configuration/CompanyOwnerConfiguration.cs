using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaEmp.Data.SqlSever.Configuration;

public class CompanyOwnerConfiguration : IEntityTypeConfiguration<CompanyOwner>
{
    public void Configure(EntityTypeBuilder<CompanyOwner> builder)
    {
        builder.HasKey(co => co.Id);

        builder.HasOne(co => co.User)
            .WithOne(au => au.CompanyOwnerProfile)
            .HasForeignKey<CompanyOwner>(co => co.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}