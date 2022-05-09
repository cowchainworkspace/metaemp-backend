using MediatR;

namespace MetaEmp.Application.Features.Public.Educations.All;

public record GetEducationsRequest(Guid SpecialistId) : IRequest<EducationResult[]>;