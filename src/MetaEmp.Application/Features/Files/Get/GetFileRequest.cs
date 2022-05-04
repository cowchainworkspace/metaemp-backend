using MediatR;

namespace MetaEmp.Application.Features.Files.Get;

public record GetFileRequest(Guid Id) : IRequest<FileResult>;