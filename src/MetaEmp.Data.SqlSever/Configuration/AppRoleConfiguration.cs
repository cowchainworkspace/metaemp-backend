using MetaEmp.Data.SqlSever.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaEmp.Data.SqlSever.Configuration;

internal class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
	public void Configure(EntityTypeBuilder<AppRole> builder)
	{
		builder.HasKey(e => e.Id);
		
		builder.Property(e => e.Name).HasMaxLength(64);
		builder.Property(e => e.NormalizedName).HasMaxLength(64);
		builder.Property(e => e.ConcurrencyStamp).HasMaxLength(64);

		builder.ToTable("AppRoles");
	}
}