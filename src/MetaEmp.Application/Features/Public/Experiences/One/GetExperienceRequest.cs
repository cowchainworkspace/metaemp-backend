using MediatR;

namespace MetaEmp.Application.Features.Public.Experiences.One;

public record GetExperienceRequest(Guid Id) : IRequest<ExperienceResult>;