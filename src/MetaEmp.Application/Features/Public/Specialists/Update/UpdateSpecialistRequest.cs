using System.Text.Json.Serialization;
using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Specialists.Update;

public record UpdateSpecialistRequest : IRequest<Unit>
{
    [JsonIgnore] 
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string UserStatus { get; set; } = default!;
    public string About { get; set; } = default!;
    public List<string> ListOfSkills { get; set; } = default!;
}