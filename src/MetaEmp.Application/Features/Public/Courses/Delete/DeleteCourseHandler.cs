using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CoursesEntities;

namespace MetaEmp.Application.Features.Public.Courses.Delete;

public class DeleteCourseHandler : AuthorizedRequestHandler<DeleteCourseRequest, Unit>
{
    public DeleteCourseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeleteCourseRequest request)
    {
        Context.Set<CourseProfile>()
            .Remove(new CourseProfile {Id = request.CourseId});

        await Context.SaveChangesAsync();
        return Unit.Value;
    }
}