using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Companies.Create;

public class CreateCompanyHandler : AuthorizedRequestHandler<CreateCompanyRequest, CompanyResult>
{
    public CreateCompanyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<CompanyResult> Handle(CreateCompanyRequest request)
    {
        var company = request.Adapt<Company>();
        
        // TODO: remove this with userId from jwt token
        company.OwnerId = Guid.Parse("E2E4248D-BD31-45AA-BE6F-47FE48D214D6");
        
        company.Created = DateTime.UtcNow;
        company.Status = ApprovingStatus.Pending;
        
        var createdEntity = await Context.Set<Company>().AddAsync(company);

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<CompanyResult>();
    }
}