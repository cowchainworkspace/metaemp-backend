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
        company.OwnerId = Guid.Parse("D2CBF0AA-1061-4A5F-A923-86EF5C582DB2");
        
        var createdEntity = await Context.Set<Company>().AddAsync(company);

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<CompanyResult>();
    }
}