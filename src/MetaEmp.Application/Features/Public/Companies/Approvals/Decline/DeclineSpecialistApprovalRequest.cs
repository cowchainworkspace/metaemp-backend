using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Decline;

public record DeclineSpecialistApprovalRequest([property: JsonIgnore] Guid ExperienceId, string Message) : IRequest;