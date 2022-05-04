using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;

namespace MetaEmp.Application.Features.Companies.Create;

public class CreateCompanyHandler : AuthorizedRequestHandler<CreateCompanyRequest, CompanyResult>
{
    public CreateCompanyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<CompanyResult> Handle(CreateCompanyRequest request)
    {
        var company = request.Adapt<Company>();
        
        // TODO: remove this with userId from jwt token
        company.OwnerId = Guid.Parse("0DB1B904-6663-49A0-0DED-08DA2DC17E1A");
        
        var createdEntity = await Context.Set<Company>().AddAsync(company);

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<CompanyResult>();
    }
}