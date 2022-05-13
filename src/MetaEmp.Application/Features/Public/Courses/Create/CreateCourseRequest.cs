using MediatR;

namespace MetaEmp.Application.Features.Public.Courses.Create;

public class CreateCourseRequest : IRequest<CourseResult>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<string> Roads { get; set; } = default!;
}

