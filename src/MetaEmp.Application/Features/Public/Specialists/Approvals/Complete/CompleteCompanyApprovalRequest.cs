using MediatR;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Complete;

public record CompleteCompanyApprovalRequest(Guid ExperienceId) : IRequest;