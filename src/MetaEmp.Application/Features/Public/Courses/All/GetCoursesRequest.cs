using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Courses.All;

public record GetCoursesRequest : IRequest<CourseResult[]>
{
    public string? Name { get; set; }
    public string? OrderBy { get; set; }
    public ApprovingStatus? Status { get; set; }
}