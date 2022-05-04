using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Companies.Logo;

public class UploadCompanyLogoHandler : AuthorizedRequestHandler<UploadCompanyLogoRequest, UploadCompanyLogoResult>
{
    public UploadCompanyLogoHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<UploadCompanyLogoResult> Handle(UploadCompanyLogoRequest request)
    {
        if (request.File.Length == 0)
            throw new Exception("File wrong");

        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream);
        var fileBytes = stream.ToArray();
        var base64Logo = Convert.ToBase64String(fileBytes);

        var company = await Context.Set<Company>()
            .FirstOr404Async(c => c.Id == request.CompanyId);

        company.Logo = $"data:{request.File.ContentType};base64,{base64Logo}";

        await Context.SaveChangesAsync();

        return new();
    }
}