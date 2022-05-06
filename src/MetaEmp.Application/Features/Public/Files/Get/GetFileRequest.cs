using MediatR;

namespace MetaEmp.Application.Features.Public.Files.Get;

public record GetFileRequest(Guid Id) : IRequest<FileResult>;