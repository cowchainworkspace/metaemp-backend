using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;

namespace MetaEmp.Application.Features.Companies.Delete;

public class DeleteCompanyHandler : AuthorizedRequestHandler<DeleteCompanyRequest, DeleteCompanyResult>
{
    public DeleteCompanyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<DeleteCompanyResult> Handle(DeleteCompanyRequest request)
    {
        Context.Set<Company>()
            .Remove(new Company {Id = request.CompanyId});

        await Context.SaveChangesAsync();

        return new();
    }
}