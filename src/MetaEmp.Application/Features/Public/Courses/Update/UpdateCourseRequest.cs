using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Courses.Update;

public record UpdateCourseRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<string> Roads { get; set; } = default!;
}