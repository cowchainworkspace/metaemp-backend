using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Decline;

public record DeclineSpecialistApprovalRequest(Guid ExperienceId, string Message) : IRequest;