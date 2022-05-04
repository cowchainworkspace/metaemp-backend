using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MetaEmp.Application.Features.Public.Files.Upload;

public record UploadFileRequest(IFormFile File, FileTarget Target, [property: JsonIgnore] Guid TargetId) : IRequest<UploadFileResult>;