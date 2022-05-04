using MediatR;

namespace MetaEmp.Application.Features.Protected.Companies.ToggleApprove;

public record ToggleApproveRequest(Guid Id) : IRequest<ToggleApproveResult>;