using MediatR;

namespace MetaEmp.Application.Features.Public.Experiences.Delete;

public record DeleteExperienceRequest(Guid Id) : IRequest<Unit>;
