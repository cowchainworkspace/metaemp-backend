using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Decline;

public record DeclineCompanyApprovalRequest([property: JsonIgnore] Guid ExperienceId, string Message) : IRequest;