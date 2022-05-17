using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Specialists.All;

public record FilterSpecialistsRequest : IRequest<SpecialistResult[]>
{
    public string? Name { get; set; }
    public string? OrderBy { get; set; }
    public ApprovingStatus? Status { get; set; }
}