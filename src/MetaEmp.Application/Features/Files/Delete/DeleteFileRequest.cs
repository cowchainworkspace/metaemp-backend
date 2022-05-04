using MediatR;

namespace MetaEmp.Application.Features.Files.Delete;

public record DeleteFileRequest(Guid Id) : IRequest<DeleteFileResult>;
