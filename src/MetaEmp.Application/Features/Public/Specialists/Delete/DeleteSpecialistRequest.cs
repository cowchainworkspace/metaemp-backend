using MediatR;

namespace MetaEmp.Application.Features.Public.Specialists.Delete;

public record DeleteSpecialistRequest(Guid Id) : IRequest<Unit>;
