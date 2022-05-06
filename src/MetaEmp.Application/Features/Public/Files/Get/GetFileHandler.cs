using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Extensions;
using File = MetaEmp.Data.SqlSever.Entities.File;

namespace MetaEmp.Application.Features.Public.Files.Get;

public class GetFileHandler : DbRequestHandler<GetFileRequest, FileResult>
{
    public GetFileHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    
    public override async Task<FileResult> Handle(GetFileRequest request, CancellationToken cancel)
    {
        var file = await Context.Set<File>().FirstOr404Async(f => f.Id == request.Id, cancel);
        var result = file.Adapt<FileResult>();
        
        return result;
    }
}