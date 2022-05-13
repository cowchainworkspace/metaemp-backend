using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CoursesEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Courses.One;

public class GetCourseHandler : DbRequestHandler<GetCourseRequest, CourseResult>
{
    public GetCourseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<CourseResult> Handle(GetCourseRequest request)
    {
        var course = await Context.Set<CourseProfile>()
            .FirstOr404Async(c => c.Id == request.Id);
        
        return course.Adapt<CourseResult>();
    }
}