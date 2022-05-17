using MediatR;
using MetaEmp.Application.Features.Public.Experiences;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Get;

public record GetSpecialistApprovalsRequest : IRequest<ExperienceResult[]>;