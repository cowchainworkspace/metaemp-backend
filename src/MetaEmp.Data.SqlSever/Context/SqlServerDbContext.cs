using MetaEmp.Core.Abstractions.Context;
using MetaEmp.Data.SqlSever.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Data.SqlSever.Context;

public class SqlServerDbContext : IdentityDbContext<AppUser, AppRole, long,
        IdentityUserClaim<long>, AppUserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>,
        IdentityUserToken<long>>,
    IDatabaseContext
{
    public SqlServerDbContext(DbContextOptions options) : base(options)
    {
        // To use AsNoTracking by default
        // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var entitiesAssembly = GetType().Assembly;
        builder.ApplyConfigurationsFromAssembly(entitiesAssembly);
    }
}