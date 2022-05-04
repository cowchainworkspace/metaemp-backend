using MediatR;

namespace MetaEmp.Application.Features.Public.Files.Delete;

public record DeleteFileRequest(Guid Id) : IRequest<DeleteFileResult>;
