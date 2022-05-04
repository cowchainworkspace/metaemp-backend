using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Constants;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.AspNetCore.Http;
using File = MetaEmp.Data.SqlSever.Entities.File;

namespace MetaEmp.Application.Features.Public.Files.Upload;

public class UploadFileHandler : DbRequestHandler<UploadFileRequest, UploadFileResult>
{
    public UploadFileHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<UploadFileResult> Handle(UploadFileRequest request, CancellationToken cancel)
    {
        File file;
        switch (request.Target)
        {
            case FileTarget.CompanyLogo:
                if (MimeTypes.Images.All(m => m != request.File.ContentType.ToLower()))
                    throw new ValidationFailedException("File", "Wrong file type");   
                var company = await Context.Set<Company>().FirstOr404Async(c => c.Id == request.TargetId, cancel);
                file = await UploadFile(request.File, cancel);
                company.LogoId = file.Id;
                break;
            default:
                throw new ValidationFailedException("Target", "Wrong target");
        }

        await Context.SaveChangesAsync(cancel);

        return new UploadFileResult
        {
            Id = file.Id,
            Name = file.Name,
            MimeType = file.MimeType,
            Target = request.Target,
            TargetId = request.TargetId
        };
    }

    private async Task<File> UploadFile(IFormFile file, CancellationToken cancel)
    {
        if (file.Length == 0)
            throw new Exception("File wrong");
        
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancel);
        var fileBytes = stream.ToArray();

        var fileEntity = new File
        {
            Name = file.FileName,
            Bytes = fileBytes,
            MimeType = file.ContentType
        };

        var createdEntity = await Context.Set<File>().AddAsync(fileEntity, cancel);

        return createdEntity.Entity;
    }
}