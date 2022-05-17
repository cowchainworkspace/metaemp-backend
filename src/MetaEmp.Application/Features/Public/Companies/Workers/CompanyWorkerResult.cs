using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Companies.Workers;

public class CompanyWorkerResult
{
    public WorkerRole Role { get; set; }
    public Guid CompanyId { get; set; }
    public Guid SpecialistId { get; set; }
}