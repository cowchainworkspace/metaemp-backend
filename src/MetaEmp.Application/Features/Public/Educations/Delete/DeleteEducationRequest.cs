using MediatR;

namespace MetaEmp.Application.Features.Public.Educations.Delete;

public record DeleteEducationRequest(Guid Id) : IRequest<Unit>;
