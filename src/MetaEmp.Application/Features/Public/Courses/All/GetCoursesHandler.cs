using System.Linq.Dynamic.Core;
using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.CoursesEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Courses.All;

public class GetCoursesHandler : DbRequestHandler<GetCoursesRequest, CourseResult[]>
{
    public GetCoursesHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<CourseResult[]> Handle(GetCoursesRequest request, CancellationToken cancel)
    {
        var coursesQuery = Context.Set<CourseProfile>().AsQueryable();

        if (request.Name is not null)
            coursesQuery = coursesQuery.Where("Name.Contains(@0)", request.Name);

        if (request.Status is not null)
            coursesQuery = coursesQuery.Where("Status == @0", request.Status);

        if (request.OrderBy is not null)
            coursesQuery = coursesQuery.OrderBy(request.OrderBy);

        HttpContext.SetCountHeader(await coursesQuery.CountAsync(cancel));

        return await coursesQuery.ProjectToType<CourseResult>()
            .ToArrayAsync(cancel);
    }
}