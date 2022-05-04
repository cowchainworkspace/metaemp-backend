using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Application.Features.Companies.One;

public record GetCompanyRequest(Guid Id) : IRequest<CompanyResult>;