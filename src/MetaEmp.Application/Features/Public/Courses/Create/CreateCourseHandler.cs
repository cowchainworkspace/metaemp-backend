using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.EducationEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Courses.Create;

public class CreateCourseHandler : AuthorizedRequestHandler<CreateCourseRequest, CourseResult>
{
    public CreateCourseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<CourseResult> Handle(CreateCourseRequest request)
    {
        var course = request.Adapt<CourseProfile>();

        // TODO: remove this with userId from jwt token
        course.UserId = Guid.Parse("09ABD51D-B0AB-4395-7681-08DA32A20000");

        course.Created = DateTime.UtcNow;
        course.Status = ApprovingStatus.Pending;

        var createdEntity = await Context.Set<CourseProfile>().AddAsync(course);

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<CourseResult>();
    }
}