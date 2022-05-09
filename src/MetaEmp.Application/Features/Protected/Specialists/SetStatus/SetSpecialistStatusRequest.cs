using System.Text.Json.Serialization;
using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Protected.Specialists.SetStatus;

public record SetSpecialistStatusRequest
    ([property: JsonIgnore] Guid Id, ApprovingStatus Status, string RejectedMessage) : IRequest<Unit>;