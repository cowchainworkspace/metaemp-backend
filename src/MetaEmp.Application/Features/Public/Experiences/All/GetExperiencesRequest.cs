using MediatR;

namespace MetaEmp.Application.Features.Public.Experiences.All;

public record GetExperiencesRequest(Guid SpecialistId) : IRequest<ExperienceResult[]>;