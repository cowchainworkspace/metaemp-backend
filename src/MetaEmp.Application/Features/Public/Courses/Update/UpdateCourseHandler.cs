using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CoursesEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Courses.Update;

public class UpdateCourseHandler : AuthorizedRequestHandler<UpdateCourseRequest, Unit>
{
    public UpdateCourseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(UpdateCourseRequest request)
    {
        var course = await Context.Set<CourseProfile>()
            .FirstOr404Async(c => c.Id == request.Id);

        request.Adapt(course);

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}