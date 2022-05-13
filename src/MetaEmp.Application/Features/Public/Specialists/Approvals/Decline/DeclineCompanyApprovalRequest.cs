using MediatR;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Decline;

public record DeclineCompanyApprovalRequest(Guid ExperienceId, string Message) : IRequest;