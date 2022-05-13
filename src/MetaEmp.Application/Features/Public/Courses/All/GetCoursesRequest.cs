using MediatR;

namespace MetaEmp.Application.Features.Public.Courses.All;

public record GetCoursesRequest : IRequest<CourseResult[]>;