using MetaEmp.Application.Abstractions;
using File = MetaEmp.Data.SqlSever.Entities.File;

namespace MetaEmp.Application.Features.Public.Files.Delete;

public class DeleteFileHandler : DbRequestHandler<DeleteFileRequest, DeleteFileResult>
{
    public DeleteFileHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<DeleteFileResult> Handle(DeleteFileRequest request)
    {
        Context.Set<File>().Remove(new File {Id = request.Id});

        await Context.SaveChangesAsync();

        return new();
    }
}