using MediatR;

namespace MetaEmp.Application.Features.Public.Courses.One;

public record GetCourseRequest(Guid Id) : IRequest<CourseResult>;