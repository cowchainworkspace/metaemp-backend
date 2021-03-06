using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Specialists.Create;

public record CreateSpecialistRequest : IRequest<SpecialistResult>
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Title { get; set; }
    public string? UserStatus { get; set; }
    public string? About { get; set; }
    public List<string>? ListOfSkills { get; set; }
}