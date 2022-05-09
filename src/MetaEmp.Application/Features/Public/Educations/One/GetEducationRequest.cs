using MediatR;
using MetaEmp.Application.Features.Public.Educations;

namespace MetaEmp.Application.Features.Public.Educations.One;

public record GetEducationRequest(Guid Id) : IRequest<EducationResult>;