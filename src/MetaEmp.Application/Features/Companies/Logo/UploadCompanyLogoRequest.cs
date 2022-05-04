using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MetaEmp.Application.Features.Companies.Logo;

public record UploadCompanyLogoRequest : IRequest<UploadCompanyLogoResult>
{
    [BindNever]
    public Guid CompanyId { get; set; }
    public IFormFile File { get; set; } 
}