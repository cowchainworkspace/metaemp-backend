using MetaEmp.Data.SqlSever.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaEmp.Data.SqlSever.Configuration;

public class WorkApprovalConfiguration : IEntityTypeConfiguration<WorkApproval>
{
    public void Configure(EntityTypeBuilder<WorkApproval> builder)
    {
        builder.HasKey(wa => wa.Id);

        builder.HasOne(wa => wa.Company)
            .WithMany(c => c.Approvals)
            .HasForeignKey(wa => wa.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(wa => wa.Specialist)
            .WithMany(s => s.Approvals)
            .HasForeignKey(wa => wa.SpecialistId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}