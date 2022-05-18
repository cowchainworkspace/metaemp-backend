using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Extensions;

public static class CompanyExtensions
{
    public static IEnumerable<CompanyWorker>? GetHRs(this Company company) =>
        company.Workers?.Where(w => w.Role == WorkerRole.HR);
}