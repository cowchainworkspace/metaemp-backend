using MediatR;

namespace MetaEmp.Application.Features.Public.Courses.Delete;

public record DeleteCourseRequest(Guid CourseId) : IRequest;

    
