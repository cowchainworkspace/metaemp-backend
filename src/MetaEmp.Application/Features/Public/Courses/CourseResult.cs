using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Courses;

public class CourseResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<string> Roads { get; set; } = default!;
    public ApprovingStatus Status { get; set; }
    public DateTime Created { get; set; }
    public Guid UserId { get; set; }
    public Guid? LogoId { get; set; }
}