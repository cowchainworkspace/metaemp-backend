using MediatR;

namespace MetaEmp.Application.Features.Public.Specialists.One;

public record GetSpecialistRequest(Guid Id) : IRequest<SpecialistResult>;