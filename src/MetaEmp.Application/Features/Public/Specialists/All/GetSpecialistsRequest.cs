using MediatR;

namespace MetaEmp.Application.Features.Public.Specialists.All;

public record GetSpecialistsRequest : IRequest<SpecialistResult[]>;