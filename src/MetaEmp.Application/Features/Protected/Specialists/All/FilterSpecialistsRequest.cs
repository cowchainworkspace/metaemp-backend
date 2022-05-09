using MediatR;
using MetaEmp.Application.Features.Public.Specialists;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Protected.Specialists.All;

public class FilterSpecialistsRequest : IRequest<SpecialistResult[]>
{
    public string? Name { get; set; }
    public string? SortFilter { get; set; }
    public ApprovingStatus? Status { get; set; }
}