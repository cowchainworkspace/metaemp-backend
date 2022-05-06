using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Companies.Update;

public class UpdateCompanyHandler : AuthorizedRequestHandler<UpdateCompanyRequest, UpdateCompanyResult>
{
    public UpdateCompanyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<UpdateCompanyResult> Handle(UpdateCompanyRequest request)
    {
        var company = await Context.Set<Company>()
            .FirstOr404Async(c => c.Id == request.CompanyId);

        request.Adapt(company);

        await Context.SaveChangesAsync();
        
        return new();
    }
}