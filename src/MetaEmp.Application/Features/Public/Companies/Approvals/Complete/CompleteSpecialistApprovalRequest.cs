using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Complete;

public record CompleteSpecialistApprovalRequest(Guid ExperienceId) : IRequest;