using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.EducationEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Courses.All;

public class GetCoursesHandler : DbRequestHandler<GetCoursesRequest, CourseResult[]>
{
    public GetCoursesHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<CourseResult[]> Handle(GetCoursesRequest request, CancellationToken cancel)
    {
        var courses = await Context.Set<CourseProfile>()
            .ProjectToType<CourseResult>()
            .ToArrayAsync(cancel);

        HttpContext.SetCountHeader(await Context.Set<CourseProfile>().CountAsync(cancel));

        return courses;
    }
    
}