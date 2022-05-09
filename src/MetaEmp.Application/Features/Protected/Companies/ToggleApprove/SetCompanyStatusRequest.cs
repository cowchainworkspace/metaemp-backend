using System.Text.Json.Serialization;
using MediatR;
using MetaEmp.Data.SqlSever;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Protected.Companies.ToggleApprove;

public record SetCompanyStatusRequest
    ([property: JsonIgnore] Guid Id, ApprovingStatus Status, string RejectedMessage) : IRequest<SetCompanyStatusResult>;