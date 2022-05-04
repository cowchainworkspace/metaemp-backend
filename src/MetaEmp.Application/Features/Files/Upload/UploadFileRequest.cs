using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MetaEmp.Application.Features.Files.Upload;

public record UploadFileRequest(IFormFile File, FileTarget Target, [property: JsonIgnore] Guid TargetId) : IRequest<UploadFileResult>;